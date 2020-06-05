// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.Api.NetCore.Container.Modules {
    public class OdsConnectionStringProviderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PrototypeWithDatabaseNameTokenReplacementConnectionStringProvider>()
                .WithParameter(new NamedParameter("prototypeConnectionStringName", "EdFi_Ods"))
                .As<IOdsDatabaseConnectionStringProvider>()
                .SingleInstance();
        }
    }
}
