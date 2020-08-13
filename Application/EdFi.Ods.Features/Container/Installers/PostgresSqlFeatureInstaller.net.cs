#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Common.Infrastructure.Activities;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Security.Authorization;

namespace EdFi.Ods.Features.PostgreSqlSupport
{
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
