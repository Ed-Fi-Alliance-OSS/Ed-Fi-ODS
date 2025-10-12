// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Sandbox.Provisioners;
using EdFi.Ods.SandboxAdmin.Services;

namespace EdFi.Ods.SandboxAdmin.Modules
{
    public class AzureSqlServerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlServerTemplateDatabaseLeaQuery>().As<ITemplateDatabaseLeaQuery>();
            builder.RegisterType<AzureSqlServerSandboxProvisioner>().As<ISandboxProvisioner>();
        }
    }
}
