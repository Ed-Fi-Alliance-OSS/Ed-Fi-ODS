#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using Castle.MicroKernel.Registration;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensibility;
using EdFi.Ods.Features.Container.Installers;

namespace EdFi.Ods.Features.SqlServerSupport
{
    /// <summary>
    /// A feature implementation that registers components supporting SQL Server
    /// if the database engine is configured as SQL Server.
    /// </summary>
    public class SqlServerSupportConditionalFeature : ConditionalFeatureBase
    {
        public SqlServerSupportConditionalFeature(IConfigValueProvider configValueProvider,
            IApiConfigurationProvider apiConfigurationProvider)
            : base(configValueProvider, apiConfigurationProvider) { }

        public override string FeatureName => SqlServerSupportConstants.FeatureName;

        protected override Func<IApiConfigurationProvider, IConfigValueProvider, bool> ActivationPredicate
            => (apiConfig, config) => apiConfig.DatabaseEngine == DatabaseEngine.SqlServer;

        public override IWindsorInstaller Installer => new SqlServerSupportFeatureInstaller();
    }
}
#endif