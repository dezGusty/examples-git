@Echo Off
SetLocal EnableDelayedExpansion
SetLocal EnableExtensions

Rem === Begin Parameter section ===
Set goodGitHash=fd34a27
Set badGitHash=8d3a3d2
Set batchNameInThisDir=buildandruntest.bat
Set vscmd="c:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\Tools\VsDevCmd.bat"
Rem === End Parameter section ===

Set calledBatch=%~dp0%!batchNameInThisDir!
Call !vscmd!

Rem Operation. Work in the root repo dir.
PushD ..
git bisect start
git bisect good !goodGitHash!
git bisect bad !badGitHash!
git bisect run !calledBatch!

For /F "tokens=* USEBACKQ" %%F IN (`git rev-parse --short HEAD`) DO (
  Set hashcode=%%F
)
Echo.
Echo.--- == === Finished === == ---
Echo.
Echo.The most recent commit when tests were working: [!hashcode!]
Echo.
git bisect reset
PopD