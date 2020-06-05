// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Validation;
using Module = Autofac.Module;

namespace EdFi.Ods.Api.NetCore.Container.Modules
{
    public class DomainModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DomainModelProvider>().As<IDomainModelProvider>().SingleInstance();

            // Domain Model
            builder.Register(c => c.Resolve<IDomainModelProvider>().GetDomainModel()).As<DomainModel>().SingleInstance();

            // Schemas
            builder.Register(c => c.Resolve<DomainModel>().Schemas.ToArray()).As<Schema[]>().SingleInstance();

            // Schema Name Map Provider
            builder.Register(c => c.Resolve<DomainModel>().SchemaNameMapProvider).As<ISchemaNameMapProvider>().SingleInstance();

            // Resource Model Provider
            builder.RegisterType<ResourceModelProvider>().As<IResourceModelProvider>().SingleInstance();

            // Validator for the domain model provider
            builder.RegisterType<FluentValidationObjectValidator>().As<IExplicitObjectValidator>().SingleInstance();

            // Domain Models definitions provider
            builder.RegisterType<DomainModelDefinitionsJsonEmbeddedResourceProvider>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(Assembly),
                        (p, c) => c.Resolve<IAssembliesProvider>().GetAssemblies().SingleOrDefault(x => x.IsStandardAssembly())))
                .As<IDomainModelDefinitionsProvider>().SingleInstance();
        }
    }
}
