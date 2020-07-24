@Echo Off
SetLocal EnableDelayedExpansion
SetLocal EnableExtensions

Rem Copy the files to a location outside the repository. Why?
Rem Because they will call git operations on the repository, which will change the revision
Rem and implicitly their own content while running.
Rem That's a big no-no
If Not Exist "..\..\deleteme" (
    Mkdir "..\..\deleteme"
    Echo.Created "..\..\deleteme" directory outside the repo.
)

If Exist "buildandruntest.bat" (
    Copy "buildandruntest.bat" "..\..\deleteme\buildandruntest.bat"
    Echo.Copied [buildandruntest.bat]
)

If Exist "rungitbisect.bat" (
    Copy "rungitbisect.bat" "..\..\deleteme\rungitbisect.bat"
    Echo.Copied [rungitbisect.bat]
)

Rem Call the batch file.
PushD "..\..\deleteme"

If Exist "rungitbisect.bat" (
    Echo.Calling git bisect...
    Call "rungitbisect.bat"
)
