// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using Castle.MicroKernel.Registration;
using EdFi.Ods.Api._Installers;
using EdFi.Ods.Api.Startup.Features.Installers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensibility;

namespace EdFi.Ods.Api.Startup.Features
{
    /// <summary>
    /// A feature implementation that registers components supporting PostgreSQL
    /// if the database engine is configured as PostgreSQL.
    /// </summary>
    public class PostgreSqlSupportConditionalFeature : ConditionalFeatureBase
    {
        public PostgreSqlSupportConditionalFeature(IConfigValueProvider configValueProvider,
            IApiConfigurationProvider apiConfigurationProvider)
            : base(configValueProvider, apiConfigurationProvider) { }

        public override string FeatureName => PostgreSqlSupportConstants.FeatureName;

        protected override Func<IApiConfigurationProvider, IConfigValueProvider, bool> ActivationPredicate
            => (apiConfig, config) => apiConfig.DatabaseEngine == DatabaseEngine.Postgres;

        public override IWindsorInstaller Installer => new PostgresSqlFeatureInstaller();
    }
}
