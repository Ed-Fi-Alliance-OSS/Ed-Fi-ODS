// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Models;
using EdFi.TestFixture;
using Microsoft.Extensions.Configuration;
using NCrunch.Framework;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Admin.DataAccess.IntegrationTests.Models
{
    public class UserContextMappingTests
    {
        [TestFixture]
        [ExclusivelyUses(TestSingletons.EmptyAdminDatabase)]
        public class When_creating_a_user : UserContextTestBase
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
                using (var context = new SqlServerUsersContext(ConnectionString))
                {
                    //Arrange
                    var user = new User {Email = emailAddress};

                    //Act
                    context.Users.Add(user);
                    context.SaveChangesForTest();

                    //Assert
                    context.Users.Count(x => x.Email == emailAddress)
                        .ShouldBe(1);
                }
            }
        }

        [TestFixture]
        [ExclusivelyUses(TestSingletons.EmptyAdminDatabase)]
        public class When_adding_an_lea_mapping_to_a_client : UserContextTestBase
        {
            private string clientName;
            private int leaId;

            [OneTimeSetUp]
            public new void Setup()
            {
                clientName = string.Format("{0}_TestData", DateTime.Now.Ticks);
                leaId = int.MaxValue - 1;
            }

            [Test]
            public void Should_persist_the_lea_mapping_without_explicitly_adding_that_mapping_to_the_databaseContext()
            {
                using (var context = new SqlServerUsersContext(ConnectionString))
                {
                    //Arrange
                    var lea = new ApplicationEducationOrganization {EducationOrganizationId = leaId};

                    var client = new ApiClient(true) {Name = clientName};

                    client.ApplicationEducationOrganizations.Add(lea);

                    //Act
                    context.Clients.Add(client);
                    context.SaveChangesForTest();

                    //Assert
                    var clientFromDb = context.Clients.Where(x => x.Name == clientName)
                        .Include(x => x.ApplicationEducationOrganizations)
                        .Single();

                    int[] leas = clientFromDb.ApplicationEducationOrganizations.Select(x => x.EducationOrganizationId)
                        .ToArray();

                    leas.ShouldBe(
                        new[] {leaId});
                }
            }
        }

        [TestFixture]
        [ExclusivelyUses(TestSingletons.EmptyAdminDatabase)]
        public class When_adding_an_lea_mapping_to_an_application : UserContextTestBase
        {
            private string appName;
            private int leaId;

            [OneTimeSetUp]
            public new void Setup()
            {
                appName = string.Format("{0}_TestData", DateTime.Now.Ticks);
                leaId = int.MaxValue - 1;
            }

            [Test]
            public void Should_persist_the_lea_mapping_without_explicitly_adding_that_mapping_to_the_databaseContext()
            {
                using (var context = new SqlServerUsersContext(ConnectionString))
                {
                    //Arrange
                    var lea = new ApplicationEducationOrganization {EducationOrganizationId = leaId};

                    var application = new Application {ApplicationName = appName};

                    application.ApplicationEducationOrganizations.Add(lea);

                    application.OperationalContextUri = "uri://ed-fi-api-host.org";

                    //Act
                    context.Applications.Add(application);
                    context.SaveChangesForTest();

                    //Assert
                    var applicationFromDb = context.Applications.Where(x => x.ApplicationName == appName)
                        .Include(x => x.ApplicationEducationOrganizations)
                        .Single();

                    int[] leas = applicationFromDb.ApplicationEducationOrganizations.Select(x => x.EducationOrganizationId)
                        .ToArray();

                    leas.ShouldBe(
                        new[] {leaId});
                }
            }
        }

        [TestFixture]
        [ExclusivelyUses(TestSingletons.EmptyAdminDatabase)]
        public class When_adding_an_application_to_a_vendor : UserContextTestBase
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
                var vendor = new Vendor {VendorName = vendorName};

                vendor.CreateApplication(appName, ClaimSetName);
                using (var context = new SqlServerUsersContext(ConnectionString))
                {
                    vendor.Applications.AsEnumerable()
                        .ElementAt(0)
                        .OperationalContextUri = "uri://ed-fi-api-host.org";

                    context.Vendors.Add(vendor);
                    context.SaveChangesForTest();

                    //Act
                    var vendorFromDb = context.Vendors.Where(v => v.VendorName == vendorName)
                        .Include(x => x.Applications)
                        .Single();

                    //Assert
                    vendorFromDb.ShouldNotBeNull();
                    vendorFromDb.Applications.Count.ShouldBe(1);

                    vendorFromDb.Applications.ToList()[0]
                        .ApplicationName.ShouldBe(appName);
                }
            }
        }

        [TestFixture]
        public class When_adding_a_local_education_agency_to_an_application : UserContextTestBase
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
                var vendor = new Vendor {VendorName = vendorName};

                vendor.CreateApplication(appName, ClaimSetName);

                var educationOrganizationAssociation = vendor.Applications.AsEnumerable()
                    .ElementAt(0)
                    .CreateApplicationEducationOrganization(leaId);

                using (var context = new SqlServerUsersContext(ConnectionString))
                {
                    vendor.Applications.AsEnumerable()
                        .ElementAt(0)
                        .OperationalContextUri = "uri://ed-fi-api-host.org";

                    context.ApplicationEducationOrganizations.AddOrUpdate(educationOrganizationAssociation);
                    context.Vendors.Add(vendor);
                    context.SaveChangesForTest();

                    //Act
                    var application = context.Applications.Where(app => app.ApplicationName == appName)
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
}
