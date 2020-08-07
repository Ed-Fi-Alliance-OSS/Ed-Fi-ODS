// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Entity;
using System.Linq;
using EdFi.Admin.DataAccess;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Utils;
using EdFi.Ods.Admin.Services;
using EdFi.Ods.Common.Configuration;
using FakeItEasy;
using NCrunch.Framework;
using NUnit.Framework;
using Shouldly;
using Test.Common;

// ReSharper disable InconsistentNaming

namespace EdFi.Ods.Admin.Tests.Services
{
    public class DefaultApplicationCreatorTests
    {
        [TestFixture]
        [ExclusivelyUses(TestSingletons.EmptyAdminDatabase)]
        public class When_default_application_does_not_exist_for_vendor_and_sandbox_type : UserContextTestBase
        {
            private const string _defaultApplicationName = "Default Sandbox Application";
            private const string _defaultClaimSet = "Default ClaimSet";
            private const string _defaultOperationalContextUri = "uri://ed-fi-api-host.org";

            private Application _createdApplication;
            private Application _loadedApplication;

            private string _vendorName;
            private int _leaId;

            [OneTimeSetUp]
            public new void Setup()
            {
                _vendorName = $"{DateTime.Now.Ticks}_TestData";
                _leaId = int.MaxValue - 1;

                DeleteApplicationEducationOrganization(_leaId);
                DeleteVendor(_vendorName);

                var leaQuery = Stub<ITemplateDatabaseLeaQuery>();

                A.CallTo(() => leaQuery.GetLocalEducationAgencyIds(A<string>._))
                    .Returns(
                        new[] {_leaId});

                var configValueProvider = Stub<IConfigValueProvider>();

                A.CallTo(() => configValueProvider.GetValue("DefaultApplicationName"))
                    .Returns(_defaultApplicationName);

                A.CallTo(() => configValueProvider.GetValue("DefaultClaimSetName"))
                    .Returns(_defaultClaimSet);

                A.CallTo(() => configValueProvider.GetValue("DefaultOperationalContextUri"))
                    .Returns(_defaultOperationalContextUri);

                var usersContextFactory = Stub<IUsersContextFactory>();

                A.CallTo(() => usersContextFactory.CreateContext())
                    .Returns(new SqlServerUsersContext());

                using (var context = new SqlServerUsersContext())
                {
                    var vendor = new Vendor {VendorName = _vendorName};

                    context.Vendors.Add(vendor);
                    context.SaveChanges();

                    var creator = new DefaultApplicationCreator(usersContextFactory, configValueProvider);

                    _createdApplication =
                        creator.FindOrCreateUpdatedDefaultSandboxApplication(vendor.VendorId, SandboxType.Sample);

                    context.SaveChanges();

                    _loadedApplication =
                        context.Applications.Where(
                                a => a.ApplicationName == _createdApplication.ApplicationName &&
                                     a.Vendor.VendorName == _vendorName)
                            .Include(x => x.ApplicationEducationOrganizations)
                            .Single();
                }
            }

            [OneTimeTearDown]
            public new void TearDown()
            {
                DeleteApplicationEducationOrganization(_leaId);
                DeleteApplication(_createdApplication.ApplicationName);
                DeleteVendor(_vendorName);
            }

            [Test]
            public void Should_associate_application_with_vendor()
            {
                _createdApplication.Vendor.VendorName.ShouldBe(_vendorName);
            }

            [Test]
            public void Should_associate_with_default_claimset()
            {
                _createdApplication.ClaimSetName.ShouldBe(_defaultClaimSet);
            }

            [Test]
            public void Should_create_default_application()
            {
                _createdApplication.ApplicationName.ShouldBe(_defaultApplicationName + " Sample");
            }
        }

        [TestFixture]
        [ExclusivelyUses(TestSingletons.EmptyAdminDatabase)]
        public class
            When_default_application_exists_for_vendor_and_sandbox_type_and_application_is_missing_an_LEA_association :
                UserContextTestBase
        {
            private const string _defaultApplicationName = "Default Sandbox Application";
            private const string _defaultClaimSet = "Default ClaimSet";
            private const string _defaultOperationalContextUri = "uri://ed-fi-api-host.org";

            private Application _loadedApplication;
            private Application _foundApplication;
            private Application[] _applications;

            private string vendorName;
            private int leaId1;
            private int leaId2;

            [OneTimeSetUp]
            public new void Setup()
            {
                vendorName = string.Format("{0}_TestData", DateTime.Now.Ticks);
                leaId1 = int.MaxValue - 1;
                leaId2 = int.MaxValue - 2;

                DeleteApplicationEducationOrganization(leaId1);
                DeleteApplicationEducationOrganization(leaId2);
                DeleteVendor(vendorName);

                var leaQuery = Stub<ITemplateDatabaseLeaQuery>();

                A.CallTo(() => leaQuery.GetLocalEducationAgencyIds(A<string>._))
                    .Returns(
                        new[]
                        {
                            leaId1,
                            leaId2
                        });

                var configValueProvider = Stub<IConfigValueProvider>();

                A.CallTo(() => configValueProvider.GetValue("DefaultApplicationName"))
                    .Returns(_defaultApplicationName);

                A.CallTo(() => configValueProvider.GetValue("DefaultClaimSetName"))
                    .Returns(_defaultClaimSet);

                A.CallTo(() => configValueProvider.GetValue("DefaultOperationalContextUri"))
                    .Returns(_defaultOperationalContextUri);

                var usersContextFactory = Stub<IUsersContextFactory>();

                A.CallTo(() => usersContextFactory.CreateContext())
                    .Returns(new SqlServerUsersContext());

                using (var context = new SqlServerUsersContext())
                {
                    var vendor = new Vendor {VendorName = vendorName};

                    var application = vendor.CreateApplication(_defaultApplicationName + " Sample", _defaultClaimSet);
                    application.CreateApplicationEducationOrganization(leaId1);
                    application.OperationalContextUri = _defaultOperationalContextUri;
                    context.Vendors.Add(vendor);
                    context.SaveChanges();

                    var creator = new DefaultApplicationCreator(usersContextFactory, configValueProvider);
                    _foundApplication = creator.FindOrCreateUpdatedDefaultSandboxApplication(vendor.VendorId, SandboxType.Sample);
                    context.SaveChanges();

                    _applications = context.Applications.Where(a => a.Vendor.VendorName == vendorName)
                        .Include(x => x.ApplicationEducationOrganizations)
                        .ToArray();

                    _loadedApplication = _applications.FirstOrDefault();
                }
            }

            [OneTimeTearDown]
            public new void TearDown()
            {
                DeleteApplicationEducationOrganization(leaId1);
                DeleteApplicationEducationOrganization(leaId2);
                DeleteApplication(_foundApplication.ApplicationName);
                DeleteVendor(vendorName);
            }

            [Test]
            public void Should_find_existing_default_application()
            {
                _applications.Length.ShouldBe(1);

                _foundApplication.ShouldNotBeNull();
                _foundApplication.ApplicationName.ShouldBe(_defaultApplicationName + " Sample");
                _foundApplication.Vendor.VendorName.ShouldBe(vendorName);
            }
        }
    }
}
