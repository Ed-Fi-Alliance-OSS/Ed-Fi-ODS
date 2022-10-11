// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Common.Configuration;
using EdFi.TestFixture;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Data.Entity;
using System.Transactions;
using EdFi.Admin.DataAccess.DbConfigurations;

namespace EdFi.Ods.Admin.DataAccess.IntegrationTests.Models
{
    public abstract class UserContextTestBase : TestFixtureBase
    {
        private TransactionScope _transaction;
        private UsersContext _userContext;

        protected DatabaseEngine TestDatabaseEngine { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var config = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile("appsettings.Development.json", true)
                .AddEnvironmentVariables()
                .Build();

            var engine = config.GetSection("ApiSettings").GetValue<string>("Engine");
            TestDatabaseEngine = DatabaseEngine.TryParseEngine(engine);

            var connectionStringProvider = new AdminDatabaseConnectionStringProvider(new ConfigConnectionStringsProvider(config));

            DbConfiguration.SetConfiguration(new DatabaseEngineDbConfiguration(TestDatabaseEngine));
            var userContextFactory = new UsersContextFactory(connectionStringProvider, TestDatabaseEngine);
            _userContext = userContextFactory.CreateContext() as UsersContext;
        }

        protected UsersContext GetUsersContextTest()
        {
            return _userContext;
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
    }
}
