// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using EdFi.Admin.DataAccess;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Utils;
using EdFi.Ods.Admin.Services;
using EdFi.Ods.Common.Configuration;
using EdFi.TestFixture;
using FakeItEasy;
using Microsoft.Extensions.Configuration;
using NCrunch.Framework;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Admin.Tests.Services
{
    public abstract class UserContextTestBase : TestFixtureBase
    {
        private TransactionScope _transaction;

        protected string ConnectionString { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionStringProvider = new ConfigConnectionStringsProvider(config);

            ConnectionString = connectionStringProvider.GetConnectionString("EdFi_Admin");
        }

        [SetUp]
        public void Setup()
        {
            _transaction = new TransactionScope();
        }

        [TearDown]
        public void TearDown()
        {
            _transaction.Dispose();
        }

        protected void DeleteApplicationEducationOrganization(int educationOrganizationId)
        {
            Delete(
                context => context.ApplicationEducationOrganizations,
                context => context.ApplicationEducationOrganizations
                    .Where(aeo => aeo.EducationOrganizationId == educationOrganizationId)
            );
        }

        protected void DeleteApplication(string appName)
        {
            Delete(context => context.Applications, context => context.Applications.Where(app => app.ApplicationName == appName));
        }

        protected void DeleteVendor(string vendorName)
        {
            Delete(context => context.Vendors, context => context.Vendors.Where(app => app.VendorName == vendorName));
        }

        private void Delete<T>(
            Func<SqlServerUsersContext, IDbSet<T>> dbObject,
            Func<SqlServerUsersContext, IQueryable<T>> filter)
            where T : class
        {
            using (var context = new SqlServerUsersContext(ConnectionString))
            {
                foreach (var tDelete in filter(context))
                {
                    dbObject(context)
                        .Remove(tDelete);
                }

                context.SaveChangesForTest();
            }
        }
    }
}
