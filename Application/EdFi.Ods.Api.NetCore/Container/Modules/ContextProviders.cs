// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security;

namespace EdFi.Ods.Api.NetCore.Container.Modules
{
    public class ContextProviders : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApiKeyContextProvider>().As<IApiKeyContextProvider>().As<IHttpContextStorageTransferKeys>()
                .AsSelf();

            builder.RegisterType<SchoolYearContextProvider>().As<ISchoolYearContextProvider>()
                .As<IHttpContextStorageTransferKeys>().AsSelf();
        }
    }
}
