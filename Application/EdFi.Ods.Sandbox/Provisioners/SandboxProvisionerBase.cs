// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using EdFi.Admin.DataAccess;
using EdFi.Admin.DataAccess.Utils;
using EdFi.Common.Configuration;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;
using Microsoft.Extensions.Configuration;

namespace EdFi.Ods.Sandbox.Provisioners
{
    public abstract class SandboxProvisionerBase : ISandboxProvisioner
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigConnectionStringsProvider _connectionStringsProvider;
        protected readonly IDatabaseNameBuilder _databaseNameBuilder;

        protected SandboxProvisionerBase(IConfiguration configuration,
            IConfigConnectionStringsProvider connectionStringsProvider, IDatabaseNameBuilder databaseNameBuilder)
        {
            _configuration = configuration;
            _connectionStringsProvider = connectionStringsProvider;
            _databaseNameBuilder = databaseNameBuilder;

            CommandTimeout = int.TryParse(_configuration.GetSection("SandboxAdminSQLCommandTimeout").Value, out int timeout)
                ? timeout
                : 30;

            ConnectionString = _connectionStringsProvider.GetConnectionString("EdFi_Master");
        }

        protected int CommandTimeout { get; }

        protected string ConnectionString { get; }

        public string[] GetSandboxDatabases() => GetSandboxDatabasesAsync().GetResultSafely();

        public void AddSandbox(string sandboxKey, SandboxType sandboxType)
            => AddSandboxAsync(sandboxKey, sandboxType).WaitSafely();

        public void DeleteSandboxes(params string[] deletedClientKeys) => DeleteSandboxesAsync(deletedClientKeys).WaitSafely();

        public void RenameSandbox(string oldName, string newName) => RenameSandboxAsync(oldName, newName).WaitSafely();

        public SandboxStatus GetSandboxStatus(string clientKey) => GetSandboxStatusAsync(clientKey).GetResultSafely();

        public void ResetDemoSandbox() => ResetDemoSandboxAsync().WaitSafely();

        public async Task AddSandboxAsync(string sandboxKey, SandboxType sandboxType)
        {
            await DeleteSandboxesAsync(sandboxKey).ConfigureAwait(false);
            
            switch (sandboxType)
            {
                case SandboxType.Minimal:
                    await CopySandboxAsync(
                            _databaseNameBuilder.MinimalDatabase,
                            _databaseNameBuilder.SandboxNameForKey(sandboxKey))
                        .ConfigureAwait(false);

                    break;
                case SandboxType.Sample:
                    await CopySandboxAsync(
                            _databaseNameBuilder.SampleDatabase,
                            _databaseNameBuilder.SandboxNameForKey(sandboxKey))
                        .ConfigureAwait(false);

                    break;
                default:
                    throw new Exception("Unhandled SandboxType provided");
            }
        }

        public abstract Task DeleteSandboxesAsync(params string[] deletedClientKeys);

        public abstract Task<SandboxStatus> GetSandboxStatusAsync(string clientKey);

        public async Task ResetDemoSandboxAsync()
        {
            var tmpName = Guid.NewGuid().ToString("N");
            await CopySandboxAsync(_databaseNameBuilder.SampleDatabase, tmpName).ConfigureAwait(false);
            await DeleteSandboxesAsync(_databaseNameBuilder.DemoSandboxDatabase).ConfigureAwait(false);
            await RenameSandboxAsync(tmpName, _databaseNameBuilder.DemoSandboxDatabase).ConfigureAwait(false);
        }

        public abstract Task<string[]> GetSandboxDatabasesAsync();

        public abstract Task RenameSandboxAsync(string oldName, string newName);

        public abstract Task CopySandboxAsync(string originalDatabaseName, string newDatabaseName);

        protected abstract DbConnection CreateConnection();
    }
}