// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Security.DataAccess.Contexts;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Shouldly;
using System;
using System.Linq;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using EdFi.Security.DataAccess.Models;
using EdFi.TestFixture;
using Action = EdFi.Security.DataAccess.Models.Action;

namespace EdFi.Security.DataAccess.IntegrationTests.Contexts
{

    [TestFixture]
    public class PostgreSQLSecurityContextFactoryTests
    {
        private PostgresSecurityContext _context;
        private TransactionScope _transaction;

        [SetUp]
        public void Setup()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var builder = new ConfigurationBuilder()
               .AddJsonFile($"appSettings.json", true, true)
               .AddJsonFile($"appSettings.development.json", true, true);

            var config = builder.Build();
            var connectionString = config.GetConnectionString("PostgreSQL");

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseNpgsql(connectionString);
            optionsBuilder.UseLowerCaseNamingConvention();
            _context = new PostgresSecurityContext(optionsBuilder.Options);

            _transaction = new TransactionScope();
        }

        [TearDown]
        public void Teardown()
        {
            _transaction.Dispose();
        }

        [Test]
        public void Given_configured_for_Postgres_then_create_PostgresSecurityContext_make_a_change_and_save_it()
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
        public class When_creating_a_claimset : PostgreSQLSecurityContextFactoryTests
        {
            private const string claimSetName = "ClaimSet";
        
            [Test]
            public void Should_create_claimSet()
            {
                var testClaimSet = new ClaimSet()
                {
                    ClaimSetName = claimSetName,
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
                string resourceName = "ResourceClaimDisplayNameTest";
                string claimName = "http://ed-fi.org/ods/identity/claims/domains/" + resourceName;
        
                var testResourceClaim = new ResourceClaim()
                {
                    ResourceName = resourceName,
                    ClaimName = claimName,
                };
        
                //Arrange
                _context.ResourceClaims.Add(testResourceClaim);
                _context.SaveChangesForTest();
        
                //Act
                var resourceClaimSetFromDb = _context.ResourceClaims.Where(v => v.ResourceName == resourceName).Single();
        
                //Assert
                resourceClaimSetFromDb.ShouldNotBeNull();
            }
        }
    }
}