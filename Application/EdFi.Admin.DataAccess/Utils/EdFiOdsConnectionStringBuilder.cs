// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Configuration;
using System.Data.SqlClient;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Admin.DataAccess.Utils
{
    public class EdFiOdsConnectionStringBuilder
    {
        /// <summary>
        /// Builds the connection string to the specified ODS database.
        /// </summary>
        /// <param name="databaseName">The name of the ODS database.</param>
        /// <returns>The connection string for the specified ODS database.</returns>
        /// <exception cref="ConfigurationErrorsException">Occurs when the connection strings section doesn't have an entry for "EdFi_Ods".</exception>
        /// <seealso cref="DatabaseNameBuilder"/>
        public static string GetEdFiOdsConnectionString(string databaseName)
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings["EdFi_Ods"];

            if (connectionStringSettings == null)
            {
                throw new ConfigurationErrorsException("The connection string [EdFi_Ods] is required.");
            }

            var connectionStringBuilder =
                new SqlConnectionStringBuilder(connectionStringSettings.ConnectionString);

            connectionStringBuilder.InitialCatalog = databaseName.IsFormatString()
                ? string.Format(connectionStringBuilder.InitialCatalog, databaseName)
                : databaseName;

            var connectionString = connectionStringBuilder.ConnectionString;
            return connectionString;
        }
    }
}
