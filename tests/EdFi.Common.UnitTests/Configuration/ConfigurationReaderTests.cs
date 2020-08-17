﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using EdFi.Ods.Common.Configuration;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Common.UnitTests.Configuration
{
    public class ConfigurationReaderTests
    {
        [TestFixture]
        public class When_configuration_value_is_not_present
        {
            [Test]
            public void Should_return_a_null_value()
            {
                var config = new ConfigurationBuilder()
                   .SetBasePath(TestContext.CurrentContext.TestDirectory)
                   .AddJsonFile("appsettings.json", optional: true)
                   .Build();

                new AppConfigValueProvider(config).GetValue("Non-existent Key")
                                            .ShouldBeNull();
            }
        }
    }
}
#endif