@echo off

set SOLUTION_NAME=.\ReactiveExtensionExample.sln

dotnet list %SOLUTION_NAME% package --include-transitive > packages_list.txt

pause