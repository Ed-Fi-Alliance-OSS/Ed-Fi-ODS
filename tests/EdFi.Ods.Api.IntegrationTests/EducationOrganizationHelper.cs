using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdFi.Ods.Api.IntegrationTests
{
    public static class EducationOrganizationHelper
    {
        public static async Task<int> InsertEducationOrganizations(List<(int, string)> educationOrganizations)
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

            await using var connection = new SqlConnection(OneTimeGlobalDatabaseSetup.ConnectionString);
            connection.Open();

            await using var command = new SqlCommand(sql.ToString(), connection);
            return await command.ExecuteNonQueryAsync();
        }

        public static async Task<bool> QueryEducationOrganizationIdToToEducationOrganizationId((int, int) sourceTargetTuple)
        {
            (int source, int target) = sourceTargetTuple;

            var sql = @$"
                SELECT COUNT(*)
                FROM auth.EducationOrganizationIdToEducationOrganizationId
                WHERE SourceEducationOrganizationId = {source} AND TargetEducationOrganizationId = {target}";

            await using var connection = new SqlConnection(OneTimeGlobalDatabaseSetup.ConnectionString);
            connection.Open();

            await using var command = new SqlCommand(sql, connection);
            return 1 == Convert.ToInt32(await command.ExecuteScalarAsync());
        }

        public static async Task<int> DeleteEducationOrganizations(List<int> educationOrganizationIds)
        {
            var sql = @$"
                DELETE FROM edfi.EducationOrganization
                WHERE EducationOrganizationId 
                    IN ({string.Join(", ", educationOrganizationIds)})";

            await using var connection = new SqlConnection(OneTimeGlobalDatabaseSetup.ConnectionString);
            connection.Open();

            await using var command = new SqlCommand(sql, connection);
            return await command.ExecuteNonQueryAsync();
        }
    }
}
