@echo off

:: --HAS ENDING BACKSLASH
set batdir=%~dp0
:: --MISSING ENDING BACKSLASH
:: set batdir=%CD%
pushd "%batdir%"
dotnet msbuild ./Example/Shooter.sln /restore /t:Build /p:Configuration=Debug /v:normal /p:GodotTargetPlatform=windows
