﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Common.Configuration;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Admin.DataAccess.IntegrationTests.Contexts
{
    [TestFixture]
    public class SqlServerUserContextFactoryTests
    {
        [Test, Explicit]
        public void Given_configured_for_SqlServer_then_create_SqlServerUsersContext_make_a_change_and_save_it()
        {
            var connectionStringsProvider = A.Fake<IAdminDatabaseConnectionStringProvider>();
            A.CallTo(() => connectionStringsProvider.GetConnectionString()).Returns("Server=.;Database=EdFi_Admin_Test;Trusted_Connection=True;");

            var context = new UsersContextFactory(connectionStringsProvider, DatabaseEngine.SqlServer)
                .CreateContext();

            var testVendor = new Vendor()
            {
                VendorName = "Test"
            };

            int originalCount = context.Vendors.Count();
            context.Vendors.Add(testVendor);
            context.SaveChanges();
            context.Vendors.Count().ShouldBe(originalCount + 1);
            context.Vendors.Remove(testVendor);
            context.SaveChanges();
            context.Vendors.Count().ShouldBe(originalCount);
        }
    }
}