// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Common.IO;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Features.Composites;

namespace EdFi.Ods.Repositories.NHibernate.Tests
{
    [Obsolete("Required for bulk load")]
    public class LegacyEdFiOdsCommonInstaller : RegistrationMethodsInstallerBase
    {
        // Add registrations for components that may have alternative implementations
        // based on different environmental configurations or implementation-specific requirements
        // protected virtual void RegisterISomething(IWindsorContainer container)
        // {
        //     container.Register(Component
        //            .For<ISomething>()
        //            .ImplementedBy<Something>());
        // }

        protected virtual void RegisterIApiKeyContextProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IApiKeyContextProvider, IHttpContextStorageTransferKeys>()
                   .ImplementedBy<ApiKeyContextProvider>());
        }

        protected virtual void RegisterISchoolYearContextProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<ISchoolYearContextProvider, IHttpContextStorageTransferKeys>()
                   .ImplementedBy<SchoolYearContextProvider>());
        }

        protected virtual void RegisterICompositeDefinitionProcessor(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For(typeof(ICompositeDefinitionProcessor<,>))
                   .ImplementedBy(typeof(CompositeDefinitionProcessor<,>)));
        }

        protected virtual void RegisterIResourceJoinPathExpressionProcessor(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IResourceJoinPathExpressionProcessor>()
                   .ImplementedBy<ResourceJoinPathExpressionProcessor>());
        }

        protected virtual void RegisterIFileSystem(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IFileSystem>()
                   .ImplementedBy<FileSystemWrapper>());
        }

        protected virtual void RegisterResourceLoadGraphFactory(IWindsorContainer container)
        {
            // Graph Model
            container.Register(
                Component.For<IResourceLoadGraphFactory>().ImplementedBy<ResourceLoadGraphFactory>());
        }
    }
}
