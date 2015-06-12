cls
powershell -Command "& { [Console]::WindowWidth = 150; [Console]::WindowHeight = 50; [Console]::BufferHeight = 1000; Start-Transcript %~dp0runbuild.txt; Import-Module %~dp0..\Tools\PSake\psake.psm1; Invoke-psake %~dp0..\ps\build.ps1 %*; Stop-Transcript; }"
PAUSE