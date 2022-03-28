using Framework.Game.Server;

namespace Shooter.Server
{
    public partial class MyServerWorld : ServerWorld
    {
        /*
        public override void OnServerPlayerCreated(ServerPlayer serverPlayer)
        {
            //   var bodyComponent = serverPlayer.Simulation.Components.AddComponent<PlayerBodyComponent>("res://Assets/Player/PlayerBody.tscn");
            //  serverPlayer.Simulation.Body = bodyComponent;

            //   var gt = bodyComponent.GlobalTransform;
            //   gt.origin = serverPlayer.SpawnPoint.GlobalTransform.origin;
            //  bodyComponent.GlobalTransform = gt;

            //  var playerServerCamera = serverPlayer.Simulation.Components.AddComponent<PlayerCameraComponent>();
            // playerServerCamera.cameraMode = CameraMode.Server;
        }
        */

        public override void OnPlayerConnected(int clientId)
        {
            this.AddPlayer<MyServerPlayer>(clientId);
        }
    }
}