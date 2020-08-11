// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Transactions;
using EdFi.Ods.Common.Configuration;
using EdFi.TestFixture;
using Microsoft.Extensions.Configuration;
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
    }
}
