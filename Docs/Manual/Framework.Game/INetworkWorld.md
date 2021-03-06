# INetworkWorld interface

The required interface for an game world

```csharp
public interface INetworkWorld
```

## Members

| name | description |
| --- | --- |
| [GameInstance](INetworkWorld/GameInstance.md) { get; } | Game logic controller |
| [NetworkLevel](INetworkWorld/NetworkLevel.md) { get; } | The loaded game level of the world |
| [Players](INetworkWorld/Players.md) { get; } | All players of the world |
| [ResourceWorldPath](INetworkWorld/ResourceWorldPath.md) { get; } | Path of the world resource |
| [ResourceWorldScriptPath](INetworkWorld/ResourceWorldScriptPath.md) { get; } | Path of the world resource script |
| [ServerVars](INetworkWorld/ServerVars.md) { get; } | The server vars of the world |
| [WorldTick](INetworkWorld/WorldTick.md) { get; } | The current tick of the world |
| [Destroy](INetworkWorld/Destroy.md)() | Destroy the game world |
| [OnLevelAddToScene](INetworkWorld/OnLevelAddToScene.md)() | When level was adding complelty to scene |
| [OnPlayerInitilaized](INetworkWorld/OnPlayerInitilaized.md)(…) | Calls when an player is initialized and the map was loaded sucessfulll |
| [Tick](INetworkWorld/Tick.md)(…) | The physics and network related tick process method |

## See Also

* namespace [Framework.Game](../Framework.md)
* [INetworkWorld.cs](https://github.com/TeamStriked/godot4-fast-paced-network-fps-tps/blob/master/Example/Framework/Game/INetworkWorld.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Framework.dll -->
