// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.IO;
using EdFi.Common;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using log4net;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class LegacyDatabaseSpecificAssemblyDataProvider : IAssemblyDataProvider
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(AssembliesProvider));

        private readonly ICodeRepositoryProvider _codeRepositoryProvider;
        private readonly IStandardVersionPathProvider _standardVersionPathProvider;

        public LegacyDatabaseSpecificAssemblyDataProvider(ICodeRepositoryProvider codeRepositoryProvider,
            IStandardVersionPathProvider standardVersionPathProvider)
        {
            _codeRepositoryProvider = Preconditions.ThrowIfNull(codeRepositoryProvider, nameof(codeRepositoryProvider));
            _standardVersionPathProvider = standardVersionPathProvider;
        }

        public IEnumerable<AssemblyData> Get()
        {
            var assemblyData = new AssemblyData
            {
                AssemblyName = "ODS Database Specific",
                Path = GetPath(),
                TemplateSet = TemplateSetConventions.Database,
                IsExtension = false,
                SchemaName = EdFiConventions.ProperCaseName
            };

            _logger.Debug($"Created '{assemblyData.AssemblyName}' assembly data for '{assemblyData.Path}'");

            return new List<AssemblyData> { assemblyData };

            string GetPath()
            {
                var repositoryPath = _codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.Ods);
                return Path.Combine(repositoryPath, CodeRepositoryConventions.Application, "EdFi.Ods.Standard",
                        _standardVersionPathProvider.StandardVersionPath(), CodeRepositoryConventions.Database);
            }
        }
    }
}
