// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Generator.Database.DataTypes;
using EdFi.Ods.Generator.Database.NamingConventions;
using EdFi.Ods.Generator.Rendering;

namespace EdFi.Ods.Generator.Database.Engines.PostgreSql
{
    public class PostgresRenderingPlugin : IRenderingPlugin
    {
        public void Initialize(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<PostgresDatabaseTypeTranslator>()
                .Keyed<IDatabaseTypeTranslator>(DatabaseEngine.PostgreSql);

            containerBuilder.RegisterType<PostgresDatabaseNamingConvention>()
                .Keyed<IDatabaseNamingConvention>(DatabaseEngine.PostgreSql);
        }
    }
}
