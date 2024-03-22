// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Transactions;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Models;
using EdFi.Common.Configuration;
using EdFi.TestFixture;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Admin.DataAccess.IntegrationTests.Contexts
{

    [TestFixture, Category("DataAccessIntegrationTests")]
    public class PostgreSQLUserContextFactoryTests
    {
        private PostgresUsersContext _context;
        private TransactionScope _transaction;

        [SetUp]
        public void Setup()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var builder = new ConfigurationBuilder()
               .AddJsonFile($"appsettings.json", true, true)
               .AddJsonFile($"appsettings.Development.json", true, true);

            var config = builder.Build();
            var engine = config.GetSection("ApiSettings")["Engine"] ?? "";

            if (!engine.Equals(DatabaseEngine.Postgres.Value, StringComparison.OrdinalIgnoreCase))
            {
                Assert.Inconclusive("PostgreSQL UserContextFactory integration tests are not being run because the engine is not set to Postgres.");
            }
            
            var connectionString = config.GetConnectionString("PostgreSQL");

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseNpgsql(connectionString);
            _context = new PostgresUsersContext(optionsBuilder.Options);

            _transaction = new TransactionScope();
        }

        [TearDown]
        public void Teardown()
        {
            _transaction?.Dispose();
        }

        [Test]
        public void Given_configured_for_Postgres_then_create_PostgresUsersContext_make_a_change_and_save_it()
        {

            var testVendor = new Vendor()
            {
                VendorName = "Test"
            };

            int originalCount = _context.Vendors.Count();
            _context.Vendors.Add(testVendor);
            _context.SaveChanges();
            _context.Vendors.Count().ShouldBe(originalCount + 1);
            _context.Vendors.Remove(testVendor);
            _context.SaveChanges();
            _context.Vendors.Count().ShouldBe(originalCount);
        }

        [TestFixture]
        public class When_creating_a_user : PostgreSQLUserContextFactoryTests
        {
            private string emailAddress;

            [OneTimeSetUp]
            public new void Setup()
            {
                emailAddress = string.Format("{0}@{1}.com", DateTime.Now.Ticks, DateTime.Now.Ticks + 1);
            }

            [Test]
            public void Should_persist_the_user_to_the_database()
            {
                //Arrange
                var user = new User { Email = emailAddress };

                //Act
                _context.Users.Add(user);
                _context.SaveChangesForTest();

                //Assert
                _context.Users.Count(x => x.Email == emailAddress)
                    .ShouldBe(1);
            }
        }

        [TestFixture]
        public class When_adding_an_lea_mapping_to_a_client : PostgreSQLUserContextFactoryTests
        {
            private string clientName;
            private long leaId;
            private string vendorName;
            private string appName;
            private const string ClaimSetName = "ClaimSet";

            [OneTimeSetUp]
            public new void Setup()
            {
                vendorName = string.Format("{0}_TestData", DateTime.Now.Ticks);
                appName = string.Format("{0}_TestData", DateTime.Now.Ticks);
                clientName = string.Format("{0}_TestData", DateTime.Now.Ticks);
                leaId = long.MaxValue - 1;
            }

            [Test]
            public void Should_persist_the_lea_mapping_without_explicitly_adding_that_mapping_to_the_databaseContext()
            {
                //Arrange

                var vendor = new Vendor { VendorName = vendorName };

                vendor.CreateApplication(appName, ClaimSetName);

                vendor.Applications.AsEnumerable()
                    .ElementAt(0)
                    .OperationalContextUri = "uri://ed-fi-api-host.org";

                _context.Vendors.Add(vendor);

                _context.SaveChangesForTest();

                var lea = new ApplicationEducationOrganization { EducationOrganizationId = leaId, Application = vendor.Applications.AsEnumerable().ElementAt(0) };

                var client = new ApiClient(true) { Name = clientName };

                client.ApplicationEducationOrganizations.Add(lea);

                //Act
                _context.ApiClients.Add(client);
                _context.SaveChangesForTest();

                //Assert
                var clientFromDb = _context.ApiClients.Where(x => x.Name == clientName)
                    .Include(x => x.ApplicationEducationOrganizations)
                    .Single();

                long[] leas = clientFromDb.ApplicationEducationOrganizations.Select(x => x.EducationOrganizationId)
                    .ToArray();

                leas.ShouldBe(
                    new[] { leaId });

            }
        }

        [TestFixture]
        public class When_adding_an_lea_mapping_to_an_application : PostgreSQLUserContextFactoryTests
        {
            private string appName;
            private long leaId;

            [OneTimeSetUp]
            public new void Setup()
            {
                appName = string.Format("{0}_TestData", DateTime.Now.Ticks);
                leaId = long.MaxValue - 1;
            }

            [Test]
            public void Should_persist_the_lea_mapping_without_explicitly_adding_that_mapping_to_the_databaseContext()
            {
                //Arrange
                var lea = new ApplicationEducationOrganization { EducationOrganizationId = leaId };

                var application = new Application { ApplicationName = appName };

                application.ApplicationEducationOrganizations.Add(lea);

                application.OperationalContextUri = "uri://ed-fi-api-host.org";

                //Act
                _context.Applications.Add(application);
                _context.SaveChangesForTest();

                //Assert
                var applicationFromDb = _context.Applications.Where(x => x.ApplicationName == appName)
                    .Include(x => x.ApplicationEducationOrganizations)
                    .Single();

                long[] leas = applicationFromDb.ApplicationEducationOrganizations.Select(x => x.EducationOrganizationId)
                    .ToArray();

                leas.ShouldBe(
                    new[] { leaId });

            }
        }

        [TestFixture]
        public class When_adding_an_application_to_a_vendor : PostgreSQLUserContextFactoryTests
        {
            private string vendorName;
            private string appName;
            private const string ClaimSetName = "ClaimSet";

            [OneTimeSetUp]
            public new void Setup()
            {
                vendorName = string.Format("{0}_TestData", DateTime.Now.Ticks);
                appName = string.Format("{0}_TestData", DateTime.Now.Ticks);
            }

            [Test]
            public void Should_create_application()
            {
                //Arrange
                var vendor = new Vendor { VendorName = vendorName };

                vendor.CreateApplication(appName, ClaimSetName);

                vendor.Applications.AsEnumerable()
                    .ElementAt(0)
                    .OperationalContextUri = "uri://ed-fi-api-host.org";

                _context.Vendors.Add(vendor);
                _context.SaveChangesForTest();

                //Act
                var vendorFromDb = _context.Vendors.Where(v => v.VendorName == vendorName)
                    .Include(x => x.Applications)
                    .Single();

                //Assert
                vendorFromDb.ShouldNotBeNull();
                vendorFromDb.Applications.Count.ShouldBe(1);

                vendorFromDb.Applications.ToList()[0]
                    .ApplicationName.ShouldBe(appName);

            }
        }

        [TestFixture]
        public class When_adding_a_local_education_agency_to_an_application : PostgreSQLUserContextFactoryTests
        {
            private string vendorName;
            private string appName;
            private int leaId;
            private const string ClaimSetName = "ClaimSet";

            [OneTimeSetUp]
            public new void Setup()
            {
                vendorName = string.Format("{0}_TestData", DateTime.Now.Ticks);
                appName = string.Format("{0}_TestData", DateTime.Now.Ticks);
                leaId = int.MaxValue - 1;
            }

            [Test]
            public void Should_create_lea_association()
            {
                //Arrange
                var vendor = new Vendor { VendorName = vendorName };

                vendor.CreateApplication(appName, ClaimSetName);

                var educationOrganizationAssociation = vendor.Applications.AsEnumerable()
                    .ElementAt(0)
                    .CreateApplicationEducationOrganization(leaId);

                vendor.Applications.AsEnumerable()
                    .ElementAt(0)
                    .OperationalContextUri = "uri://ed-fi-api-host.org";

                _context.ApplicationEducationOrganizations.Update(educationOrganizationAssociation);
                _context.Vendors.Add(vendor);
                _context.SaveChangesForTest();

                //Act
                var application = _context.Applications.Where(app => app.ApplicationName == appName)
                    .Include(x => x.ApplicationEducationOrganizations)
                    .Single();

                var applicationLocalEducationAgencies = application.ApplicationEducationOrganizations.ToArray();
                applicationLocalEducationAgencies.Length.ShouldBe(1);

                applicationLocalEducationAgencies[0]
                    .EducationOrganizationId.ShouldBe(leaId);

            }
        }
    }
}