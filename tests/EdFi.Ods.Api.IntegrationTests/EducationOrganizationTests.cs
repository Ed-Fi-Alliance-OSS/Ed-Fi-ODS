using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Api.IntegrationTests
{
    [TestFixture]
    public class EducationOrganizationTests
    {
        [Test]
        public async Task InsertAndDeleteSingleEducationOrganization()
        {
            var educationOrganizations = new List<(int, string)>
            {
                (99990000, "LocalEducationAgency"),
            };

            var expectedEducationOrganizationIdToToEducationOrganizationId = new List<(int, int)> {(99990000, 99990000)};

            (await EducationOrganizationHelper.InsertEducationOrganizations(educationOrganizations)).ShouldBe(
                educationOrganizations.Count);

            expectedEducationOrganizationIdToToEducationOrganizationId.ForEach(
                async x =>
                {
                    (await EducationOrganizationHelper.QueryEducationOrganizationIdToToEducationOrganizationId(x)).ShouldBeTrue();
                });

            (await EducationOrganizationHelper.DeleteEducationOrganizations(educationOrganizations.Select(x => x.Item1).ToList()))
                .ShouldBe(educationOrganizations.Count);
        }

        [Test]
        public async Task InsertAndDeleteMultipleEducationOrganizations()
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

            (await EducationOrganizationHelper.InsertEducationOrganizations(educationOrganizations))
                .ShouldBe(educationOrganizations.Count);

            expectedEducationOrganizationIdToToEducationOrganizationId.ForEach(
                async x => (await EducationOrganizationHelper.QueryEducationOrganizationIdToToEducationOrganizationId(x))
                    .ShouldBeTrue());

            (await EducationOrganizationHelper.DeleteEducationOrganizations(educationOrganizations.Select(x => x.Item1).ToList()))
                .ShouldBe(educationOrganizations.Count);
        }
    }
}
