// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using EdFi.Admin.DataAccess;
using EdFi.Admin.DataAccess.Utils;


namespace EdFi.Ods.Sandbox.Provisioners
{
    /// <summary>
    ///     Provision Sandboxes using SQL Azure
    /// </summary>
    public class AzureSandboxProvisioner : ISandboxProvisioner
    {
        protected int CommandTimeout { get; }
        private string _connectionString;
        private ObjectContext _context;

        public AzureSandboxProvisioner()
        {
            // On some systems, creating a new populated template takes longer than the 30 second default
            CommandTimeout = int.TryParse(ConfigurationManager.AppSettings["SandboxAdminSQLCommandTimeout"], out int timeout)
                ? timeout
                : 30;
        }

        protected ObjectContext ObjectContext
        {
            get
            {
                if (_context == null)
                {
                    var tmp = new DbContext("EdFi_master");
                    _connectionString = tmp.Database.Connection.ConnectionString;
                    _context = (tmp as IObjectContextAdapter).ObjectContext;

                    _context.CommandTimeout = CommandTimeout;
                }

                return _context;
            }
        }

        protected string ConnectionString
        {
            get
            {
                return _connectionString ??
                       (_connectionString = ConfigurationManager.ConnectionStrings["EdFi_master"]
                                                                .ConnectionString);
            }
        }

#region static members

        /// <summary>
        ///     Runs in a worker thread and
        /// </summary>
        public static void ResetDemoSandboxWorker(object obj = null)
        {
            SandboxStatus result;
            var prov = new AzureSandboxProvisioner();

            var tmpName = Guid.NewGuid()
                              .ToString("N");

            prov.CopySandbox(DatabaseNameBuilder.SampleDatabase, tmpName);

            // wait for successful copy of template database
            do
            {
                Thread.Sleep(new TimeSpan(0, 0, 0, 5));
                result = prov.DoGetSandboxStatus(tmpName);
            }
            while (result.Code != 0);

            if (result.Code == 0)
            {
                prov.DeleteSandbox(DatabaseNameBuilder.CodeGenDatabase);
                prov.RenameSandbox(tmpName, DatabaseNameBuilder.CodeGenDatabase);
            }
        }

#endregion

#region ISandboxProvisioner

        public void AddSandbox(string sandboxKey, SandboxType sandboxType)
        {
            switch (sandboxType)
            {
                case SandboxType.Minimal:
                    CopySandbox(DatabaseNameBuilder.MinimalDatabase, DatabaseNameBuilder.SandboxNameForKey(sandboxKey));
                    break;

                case SandboxType.Sample:
                    CopySandbox(DatabaseNameBuilder.SampleDatabase, DatabaseNameBuilder.SandboxNameForKey(sandboxKey));
                    break;

                case SandboxType.Empty:
                    CopySandbox(DatabaseNameBuilder.EmptyDatabase, DatabaseNameBuilder.SandboxNameForKey(sandboxKey));
                    break;

                default:
                    throw new Exception("Unhandled SandboxType provided");
            }
        }

        public void DeleteSandboxes(string[] deletedClientKeys)
        {
            foreach (var key in deletedClientKeys)
            {
                DeleteSandbox(DatabaseNameBuilder.SandboxNameForKey(key));
            }
        }

        public SandboxStatus GetSandboxStatus(string clientKey)
        {
            return DoGetSandboxStatus(DatabaseNameBuilder.SandboxNameForKey(clientKey));
        }

        public void ResetDemoSandbox()
        {
            ThreadPool.QueueUserWorkItem(ResetDemoSandboxWorker);
        }

#endregion

#region internal members

        protected virtual void CopySandbox(string orig, string copy)
        {
            var sql = string.Format("CREATE DATABASE [{0}] AS COPY OF [{1}];", copy, orig);
            ObjectContext.ExecuteStoreCommand(TransactionalBehavior.DoNotEnsureTransaction, sql);
        }

        protected virtual void DeleteSandbox(string sandboxName)
        {
            try
            {
                var sql = string.Format("DROP DATABASE [{0}]", sandboxName);
                ObjectContext.ExecuteStoreCommand(TransactionalBehavior.DoNotEnsureTransaction, sql);
            }
            catch (SqlException)
            {
                // either they don't have permission to delete the database 
                // or (more likely) it doesn't exist, suppress the error.
            }
        }

        protected virtual void RenameSandbox(string oldName, string newName)
        {
            var sql = string.Format("ALTER DATABASE [{0}] MODIFY Name = [{1}];", oldName, newName);
            ObjectContext.ExecuteStoreCommand(sql);
        }

        protected virtual SandboxStatus DoGetSandboxStatus(string sandboxName)
        {
            object[] parms =
            {
                new SqlParameter("@name", sandboxName)
            };

            var result = ObjectContext.ExecuteStoreQuery<SandboxStatus>(
                                           "SELECT name, state Code, state_desc Description FROM sys.databases WHERE name = @name;",
                                           parms)
                                      .FirstOrDefault();

            return result ?? SandboxStatus.ErrorStatus();
        }

        public string[] GetSandboxDatabases()
        {
            object[] parameters =
            {
                new SqlParameter("@name", DatabaseNameBuilder.SandboxNameForKey("%"))
            };

            var result = ObjectContext.ExecuteStoreQuery<string>(
                                           "SELECT name FROM sys.databases WHERE name like @name;",
                                           parameters)
                                      .ToArray();

            return result;
        }

#endregion
    }
}
