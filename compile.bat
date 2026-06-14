@echo off
title tylow clicker V1 ( opensource ) ( @ky.aa )
echo Compiling Tylow clicker in a portable executable...
echo.
if exist "tylowprivate\bin\Release\net8.0-windows\publish" rmdir /s /q "bin\Release\net8.0-windows\publish"

dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true /p:DebugType=None /p:DebugSymbols=false

move "tylowprivate\bin\Release\net8.0-windows\publish\tylowprivate.exe" "tylowprivate.exe"

echo.
echo Compilation Completed!
echo the exe is on: %CD%\tylowprivate.exe
echo.

pause