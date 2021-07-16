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
            var educationOrganizations = new List<(int, string)>
            {
                (99990000, "LocalEducationAgency"),
            };

            var expectedEducationOrganizationIdToToEducationOrganizationId = new List<(int, int)>
            {
                (99990000, 99990000)
            };

            EducationOrganizationHelper.InsertEducationOrganizations(educationOrganizations).ShouldBe(educationOrganizations.Count);

            expectedEducationOrganizationIdToToEducationOrganizationId.ForEach(
                x =>
                {
                    EducationOrganizationHelper.QueryEducationOrganizationIdToToEducationOrganizationId(x).ShouldBeTrue();
                });

            EducationOrganizationHelper.DeleteEducationOrganizations(educationOrganizations.Select(x => x.Item1).ToList()).ShouldBe(educationOrganizations.Count);
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
