// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.NHibernate.Architecture
{
    public class OrmMappingFileDataProvider : IOrmMappingFileDataProvider
    {
        private readonly Lazy<OrmMappingFileData> _ormMappingFileData;

        public OrmMappingFileDataProvider(IAssembliesProvider assembliesProvider, DatabaseEngine databaseEngine,
            string assemblyName)
        {
            Preconditions.ThrowIfNull(assemblyName, nameof(assemblyName));
            Preconditions.ThrowIfNull(assembliesProvider, nameof(assembliesProvider));
            Preconditions.ThrowIfNull(databaseEngine, nameof(databaseEngine));

            _ormMappingFileData = new Lazy<OrmMappingFileData>(
                () =>
                {
                    return new OrmMappingFileData
                    {
                        Assembly = assembliesProvider.Get(assemblyName),
                        MappingFileFullNames = new[]
                        {
                            $"{assemblyName}.{OrmMappingFileConventions.EntityOrmMappings}.{databaseEngine.ScriptsFolderName}.{OrmMappingFileConventions.EntityOrmMappingsGeneratedHbm}",
                            $"{assemblyName}.{OrmMappingFileConventions.EntityOrmMappings}.{databaseEngine.ScriptsFolderName}.{OrmMappingFileConventions.EntityOrmMappingsForQueriesGeneratedHbm}",
                            $"{assemblyName}.{OrmMappingFileConventions.EntityOrmMappings}.{databaseEngine.ScriptsFolderName}.{OrmMappingFileConventions.EntityOrmMappingsForViewsGeneratedHbm}"
                        }
                    };
                });
        }

        public OrmMappingFileData OrmMappingFileData() => _ormMappingFileData.Value;
    }
}
