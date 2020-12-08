// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest;
using EdFi.LoadTools.SmokeTest.SdkTests;
using EdFi.SmokeTest.Console.Application;

namespace EdFi.SmokeTest.Console
{
    public class SmokeTestsSdkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SdkConfigurationFactory>(
                ).As<ISdkConfigurationFactory>()
                .SingleInstance();

            builder.RegisterType<SdkLibraryFactory>()
                .As<ISdkLibraryFactory>()
                .SingleInstance();

            builder.RegisterType<SdkCategorizer>()
                .As<ISdkCategorizer>();
        }
    }
}
