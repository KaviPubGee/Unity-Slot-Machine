@echo off
echo Starting local server for Unity WebGL build...
echo.
echo Opening game in browser...
echo http://localhost:8000
echo.

start "" cmd /c "timeout /t 2 >nul && start http://localhost:8000"

py -m http.server 8000

pause