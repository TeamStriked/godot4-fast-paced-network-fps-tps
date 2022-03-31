using Framework.Game.Server;
using Framework.Game;
using Shooter.Shared.Components;
namespace Shooter.Server
{
    public partial class MyServerPlayer : ServerPlayer
    {
        public MyServerPlayer() : base()
        {
            this.AvaiablePlayerComponents.Add("body", new AssignedComponent(
                typeof(PlayerBodyComponent), "res://Assets/Player/PlayerBody.tscn"
            ));

            this.AvaiablePlayerComponents.Add("camera", new AssignedComponent(
                typeof(PlayerCameraComponent)
            ));

            this.AvaiablePlayerComponents.Add("footsteps", new AssignedComponent(
                typeof(PlayerFootstepComponent)
            ));
        }

        public override void Tick(float delta)
        {
            base.Tick(delta);
        }
    }
}