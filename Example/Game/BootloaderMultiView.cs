
using System;
using System.Linq;
using Godot;
using Shooter.Client;
using Shooter.Server;
using Framework.Game;

using Framework;
using System.Collections.Generic;

public partial class BootloaderMultiView : Bootloader
{
    public int viewSlot = 0;

    private List<HSplitContainer> containers = new List<HSplitContainer>();

    private List<GameLogic> logics = new List<GameLogic>();

    private GameLogic currentLogic = null;

    [Export]
    public NodePath rootContainerPath;


    [Export]
    public int viewsPerRow = 2;

    private VSplitContainer rootContainer = null;

    public override void _EnterTree()
    {
        base._EnterTree();

        this.rootContainer = this.GetNode<VSplitContainer>(rootContainerPath);
        this.ProcessMode = ProcessModeEnum.Always;

        this.CreateSlot(ServerLogicScenePath);
        this.CreateSlot(ClientLogicScenePath);
    }

    private HSplitContainer CreateContainer()
    {
        Logger.LogDebug(this, "Add new split container with id " + this.containers.Count());
        var container = new HSplitContainer();

        container.SizeFlagsHorizontal = (int)Control.SizeFlags.ExpandFill;
        container.SizeFlagsVertical = (int)Control.SizeFlags.ExpandFill;

        this.rootContainer.AddChild(container);
        this.containers.Add(container);

        return container;
    }

    private GameLogic CreateSlot(string resourcePath)
    {
        var container = this.containers.LastOrDefault();
        if (container == null)
        {
            container = CreateContainer();
        }
        else
        {
            int amount = 0;
            foreach (var child in container.GetChildren())
            {
                if (child is SubViewportContainer && (child as SubViewportContainer).Visible)
                    amount++;
            }

            if (amount >= viewsPerRow)
            {
                container = CreateContainer();
            }
        }

        if (container == null)
        {
            throw new Exception("Cant create new view");
        }

        Logger.LogDebug(this, "Add new viewport to split container");

        var slot = new SubViewportContainer();
        slot.Stretch = true;
        slot.SizeFlagsHorizontal = (int)Control.SizeFlags.ExpandFill;
        slot.SizeFlagsVertical = (int)Control.SizeFlags.ExpandFill;
        slot.ProcessMode = ProcessModeEnum.Always;

        container.AddChild(slot);

        var viewport = GD.Load<PackedScene>(resourcePath).Instantiate<GameLogic>();
        viewport.GuiDisableInput = true;
        viewport.ProcessMode = ProcessModeEnum.Always;
        slot.AddChild(viewport);

        this.logics.Add(viewport);
        this.ActivateGui(viewport);

        if (viewport is Framework.Game.Server.NetworkServerLogic)
        {
            var visible = (viewport as Framework.Game.Server.NetworkServerLogic).CanBeVisible;
            slot.Visible = visible;
        }

        return viewport;
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);

        if (this.createNewSlot)
        {
            this.createNewSlot = false;
            this.CreateSlot(ClientLogicScenePath);
        }

        if (this.switchToNext)
        {
            this.switchToNext = false;
            var currentLogicID = this.logics.IndexOf(this.currentLogic);
            if (currentLogicID == -1)
            {
                currentLogicID = 0;
            }

            if (this.logics.Count() >= (currentLogicID + 2))
            {
                currentLogicID += 1;
            }
            else
            {
                currentLogicID = 0;
            }

            if (this.logics.Count >= currentLogicID + 1)
            {
                var found = this.logics[currentLogicID];
                if (found is MyServerLogic)
                {
                    if (this.logics.Count >= currentLogicID + 2)
                    {
                        this.ActivateGui(this.logics[currentLogicID + 1]);
                    }
                }
                else
                {
                    this.ActivateGui(found);
                }
            }
        }
    }

    private void ActivateGui(GameLogic logic)
    {
        Input.SetMouseMode(Input.MouseMode.Visible);

        foreach (var item in this.logics)
        {
            item.GuiDisableInput = !(item == logic);
            item.AudioListenerEnable2d = (item == logic);
            item.AudioListenerEnable3d = (item == logic);
        }

        this.currentLogic = logic;
    }

    private bool createNewSlot = false;
    private bool switchToNext = false;

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        if (@event.IsActionReleased("view_add"))
        {
            this.createNewSlot = true;
        }

        if (@event.IsActionReleased("switch_view"))
        {
            this.switchToNext = true;
        }

        @event.Dispose();
    }
}
