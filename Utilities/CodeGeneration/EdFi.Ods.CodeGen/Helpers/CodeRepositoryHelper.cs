// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.Common.Extensions;

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

            var dirList = codeRepositoryPath.Split(Path.DirectorySeparatorChar)
                .ToList();

            var root = string.Join(
                Path.DirectorySeparatorChar,
                dirList.TakeWhile(x => !x.EqualsIgnoreCase(CodeRepositoryConventions.EdFiOdsFolderName)));

            if (Directory.Exists(codeRepositoryPath))
            {
                bool IsEdFiOdsFolderExist = Directory.GetDirectories(codeRepositoryPath).Where(s => s.Equals(codeRepositoryPath + CodeRepositoryConventions.EdFiOdsFolderName)).Any();

                if (IsEdFiOdsFolderExist)
                {
                    root = codeRepositoryPath;
                }
            }
            
            _repositoryByName.Add(CodeRepositoryConventions.Root, root);
            _repositoryByName.Add(CodeRepositoryConventions.Ods, Path.Combine(root, CodeRepositoryConventions.EdFiOdsFolderName));

            _repositoryByName.Add(
                CodeRepositoryConventions.Implementation,
                Path.Combine(root, CodeRepositoryConventions.EdFiOdsImplementationFolderName));

            _repositoryByName.Add(CodeRepositoryConventions.ExtensionsRepositoryName, Path.Combine(root, CodeRepositoryConventions.ExtensionsRepositoryName));
        }

        public string this[string key]
        {
            get => _repositoryByName[key];
            set => _repositoryByName[key] = value;
        }
    }
}
