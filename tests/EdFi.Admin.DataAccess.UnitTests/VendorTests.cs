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
    public class VendorTests
    {
        [TestFixture]
        public class When_creating_an_application
        {
            private const string VendorName = "Foo";
            private const string ApplicationName = "MyApp";
            private const string ClaimSetName = "ClaimSet";

            private Vendor _vendor;
            private Application _application;

            [OneTimeSetUp]
            public void Setup()
            {
                _vendor = new Vendor
                          {
                              VendorName = VendorName
                          };

                _application = _vendor.CreateApplication(ApplicationName, ClaimSetName);
            }

            [Test]
            public void Should_add_application_to_vendor_collection()
            {
                var applications = _vendor.Applications.ToArray();
                applications.Length.ShouldBe(1);

                applications[0]
                   .ShouldBeSameAs(_application);
            }

            [Test]
            public void Should_set_application_name()
            {
                _application.ApplicationName.ShouldBe(ApplicationName);
            }

            [Test]
            public void Should_set_claimset_name()
            {
                _application.ClaimSetName.ShouldBe(ClaimSetName);
            }

            [Test]
            public void Should_set_vendor()
            {
                _application.Vendor.ShouldBeSameAs(_vendor);
            }
        }
    }
}
