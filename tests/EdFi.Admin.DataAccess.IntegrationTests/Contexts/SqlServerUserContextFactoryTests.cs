// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Transactions;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Common.Configuration;
using EdFi.TestFixture;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Admin.DataAccess.IntegrationTests.Contexts
{
    [TestFixture]
    public class SqlServerUserContextFactoryTests
    {
        protected SqlServerUsersContext _context;
        protected TransactionScope _transaction;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appSettings.json", true, true)
                .AddJsonFile($"appSettings.development.json", true, true);

            var config = builder.Build();
            var connectionString = config.GetConnectionString("MSSQL");

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(connectionString);
            _context = new SqlServerUsersContext(optionsBuilder.Options);

            _transaction = new TransactionScope();
        }

        [TearDown]
        public void Teardown()
        {
            _transaction.Dispose();
        }

        [Test]
        public void Given_configured_for_SqlServer_then_create_SqlServerUsersContext_make_a_change_and_save_it()
        {
            var connectionStringsProvider = A.Fake<IAdminDatabaseConnectionStringProvider>();
            A.CallTo(() => connectionStringsProvider.GetConnectionString()).Returns("Server=.;Database=EdFi_Admin_Test;Trusted_Connection=True; Encrypt=False;");

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

        [TestFixture]
        public class When_creating_a_user : SqlServerUserContextFactoryTests
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
        public class When_adding_an_lea_mapping_to_a_client : SqlServerUserContextFactoryTests
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
        public class When_adding_an_lea_mapping_to_an_application : SqlServerUserContextFactoryTests
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
        public class When_adding_an_application_to_a_vendor : SqlServerUserContextFactoryTests
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
        public class When_adding_a_local_education_agency_to_an_application : SqlServerUserContextFactoryTests
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