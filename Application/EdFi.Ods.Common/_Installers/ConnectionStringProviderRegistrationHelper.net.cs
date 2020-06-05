#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common._Installers.ComponentNaming;

namespace EdFi.Ods.Common._Installers
{
    /// <summary>
    /// Provides methods for registering named connection strings
    /// </summary>
    public static class ConnectionStringProviderRegistrationHelper
    {
        /// <summary>
        /// Registers the named database connection string provider with the specified database enumeration value (where the
        /// enumerated value defines the connection string name via the <see cref="ConnectionStringNameAttribute"/> class).
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration defining the database codes.</typeparam>
        /// <param name="container">The Castle Windsor container.</param>
        /// <param name="databaseCode">The enumerated value identifying the database for which the named connection string provider should be registered.</param>
        public static void RegisterNamedConnectionStringProvider<TEnum>(IWindsorContainer container, TEnum databaseCode)
        {
            string fieldName = Enum.GetName(typeof(TEnum), databaseCode);

            string connectionStringName = typeof(TEnum).GetField(fieldName)
                                                       .GetCustomAttributes(typeof(ConnectionStringNameAttribute), false)
                                                       .Cast<ConnectionStringNameAttribute>()
                                                       .Select(x => x.ConnectionStringName)
                                                       .SingleOrDefault();

            if (connectionStringName == null)
            {
                throw new ArgumentException(
                    "The enumerated database value supplied does not have a ConnectionStringName attribute applied, and no connection string name was supplied.  Use the other overload, or define the attribute on the enumerated value.",
                    "databaseCode");
            }

            RegisterNamedConnectionStringProvider(container, databaseCode, connectionStringName);
        }

        /// <summary>
        /// Registers the named database connection string provider with the specified database enumeration value
        /// and connection string name.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration defining the database codes.</typeparam>
        /// <param name="container">The Castle Windsor container.</param>
        /// <param name="databaseCode">The enumerated value identifying the database for which the named connection string provider should be registered.</param>
        /// <param name="connectionStringName">The name of the configured connection string.</param>
        public static void RegisterNamedConnectionStringProvider<TEnum>(
            IWindsorContainer container,
            TEnum databaseCode,
            string connectionStringName)
        {
            container.Register(
                Component
                   .For<IDatabaseConnectionStringProvider>()
                   .NamedForDatabase(databaseCode)
                   .ImplementedBy<NamedDatabaseConnectionStringProvider>()
                   .DependsOn(Dependency.OnValue("connectionStringName", connectionStringName))
            );
        }
    }
}
#endif
