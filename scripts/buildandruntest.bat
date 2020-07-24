@Echo Off
SetLocal EnableDelayedExpansion
SetLocal EnableExtensions

Rem Note: in order for this to run, you need to have *msbuild* in your path
Rem You can call this after calling vsdevcmd
Rem E.g. "c:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\Tools\VsDevCmd.bat"

Rem === Begin Parameter section ===
Set ProjectDir=..\examples-git\sample-proj-mstest
Set TestProjectName=sample-proj-mstest
Set Configuration=Debug
Rem === End Parameter section ===

Set result=0

PushD !ProjectDir!
Rem === Restore the nuget packages
Call msbuild -t:restore
Rem === Build the solution ===
Call msbuild !TestProjectName!.csproj /t:Rebuild /p:Configuration=!Configuration! /v:quiet /p:OutputPath=bin\!Configuration!
Echo.MSBuild result ERRORLEVEL: %ERRORLEVEL%
PopD

Rem === Run the tests ===
PushD !ProjectDir!\bin\!Configuration!
VSTest.Console.exe !TestProjectName!.dll
IF %ERRORLEVEL% EQU 0 (
  Rem Test execution: all successful
  Echo.    OK.
  Set result=0
  
) Else (
  Rem Test execution: at least 1 failed
  Echo.    Some tests failed.
  Set result=1
)
PopD

Exit /B !result!


