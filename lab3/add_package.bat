@echo off
REM Підключення NuGet пакету до консольного проекту
dotnet add ./lab3/lab3.csproj package GK --source ./GK/bin/Release/
