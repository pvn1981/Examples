@echo off

set CUR_DIR=%CD%
set BACKUP_DIR=.\packages_offline_NET6

set BACKUP_DIR_MAIN=%BACKUP_DIR%
set BACKUP_DIR_TRANSITIVE=%BACKUP_DIR%\TRANSITIVE

set FRAMEWORKS="net@6.0"

REM Проект "ScottPlotCommunityToolkitMvvm" содержит следующие ссылки на пакеты
   REM [net6.0-windows7.0]: 
   REM Пакет верхнего уровня                 Запрошено   Разрешено
   REM > CommunityToolkit.Mvvm               8.4.0       8.4.0    
   REM > Microsoft.Xaml.Behaviors.Wpf        1.1.135     1.1.135  
   REM > OpenTK                              4.9.3       4.9.3    
   REM > ScottPlot                           5.0.53      5.0.53   
   REM > ScottPlot.WPF                       5.0.53      5.0.53   
   REM > SkiaSharp                           3.116.1     3.116.1  
   REM > SkiaSharp.Views.Desktop.Common      3.116.1     3.116.1  

   REM Транзитивный пакет                                 Разрешено
   REM > HarfBuzzSharp                                    7.3.0.3  
   REM > HarfBuzzSharp.NativeAssets.Linux                 7.3.0.3  
   REM > HarfBuzzSharp.NativeAssets.macOS                 7.3.0.3  
   REM > HarfBuzzSharp.NativeAssets.Win32                 7.3.0.3  
   REM > OpenTK.Audio.OpenAL                              4.9.3    
   REM > OpenTK.Compute                                   4.9.3    
   REM > OpenTK.Core                                      4.9.3    
   REM > OpenTK.GLWpfControl                              4.2.3    
   REM > OpenTK.Graphics                                  4.9.3    
   REM > OpenTK.Input                                     4.9.3    
   REM > OpenTK.Mathematics                               4.9.3    
   REM > OpenTK.redist.glfw                               3.3.8.39 
   REM > OpenTK.Windowing.Common                          4.9.3    
   REM > OpenTK.Windowing.Desktop                         4.9.3    
   REM > OpenTK.Windowing.GraphicsLibraryFramework        4.9.3    
   REM > SkiaSharp.HarfBuzz                               2.88.9   
   REM > SkiaSharp.NativeAssets.Linux.NoDependencies      2.88.9   
   REM > SkiaSharp.NativeAssets.macOS                     3.116.1  
   REM > SkiaSharp.NativeAssets.Win32                     3.116.1  
   REM > SkiaSharp.Views.WPF                              2.88.9   
   REM > System.ComponentModel.Annotations                5.0.0    
   REM > System.Runtime.CompilerServices.Unsafe           6.1.0    

rem It is necessary to load from here https://github.com/eliasby/nusave/releases/download/v3.1.1/nusave-3.1.1-win-x64.zip
set NUSAVE_APP_PATH=d:\rakurs\pvn\Software\Develop\Tools\NuGet\nusave-3.1.1-win-x64\nusave.exe

%NUSAVE_APP_PATH% cache package "CommunityToolkit.Mvvm@8.4.0" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_MAIN%"
%NUSAVE_APP_PATH% cache package "Microsoft.Xaml.Behaviors.Wpf@1.1.135" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_MAIN%"
%NUSAVE_APP_PATH% cache package "OpenTK@4.9.3" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_MAIN%"
%NUSAVE_APP_PATH% cache package "ScottPlot@5.0.53" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_MAIN%"
%NUSAVE_APP_PATH% cache package "ScottPlot.WPF@5.0.53" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_MAIN%"
%NUSAVE_APP_PATH% cache package "SkiaSharp@3.116.1" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_MAIN%"
%NUSAVE_APP_PATH% cache package "SkiaSharp.Views.Desktop.Common@3.116.1" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_MAIN%"

%NUSAVE_APP_PATH% cache package "HarfBuzzSharp@7.3.0.3" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "HarfBuzzSharp.NativeAssets.Linux@7.3.0.3" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "HarfBuzzSharp.NativeAssets.macOS@7.3.0.3" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "HarfBuzzSharp.NativeAssets.Win32@7.3.0.3" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "OpenTK.Audio.OpenAL@4.9.3" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "OpenTK.Compute@4.9.3" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "OpenTK.Core@4.9.3" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "OpenTK.GLWpfControl@4.2.3" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "OpenTK.Graphics@4.9.3" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "OpenTK.Input@4.9.3" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "OpenTK.Mathematics@4.9.3" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "OpenTK.redist.glfw@3.3.8.39" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "OpenTK.Windowing.Common@4.9.3" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "OpenTK.Windowing.Desktop@4.9.3" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "OpenTK.Windowing.GraphicsLibraryFramework@4.9.3" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "SkiaSharp.HarfBuzz@2.88.9" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "SkiaSharp.NativeAssets.Linux.NoDependencies@2.88.9" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "SkiaSharp.NativeAssets.macOS@3.116.1" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "SkiaSharp.NativeAssets.Win32@3.116.1" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "SkiaSharp.Views.WPF@2.88.9" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "System.ComponentModel.Annotations@5.0.0" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"
%NUSAVE_APP_PATH% cache package "System.Runtime.CompilerServices.Unsafe@6.1.0" --targetFrameworks "%FRAMEWORKS%" --cacheDir "%BACKUP_DIR_TRANSITIVE%"

pause