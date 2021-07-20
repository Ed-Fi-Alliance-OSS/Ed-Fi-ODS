using NUnit.Framework;

namespace EdFi.Ods.Api.IntegrationTests
{
    [TestFixture]
    public class SchoolTests : DatabaseTestFixtureBase
    {
        [Test]
        public void When_inserting_and_deleting_school_without_local_education_agency_should_update_tuples()
        {
            Builder
                .AddSchool(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001));

            Builder
                .DeleteEducationOrganization(9001)
                .Execute();

            EducationOrganizationHelper.ShouldNotContainTuples(Connection, (9001, 9001));
        }

        [Test]
        public void When_inserting_and_deleting_school_with_local_education_agency_should_update_tuples()
        {
            Builder
                .AddLocalEducationAgency(900)
                .AddSchool(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001), (900, 9001));

            Builder
                .DeleteEducationOrganization(9001)
                .Execute();

            EducationOrganizationHelper.ShouldNotContainTuples(Connection, (9001, 9001), (900, 9001));
        }

        [Test]
        public void When_updating_school_without_local_education_agency_to_with_local_education_agency_should_update_tuples()
        {
            Builder
                .AddLocalEducationAgency(900)
                .AddSchool(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001));

            Builder
                .UpdateSchool(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001), (900, 9001));
        }

        [Test]
        public void When_updating_school_with_local_education_agency_to_without_local_education_agency_should_update_tuples()
        {
            Builder
                .AddLocalEducationAgency(900)
                .AddSchool(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001), (900, 9001));

            var expectedTuples = new[] { (9001, 9001), (900, 9001) };

            Builder
                .UpdateSchool(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001));
            EducationOrganizationHelper.ShouldNotContainTuples(Connection, (900, 9001));
        }
    }
}
