// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            var dirList = codeRepositoryPath.Split('\\')
                .ToList();

            var root = string.Join(
                "\\",
                dirList.TakeWhile(x => !x.EqualsIgnoreCase(CodeRepositoryConventions.EdFiOdsFolderName)));

            _repositoryByName.Add(CodeRepositoryConventions.Root, root);
            _repositoryByName.Add(CodeRepositoryConventions.Ods, Path.Combine(root, CodeRepositoryConventions.EdFiOdsFolderName));

            _repositoryByName.Add(
                CodeRepositoryConventions.Implementation,
                Path.Combine(root, CodeRepositoryConventions.EdFiOdsImplementationFolderName));
        }

        public string this[string key]
        {
            get => _repositoryByName[key];
            set => _repositoryByName[key] = value;
        }
    }
}
