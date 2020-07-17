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
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Sandbox.Provisioners
{
    public abstract class SandboxProvisionerBase : ISandboxProvisioner
    {
        private readonly IConfigValueProvider _configValueProvider;
        private readonly IConfigConnectionStringsProvider _connectionStringsProvider;

        protected SandboxProvisionerBase(IConfigValueProvider configValueProvider,
            IConfigConnectionStringsProvider connectionStringsProvider)
        {
            _configValueProvider = configValueProvider;
            _connectionStringsProvider = connectionStringsProvider;

            CommandTimeout = int.TryParse(_configValueProvider.GetValue("SandboxAdminSQLCommandTimeout"), out int timeout)
                ? timeout
                : 30;

            ConnectionString = _connectionStringsProvider.GetConnectionString("EdFi_master");
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
            switch (sandboxType)
            {
                case SandboxType.Minimal:
                    await CopySandboxAsync(
                            DatabaseNameBuilder.MinimalDatabase,
                            DatabaseNameBuilder.SandboxNameForKey(sandboxKey))
                        .ConfigureAwait(false);

                    break;
                case SandboxType.Sample:
                    await CopySandboxAsync(
                            DatabaseNameBuilder.SampleDatabase,
                            DatabaseNameBuilder.SandboxNameForKey(sandboxKey))
                        .ConfigureAwait(false);

                    break;
                case SandboxType.Empty:
                    await CopySandboxAsync(
                            DatabaseNameBuilder.EmptyDatabase,
                            DatabaseNameBuilder.SandboxNameForKey(sandboxKey))
                        .ConfigureAwait(false);

                    break;
                default:
                    throw new Exception("Unhandled SandboxType provided");
            }
        }

        public async Task DeleteSandboxesAsync(params string[] deletedClientKeys)
        {
            using (var conn = CreateConnection())
            {
                foreach (string key in deletedClientKeys)
                {
                    await conn.ExecuteAsync($"DROP DATABASE IF EXISTS {DatabaseNameBuilder.SandboxNameForKey(key)};", commandTimeout: CommandTimeout)
                        .ConfigureAwait(false);
                }
            }
        }

        public abstract Task<SandboxStatus> GetSandboxStatusAsync(string clientKey);

        public async Task ResetDemoSandboxAsync()
        {
            var tmpName = Guid.NewGuid().ToString("N");
            await CopySandboxAsync(DatabaseNameBuilder.SampleDatabase, tmpName).ConfigureAwait(false);
            await DeleteSandboxesAsync(DatabaseNameBuilder.DemoSandboxDatabase).ConfigureAwait(false);
            await RenameSandboxAsync(tmpName, DatabaseNameBuilder.DemoSandboxDatabase).ConfigureAwait(false);
        }

        public abstract Task<string[]> GetSandboxDatabasesAsync();

        public abstract Task RenameSandboxAsync(string oldName, string newName);

        public abstract Task CopySandboxAsync(string originalDatabaseName, string newDatabaseName);

        protected abstract DbConnection CreateConnection();
    }
}
