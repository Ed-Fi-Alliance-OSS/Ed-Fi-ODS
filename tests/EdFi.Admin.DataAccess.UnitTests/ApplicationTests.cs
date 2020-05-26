// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;
using EdFi.Admin.DataAccess.Models;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Admin.DataAccess.UnitTests
{
    public class ApplicationTests
    {
        [TestFixture]
        public class When_creating_an_application_local_education_agency
        {
            private Application _application;
            private ApplicationEducationOrganization _lea;

            [OneTimeSetUp]
            public void Setup()
            {
                _application = new Application
                               {
                                   ApplicationName = "Foo"
                               };

                _lea = _application.CreateEducationOrganizationAssociation(42);
            }

            [Test]
            public void Should_add_association_to_application_collection()
            {
                var leas = _application.ApplicationEducationOrganizations.ToArray();
                leas.Length.ShouldBe(1);

                leas[0]
                   .ShouldBeSameAs(_lea);
            }

            [Test]
            public void Should_set_application()
            {
                _lea.Application.ShouldBeSameAs(_application);
            }

            [Test]
            public void Should_set_lea_id()
            {
                _lea.EducationOrganizationId.ShouldBe(42);
            }
        }
    }
}
