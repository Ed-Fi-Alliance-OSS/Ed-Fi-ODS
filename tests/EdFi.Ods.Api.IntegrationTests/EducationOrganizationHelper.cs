using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EdFi.Ods.Entities.NHibernate.CommunityOrganizationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CommunityProviderAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationServiceCenterAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.LocalEducationAgencyAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.OrganizationDepartmentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SchoolAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StateEducationAgencyAggregate.EdFi;
using Shouldly;

namespace EdFi.Ods.Api.IntegrationTests
{
    public static class EducationOrganizationHelper
    {
        public static List<(int, int)> GetExistingTuples(IDbConnection connection)
        {
            var sql = @"
                SELECT SourceEducationOrganizationId, TargetEducationOrganizationId
                FROM auth.EducationOrganizationIdToEducationOrganizationId;";

            using var command = connection.CreateCommand();
            command.CommandText = sql;

            using var reader = command.ExecuteReader();

            var actualTuples = new List<(int, int)>();
            while (reader.Read())
            {
                actualTuples.Add((reader.GetInt32(0), reader.GetInt32(1)));
            }

            return actualTuples;
        }

        public static void ShouldContainTuples(IDbConnection connection, params (int, int)[] expectedTuples)
        {
            var actualTuples = GetExistingTuples(connection);
            expectedTuples.ShouldBeSubsetOf(actualTuples);
        }

        public static void ShouldNotContainTuples(IDbConnection connection, params (int, int)[] expectedTuples)
        {
            var actualTuples = GetExistingTuples(connection);
            expectedTuples.ShouldAllBe(item => !actualTuples.Contains(item));
        }

        public static bool QueryEducationOrganizationIdToToEducationOrganizationId(IDbConnection connection, (int, int) sourceTargetTuple)
        {
            (int source, int target) = sourceTargetTuple;

            var sql = @$"
                SELECT COUNT(*)
                FROM auth.EducationOrganizationIdToEducationOrganizationId
                WHERE SourceEducationOrganizationId = {source} AND TargetEducationOrganizationId = {target};";

            using var command = connection.CreateCommand();
            command.CommandText = sql;
            return 1 == Convert.ToInt32(command.ExecuteScalar());
        }
    }

    public class EducationOrganizationTestDataBuilder
    {
        private IDbConnection Connection { get; set; }
        private readonly StringBuilder _sql = new StringBuilder();
        public int TestLocalEducationAgencyCategoryDescriptorId { get; private set; }
        public int TestProviderStatusDescriptorId { get; private set; }
        public int TestProviderCategoryDescriptorId { get; private set; }

        private EducationOrganizationTestDataBuilder()
        {
        }

        public static EducationOrganizationTestDataBuilder Initialize(IDbConnection connection)
        {
            var builder = new EducationOrganizationTestDataBuilder { Connection = connection };


            using var command = connection.CreateCommand();
            command.CommandText = "SELECT LocalEducationAgencyCategoryDescriptorId FROM edfi.LocalEducationAgencyCategoryDescriptor;";
            builder.TestLocalEducationAgencyCategoryDescriptorId = (int) command.ExecuteScalar();

            command.CommandText = "SELECT ProviderStatusDescriptorId FROM edfi.ProviderStatusDescriptor;";
            builder.TestProviderStatusDescriptorId = (int)command.ExecuteScalar();

            command.CommandText = "SELECT ProviderCategoryDescriptorId FROM edfi.ProviderCategoryDescriptor;";
            builder.TestProviderCategoryDescriptorId = (int)command.ExecuteScalar();

            return builder;
        }

        protected EducationOrganizationTestDataBuilder AddEducationOrganization(int educationOrganizationId, string educationOrganizationType)
        {
            _sql.AppendLine(
                $@"INSERT INTO edfi.EducationOrganization (
                    EducationOrganizationId,
                    NameOfInstitution,
                    Discriminator)
                VALUES (
                    {educationOrganizationId},
                    '{educationOrganizationId}NameOfInstitution',
                    'edfi.{educationOrganizationType}');"
                );

            return this;
        }

        public EducationOrganizationTestDataBuilder DeleteEducationOrganization(int educationOrganizationId)
        {
            _sql.AppendLine($"DELETE FROM edfi.EducationOrganization WHERE EducationOrganizationId = {educationOrganizationId};");

            return this;
        }

        public EducationOrganizationTestDataBuilder AddStateEducationAgency(int stateEducationAgencyId)
        {
            // Nameof usage is intentional here, by creating a dependency on generated entities
            // this ensures compilation errors if the organization subtype is removed
            AddEducationOrganization(stateEducationAgencyId, nameof(StateEducationAgency));

            _sql.AppendLine(
                $@"INSERT INTO edfi.StateEducationAgency (
                    StateEducationAgencyId)
                VALUES (
                    {stateEducationAgencyId});"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder AddEducationServiceCenter(int educationServiceCenterId, int? stateEducationAgencyId = null)
        {
            AddEducationOrganization(educationServiceCenterId, nameof(EducationServiceCenter));

            _sql.AppendLine(
                $@"INSERT INTO edfi.EducationServiceCenter (
                    EducationServiceCenterId,
                    StateEducationAgencyId)
                VALUES (
                    {educationServiceCenterId},
                    {ToSqlValue(stateEducationAgencyId)});"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder AddLocalEducationAgency(int localEducationAgencyId, int? stateEducationAgencyId = null, int? educationServiceCenterId = null, int? parentLocalEducationAgencyId = null)
        {
            AddEducationOrganization(localEducationAgencyId, nameof(LocalEducationAgency));

            _sql.AppendLine(
                $@"INSERT INTO edfi.LocalEducationAgency (
                    LocalEducationAgencyId,
                    LocalEducationAgencyCategoryDescriptorId,
                    StateEducationAgencyId,
                    EducationServiceCenterId,
                    ParentLocalEducationAgencyId)
                VALUES (
                    {localEducationAgencyId},
                    {TestLocalEducationAgencyCategoryDescriptorId},
                    {ToSqlValue(stateEducationAgencyId)},
                    {ToSqlValue(educationServiceCenterId)},
                    {ToSqlValue(parentLocalEducationAgencyId)});"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder UpdateLocalEducationAgency(int localEducationAgencyId, int? stateEducationAgencyId = null, int? educationServiceCenterId = null, int? parentLocalEducationAgencyId = null)
        {
            _sql.AppendLine(
                $@"UPDATE edfi.LocalEducationAgencyId SET
                    StateEducationAgencyId = {ToSqlValue(stateEducationAgencyId)}
                    EducationServiceCenterId = {ToSqlValue(educationServiceCenterId)}
                    ParentLocalEducationAgencyId = {ToSqlValue(parentLocalEducationAgencyId)}
                WHERE LocalEducationAgencyId = {localEducationAgencyId};"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder AddSchool(int schoolId, int? localEducationAgencyId = null)
        {
            AddEducationOrganization(schoolId, nameof(School));

            _sql.AppendLine(
                $@"INSERT INTO edfi.School (
                    SchoolId,
                    LocalEducationAgencyId)
                VALUES (
                    {schoolId},
                    {ToSqlValue(localEducationAgencyId)});"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder UpdateSchool(int schoolId, int? localEducationAgencyId = null)
        {
            _sql.AppendLine(
                $@"UPDATE edfi.School SET
                    LocalEducationAgencyId = {ToSqlValue(localEducationAgencyId)}
                WHERE SchoolId = {schoolId};"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder AddOrganizationDepartment(int organizationDepartmentId, int? parentEducationOrganizationId = null)
        {
            AddEducationOrganization(organizationDepartmentId, nameof(OrganizationDepartment));

            _sql.AppendLine(
                $@"INSERT INTO edfi.OrganizationDepartment (
                    OrganizationDepartmentId,
                    ParentEducationOrganizationId)
                VALUES (
                    {organizationDepartmentId},
                    {ToSqlValue(parentEducationOrganizationId)});"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder AddCommunityOrganization(int communityOrganizationId)
        {
            AddEducationOrganization(communityOrganizationId, nameof(CommunityOrganization));

            _sql.AppendLine(
                $@"INSERT INTO edfi.CommunityOrganization (
                    CommunityOrganizationId)
                VALUES (
                    {communityOrganizationId});"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder AddCommunityProvider(int communityProviderId, int? communityOrganizationId = null)
        {
            AddEducationOrganization(communityProviderId, nameof(CommunityProvider));

            _sql.AppendLine(
                $@"INSERT INTO edfi.CommunityProvider (
                    CommunityProviderId,
                    CommunityOrganizationId,
                    ProviderStatusDescriptorId,
                    ProviderCategoryDescriptorId)
                VALUES (
                    {communityProviderId},
                    {ToSqlValue(communityOrganizationId)},
                    {TestProviderStatusDescriptorId},
                    {TestProviderCategoryDescriptorId});"
            );

            return this;
        }

        private string ToSqlValue<T>(T? input) where T : struct
        {
            return input.HasValue
                ? input.Value.ToString()
                : "null";
        }

        public int Execute()
        {
            using var command = Connection.CreateCommand();
            command.CommandText = _sql.ToString();
            var result = command.ExecuteNonQuery();

            _sql.Clear();
            return result;
        }
    }
}
