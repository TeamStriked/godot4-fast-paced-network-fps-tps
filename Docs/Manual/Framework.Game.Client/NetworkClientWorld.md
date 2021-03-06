# NetworkClientWorld class

Base class for the client world

```csharp
public class NetworkClientWorld : NetworkWorld
```

## Public Members

| name | description |
| --- | --- |
| [NetworkClientWorld](NetworkClientWorld/NetworkClientWorld.md)() | The default constructor. |
| [LastAckedInputTick](NetworkClientWorld/LastAckedInputTick.md) { get; } |  |
| [LastServerWorldTick](NetworkClientWorld/LastServerWorldTick.md) { get; } |  |
| [LocalPlayer](NetworkClientWorld/LocalPlayer.md) { get; set; } | The local character of the client world |
| [MyServerId](NetworkClientWorld/MyServerId.md) { get; } | The current client player id the server |
| [clientSimulationAdjuster](NetworkClientWorld/clientSimulationAdjuster.md) | Client adjuster Handles server ticks and make them accuracy |
| [LocalPlayerInputsSnapshots](NetworkClientWorld/LocalPlayerInputsSnapshots.md) | The local player input snapshots |
| [LocalPlayerStateSnapshots](NetworkClientWorld/LocalPlayerStateSnapshots.md) | The local player states |
| [LocalPlayerWorldTickSnapshots](NetworkClientWorld/LocalPlayerWorldTickSnapshots.md) | The last world player ticks related to the state snapshots |

## See Also

* class [NetworkWorld](../Framework.Game/NetworkWorld.md)
* namespace [Framework.Game.Client](../Framework.md)
* [NetworkClientWorld.cs](https://github.com/TeamStriked/godot4-fast-paced-network-fps-tps/blob/master/Example/Framework/Game/Client/NetworkClientWorld.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Framework.dll -->
