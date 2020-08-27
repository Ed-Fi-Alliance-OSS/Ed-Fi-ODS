// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.TestFixture;
using NUnit.Framework;

namespace EdFi.Ods.Admin.DataAccess.IntegrationTests.Models
{
    public abstract class UserContextTestBase : TestFixtureBase
    {
        private TransactionScope _transaction;

        protected string ConnectionString { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            using (var usersContext = new SqlServerUsersContext())
            {
                ConnectionString = usersContext.Database.Connection.ConnectionString;
            }
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

        protected void DeleteUser(string emailAddress)
        {
            Delete(context => context.Users, context => context.Users.Where(u => u.Email == emailAddress));
        }

        protected void DeleteClient(string clientName)
        {
            Delete(context => context.Clients, context => context.Clients.Where(c => c.Name == clientName));
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

        protected void Delete<T>(
            Func<SqlServerUsersContext, IDbSet<T>> dbObject,
            Func<SqlServerUsersContext, IQueryable<T>> filter)
            where T : class
        {
            using (var context = new SqlServerUsersContext())
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
