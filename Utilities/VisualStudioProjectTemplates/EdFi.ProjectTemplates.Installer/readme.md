Visual Studio stores startup information for debugging in the .csproj.user file, not in source control.

To debug this project, right click and go to project properties and on the Debug tab change the following settings:

Set Start External Program, and point it at the Visual Studio instance to test
  (C:\Program Files\Microsoft Visual Studio\2022\{Edition}\Common7\IDE\devenv.exe for VS2022 by default)

Set CommandLineArguments to: /rootsuffix Exp