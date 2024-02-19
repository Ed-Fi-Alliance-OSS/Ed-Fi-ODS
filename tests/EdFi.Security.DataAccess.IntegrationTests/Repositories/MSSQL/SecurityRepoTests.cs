// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Models;
using EdFi.Security.DataAccess.Repositories;
using EdFi.TestFixture;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Action = EdFi.Security.DataAccess.Models.Action;

namespace EdFi.Security.DataAccess.IntegrationTests.Repositories.MSSQL
{
    [TestFixture]
    public class SecurityRepoTests
    {
        protected SqlServerSecurityContext Context;
        protected TransactionScope Transaction;

        [SetUp]
        public void Setup()
        {
            // Read settings
            var builder = new ConfigurationBuilder()
               .AddJsonFile($"appSettings.json", true, true)
               .AddJsonFile($"appSettings.development.json", true, true);

            var config = builder.Build();
            
            // Setup SQL Server
            var connectionString = config.GetConnectionString("MSSQL");

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(connectionString);
            Context = new SqlServerSecurityContext(optionsBuilder.Options);

            // Startup a transaction so we can dispose of any changes after running the tests
            Transaction = new TransactionScope();

            // Configure settings mocks
            var usersContextFactory = A.Fake<ISecurityContextFactory>();
            A.CallTo(() => usersContextFactory.CreateContext())
                .Returns(Context);

            // Create the system under test
            _securityRepo = new SecurityRepository(usersContextFactory);

            // Load a fake Action
            _testActions = new Action() 
            {
                ActionName = ActionName,
                ActionUri = "http://ed-fi.org/odsapi/actions/" + ActionName
            };
            Context.Actions.Add(_testActions);
            Context.SaveChangesForTest();
        }

        [TearDown]
        public void Teardown()
        {
            Transaction.Dispose();
        }

        private const string ActionName = "ActionTest";
        private SecurityRepository _securityRepo;
        private Action _testActions;

        [TestFixture]
        public class When_getting_actions : SecurityRepoTests
        {
            [Test]
            public void Should_get_action_by_name()
            {
                var tmpAction = _securityRepo.GetActionByName(_testActions.ActionName);
                tmpAction.ShouldNotBeNull();
                tmpAction.ActionName.ShouldBe(_testActions.ActionName);
            }

            [Test]
            public void Should_not_get_action_by_name()
            {
                var tmpAction = _securityRepo.GetActionByName(string.Empty);
                tmpAction.ShouldBeNull();
            }
        }
        
        private string _claimSetName = "ClaimSetTest" + Guid.NewGuid().ToString("N");
        private IEnumerable<ClaimSetResourceClaimAction> _result;
        
        [TestFixture]
        public class When_getting_claimsResources : SecurityRepoTests
        {
            [SetUp]
            public void Setup()
            {
                string resourceName = "ResourceNameTest" + Guid.NewGuid().ToString("N");

                //using FirstOrDefault Application because SecurityRepository.GetApplication always filter by ApplicationName == "Ed-Fi ODS API"
                var testApplication = Context.Applications.FirstOrDefault();

                //Load a fake ClaimSet
                var testClaimSet = new ClaimSet()
                {
                    ClaimSetName = _claimSetName,
                    Application = testApplication,
                    IsEdfiPreset = false,
                    ForApplicationUseOnly = true
                };
                Context.ClaimSets.Add(testClaimSet);
                Context.SaveChangesForTest();

                //Load a fake ResourceClaim
                var testResourceClaim = new ResourceClaim()
                {
                    DisplayName = resourceName,
                    ResourceName = resourceName,
                    ClaimName = "http://ed-fi.org/ods/identity/claims/domains/" + resourceName,
                    Application = testApplication
                };
                Context.ResourceClaims.Add(testResourceClaim);
                Context.SaveChangesForTest();
                
                //Load a fake ClaimSetResourceClaimActions
                var testClaimSetResourceClaimAction = new ClaimSetResourceClaimAction()
                {
                    ClaimSet = testClaimSet,
                    ResourceClaim = testResourceClaim,
                    Action = _testActions
                };
                Context.ClaimSetResourceClaimActions.Add(testClaimSetResourceClaimAction);
                Context.SaveChangesForTest();

                // Act
                // Taken from SecurityRepository, it cannot call GetResourceClaimActionAuthorizations
                // directly because whenever it tries to get Application.Value.ApplicationId internally
                // it generates a Dispose and this generates an error: Message=Cannot access a disposed context instance.
                _result = Context.ClaimSetResourceClaimActions
                    .Include(csrc => csrc.Action)
                    .Include(csrc => csrc.ClaimSet)
                    .Include(csrc => csrc.ClaimSet.Application)
                    .Include(csrc => csrc.ResourceClaim)
                    .Include(csrc => csrc.AuthorizationStrategyOverrides)
                    .ThenInclude(aso => aso.AuthorizationStrategy)
                    .Where(csrc => csrc.ResourceClaim.Application.ApplicationId.Equals(testApplication.ApplicationId))
                    .ToList();
            }

            [Test]
            public void Then_result_not_be_null()
            {
                _result.ShouldNotBeNull();
            }

            [Test]
            public void Then_result_count_of_claimSet_by_claimSetName_should_be_one()
            {
                _result.Where(x => x.ClaimSet.ClaimSetName == _claimSetName).Count().ShouldBe(1);
            }
        }
    }
}
