/*
 * Created on Mon Mar 28 2022
 *
 * The MIT License (MIT)
 * Copyright (c) 2022 Stefan Boronczyk, Striked GmbH
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software
 * and associated documentation files (the "Software"), to deal in the Software without restriction,
 * including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
 * and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,
 * subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or substantial
 * portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
 * TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
 * THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
 * TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using Godot;
using Framework.Utils;
using Framework.Game.Client;

namespace Framework.Physics
{
    /// <summary>
    /// The camera mode for the player camera
    /// </summary>
    public enum CameraMode
    {
        /// <summary>
        /// FPS Mode
        /// </summary>
        FPS,
        /// <summary>
        /// TPS Mode
        /// </summary>
        TPS,
        /// <summary>
        /// Follow player mode
        /// </summary>
        Follow,
        /// <summary>
        /// Dungeon camera mode
        /// </summary>
        Dungeon
    }

    /// <summary>
    /// The player camera for an physics player
    /// </summary>
    public partial class PhysicsPlayerCamera : Camera3D, IPlayerComponent
    {
        internal DoubleBuffer<Vector3> positionBuffer = new DoubleBuffer<Vector3>();
        internal float tempRotX = 0.0f;
        internal float tempRotY = 0.0f;

        /// <summary>
        /// The base component of the child component
        /// </summary>
        /// <value></value>
        public IBaseComponent BaseComponent { get; set; }

        /// <summary>
        /// The current camera mode in use
        /// </summary>
        /// <value></value>
        public CameraMode Mode { get; set; } = CameraMode.FPS;

        /// <summary>
        /// The Camera Distance from the character in TPS Mode
        /// </summary>
        [Export]
        public float TPSCameraDistance = 4f;

        /// <summary>
        /// The Camera Offset for the FPS Mode
        /// </summary>
        [Export]
        public Godot.Vector3 FPSCameraOffset = new Godot.Vector3(0, 0.5f, 0.1f);

        /// <summary>
        /// Called on each physics network tick for component
        /// </summary>
        /// <param name="delta"></param>
        public virtual void Tick(float delta)
        {
        }

        /// <inheritdoc />
        internal void PlayerPositionUpdated()
        {
            if (this.IsLocal())
            {
                var local = this.BaseComponent as LocalPlayer;
                if (local.Body != null)
                {
                    var targetPos = local.Body.Transform.origin + FPSCameraOffset + Vector3.Up * local.Body.GetShapeHeight();
                    positionBuffer.Push(targetPos);
                }
            }
        }

        /// <inheritdoc />
        public override void _EnterTree()
        {
            base._EnterTree();

            var rotation = this.Transform.basis.GetEuler();

            this.tempRotX = rotation.x;
            this.tempRotY = rotation.y;
        }

        /// <inheritdoc />
        public override void _Process(float delta)
        {
            if (!this.IsLocal())
                return;

            var localPlayer = this.BaseComponent as LocalPlayer;
            if (localPlayer.Body != null)
            {
                if (this.Mode == CameraMode.TPS)
                {
                    var targetNode = localPlayer.Body.Transform;
                    var transform = this.Transform;
                    transform.origin.x = localPlayer.Body.Transform.origin.x + TPSCameraDistance * Mathf.Cos(tempRotY * -1);
                    transform.origin.z = localPlayer.Body.Transform.origin.z + TPSCameraDistance * Mathf.Sin(tempRotY * -1);
                    this.Transform = transform;
                    this.Transform = this.Transform.LookingAt(localPlayer.Body.Transform.origin, Vector3.Up);

                }
                else if (this.Mode == CameraMode.FPS)
                {
                    var transform = this.Transform;

                    // Interpolate position.
                    transform.origin = positionBuffer.Old().Lerp(
                                                positionBuffer.New(),
                                                InterpolationController.InterpolationFactor);

                    transform.basis = new Basis(new Vector3(tempRotX, tempRotY, 0));
                    this.Transform = transform;
                }

                this.Fov = ClientSettings.Variables.Get<int>("cl_fov");
            }
        }

        /// <inheritdoc />
        public override void _Input(InputEvent @event)
        {
            base._Input(@event);
            this.HandleInput(@event);

            @event.Dispose();
        }

        /// <inheritdoc />
        internal void HandleInput(InputEvent @event)
        {
            if (this.IsLocal())
            {
                var localPlayer = this.BaseComponent as LocalPlayer;

                var sensX = ClientSettings.Variables.Get<float>("cl_sensitivity_y", 2.0f);
                var sensY = ClientSettings.Variables.Get<float>("cl_sensitivity_x", 2.0f);

                if (@event is InputEventMouseMotion && localPlayer.InputProcessor.InputEnabled)
                {
                    // Handle cursor lock state
                    if (Godot.Input.GetMouseMode() == Godot.Input.MouseMode.Captured)
                    {
                        var ev = @event as InputEventMouseMotion;
                        tempRotX -= ev.Relative.y * (sensY / 1000);
                        tempRotY -= ev.Relative.x * (sensX / 1000);
                        tempRotX = Mathf.Clamp(tempRotX, Mathf.Deg2Rad(-90), Mathf.Deg2Rad(90));
                    }
                }

                if (@event.IsActionReleased("camera"))
                {
                    if (this.Mode == CameraMode.FPS)
                    {
                        this.Mode = CameraMode.TPS;
                    }
                    else if (this.Mode == CameraMode.TPS)
                    {
                        this.Mode = CameraMode.FPS;
                    }
                }
            }
        }
    }

}