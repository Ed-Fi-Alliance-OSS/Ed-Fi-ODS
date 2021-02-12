// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using EdFi.Common;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.CodeGen.Helpers;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using log4net;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class LegacyProfileAssemblyDataProvider : IAssemblyDataProvider
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(AssembliesProvider));

        private readonly AssemblyDataHelper _assemblyDataHelper;
        private readonly ICodeRepositoryProvider _codeRepositoryProvider;

        public const string ProfilesSearchString = "EdFi.Ods.Profiles.*.csproj";

        public LegacyProfileAssemblyDataProvider(AssemblyDataHelper assemblyDataHelper, ICodeRepositoryProvider codeRepositoryProvider)
        {
            _assemblyDataHelper = Preconditions.ThrowIfNull(assemblyDataHelper, nameof(assemblyDataHelper));
            _codeRepositoryProvider = Preconditions.ThrowIfNull(codeRepositoryProvider, nameof(codeRepositoryProvider));
        }

        public IEnumerable<AssemblyData> Get()
        {
            // Convention based location of profiles (backwards compatibility)
            var legacyProfilePath = _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                CodeRepositoryConventions.Implementation,
                CodeRepositoryConventions.Application);

            var assemblyData = Directory.GetFiles(
                    legacyProfilePath,
                    ProfilesSearchString,
                    SearchOption.AllDirectories)
                .Select(
                    x => new AssemblyData
                    {
                        Path = Path.GetDirectoryName(x),
                        TemplateSet = TemplateSetConventions.Profile,
                        AssemblyName = _assemblyDataHelper.GetAssemblyName(x),
                        IsProfile = true,
                        IsExtension = false,
                        SchemaName = EdFiConventions.ProperCaseName
                    }).ToList();

            assemblyData.ForEach(x => _logger.Debug($"Found file matching '{ProfilesSearchString}' at '{x.Path}'"));

            return assemblyData;
        }
    }
}
