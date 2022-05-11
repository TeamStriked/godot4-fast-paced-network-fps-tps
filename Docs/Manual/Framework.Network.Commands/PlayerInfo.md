# PlayerInfo structure

Network package for notification of new players or players changes.

```csharp
public struct PlayerInfo : INetSerializable
```

## Public Members

| name | description |
| --- | --- |
| [NetworkId](PlayerInfo/NetworkId.md) | Current network id |
| [PlayerName](PlayerInfo/PlayerName.md) | Current player name |
| [RequiredComponents](PlayerInfo/RequiredComponents.md) | Required local player components |
| [RequiredPuppetComponents](PlayerInfo/RequiredPuppetComponents.md) | Required puppet components |
| [ResourcePath](PlayerInfo/ResourcePath.md) | Resource path to the scene |
| [ScriptPaths](PlayerInfo/ScriptPaths.md) | Script path of the scene |
| [State](PlayerInfo/State.md) | Current network connection state |
| [Deserialize](PlayerInfo/Deserialize.md)(…) |  |
| [Serialize](PlayerInfo/Serialize.md)(…) |  |

## See Also

* namespace [Framework.Network.Commands](../Framework.md)
* [PlayerInfo.cs](https://github.com/TeamStriked/godot4-fast-paced-network-fps-tps/blob/master/Example/Framework/Network/Commands/PlayerInfo.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Framework.dll -->