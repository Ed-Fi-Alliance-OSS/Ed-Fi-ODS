// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalTests.Reporters.TestFrameworks;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.WebApi.IntegrationTests.Sandbox.Controllers
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter), typeof(NUnit3Reporter))]
    public class AggregateDependencyControllerTests : AggregateDependencyControllerTestsBase
    {

        [Test]
        public async Task Should_Get_Dependencies()
        {
            var json = await Get_Dependencies();

            json.ShouldNotBeNullOrWhiteSpace();

            // fix for teamcity
            Approvals.Verify(json, s => s.Replace(@"\r\n", @"\n"));
        }

        [Test]
        public async Task Should_Get_Dependencies_GraphML()
        {
            var xml = await Get_Dependencies_GraphML();

            xml.ShouldNotBeNullOrWhiteSpace();

            // fix for teamcity
            Approvals.Verify(xml, s => s.Replace(@"\r\n", @"\n"));
        }
    }
}