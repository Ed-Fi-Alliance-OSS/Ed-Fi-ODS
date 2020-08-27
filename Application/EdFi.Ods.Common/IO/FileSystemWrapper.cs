// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;

namespace EdFi.Ods.Common.IO
{
    public class FileSystemWrapper : IFileSystem
    {
        public string[] GetFilesInDirectory(string path)
        {
            return Directory.GetFiles(path);
        }

        public string GetParentDirectory(string path)
        {
            var directoryInfo = Directory.GetParent(path);

            if (directoryInfo == null)
            {
                return null;
            }

            return directoryInfo.FullName;
        }

        public string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        public string GetAssemblyLocation<T>()
        {
            return Path.GetDirectoryName(typeof(T).Assembly.Location);
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public string GetTempPath()
        {
            return Path.GetTempPath();
        }

        public void CopyFile(string sourcePath, string destinationPath)
        {
            File.Copy(sourcePath, destinationPath);
        }

        public string GetFilenameFromPath(string path)
        {
            return Path.GetFileName(path);
        }
    }
}
