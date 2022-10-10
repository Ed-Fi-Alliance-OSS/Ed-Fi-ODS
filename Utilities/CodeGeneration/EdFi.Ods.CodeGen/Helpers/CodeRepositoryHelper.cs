// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using EdFi.Ods.CodeGen.Conventions;

namespace EdFi.Ods.CodeGen.Helpers
{
    public class CodeRepositoryHelper
    {
        private readonly IDictionary<string, string> _repositoryByName =
            new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        public CodeRepositoryHelper(string codeRepositoryPath)
        {
            if (codeRepositoryPath == null)
            {
                throw new ArgumentNullException(nameof(codeRepositoryPath));
            }

            string resolveSharedRootPath = ResolveSharedRootPath();
            
            _repositoryByName.Add(CodeRepositoryConventions.Root, resolveSharedRootPath);
            
            _repositoryByName.Add(CodeRepositoryConventions.Ods, 
                Path.Combine(resolveSharedRootPath, CodeRepositoryConventions.EdFiOdsFolderName));

            _repositoryByName.Add(CodeRepositoryConventions.Implementation,
                Path.Combine(resolveSharedRootPath, CodeRepositoryConventions.EdFiOdsImplementationFolderName));

            _repositoryByName.Add(CodeRepositoryConventions.ExtensionsRepositoryName, 
                Path.Combine(resolveSharedRootPath, CodeRepositoryConventions.ExtensionsRepositoryName));

            string ResolveSharedRootPath()
            {
                string[] repositoryFolderNames =
                {
                    CodeRepositoryConventions.EdFiOdsFolderName,
                    CodeRepositoryConventions.EdFiOdsImplementationFolderName,
                    CodeRepositoryConventions.ExtensionsRepositoryName
                };

                string probePath = codeRepositoryPath.TrimEnd(Path.DirectorySeparatorChar);

                while (probePath != null && !Directory.Exists(Path.Combine(probePath, CodeRepositoryConventions.EdFiOdsFolderName)))
                {
                    // Probe higher up the directory tree
                    probePath = Path.GetDirectoryName(probePath);
                }

                if (probePath == null)
                {
                    throw new Exception(
                        $"Unable to determine the path to the shared root folder for the repositories (i.e. '{string.Join("', '", repositoryFolderNames)}') from the supplied code repository path '{codeRepositoryPath}'.");
                }
                
                return probePath;
            }
        }

        public string this[string key]
        {
            get => _repositoryByName[key];
            set => _repositoryByName[key] = value;
        }
    }
}
