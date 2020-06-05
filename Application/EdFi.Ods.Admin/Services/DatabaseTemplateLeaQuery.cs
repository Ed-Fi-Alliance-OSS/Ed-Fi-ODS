// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using EdFi.Admin.DataAccess;
using EdFi.Admin.DataAccess.Utils;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Admin.Services
{
    public class DatabaseTemplateLeaQuery : IDatabaseTemplateLeaQuery
    {
        public int[] GetLocalEducationAgencyIds(SandboxType sandboxType)
        {
            switch (sandboxType)
            {
                case SandboxType.Sample:
                    return GetAllPopulatedTemplateLeaIds();
                case SandboxType.Minimal:
                    return GetAllMinimalTemplateLeaIds();
                case SandboxType.Empty:
                    return new int[0];
                default:
                    throw new Exception(string.Format("Cannot lookup LEA's for sandbox type {0}", sandboxType));
            }
        }

        public int[] GetAllMinimalTemplateLeaIds()
        {
            return GetLeasForConnectionString(DatabaseNameBuilder.MinimalDatabase);
        }

        public int[] GetAllPopulatedTemplateLeaIds()
        {
            return GetLeasForConnectionString(DatabaseNameBuilder.SampleDatabase);
        }

        private static int[] GetLeasForConnectionString(string sourceDatabaseName)
        {
            var results = new List<int>();

            string connectionString = EdFiOdsConnectionStringBuilder.GetEdFiOdsConnectionString(sourceDatabaseName);

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sql = "select LocalEducationAgencyId from edfi.LocalEducationAgency";

                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add((int) reader[0]);
                        }
                    }
                }
            }

            return results.ToArray();
        }
    }
}
