#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;
using Castle.Core;
using Castle.MicroKernel.Facilities;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.InversionOfControl
{
    /// <summary>
    /// Provides a Castle Windsor Facility that processes dependencies on
    /// <see cref="IDatabaseConnectionStringProvider"/> using naming conventions, applying 
    /// the parameter name's prefix (the text coming before "DatabaseConnectionStringProvider")
    /// as a suffix on the connection string provider's registration key.  For example, a 
    /// constructor parameter named "abcDatabaseConnectionStringProvider" will be matched 
    /// with a provider registered using the key "IDatabaseConnectionStringProvider.Abc".
    /// </summary>
    public class DatabaseConnectionStringProviderFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.ComponentModelCreated += OnComponentModelCreated;
        }

        private void OnComponentModelCreated(ComponentModel model)
        {
            // Look for dependencies on connection string providers
            var connectionStringDependencies =
                from d in model.Dependencies
                where d.DependencyKey != null
                      && d.DependencyKey.EndsWith("DatabaseConnectionStringProvider")
                      && d.TargetType == typeof(IDatabaseConnectionStringProvider)
                      && d.DependencyKey.Length > "DatabaseConnectionStringProvider".Length
                select d;

            // Configure connection string providers to use components based on conventions
            foreach (var dependency in connectionStringDependencies)
            {
                model.Parameters.Add(dependency.DependencyKey, GetRegistrationKey(dependency));
            }
        }

        private static string GetRegistrationKey(DependencyModel model)
        {
            string databaseKey =
                model.DependencyKey
                     .Replace("DatabaseConnectionStringProvider", string.Empty)
                     .ToMixedCase();

            return string.Format(
                "${{{0}.{1}}}",
                typeof(IDatabaseConnectionStringProvider).Name,
                databaseKey);
        }
    }
}
#endif