// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETSTANDARD
using Autofac;
using EdFi.Ods.Api.Common.ExceptionHandling;

namespace EdFi.Ods.Api.Common.Container.Modules {
    public class ExceptionTranslatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // All exception translators
            builder.RegisterTypes()
                .Where(t => t == typeof(IExceptionTranslator))
                .As<IExceptionTranslator>()
                .AsSelf();
        }
    }
}
#endif
