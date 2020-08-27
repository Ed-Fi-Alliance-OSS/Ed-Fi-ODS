// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Configuration;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Admin.Services
{
    [TestFixture]
    public class AppSettingsConfigurationTests
    {
        [Test]
        public void When_Accessing_App_Settings()
        {
            var smtpUsername = ConfigurationManager.AppSettings.Get("smtp:Username");
            var smtpPassword = ConfigurationManager.AppSettings.Get("smtp:Password");

            if (smtpUsername == null)
            {
                Assert.Fail("Expected smtp:Username in app.config, but not found or could not read");
            }

            if (smtpPassword == null)
            {
                Assert.Fail("Expected smtp:Password in app.config, but not found or could not read");
            }

            smtpUsername.ShouldBe("Bingo");
            smtpPassword.ShouldBe("Tingo");
        }
    }
}
