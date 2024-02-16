// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Models;
using FakeItEasy;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Shouldly;
using System;
using System.Linq;
using System.Transactions;
using EdFi.TestFixture;
using Microsoft.EntityFrameworkCore;
using Action = EdFi.Security.DataAccess.Models.Action;

namespace EdFi.Security.DataAccess.IntegrationTests.Contexts
{
    [TestFixture]
    public class SqlServerSecurityContextFactoryTests
    {
        protected SqlServerSecurityContext _context;
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
            _context = new SqlServerSecurityContext(optionsBuilder.Options);

            _transaction = new TransactionScope();
        }

        [TearDown]
        public void Teardown()
        {
            _transaction.Dispose();
        }

        [Test]
        public void Given_configured_for_SqlServer_then_create_SQLSecurityContext_make_a_change_and_save_it()
        {

            var testAction = new Action()
            {
                ActionName = "Test",
                ActionUri = "http://ed-fi.org/odsapi/actions/Test"
            };

            int originalCount = _context.Actions.Count();
            _context.Actions.Add(testAction);
            _context.SaveChanges();
            _context.Actions.Count().ShouldBe(originalCount + 1);
            _context.Actions.Remove(testAction);
            _context.SaveChanges();
            _context.Actions.Count().ShouldBe(originalCount);
        }

        [TestFixture]
        public class When_creating_an_application : SqlServerSecurityContextFactoryTests
        {
            [Test]
            public void Should_persist_the_user_to_the_database()
            {
                string applicationName = "Test Application";

                //Arrange
                var application = new Application() { ApplicationName = applicationName };

                //Act
                _context.Applications.Add(application);
                _context.SaveChangesForTest();

                //Assert
                _context.Applications.Count(x => x.ApplicationName == applicationName)
                    .ShouldBe(1);
            }
        }

        [TestFixture]
        public class When_creating_a_claim : SqlServerSecurityContextFactoryTests
        {
            private string appName = string.Format("{0}_TestData", DateTime.Now.Ticks);
            private const string claimSetName = "ClaimSet";
            private Application applicationTest;

            [Test]
            public void Should_create_claimSet()
            {
                applicationTest = new Application() { ApplicationName = appName };

                _context.Applications.Add(applicationTest);
                _context.SaveChangesForTest();

                var testApplication = _context.Applications.Where(v => v.ApplicationName == appName).FirstOrDefault();

                var testClaimSet = new ClaimSet()
                {
                    ClaimSetName = claimSetName,
                    Application = testApplication,
                    IsEdfiPreset = false,
                    ForApplicationUseOnly = true
                };

                //Arrange
                _context.ClaimSets.Add(testClaimSet);
                _context.SaveChangesForTest();

                //Act
                var claimSetFromDb = _context.ClaimSets.Where(v => v.ClaimSetName == claimSetName).Single();

                //Assert
                claimSetFromDb.ShouldNotBeNull();
            }

            [Test]
            public void Should_create_resourceClaim()
            {
                applicationTest = new Application() { ApplicationName = appName };

                _context.Applications.Add(applicationTest);
                _context.SaveChangesForTest();

                var testApplication = _context.Applications.Where(v => v.ApplicationName == appName).FirstOrDefault();

                string displayName = "ResourceClaimDisplayNameTest";

                var testResourceClaim = new ResourceClaim()
                {
                    DisplayName = displayName,
                    ResourceName = displayName,
                    ClaimName = "http://ed-fi.org/ods/identity/claims/domains/" + displayName,
                    Application = testApplication
                };

                //Arrange
                _context.ResourceClaims.Add(testResourceClaim);
                _context.SaveChangesForTest();

                //Act
                var resourceClaimSetFromDb = _context.ResourceClaims.Where(v => v.DisplayName == displayName).Single();

                //Assert
                resourceClaimSetFromDb.ShouldNotBeNull();
            }
        }
    }
}