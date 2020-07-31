// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using EdFi.Ods.CodeGen.Conventions;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class MetadataFolderProvider : IMetadataFolderProvider
    {
        private readonly ICodeRepositoryProvider _codeRepositoryProvider;

        public MetadataFolderProvider(ICodeRepositoryProvider codeRepositoryProvider)
        {
            _codeRepositoryProvider = codeRepositoryProvider ?? throw new ArgumentNullException(nameof(codeRepositoryProvider));
        }

        public string GetStandardMetadataFolder()
        {
            return _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                CodeRepositoryConventions.Ods,
                StandardConventions.Metadata);
        }

        public string GetStandardSchemaFolder()
        {
            return _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                CodeRepositoryConventions.Ods,
                StandardConventions.Schemas);
        }

        public string GetProjectSchemaFolder(string projectPath)
        {
            return Path.Combine(projectPath, SupportingArtifactConventions.Schemas);
        }

        public string GetProjectMetadataFolder(string projectPath)
        {
            return Path.Combine(projectPath, SupportingArtifactConventions.Metadata);
        }
    }
}
