using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EdFi.Ods.Api.IntegrationTests
{
    public static class EducationOrganizationHelper
    {
        public static int InsertEducationOrganizations(List<(int, string)> educationOrganizations)
        {
            var sql = new StringBuilder(
                @"INSERT INTO edfi.EducationOrganization (
                    EducationOrganizationId,
                    NameOfInstitution,
                    ShortNameOfInstitution,
                    WebSite,
                    Discriminator)
                VALUES "
            );

            sql.AppendJoin(
                ", ",
                educationOrganizations.Select(
                    x => @$"(
                     {x.Item1},
                    '{x.Item1}NameOfInstitution',
                    '{x.Item1}ShortNameOfInstitution',
                    '{x.Item1}WebSite',
                    'edfi.{x.Item2}')"
                ));

            using var connection = new SqlConnection(OneTimeGlobalDatabaseSetup.ConnectionString);
            connection.Open();

            using var command = new SqlCommand(sql.ToString(), connection);
            return command.ExecuteNonQuery();
        }

        public static bool QueryEducationOrganizationIdToToEducationOrganizationId((int, int) sourceTargetTuple)
        {
            (int source, int target) = sourceTargetTuple;

            var sql = @$"
                SELECT COUNT(*)
                FROM auth.EducationOrganizationIdToEducationOrganizationId
                WHERE SourceEducationOrganizationId = {source} AND TargetEducationOrganizationId = {target}";

            using var connection = new SqlConnection(OneTimeGlobalDatabaseSetup.ConnectionString);
            connection.Open();

            using var command = new SqlCommand(sql, connection);
            return 1 == Convert.ToInt32(command.ExecuteScalar());
        }

        public static int DeleteEducationOrganizations(List<int> educationOrganizationIds)
        {
            var sql = @$"
                DELETE FROM edfi.EducationOrganization
                WHERE EducationOrganizationId 
                    IN ({string.Join(", ", educationOrganizationIds)})";

            using var connection = new SqlConnection(OneTimeGlobalDatabaseSetup.ConnectionString);
            connection.Open();

            using var command = new SqlCommand(sql, connection);
            return command.ExecuteNonQuery();
        }
    }
}
