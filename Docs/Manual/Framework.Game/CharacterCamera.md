# CharacterCamera class

The player camera for an physics player

```csharp
public class CharacterCamera : Camera3D, IPlayerComponent
```

## Public Members

| name | description |
| --- | --- |
| [CharacterCamera](CharacterCamera/CharacterCamera.md)() | The default constructor. |
| [BaseComponent](CharacterCamera/BaseComponent.md) { get; set; } | The base component of the child component |
| [IsEnabled](CharacterCamera/IsEnabled.md) { get; set; } |  |
| [Mode](CharacterCamera/Mode.md) { get; set; } | The current camera mode in use |
| [NetworkId](CharacterCamera/NetworkId.md) { get; set; } |  |
| [FPSCameraOffset](CharacterCamera/FPSCameraOffset.md) |  |
| [TPSCameraOffset](CharacterCamera/TPSCameraOffset.md) | The Camera Distance from the character in TPS Mode |
| [TPSCameraRadius](CharacterCamera/TPSCameraRadius.md) | The Camera Radis |
| virtual [GetViewRotation](CharacterCamera/GetViewRotation.md)() | Get the view rotation of an local player |
| virtual [Tick](CharacterCamera/Tick.md)(…) | Called on each physics network tick for component |
| override [_EnterTree](CharacterCamera/_EnterTree.md)() |  |
| override [_Input](CharacterCamera/_Input.md)(…) |  |
| override [_Process](CharacterCamera/_Process.md)(…) |  |

## See Also

* interface [IPlayerComponent](../Framework/IPlayerComponent.md)
* namespace [Framework.Game](../Framework.md)
* [CharacterCamera.cs](https://github.com/TeamStriked/godot4-fast-paced-network-fps-tps/blob/master/Example/Framework/Game/CharacterCamera.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Framework.dll -->
