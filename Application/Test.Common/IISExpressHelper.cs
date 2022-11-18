// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics;

namespace Test.Common
{
    // ReSharper disable once InconsistentNaming
    public static class IISExpressHelper
    {
        public static Process Start(string path, int port)
        {
            var programfiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            var iisProcess = new Process
            {
                StartInfo =
                {
                    FileName = programfiles + "/IIS Express/iisexpress.exe",
                    Arguments = string.Format("/path:\"{0}\" /port:{1}", path, port),
                    UseShellExecute = true
                }
            };

            try
            {
                iisProcess.Start();
            }
            catch
            {
                iisProcess.CloseMainWindow();
                iisProcess.Dispose();
            }

            return iisProcess;
        }

        public static void Stop(Process iisProcess)
        {
            if (iisProcess != null)
            {
                if (!iisProcess.HasExited)
                {
                    iisProcess.Kill();
                }

                iisProcess.Dispose();
            }
        }
    }
}
