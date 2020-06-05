// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Api.Common.Authentication;
using EdFi.Ods.Api.Services.Authorization;
using EdFi.TestFixture;
using NUnit.Framework;
using Shouldly;

// ReSharper disable InconsistentNaming

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Authorization
{
    [TestFixture]
    public class ApiClientDetailsTests
    {

        public static void AssertIsDefaultObject(ApiClientDetails input)
        {
            input.ShouldSatisfyAllConditions(
                () => input.ApiKey.ShouldBeNull(),
                () => input.ApplicationId.ShouldBe(0),
                () => input.ClaimSetName.ShouldBeNull(),
                () => input.EducationOrganizationIds.ShouldBeEmpty(),
                () => input.IsSandboxClient.ShouldBeFalse(),
                () => input.IsTokenValid.ShouldBeFalse(),
                () => input.NamespacePrefixes.ShouldBeEmpty(),
                () => input.Profiles.ShouldBeEmpty(),
                () => input.StudentIdentificationSystemDescriptor.ShouldBeNull()
            );
        }

        [TestCase("", false)]
        [TestCase("      ", false)]
        [TestCase(null, false)]
        [TestCase("value", true)]
        public void IsTokenValid_should_depend_on_ApiKey_Value(string apiKey, bool expected)
        {
            new ApiClientDetails {ApiKey = apiKey}
                .IsTokenValid
                .ShouldBe(expected);
        }

        [TestFixture]
        public class Given_empty_list : TestFixtureBase
        {
            protected ApiClientDetails Result;

            protected override void Act()
            {
                var input = new OAuthTokenClient[0];
                Result = ApiClientDetails.Create(input);
            }

            [TestFixture]
            public class When_converting_to_ApiClientDetails : Given_empty_list
            {
                [Test]
                public void Should_return_default_object()
                {
                    Result.ShouldNotBeNull();
                    AssertIsDefaultObject(Result);
                }
            }
        }

        [TestFixture]
        public class Given_list_contains_multiple_edOrgs : TestFixtureBase
        {
            protected OAuthTokenClient Record1;
            protected OAuthTokenClient Record2;
            protected OAuthTokenClient Record3;
            protected ApiClientDetails Result;

            protected override void Arrange()
            {
                Record1 = new OAuthTokenClient
                {
                    ClaimSetName = "Disintegration",
                    EducationOrganizationId = 12,
                    Key = "is the",
                    NamespacePrefix = "best",
                    ProfileName = "album",
                    StudentIdentificationSystemDescriptor = "ever!",
                    UseSandbox = true
                };

                Record2 = new OAuthTokenClient {EducationOrganizationId = 1234};
                Record3 = new OAuthTokenClient {EducationOrganizationId = 45688};
            }

            [TestFixture]
            public class When_converting_to_ApiClientDetails : Given_list_contains_multiple_edOrgs
            {
                protected override void Act()
                {
                    var input = new[]
                    {
                        Record1,
                        Record2,
                        Record3
                    };

                    Result = ApiClientDetails.Create(input);
                }

                [Test]
                public void Should_contain_educationOrganizationId_one()
                {
                    Result.EducationOrganizationIds.ShouldContain(Record1.EducationOrganizationId.Value);
                }

                [Test]
                public void Should_contain_educationOrganizationId_three()
                {
                    Result.EducationOrganizationIds.ShouldContain(Record3.EducationOrganizationId.Value);
                }

                [Test]
                public void Should_contain_educationOrganizationId_two()
                {
                    Result.EducationOrganizationIds.ShouldContain(Record2.EducationOrganizationId.Value);
                }

                [Test]
                public void Should_contain_three_educationOrganizationIds()
                {
                    Result.ShouldNotBeNull();
                    Result.EducationOrganizationIds.Count.ShouldBe(3);
                }
            }
        }

        [TestFixture]
        public class Given_list_contains_multiple_namespacePrefixes : TestFixtureBase
        {
            protected OAuthTokenClient Record1;
            protected OAuthTokenClient Record2;
            protected OAuthTokenClient Record3;
            protected ApiClientDetails Result;

            protected override void Arrange()
            {
                Record1 = new OAuthTokenClient
                {
                    ClaimSetName = "Disintegration",
                    EducationOrganizationId = 12,
                    Key = "is the",
                    NamespacePrefix = "best",
                    ProfileName = "album",
                    StudentIdentificationSystemDescriptor = "ever!",
                    UseSandbox = true
                };

                Record2 = new OAuthTokenClient {NamespacePrefix = "1234"};
                Record3 = new OAuthTokenClient {NamespacePrefix = "45688"};
            }

            [TestFixture]
            public class When_converting_to_ApiClientDetails : Given_list_contains_multiple_namespacePrefixes
            {
                protected override void Act()
                {
                    var input = new[]
                    {
                        Record1,
                        Record2,
                        Record3
                    };

                    Result = ApiClientDetails.Create(input);
                }

                [Test]
                public void Should_contain_namespacePrefixes_one()
                {
                    Result.NamespacePrefixes.ShouldContain(Record1.NamespacePrefix);
                }

                [Test]
                public void Should_contain_namespacePrefixes_three()
                {
                    Result.NamespacePrefixes.ShouldContain(Record3.NamespacePrefix);
                }

                [Test]
                public void Should_contain_namespacePrefixes_two()
                {
                    Result.NamespacePrefixes.ShouldContain(Record2.NamespacePrefix);
                }

                [Test]
                public void Should_contain_three_namespacePrefxes()
                {
                    Result.ShouldNotBeNull();
                    Result.NamespacePrefixes.Count.ShouldBe(3);
                }
            }
        }

        [TestFixture]
        public class Given_list_contains_multiple_profileNames : TestFixtureBase
        {
            protected OAuthTokenClient Record1;
            protected OAuthTokenClient Record2;
            protected OAuthTokenClient Record3;
            protected ApiClientDetails Result;

            protected override void Arrange()
            {
                Record1 = new OAuthTokenClient
                {
                    ClaimSetName = "Disintegration",
                    EducationOrganizationId = 12,
                    Key = "is the",
                    NamespacePrefix = "best",
                    ProfileName = "album",
                    StudentIdentificationSystemDescriptor = "ever!",
                    UseSandbox = true
                };

                Record2 = new OAuthTokenClient {ProfileName = "1234"};
                Record3 = new OAuthTokenClient {ProfileName = "45688"};
            }

            [TestFixture]
            public class When_converting_to_ApiClientDetails : Given_list_contains_multiple_profileNames
            {
                protected override void Act()
                {
                    var input = new[]
                    {
                        Record1,
                        Record2,
                        Record3
                    };

                    Result = ApiClientDetails.Create(input);
                }

                [Test]
                public void Should_contain_profileNames_one()
                {
                    Result.Profiles.ShouldContain(Record1.ProfileName);
                }

                [Test]
                public void Should_contain_profileNames_three()
                {
                    Result.Profiles.ShouldContain(Record3.ProfileName);
                }

                [Test]
                public void Should_contain_profileNames_two()
                {
                    Result.Profiles.ShouldContain(Record2.ProfileName);
                }

                [Test]
                public void Should_contain_three_profileNames()
                {
                    Result.ShouldNotBeNull();
                    Result.Profiles.Count.ShouldBe(3);
                }
            }
        }

        [TestFixture]
        public class Given_list_contains_null_objects : TestFixtureBase
        {
            protected ApiClientDetails Result;

            [TestFixture]
            public class When_converting_to_ApiClientDetails : Given_list_contains_null_objects
            {
                protected override void Act()
                {
                    var input = new List<OAuthTokenClient>
                    {
                        null,
                        null
                    };

                    // Act
                    Result = ApiClientDetails.Create(input);
                }

                [Test]
                public void Should_return_default_object()
                {
                    Result.ShouldNotBeNull();
                    AssertIsDefaultObject(Result);
                }
            }
        }

        [TestFixture]
        public class Given_null_argument : TestFixtureBase
        {
            [TestFixture]
            public class When_converting_to_ApiClientDetails : Given_null_argument
            {
                protected override void Act()
                {
                    var _ = ApiClientDetails.Create(null);
                }

                [Test]
                public void Should_throw_exception()
                {
                    ActualException.ShouldBeOfType<ArgumentNullException>();
                }
            }
        }

        [TestFixture]
        public class Given_single_record_with_all_values : TestFixtureBase
        {
            protected ApiClientDetails Result;
            protected OAuthTokenClient TokenClient;

            protected override void Arrange()
            {
                TokenClient = new OAuthTokenClient
                {
                    ClaimSetName = "Disintegration",
                    EducationOrganizationId = 12,
                    Key = "is the",
                    NamespacePrefix = "best",
                    ProfileName = "album",
                    StudentIdentificationSystemDescriptor = "ever!",
                    UseSandbox = true
                };
            }

            [TestFixture]
            public class When_converting_to_ApiClientDetails : Given_single_record_with_all_values
            {
                protected override void Act()
                {
                    var input = new List<OAuthTokenClient> {TokenClient};

                    Result = ApiClientDetails.Create(input);
                }

                [Test]
                public void Should_leave_ApplicationId_with_default_value()
                {
                    Result.ApplicationId.ShouldBe(0);
                }

                [Test]
                public void Should_map_the_ApiKey()
                {
                    Result.ApiKey.ShouldBe(TokenClient.Key);
                }

                [Test]
                public void Should_map_the_ClaimSetName()
                {
                    Result.ClaimSetName.ShouldBe(TokenClient.ClaimSetName);
                }

                [Test]
                public void Should_map_the_EducationOrganizationId()
                {
                    Result.EducationOrganizationIds.ShouldHaveSingleItem().ShouldBe(TokenClient.EducationOrganizationId.Value);
                }

                [Test]
                public void Should_map_the_NamespacePrefixes()
                {
                    Result.NamespacePrefixes.ShouldHaveSingleItem().ShouldBe(TokenClient.NamespacePrefix);
                }

                [Test]
                public void Should_map_the_ProfileName()
                {
                    Result.Profiles.ShouldHaveSingleItem().ShouldBe(TokenClient.ProfileName);
                }

                [Test]
                public void Should_map_UseSandbox_to_IsSandboxClient()
                {
                    Result.IsSandboxClient.ShouldBe(TokenClient.UseSandbox);
                }
            }
        }

        [TestFixture]
        public class Given_single_record_with_no_values : TestFixtureBase
        {
            [TestFixture]
            public class When_converting_to_ApiClientDetails : Given_single_record_with_no_values
            {
                protected ApiClientDetails Result;

                protected override void Act()
                {
                    var oauthAccessTokenClient = new OAuthTokenClient();
                    var input = new[] {oauthAccessTokenClient};

                    Result = ApiClientDetails.Create(input);
                }

                [Test]
                public void Should_return_default_object()
                {
                    Result.ShouldNotBeNull();
                    AssertIsDefaultObject(Result);
                }
            }
        }

        [TestFixture]
        public class When_constructing
        {
            [Test]
            public void Should_initialize_EducationOrganizationIds_collection()
            {
                new ApiClientDetails()
                    .EducationOrganizationIds.ShouldNotBeNull();
            }

            [Test]
            public void Should_initialize_NamespacePrefixes_collection()
            {
                new ApiClientDetails()
                    .NamespacePrefixes.ShouldNotBeNull();
            }

            [Test]
            public void Should_initialize_Profiles_collection()
            {
                new ApiClientDetails()
                    .Profiles.ShouldNotBeNull();
            }
        }
    }
}
