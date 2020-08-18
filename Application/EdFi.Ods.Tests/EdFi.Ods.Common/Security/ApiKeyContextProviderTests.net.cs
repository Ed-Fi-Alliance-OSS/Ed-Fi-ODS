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
    public class ApiKeyContextProviderTests
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
            
            private readonly short?[] _suppliedOwnershipTokenIds =
            {
                1,
                2
            };

            private readonly ApiKeyContext _suppliedApiKeyContext = ApiKeyContext.Empty;

            private string _actualApiKey;
            private string _actualClaimsetName;
            private IEnumerable<int> _actualEducationOrganizationIds;
            private IEnumerable<string> _actualNamespacePrefixes;
            private ApiKeyContext _actualApiKeyContext;
            private IEnumerable<string> _actualProfiles;
            private string _actualStudentIdentificationSystemDescriptor;
            private HashtableContextStorage _contextStorage;
            private short? _actualCreatorOwnershipTokenId;
            private IEnumerable<short?> _actualOwnershipTokenIds;

            protected override void Act()
            {
                _contextStorage = new HashtableContextStorage();

                var settingProvider = new ApiKeyContextProvider(_contextStorage);

                settingProvider.SetApiKeyContext(
                    new ApiKeyContext(
                        SuppliedApiKey,
                        SuppliedClaimsetName,
                        _suppliedEducationOrganizationIds,
                        _suppliedNamespacePrefixes,
                        _suppliedProfiles,
                        SuppliedStudentIdentificationSystemDescriptor,
                        _suppliedCreatorOwnershipTokenId,
                        _suppliedOwnershipTokenIds));

                var gettingProvider = new ApiKeyContextProvider(_contextStorage);

                _actualApiKey = gettingProvider.GetApiKeyContext()
                    .ApiKey;

                _actualClaimsetName = gettingProvider.GetApiKeyContext()
                    .ClaimSetName;

                _actualEducationOrganizationIds = gettingProvider.GetApiKeyContext()
                    .EducationOrganizationIds;

                _actualNamespacePrefixes = gettingProvider.GetApiKeyContext()
                    .NamespacePrefixes;

                _actualProfiles = gettingProvider.GetApiKeyContext()
                    .Profiles;

                _actualStudentIdentificationSystemDescriptor =
                    gettingProvider.GetApiKeyContext().StudentIdentificationSystemDescriptor;

                _actualCreatorOwnershipTokenId = gettingProvider.GetApiKeyContext().CreatorOwnershipTokenId;

                _actualOwnershipTokenIds = gettingProvider.GetApiKeyContext().OwnershipTokenIds;

                settingProvider.SetApiKeyContext(_suppliedApiKeyContext);

                _actualApiKeyContext = gettingProvider.GetApiKeyContext();
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
                _actualApiKeyContext.ShouldBeSameAs(_suppliedApiKeyContext);
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
        }
    }
}
