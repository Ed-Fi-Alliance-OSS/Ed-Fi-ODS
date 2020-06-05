// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.IO
{
    public interface IFileSystem
    {
        string[] GetFilesInDirectory(string path);

        string GetParentDirectory(string path);

        string GetCurrentDirectory();

        string GetAssemblyLocation<T>();

        bool DirectoryExists(string path);

        string GetTempPath();

        void CopyFile(string sourcePath, string destinationPath);

        string GetFilenameFromPath(string path);
    }
}
