// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.NetCore.Infrastructure.Context;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Api.NetCore.Container.Modules
{
    public class ContextStorageModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Primary context storage for ASP.NET web applications
            builder.RegisterType<HttpContextStorage>().As<IContextStorage>().AsSelf();

            // Secondary context storage for background tasks running in ASP.NET web applications
            // Allows selected context to flow to worker Tasks (see IHttpContextStorageTransferKeys and IHttpContextStorageTransfer)
            builder.RegisterType<CallContextStorage>().As<IContextStorage>().AsSelf();

            // Features to transfer context from HttpContext to the secondary storage in ASP.NET applications
            builder.RegisterType<HttpContextStorageTransfer>().As<IHttpContextStorageTransfer>();
        }
    }
}
