@echo off
set /p address=Type an address you wish to connect to: 
set /p ticket=Type the Character Appearence Name you wish you use:

@echo Starting FreeRealms...



start /min FreeRealms.exe inifile=ClientConfig.ini Guid=1234 Server=%address%:20260 Ticket=%ticket% Internationalization:Locale=8 ShowMemberLoadingScreen=0 Country=US key=m80HqsRO9i4PjJSCOasVMg== CasSessionId=Jk6TeiRMc4Ba38NO

exit /B