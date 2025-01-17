// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using System.Xml.Linq;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Common.Metadata.Profiles;
using EdFi.Ods.Features.Profiles;
using EdFi.TestFixture;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Features.UnitTests.Profiles
{
    public class AdminDatabaseProfileDefinitionsProviderTests
    {
        [TestFixture]
        public class WhenProfileDefinitionIsValid : TestFixtureBase
        {
            private const string ValidProfileName = "Sample-Profile-Resource-WriteOnly";
            private IProfileDefinitionsProvider? _adminDatabaseProfileDefinitionsProvider;
            public IDictionary<string, XElement>? _profileDefinitions;

            private readonly Profile ValidProfile = new()
            {
                ProfileName = ValidProfileName,
                ProfileDefinition = $"<Profile name=\"{ValidProfileName}\"><Resource name=\"School\"><WriteContentType memberSelection=\"IncludeAll\"/></Resource></Profile>"
            };

            private readonly Profile InvalidProfile = new()
            {
                ProfileName = "Invalid-Profile",
                ProfileDefinition = "Invalid xml"
            };

            private readonly Profile EmptyProfile = new()
            {
                ProfileName = "Empty-Profile",
            };

            protected override void Arrange()
            {
                var profiles = new[] { ValidProfile, InvalidProfile, EmptyProfile }.AsQueryable();

                var userContext = Stub<IUsersContext>();

                var fakeDbSet = A.Fake<DbSet<Profile>>(options => options.Implements(typeof(IQueryable<Profile>)));
                A.CallTo(() => ((IQueryable)fakeDbSet).Provider).Returns(profiles.Provider);
                A.CallTo(() => ((IQueryable)fakeDbSet).Expression).Returns(profiles.Expression);
                A.CallTo(() => ((IQueryable)fakeDbSet).ElementType).Returns(profiles.ElementType);
                A.CallTo(() => ((IEnumerable)fakeDbSet).GetEnumerator()).Returns(profiles.GetEnumerator());

                A.CallTo(() => userContext.Profiles)
                    .Returns(fakeDbSet);

                var usersContextFactory = Stub<IUsersContextFactory>();
                A.CallTo(() => usersContextFactory.CreateContext())
                    .Returns(userContext);

                var profileMetadataValidator = Stub<IProfileMetadataValidator>();
                A.CallTo(() => profileMetadataValidator.Validate(An<XDocument>.Ignored))
                    .Returns(new FluentValidation.Results.ValidationResult());

                _adminDatabaseProfileDefinitionsProvider = new AdminDatabaseProfileDefinitionsProvider(
                    usersContextFactory,
                    profileMetadataValidator);
            }

            protected override void Act()
            {
                _profileDefinitions = _adminDatabaseProfileDefinitionsProvider!.GetProfileDefinitions();
            }

            [Test]
            public void Should_contain_valid_profile_definition()
            {
                _profileDefinitions!.ShouldContainKey(ValidProfileName);
                _profileDefinitions![ValidProfileName].Name.ShouldBe("Profile");

            }

            [TestCase("Invalid-Profile", "Profile Definition is not in valid XML format")]
            public void Should_contain_invalid_messages(string profileName, string errorMessage)
            {
                var validationResult = _adminDatabaseProfileDefinitionsProvider!.ValidationResultsByMetadataStream
                    .First(x => x.Key.name == profileName).Value;

                validationResult.ShouldNotBeNull();
                validationResult.Errors[0].ErrorMessage.ShouldBe(errorMessage);
            }

            [TestCase("Invalid-Profile")]
            [TestCase("Empty-Profile")]
            public void Should_not_contain_invalid_profiles(string profileName)
            {
                _profileDefinitions!.ShouldNotContainKey(profileName);
            }
        }
    }
}
