// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Common.Configuration;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.SqlServer;

namespace EdFi.Ods.Features.ExternalCache.SQLServer
{
    public class OverrideSQLServerExternalCacheModule : ExternalCacheModule
    {
        public override string ExternalCacheProvider => "SqlServer";

        public OverrideSQLServerExternalCacheModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(OverrideSQLServerExternalCacheModule)) { }

        public override void RegisterDistributedCache(ContainerBuilder builder)
        {
            if (!IsProviderSelected(ApiSettings.Caching.ExternalCacheProvider))
            {
                return;
            }

            builder.Register<IDistributedCache>((c, d) => new SqlServerCache(new SqlServerCacheOptions()
            {
                ConnectionString = ApiSettings.Caching.SQLServer.ConnectionString,
                SchemaName = ApiSettings.Caching.SQLServer.SchemaName,
                TableName = ApiSettings.Caching.SQLServer.TableName
            }
            ))
            .SingleInstance();
        }
    }
}
