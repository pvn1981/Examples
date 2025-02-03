@echo off

set SOLUTION_NAME="Lambda1"
set CONSOLE_PROJECT_NAME="LambdaName"

dotnet new sln -o %SOLUTION_NAME%

cd .\%SOLUTION_NAME%\

dotnet new console -n %CONSOLE_PROJECT_NAME% --use-program-main

dotnet sln add %CONSOLE_PROJECT_NAME%/%CONSOLE_PROJECT_NAME%.csproj

rem Check sln
dotnet sln list   