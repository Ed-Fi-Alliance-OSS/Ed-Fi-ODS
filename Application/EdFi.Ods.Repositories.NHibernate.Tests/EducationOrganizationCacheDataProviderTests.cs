// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Security.Authorization;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Repositories.NHibernate.Tests
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixture]
    public class EducationOrganizationCacheDataProviderTests : BaseDatabaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Provider = new EducationOrganizationCacheDataProvider(SessionFactory);
        }

        private EducationOrganizationCacheDataProvider Provider { get; set; }

        [Test]
        public async Task Should_load_identifiers_for_all_education_organizations()
        {
            int expectedCount = 0;

            using (var session = SessionFactory.OpenStatelessSession())
            {
                expectedCount = session.CreateSQLQuery("SELECT Count(*) FROM edfi.\"EducationOrganization\";").UniqueResult<int>();
            }

            var results = (await Provider.GetAllEducationOrganizationIdentifiers().ConfigureAwait(true)).ToList();

            results.ShouldNotBeEmpty();
            results.Count.ShouldBe(expectedCount);
        }

        [Test]
        public void Should_load_the_identifiers_for_the_specified_education_organization()
        {
            int schoolId = 0;

            using (var session = SessionFactory.OpenStatelessSession())
            {
                schoolId = session.CreateSQLQuery("SELECT TOP 1 SchoolId FROM edfi.\"School\";").UniqueResult<int>();
            }

            var result = Provider.GetEducationOrganizationIdentifiers(schoolId);

            result.ShouldNotBeNull();
            result.EducationOrganizationId.ShouldBe(schoolId);
        }

        [Test]
        public void Should_return_identifiers_with_default_values_for_each_member()
        {
            var result = Provider.GetEducationOrganizationIdentifiers(int.MaxValue);

            result.ShouldBeNull();
        }
    }
}
