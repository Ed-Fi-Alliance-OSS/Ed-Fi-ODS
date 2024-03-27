// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Common;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest;
using EdFi.LoadTools.SmokeTest.ApiTests;
using EdFi.LoadTools.SmokeTest.CommonTests;
using EdFi.LoadTools.SmokeTest.PropertyBuilders;
using EdFi.LoadTools.SmokeTest.SdkTests;
using EdFi.SmokeTest.Console.Application;
using Swashbuckle.Swagger;
using GetAllTest = EdFi.LoadTools.SmokeTest.SdkTests.GetAllTest;

namespace EdFi.SmokeTest.Console
{
    public class SmokeTestsDestructiveSdkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var generators = new[]
            {
                typeof(GetStaticVersionTest),
                typeof(GetStaticDependenciesTest),
                typeof(GetSwaggerMetadataGenerator),
                typeof(DestructiveMethodsGenerator)
            };

            foreach (var generator in generators)
            {
                builder.RegisterType(generator)
                    .As<ITestGenerator>();
            }

            builder.RegisterType<ModelDependencySort>()
                .As<IModelDependencySort>();

            builder.RegisterType<DependenciesRetriever>()
                .As<IDependenciesRetriever>();

            builder.Register(
                    c =>
                    {
                        var ctx = c.Resolve<IComponentContext>();
                        var factory = ctx.Resolve<ISdkConfigurationFactory>();
                        var results = ctx.Resolve<Dictionary<string, List<object>>>();
                        var created = ctx.Resolve<Dictionary<string, Uri>>();
                        var propertyBuilder = ctx.Resolve<IEnumerable<IPropertyBuilder>>();

                        return new TestFactory<IResourceApi, ITest>
                        {
                            t => new PostTest(t, results, propertyBuilder, created, factory),
                            t => new PutTest(t, results, created, factory),
                            t => new GetAllTest(t, results, factory),
                            t => new DeleteTest(t, results, created, factory)
                        };
                    })
                .As<ITestFactory<IResourceApi, ITest>>();

            builder.RegisterInstance(
                    new DependenciesSorter()
                    {
                        {
                            typeof(PostTest), dependencies => dependencies
                                .Where(d => d.Operations.Contains(EdFiConstants.CreateOperation))
                                .OrderBy(d => d.Order)
                        },
                        {
                            typeof(PutTest), dependencies => dependencies
                                .Where(d => d.Operations.Contains(EdFiConstants.UpdateOperation))
                                .OrderBy(d => d.Order)
                        },
                        {
                            typeof(GetAllTest), dependencies => dependencies
                                .Where(d => d.Operations.Contains(EdFiConstants.CreateOperation))
                        },
                        {
                            typeof(DeleteTest), dependencies => dependencies
                                .Where(d => d.Operations.Contains(EdFiConstants.CreateOperation))
                                .OrderByDescending(d => d.Order)
                        }
                    })
                .As<IDependenciesSorter>()
                .SingleInstance();

            var propertyBuilders =
                new[]
                {
                    // note these are in order of precedence
                    typeof(IgnorePropertyBuilder),
                    typeof(ParentLocalEducationAgencyReferenceBuilder),
                    typeof(UnifiedKeyPropertyBuilder),
                    typeof(SimplePropertyBuilder),
                    typeof(NamespacePropertyBuilder),
                    typeof(ListPropertyBuilder),
                    typeof(ExistingResourceBuilder),
                    typeof(UniqueIdPropertyBuilder),
                    typeof(DescriptorPropertyBuilder),
                    typeof(EducationOrganizationReferencePropertyBuilder),
                    typeof(SchoolYearTypeReferencePropertyBuilder),
                    typeof(ReferencePropertyBuilder),
                    typeof(DateTimePropertyBuilder),
                    typeof(TimeStringPropertyBuilder),
                    typeof(EducationOrganizationAddressBuilder),
                    typeof(StringPropertyBuilder)
                };

            foreach (var propertyBuilder in propertyBuilders)
            {
                builder.RegisterType(propertyBuilder)
                    .As<IPropertyBuilder>();
            }

            builder.RegisterType<PropertyInfoMetadataLookup>()
                .As<IPropertyInfoMetadataLookup>();

            // Holds objects results for later use
            builder.RegisterInstance(new Dictionary<string, List<object>>())
                .SingleInstance();

            // Holds created resource locations
            builder.RegisterInstance(new Dictionary<string, Uri>())
                .SingleInstance();

            // Holds OpenAPI metadata
            builder.RegisterInstance(new Dictionary<string, Resource>())
                .SingleInstance();

            // Holds unique schema names
            builder.RegisterInstance(new List<string>())
                .SingleInstance();

            // Holds OpenAPI metadata
            builder.RegisterInstance(new Dictionary<string, SwaggerDocument>())
                .SingleInstance();

            // Holds the OpenAPI Model Definitions
            builder.RegisterInstance(new Dictionary<string, Entity>())
                .SingleInstance();
        }
    }
}
