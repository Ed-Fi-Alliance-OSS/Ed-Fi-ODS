// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using EdFi.Admin.DataAccess.Utils;
using log4net;

namespace EdFi.Ods.Admin.Services
{
    public class EducationOrganizationsInitializer : IEducationOrganizationsInitializer
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(EducationOrganizationsInitializer));
        
        private static readonly string[] _edOrgRelatedTables = 
            {
                // NOTE: Order here is important

                // EdOrg
                "EducationOrganization",
                "EducationOrganizationAddress",
                "EducationOrganizationAddressPeriod",
                "EducationOrganizationCategory",
                "EducationOrganizationIdentificationCode",
                "EducationOrganizationInstitutionTelephone",
                "EducationOrganizationInternationalAddress",

                // SEA
                "StateEducationAgency",
                "StateEducationAgencyAccountability",
                "StateEducationAgencyFederalFunds",

                // ESC
                "EducationServiceCenter",

                // LEA
                "LocalEducationAgency",
                "LocalEducationAgencyAccountability",
                "LocalEducationAgencyFederalFunds",

                // School
                "School",
                "SchoolCategory",
                "SchoolGradeLevel",

                // Community Organization
                "CommunityOrganization",

                // Community Provider
                "CommunityProvider",

                // Post Secondary Institution
                "PostSecondaryInstitution",
                "PostSecondaryInstitutionMediumOfInstruction",

                // Education Organization Network
                "EducationOrganizationNetwork",
            };

        public void EnsureMinimalTemplateEducationOrganizationsInitialized()
        {
            string minimalTemplateDatabaseName = DatabaseNameBuilder.MinimalDatabase;
            string sampleTemplateDatabaseName = DatabaseNameBuilder.SampleDatabase;

            string connectionString = EdFiOdsConnectionStringBuilder.GetEdFiOdsConnectionString(minimalTemplateDatabaseName);

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var countSql = "SELECT COUNT(1) FROM edfi.EducationOrganization";

                using (var command = new SqlCommand(countSql, connection))
                {
                    var result = (int) command.ExecuteScalar();

                    // Do some education organizations already exist in the minimal template?
                    if (result > 0)
                    {
                        // Leave the minimal template alone
                        _logger.Info($"Minimal template database already has education organizations. No initialization will be performed.");

                        return;
                    }
                }

                _logger.Info($"Initializing minimal template database with education organizations from the populated sample template database.");

                var insertOperations = _edOrgRelatedTables
                    .Select(
                        tableName => new 
                        {
                            TableName = tableName,
                            InsertSQL = $@"
                                INSERT INTO {minimalTemplateDatabaseName}.edfi.{tableName} 
                                SELECT * FROM {sampleTemplateDatabaseName}.edfi.{tableName}"
                        }
                    )
                    .ToArray();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var insertOperation in insertOperations)
                        {
                            var columnNames = new List<string>();

                            var columnsQuery =
                                $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'edfi' AND TABLE_NAME = '{insertOperation.TableName}'";

                            using (var command = new SqlCommand(columnsQuery, connection, transaction))
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        columnNames.Add(reader.GetString(0));
                                    }
                                }

                                var insertQuery = insertOperation.InsertSQL.Replace("*", string.Join(",", columnNames));

                                columnNames.Where(c => c.EndsWith("DescriptorId")).ToList().ForEach(
                                    descriptorColumnName =>
                                    {
                                        var selectSubquery =
                                            $@"(SELECT DescriptorId FROM {minimalTemplateDatabaseName}.edfi.Descriptor 
                                                    WHERE Namespace = (SELECT Namespace FROM {sampleTemplateDatabaseName}.edfi.Descriptor WHERE DescriptorId = {descriptorColumnName}) AND
                                                          CodeValue = (SELECT CodeValue FROM {sampleTemplateDatabaseName}.edfi.Descriptor WHERE DescriptorId = {descriptorColumnName})) {descriptorColumnName}";

                                        insertQuery = insertQuery.Replace(descriptorColumnName, selectSubquery);
                                    });

                                command.CommandText = insertQuery;

                                int recordsAffected = command.ExecuteNonQuery();

                                _logger.Debug($"edfi.{insertOperation.TableName}: {recordsAffected} record(s) copied.");
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        // Rollback transaction, but don't allow a secondary exception occurring during rollback to replace original exception
                        try
                        {
                            transaction.Rollback();
                        }
                        catch { }

                        throw;
                    }
                }
            }
        }
    }
}
