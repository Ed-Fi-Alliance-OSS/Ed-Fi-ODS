using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Api.IntegrationTests
{
    [TestFixture]
    public class EducationOrganizationTests
    {
        [Test]
        public void InsertAndDeleteSingleEducationOrganization()
        {
            const int EducationOrganizationId = 99990000;

            var insertText = @$"
                INSERT INTO edfi.EducationOrganization (
                    EducationOrganizationId,
                    NameOfInstitution,
                    ShortNameOfInstitution,
                    WebSite,
                    Discriminator)
                VALUES (
                     {EducationOrganizationId},
                    '{EducationOrganizationId}NameOfInstitution',
                    '{EducationOrganizationId}ShortNameOfInstitution',
                    '{EducationOrganizationId}WebSite',
                    'edfi.LocalEducationAgency')";

            using var connection = new SqlConnection(OneTimeGlobalDatabaseSetup.ConnectionString);
            connection.Open();

            using var insertCommand = new SqlCommand(insertText, connection);
            insertCommand.ExecuteNonQuery();

            var queryText = @$"
                SELECT 1 WHERE EXISTS (
                    SELECT *
                    FROM auth.EducationOrganizationIdToEducationOrganizationId
                    WHERE SourceEducationOrganizationId = {EducationOrganizationId}
                        AND TargetEducationOrganizationId = {EducationOrganizationId})";

            using var queryCommand = new SqlCommand(queryText, connection);
            var insertResult = queryCommand.ExecuteScalar();

            insertResult.ShouldBe(1);

            var deleteText = @$"
                DELETE FROM edfi.EducationOrganization
                WHERE EducationOrganizationId = {EducationOrganizationId}";

            using var deleteCommand = new SqlCommand(deleteText, connection);
            deleteCommand.ExecuteNonQuery();

            var deleteResult = queryCommand.ExecuteScalar();

            deleteResult.ShouldBeNull();
        }

        [Test]
        public void InsertAndDeleteMultipleEducationOrganizations()
        {
            var educationOrganizations = new List<(int, string)>
            {
                (99990000, "LocalEducationAgency"),
                (99990001, "LocalEducationAgency"),
                (99990002, "LocalEducationAgency")
            };

            var expectedEducationOrganizationIdToToEducationOrganizationId = new List<(int, int)>
            {
                (99990000, 99990000),
                (99990001, 99990001),
                (99990002, 99990002)
            };

            EducationOrganizationHelper.InsertEducationOrganizations(educationOrganizations).ShouldBe(educationOrganizations.Count);

            expectedEducationOrganizationIdToToEducationOrganizationId.ForEach(
                x =>
                {
                    EducationOrganizationHelper.QueryEducationOrganizationIdToToEducationOrganizationId(x).ShouldBeTrue();
                });

            EducationOrganizationHelper.DeleteEducationOrganizations(educationOrganizations.Select(x => x.Item1).ToList()).ShouldBe(educationOrganizations.Count);
        }
    }
}
