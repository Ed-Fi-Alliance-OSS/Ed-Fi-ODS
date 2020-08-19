// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Data.SqlClient;
using System.Globalization;

namespace EdFi.Ods.WebService.Tests.AuthorizationTests
{
    public class DataSeedHelper
    {
        private readonly string _databaseName;

        public DataSeedHelper(string databaseName)
        {
            _databaseName = databaseName;
        }

        public static string RandomName
        {
            get { return DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture); }
        }

        public void CreateStateEducationAgency(int stateEducationAgencyId, string nameOfInstitution = null)
        {
            ExecuteCommand(
                $"insert into edfi.EducationOrganization(EducationOrganizationId, NameOfInstitution, Id, Discriminator) values({stateEducationAgencyId},'{nameOfInstitution ?? "State-" + stateEducationAgencyId}', newid(), 'edfi.StateEducationAgency')");

            ExecuteCommand($"insert into edfi.StateEducationAgency(StateEducationAgencyId) select {stateEducationAgencyId}");
        }

        public void CreateLocalEducationAgency(int localEducationAgencyId, int stateEducationAgencyId, string nameOfInstitution = null)
        {
            ExecuteCommand(
                $"insert into edfi.EducationOrganization(EducationOrganizationId, NameOfInstitution, Id, Discriminator) values({localEducationAgencyId}, '{nameOfInstitution ?? "LEA-" + localEducationAgencyId}', newid(), 'edfi.LocalEducationAgency')");

            ExecuteCommand(
                $"insert into edfi.LocalEducationAgency (LocalEducationAgencyId, LocalEducationAgencyCategoryDescriptorId, StateEducationAgencyId) values ({localEducationAgencyId}, (SELECT TOP 1 LocalEducationAgencyCategoryDescriptorId FROM [edfi].[LocalEducationAgencyCategoryDescriptor]), {stateEducationAgencyId})");
        }

        public void CreateSchool(int schoolId, int leaId, string nameOfInstitution = null)
        {
            ExecuteCommand(
                $"insert into edfi.EducationOrganization(EducationOrganizationId, NameOfInstitution, Id, Discriminator) values({schoolId}, '{nameOfInstitution ?? "SCH-" + schoolId}', newid(), 'edfi.School')");

            ExecuteCommand($"insert into edfi.School (SchoolId, LocalEducationAgencyId) values ({schoolId}, {leaId})");
        }

        private void ExecuteCommand(string s)
        {
            var connectionString = new SqlConnectionStringBuilder
                                   {
                                       DataSource = "localhost", InitialCatalog = _databaseName, IntegratedSecurity = true
                                   };

            using (var conn = new SqlConnection(connectionString.ConnectionString))
            {
                conn.Open();

                var command = new SqlCommand(s, conn);
                command.ExecuteNonQuery();
            }
        }
    }
}
