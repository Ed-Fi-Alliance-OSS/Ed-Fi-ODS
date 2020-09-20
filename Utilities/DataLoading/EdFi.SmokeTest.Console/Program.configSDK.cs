// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest;
using EdFi.LoadTools.SmokeTest.ApiTests;
using EdFi.LoadTools.SmokeTest.CommonTests;
using EdFi.LoadTools.SmokeTest.PropertyBuilders;
using EdFi.LoadTools.SmokeTest.SdkTests;
using EdFi.SmokeTest.Console.Application;
using SimpleInjector;
using Swashbuckle.Swagger;
using GetAllSkipLimitTest = EdFi.LoadTools.SmokeTest.SdkTests.GetAllSkipLimitTest;
using GetAllTest = EdFi.LoadTools.SmokeTest.SdkTests.GetAllTest;
using GetByExampleTest = EdFi.LoadTools.SmokeTest.SdkTests.GetByExampleTest;
using GetByIdTest = EdFi.LoadTools.SmokeTest.SdkTests.GetByIdTest;
using GetMethodsGenerator = EdFi.LoadTools.SmokeTest.SdkTests.GetMethodsGenerator;

namespace EdFi.SmokeTest.Console
{
    public partial class Program
    {
        private static void ConfigureNonDestructiveSdk(Container c)
        {
            c.Register<ISdkCategorizer, SdkCategorizer>();

            c.Collection.Register<ITestGenerator>(
                new[]
                {
                    typeof(GetStaticVersionTest),
                    typeof(GetStaticDependenciesTest),
                    typeof(GetMethodsGenerator)
                });

            c.RegisterInstance<ITestFactory<IResourceApi, ITest>>(
                new TestFactory<IResourceApi, ITest>
                {
                    t => new GetAllTest(
                        t,
                        c.GetInstance<Dictionary<string, List<object>>>(),
                        c.GetInstance<ISdkConfigurationFactory>()),
                    t => new GetByExampleTest(
                        t,
                        c.GetInstance<Dictionary<string, List<object>>>(),
                        c.GetInstance<ISdkConfigurationFactory>()),
                    t => new GetAllSkipLimitTest(
                        t,
                        c.GetInstance<Dictionary<string, List<object>>>(),
                        c.GetInstance<ISdkConfigurationFactory>()),
                    t => new GetByIdTest(
                        t,
                        c.GetInstance<Dictionary<string, List<object>>>(),
                        c.GetInstance<ISdkConfigurationFactory>())
                });

            c.RegisterSingleton<ISdkLibraryFactory, SdkLibraryFactory>();
            c.RegisterSingleton<ITokenRetriever, TokenRetriever>();
            c.RegisterSingleton<IOAuthTokenHandler, OAuthTokenHandler>();
            c.RegisterSingleton<ISdkConfigurationFactory, SdkConfigurationFactory>();

            // Holds GetAll results for later use
            c.RegisterSingleton(() => new Dictionary<string, List<object>>());
        }

        private static void ConfigureDestructiveSdk(Container c)
        {
            c.RegisterSingleton<ISdkConfigurationFactory, SdkConfigurationFactory>();
            c.Register<ISdkCategorizer, SdkCategorizer>();
            c.RegisterSingleton<ITokenRetriever, TokenRetriever>();
            c.RegisterSingleton<IOAuthTokenHandler, OAuthTokenHandler>();

            c.Collection.Register<ITestGenerator>(
                new[]
                {
                    typeof(GetStaticVersionTest),
                    typeof(GetStaticDependenciesTest),
                    typeof(GetSwaggerMetadataGenerator),
                    typeof(DestructiveMethodsGenerator)
                });

            c.Register<IModelDependencySort, ModelDependencySort>();

            c.RegisterInstance<ITestFactory<IResourceApi, ITest>>(
                new TestFactory<IResourceApi, ITest>
                {
                    t => new GetAllTest(
                        t,
                        c.GetInstance<Dictionary<string, List<object>>>(),
                        c.GetInstance<ISdkConfigurationFactory>()),
                    t => new PostTest(
                        t,
                        c.GetInstance<Dictionary<string, List<object>>>(),
                        c.GetInstance<IEnumerable<IPropertyBuilder>>(),
                        c.GetInstance<Dictionary<string, Uri>>(),
                        c.GetInstance<ISdkConfigurationFactory>()),
                    t => new PutTest(
                        t,
                        c.GetInstance<Dictionary<string, List<object>>>(),
                        c.GetInstance<Dictionary<string, Uri>>(),
                        c.GetInstance<ISdkConfigurationFactory>()),
                    t => new DeleteTest(
                        t,
                        c.GetInstance<Dictionary<string, List<object>>>(),
                        c.GetInstance<Dictionary<string, Uri>>(),
                        c.GetInstance<ISdkConfigurationFactory>())
                });

            c.Collection.Register<IPropertyBuilder>(
                new[]
                {
                    // note these are in order of precedence
                    typeof(IgnorePropertyBuilder),
                    typeof(SimplePropertyBuilder),
                    typeof(DescriptorNamespacePropertyBuilder),
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
                });

            c.RegisterSingleton<ISdkLibraryFactory, SdkLibraryFactory>();
            c.RegisterSingleton<IPropertyInfoMetadataLookup, PropertyInfoMetadataLookup>();

            // Holds objects results for later use
            c.RegisterSingleton(() => new Dictionary<string, List<object>>());

            // Holds created resource locations
            c.RegisterSingleton(() => new Dictionary<string, Uri>());

            c.Register<SwaggerRetriever>();

            // Holds OpenAPI metadata
            c.RegisterSingleton(() => new Dictionary<string, Resource>());

            // Holds unique schema names
            c.RegisterSingleton(() => new List<string>());

            // Holds OpenAPI metadata
            c.RegisterSingleton(() => new Dictionary<string, SwaggerDocument>());

            // Holds the OpenAPI Model Definitions
            c.RegisterSingleton(() => new Dictionary<string, Entity>());
        }
    }
}
