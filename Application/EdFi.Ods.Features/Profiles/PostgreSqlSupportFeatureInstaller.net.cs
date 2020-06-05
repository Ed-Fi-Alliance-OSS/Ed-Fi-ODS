// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Api.Common.Infrastructure.Architecture.Activities;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Security.Authorization;

namespace EdFi.Ods.Features.Profiles
{
    /// <summary>
    /// An installer that installs all Postgres-specific components that are needed
    /// by the API for using Postgres as a database engine.
    /// </summary>
    public class PostgresSqlFeatureInstaller : RegistrationMethodsInstallerBase
    {
        private void RegisterIParameterListSetter(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IParameterListSetter>()
                    .ImplementedBy<ParameterListSetter>());
        }

        private void RegisterAuthorizationSegmentSqlProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IAuthorizationSegmentsSqlProvider>()
                    .ImplementedBy<PostgresAuthorizationSegmentSqlProvider>());
        }


    }
}
#endif
