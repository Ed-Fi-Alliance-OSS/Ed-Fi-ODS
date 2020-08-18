// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Common.IO;

namespace EdFi.Ods.Tests.EdFi.Ods.CommonUtils._Stubs
{
    public class TestFileSystem : IFileSystem
    {
        private readonly List<CopiedFile> _copiedFiles = new List<CopiedFile>();
        private string _tempPath;

        public CopiedFile[] CopiedFiles
        {
            get { return _copiedFiles.ToArray(); }
        }

        public string[] GetFilesInDirectory(string path)
        {
            throw new NotImplementedException();
        }

        public string GetParentDirectory(string path)
        {
            throw new NotImplementedException();
        }

        public string GetCurrentDirectory()
        {
            throw new NotImplementedException();
        }

        public string GetAssemblyLocation<T>()
        {
            throw new NotImplementedException();
        }

        public bool DirectoryExists(string path)
        {
            throw new NotImplementedException();
        }

        public string GetTempPath()
        {
            if (_tempPath == null)
            {
                throw new Exception("Temporary path not initialized");
            }

            return _tempPath;
        }

        public void CopyFile(string sourcePath, string destinationPath)
        {
            _copiedFiles.Add(
                new CopiedFile
                {
                    SourcePath = sourcePath, DestinationPath = destinationPath
                });
        }

        public string GetFilenameFromPath(string path)
        {
            throw new NotImplementedException();
        }

        //////////////////////////////
        /// Builder helpers
        //////////////////////////////
        public TestFileSystem WithTempPath(string path)
        {
            _tempPath = path;
            return this;
        }

        public class CopiedFile
        {
            public string SourcePath { get; set; }

            public string DestinationPath { get; set; }
        }
    }
}
