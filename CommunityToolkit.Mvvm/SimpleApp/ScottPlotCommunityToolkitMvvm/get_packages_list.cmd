@echo off

set SOLUTION_NAME=.\ScottPlotCommunityToolkitMvvm.sln

dotnet list %SOLUTION_NAME% package --include-transitive > packages_list.txt

pause