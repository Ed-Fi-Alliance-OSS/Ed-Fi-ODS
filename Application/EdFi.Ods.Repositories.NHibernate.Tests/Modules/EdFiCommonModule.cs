// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.IO;
using System;
using System.Collections.Generic;
using System.Text;
using EdFi.Common.Configuration;

namespace EdFi.Ods.Repositories.NHibernate.Tests.Modules
{
    public class EdFiCommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AssembliesProvider>().As<IAssembliesProvider>();
            builder.RegisterType<FileSystemWrapper>().As<IFileSystem>();
            builder.RegisterType<ConfigConnectionStringsProvider>().As<IConfigConnectionStringsProvider>();
            builder.RegisterType<DefaultPageSizeLimitProvider>().As<IDefaultPageSizeLimitProvider>();
        }
    }
}