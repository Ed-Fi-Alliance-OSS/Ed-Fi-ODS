// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Test.Common
{
    public static class ServiceHelper
    {
        public static Process StartServiceProcess(string fileName)
        {
            Process process = new Process
            {
                StartInfo =
                {
                    WindowStyle = ProcessWindowStyle.Normal,
                    ErrorDialog = false,
                    CreateNoWindow = false,
                    UseShellExecute = false,
                    FileName = fileName
                }
            };

            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    fileName
                    + " could not be started. This may be because the file is not present there. Make sure that the relevant project has been built and its executable output copied to the to the specified path.",
                    ex);
            }

            return process;
        }

        public static void StopServiceProcess(Process process)
        {
            if (!process.HasExited)
            {
                process.Kill();
            }

            process.Dispose();
        }

        public static string GetExecutable(string path, string exeName)
        {
            var fileCollection = new List<string>();
            GetFiles(path, fileCollection);
            return fileCollection.FirstOrDefault(s => s.Contains(exeName));
        }

        private static void GetFiles(string path, List<string> fileCollection)
        {
            foreach (var dir in Directory.GetDirectories(path))
            {
                fileCollection.AddRange(Directory.EnumerateFiles(dir));
                GetFiles(dir, fileCollection);
            }
        }
    }
}
