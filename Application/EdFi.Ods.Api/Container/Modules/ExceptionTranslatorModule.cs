// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using EdFi.Ods.Api.ExceptionHandling;

namespace EdFi.Ods.Api.Container.Modules {
    public class ExceptionTranslatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // All exception translators
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => typeof(IExceptionTranslator).IsAssignableFrom(t))
                .As<IExceptionTranslator>()
                .AsSelf();
        }
    }
}
#endif
