// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Common.Extensions;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.UniqueIdIntegration
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class When_retrieving_all_the_Student_identity_value_mappings
        : TestFixtureAsyncBase
    {
        // Supplied values
        private List<PersonIdentifiersValueMap> _suppliedPersonIdentifiers;

        // Actual values
        private IEnumerable<PersonIdentifiersValueMap> _actualStudentIdentifiers;
        private IEnumerable<PersonIdentifiersValueMap> _actualStaffIdentifiers;
        private IEnumerable<PersonIdentifiersValueMap> _actualParentIdentifiers;

        // External dependencies
        private IPersonIdentifiersProvider _personIdentifiersProvider;

        protected override async Task ArrangeAsync()
        {
            _personIdentifiersProvider = Stub<IPersonIdentifiersProvider>();

            _suppliedPersonIdentifiers = new List<PersonIdentifiersValueMap>
                {
                    new PersonIdentifiersValueMap
                    {
                        UniqueId = Guid.NewGuid()
                            .ToString(),
                        Usi = 100,
                        Id = new Guid()
                    },
                    new PersonIdentifiersValueMap
                    {
                        UniqueId = Guid.NewGuid()
                            .ToString(),
                        Usi = 101,
                        Id = new Guid()
                    }
                };

            A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers("Student"))
                    .Returns(Task.FromResult((IEnumerable<PersonIdentifiersValueMap>)_suppliedPersonIdentifiers));

            A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers("Staff"))
                    .Returns(Task.FromResult((IEnumerable<PersonIdentifiersValueMap>)_suppliedPersonIdentifiers));

            A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers("Parent"))
                    .Returns(Task.FromResult((IEnumerable<PersonIdentifiersValueMap>)_suppliedPersonIdentifiers));

            string validPersonTypes = string.Join("','", PersonEntitySpecification.ValidPersonTypes)
                    .SingleQuoted();
            A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers("NonPersonType"))
                .ThrowsAsync(new AggregateException(new ArgumentException($"Invalid person type 'NonPersonType'. Valid person types are: {validPersonTypes}")));
        }

        protected override async Task ActAsync()
        {
            _actualStudentIdentifiers = await _personIdentifiersProvider.GetAllPersonIdentifiers("Student");
            _actualStaffIdentifiers = await _personIdentifiersProvider.GetAllPersonIdentifiers("Staff");
            _actualParentIdentifiers = await _personIdentifiersProvider.GetAllPersonIdentifiers("Parent");

            // This statement throws an exception
            var ignoredDueToException = await _personIdentifiersProvider.GetAllPersonIdentifiers("NonPersonType");
        }

        [Assert]
        public void Should_load_some_Student_identity_mappings()
        {
            Assert.That(_actualStudentIdentifiers, Has.Count.GreaterThan(0));
        }

        [Assert]
        public void Should_load_some_Staff_identity_mappings()
        {
            Assert.That(_actualStaffIdentifiers, Has.Count.GreaterThan(0));
        }

        [Assert]
        public void Should_load_some_Parent_identity_mappings()
        {
            Assert.That(_actualParentIdentifiers, Has.Count.GreaterThan(0));
        }

        [Assert]
        public void Should_load_USIs_and_UniqueIds_but_no_Ids_for_each_value_mapping()
        {
            var allIdentifierValueMaps = _actualStudentIdentifiers
                .Concat(_actualStaffIdentifiers)
                .Concat(_actualParentIdentifiers);

            foreach (var valueMap in allIdentifierValueMaps)
            {
                valueMap.Id.ShouldBe(new Guid());
                valueMap.Usi.ShouldBeGreaterThan(0);
                valueMap.UniqueId.Length.ShouldBeGreaterThan(0);
            }
        }

        [Assert]
        public void Should_throw_an_exception_for_an_invalid_person_type_indicating_that_the_Person_type_specified_is_invalid()
        {
            Assert.That(ActualException, Is.TypeOf<AggregateException>());

            var innerException = (ActualException as AggregateException)
                ?.Flatten()
                .InnerException;

            innerException.ShouldSatisfyAllConditions(
                    () => innerException.ShouldBeOfType<ArgumentException>(),
                    () => innerException?.Message.ShouldContain("Invalid person type"));
        }
    }
}
#endif