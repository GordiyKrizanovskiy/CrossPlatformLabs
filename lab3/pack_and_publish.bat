@echo off
REM Упаковка бібліотеки
dotnet pack ./GK/GK.csproj -c Release

REM Публікація в локальний NuGet репозиторій
dotnet nuget add source ./GK/bin/Release/ -n LocalNugetRepo
