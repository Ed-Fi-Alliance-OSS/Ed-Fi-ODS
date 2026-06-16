// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Reflection;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest;
using EdFi.LoadTools.SmokeTest.SdkTests;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.LoadTools.Test.SmokeTests
{
    /// <summary>
    ///     In old-generator (Client.Configuration) mode, <c>ISdkConfigurationFactory.SdkConfiguration</c>
    ///     returns a Configuration object rather than an <see cref="IServiceProvider" />. BaseTest must
    ///     construct the API as <c>new XxxApi(configuration)</c> instead of falling into the DI /
    ///     manual-construction paths (which would pick the parameterless constructor and produce a
    ///     broken instance with no base path or bearer token).
    /// </summary>
    [TestFixture]
    public class BaseTestGetApiInstanceTests
    {
        [Test]
        public void GetApiInstance_in_legacy_mode_constructs_api_with_the_configuration()
        {
            var configuration = new FakeLegacyConfiguration { AccessToken = "TEST-TOKEN" };

            var resourceApi = A.Fake<IResourceApi>();
            A.CallTo(() => resourceApi.ApiType).Returns(typeof(FakeLegacyApi));

            var sdkConfigurationFactory = A.Fake<ISdkConfigurationFactory>();
            // Not an IServiceProvider => legacy mode.
            A.CallTo(() => sdkConfigurationFactory.SdkConfiguration).Returns(configuration);

            var test = new TestableBaseTest(resourceApi, sdkConfigurationFactory);

            var instance = InvokeGetApiInstance(test);

            instance.ShouldBeOfType<FakeLegacyApi>();
            ((FakeLegacyApi) instance).Configuration.ShouldBeSameAs(configuration);
        }

        private static object InvokeGetApiInstance(BaseTest test)
        {
            var method = typeof(BaseTest).GetMethod(
                "GetApiInstance", BindingFlags.Instance | BindingFlags.NonPublic);

            method.ShouldNotBeNull();

            try
            {
                return method.Invoke(test, null);
            }
            catch (TargetInvocationException ex) when (ex.InnerException != null)
            {
                throw ex.InnerException;
            }
        }

        // Public so the production code's Activator.CreateInstance (running in the EdFi.LoadTools
        // assembly) can construct it across the assembly boundary.
        public sealed class FakeLegacyConfiguration
        {
            public string AccessToken { get; set; }
        }

        // Mimics an old-generator API class: constructed with a single Configuration argument.
        public sealed class FakeLegacyApi
        {
            public FakeLegacyApi(FakeLegacyConfiguration configuration)
            {
                Configuration = configuration;
            }

            public FakeLegacyConfiguration Configuration { get; }
        }

        private sealed class TestableBaseTest : BaseTest
        {
            public TestableBaseTest(IResourceApi resourceApi, ISdkConfigurationFactory sdkConfigurationFactory)
                : base(resourceApi, new Dictionary<string, List<object>>(), sdkConfigurationFactory)
            {
            }

            protected override MethodInfo GetMethodInfo() => null;

            protected override object[] GetParams(MethodInfo methodInfo) => null;
        }
    }
}
