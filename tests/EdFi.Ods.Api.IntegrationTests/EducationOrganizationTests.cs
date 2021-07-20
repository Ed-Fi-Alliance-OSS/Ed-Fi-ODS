using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Api.IntegrationTests
{
    [TestFixture]
    public class EducationOrganizationTests : DatabaseTestFixtureBase
    {
        [Test]
        public void When_inserting_and_deleting_single_education_organization_should_update_tuples()
        {
            Builder
                .AddLocalEducationAgency(99990000)
                .Execute();

            var expectedTuples = new[] {(99990000, 99990000)};

            EducationOrganizationHelper.ShouldContainTuples(Connection, expectedTuples);

            Builder
                .DeleteEducationOrganization(99990000)
                .Execute();

            EducationOrganizationHelper.ShouldNotContainTuples(Connection, expectedTuples);
        }

        [Test]
        public void When_inserting_and_deleting_multiple_education_organizations_should_update_tuples()
        {
            Builder
                .AddLocalEducationAgency(99990000)
                .AddLocalEducationAgency(99990001)
                .AddLocalEducationAgency(99990002)
                .Execute();

            var expectedTuples = new[]
            {
                (99990000, 99990000),
                (99990001, 99990001),
                (99990002, 99990002)
            };
            EducationOrganizationHelper.ShouldContainTuples(Connection, expectedTuples);

            Builder
                .DeleteEducationOrganization(99990000)
                .DeleteEducationOrganization(99990001)
                .DeleteEducationOrganization(99990002)
                .Execute();

            EducationOrganizationHelper.ShouldNotContainTuples(Connection, expectedTuples);
        }
    }
}
