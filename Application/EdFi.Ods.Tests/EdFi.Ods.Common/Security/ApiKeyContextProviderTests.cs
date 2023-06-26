// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security;
using EdFi.TestFixture;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Security
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ApiClientContextProviderTests
    {
        public class When_setting_and_getting_the_ApiKey_context_values_individually : TestFixtureBase
        {
            private const string SuppliedApiKey = "SomeKey";
            private const string SuppliedClaimsetName = "SomeClaimset";
            private readonly int[] _suppliedEducationOrganizationIds =
            {
                1,
                2
            };
            private readonly string[] _suppliedNamespacePrefixes = { "SomeNamespacePrefix" };
            private readonly IList<string> _suppliedProfiles = new List<string>
            {
                "Profile1",
                "Profile2"
            };

            private const string SuppliedStudentIdentificationSystemDescriptor =
                "SomeStudentIdentificationSystemDescriptor";

            private readonly short _suppliedCreatorOwnershipTokenId = 1;

            private readonly short[] _suppliedOwnershipTokenIds =
            {
                1,
                2
            };

            private readonly int[] _suppliedOdsInstanceIds = 
            {
                1, 
                2
            };

            private readonly int _suppliedApiClientId = 7;

            private readonly ApiClientContext _suppliedApiClientContext = ApiClientContext.Empty;

            private string _actualApiKey;
            private string _actualClaimsetName;
            private IEnumerable<int> _actualEducationOrganizationIds;
            private IEnumerable<string> _actualNamespacePrefixes;
            private ApiClientContext _actualApiClientContext;
            private IEnumerable<string> _actualProfiles;
            private string _actualStudentIdentificationSystemDescriptor;
            private HashtableContextStorage _contextStorage;
            private short? _actualCreatorOwnershipTokenId;
            private IEnumerable<short> _actualOwnershipTokenIds;
            private IEnumerable<int> _actualOdsInstanceIds;
            private int _actualApiClientId;

            protected override void Act()
            {
                _contextStorage = new HashtableContextStorage();

                var settingProvider = new ApiClientContextProvider(_contextStorage);

                settingProvider.SetApiClientContext(
                    new ApiClientContext(
                        SuppliedApiKey,
                        SuppliedClaimsetName,
                        _suppliedEducationOrganizationIds,
                        _suppliedNamespacePrefixes,
                        _suppliedProfiles,
                        SuppliedStudentIdentificationSystemDescriptor,
                        _suppliedCreatorOwnershipTokenId,
                        _suppliedOwnershipTokenIds,
                        _suppliedOdsInstanceIds,
                        _suppliedApiClientId));

                var gettingProvider = new ApiClientContextProvider(_contextStorage);

                _actualApiKey = gettingProvider.GetApiClientContext()
                    .ApiKey;

                _actualClaimsetName = gettingProvider.GetApiClientContext()
                    .ClaimSetName;

                _actualEducationOrganizationIds = gettingProvider.GetApiClientContext()
                    .EducationOrganizationIds;

                _actualNamespacePrefixes = gettingProvider.GetApiClientContext()
                    .NamespacePrefixes;

                _actualProfiles = gettingProvider.GetApiClientContext()
                    .Profiles;

                _actualStudentIdentificationSystemDescriptor =
                    gettingProvider.GetApiClientContext().StudentIdentificationSystemDescriptor;

                _actualCreatorOwnershipTokenId = gettingProvider.GetApiClientContext().CreatorOwnershipTokenId;

                _actualOwnershipTokenIds = gettingProvider.GetApiClientContext().OwnershipTokenIds;

                _actualOdsInstanceIds = gettingProvider.GetApiClientContext().OdsInstanceIds;

                _actualApiClientId = gettingProvider.GetApiClientContext().ApiClientId;

                settingProvider.SetApiClientContext(_suppliedApiClientContext);

                _actualApiClientContext = gettingProvider.GetApiClientContext();
            }

            [Assert]
            public void Should_return_the_supplied_ApiKey()
            {
                _actualApiKey.ShouldBe(SuppliedApiKey);
            }

            [Assert]
            public void Should_return_the_supplied_claimset_name()
            {
                _actualClaimsetName.ShouldBe(SuppliedClaimsetName);
            }

            [Assert]
            public void Should_return_the_supplied_EducationOrganizationIds()
            {
                _actualEducationOrganizationIds.ShouldBe(_suppliedEducationOrganizationIds);
            }

            [Assert]
            public void Should_return_the_supplied_namespace_prefix()
            {
                _actualNamespacePrefixes.ShouldBe(_suppliedNamespacePrefixes);
            }

            [Assert]
            public virtual void Should_return_the_supplied_context_DTO()
            {
                _actualApiClientContext.ShouldBeSameAs(_suppliedApiClientContext);
            }

            [Assert]
            public virtual void Should_return_the_supplied_profiles()
            {
                _actualProfiles.ShouldBeSameAs(_suppliedProfiles);
            }

            [Assert]
            public virtual void Should_return_the_supplied_student_identification_system_descriptor()
            {
                _actualStudentIdentificationSystemDescriptor.ShouldBe(SuppliedStudentIdentificationSystemDescriptor);
            }

            [Assert]
            public void Should_make_use_of_the_supplied_context_storage()
            {
                _contextStorage.UnderlyingHashtable.Count.ShouldBeGreaterThan(0);
            }

            [Assert]
            public virtual void Should_return_the_supplied_Creator_Ownership_TokenId()
            {
                _actualCreatorOwnershipTokenId.ShouldBe(_suppliedCreatorOwnershipTokenId);
            }

            [Assert]
            public virtual void Should_return_the_supplied_Ownership_TokenIds()
            {
                _actualOwnershipTokenIds.ShouldBe(_suppliedOwnershipTokenIds);
            }

            [Assert]
            public virtual void Should_return_the_supplied_Ods_InstanceIds()
            {
                _actualOdsInstanceIds.ShouldBe(_suppliedOdsInstanceIds);
            }

            [Assert]
            public virtual void Should_return_the_supplied_ApiClientId()
            {
                _actualApiClientId.ShouldBe(_suppliedApiClientId);
            }
        }
    }
}