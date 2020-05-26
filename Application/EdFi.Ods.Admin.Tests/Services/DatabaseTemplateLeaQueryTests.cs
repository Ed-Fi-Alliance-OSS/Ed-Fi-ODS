// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using EdFi.Admin.DataAccess;
using EdFi.Ods.Admin.Services;
using NCrunch.Framework;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Admin.Tests.Services
{
    public class DatabaseTemplateLeaQueryTests
    {
        [TestFixture]
        [ExclusivelyUses(TestSingletons.EmptyAdminDatabase)]
        public class When_template_contains_local_education_agencies
        {
            [Test]
            [Ignore("Test data is location specific")]
            public void Should_provide_some_results_for_minimal_template()
            {
                var service = new DatabaseTemplateLeaQuery();
                var results = service.GetAllMinimalTemplateLeaIds();
                var resultsViaType = service.GetLocalEducationAgencyIds(SandboxType.Minimal);

                results.ShouldBe(resultsViaType);

                //The current minimal template contains 147 rows, but we don't want to force a 
                //tighter test since this actual count would likely change from client to client.
                results.Length.ShouldBeGreaterThan(50);
            }

            [Test]
            public void Should_provide_some_results_for_populated_template()
            {
                var service = new DatabaseTemplateLeaQuery();
                var results = service.GetAllPopulatedTemplateLeaIds();
                var resultsViaType = service.GetLocalEducationAgencyIds(SandboxType.Sample);

                results.ShouldBe(resultsViaType);

                //The sample data set only contains a single LocalEducationAgency
                results.Length.ShouldBeGreaterThanOrEqualTo(1);
            }
        }
    }
}
