@echo off

set CUR_DIR=%CD%
set BACKUP_DIR=.\packages_offline

set BACKUP_DIR_MAIN=%BACKUP_DIR%
set BACKUP_DIR_TRANSITIVE=%BACKUP_DIR%\TRANSITIVE

set FRAMEWORKS="net@9.0"

REM Проект "Range" содержит следующие ссылки на пакеты
   REM [net9.0]: 
   REM Пакет верхнего уровня      Запрошено   Разрешено
   REM > System.Reactive          6.0.1       6.0.1      

rem It is necessary to load from here https://github.com/eliasby/nusave/releases/download/v3.1.1/nusave-3.1.1-win-x64.zip
set NUSAVE_APP_PATH=d:\rakurs\pvn\Software\Develop\Tools\NuGet\nusave-3.1.1-win-x64\nusave.exe

%NUSAVE_APP_PATH% cache package "System.Reactive@6.0.1" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_MAIN%"


pause