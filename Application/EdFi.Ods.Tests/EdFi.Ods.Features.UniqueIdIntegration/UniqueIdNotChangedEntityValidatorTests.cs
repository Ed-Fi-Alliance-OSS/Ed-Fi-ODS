// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Ods.Api.Common.Models.Resources.Parent.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.Student.EdFi;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Validation;
using EdFi.Ods.Features.UniqueIdIntegration.Validation;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.UniqueIdIntegration
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class UniqueIdNotChangeEntityValidatorTests
    {
        [TestFixture]
        public class When_validating_student_resource_with_changed_unique_id : TestFixtureBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                const string uniqueId = "ABC123";

                var student = new Student
                {
                    Id = Guid.NewGuid(),
                    StudentUniqueId = uniqueId + "XYZ"
                };

                var personUniqueIdToIdCache = Stub<IPersonUniqueIdToIdCache>();
                var validator = new UniqueIdNotChangedEntityValidator(personUniqueIdToIdCache);

                A.CallTo(() => personUniqueIdToIdCache.GetUniqueId(A<string>._, A<Guid>._))
                    .Returns(uniqueId);

                var result = validator.ValidateObject(student);

                result.IsValid()
                    .ShouldBeFalse();

                result.Count.ShouldBe(1);

                result.First()
                    .ErrorMessage.ShouldBe("A person's UniqueId cannot be modified.");
            }
        }

        [TestFixture]
        public class When_validating_staff_resource_with_changed_unique_id : TestFixtureBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                const string uniqueId = "ABC123";

                var student = new Staff
                {
                    Id = Guid.NewGuid(),
                    StaffUniqueId = uniqueId + "XYZ"
                };

                var personUniqueIdToIdCache = Stub<IPersonUniqueIdToIdCache>();
                var validator = new UniqueIdNotChangedEntityValidator(personUniqueIdToIdCache);

                A.CallTo(() => personUniqueIdToIdCache.GetUniqueId(A<string>._, A<Guid>._))
                    .Returns(uniqueId);

                var result = validator.ValidateObject(student);

                result.IsValid()
                    .ShouldBeFalse();

                result.Count.ShouldBe(1);

                result.First()
                    .ErrorMessage.ShouldBe("A person's UniqueId cannot be modified.");
            }
        }

        [TestFixture]
        public class When_validating_parent_resource_with_changed_unique_id : TestFixtureBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                const string uniqueId = "ABC123";

                var student = new Parent
                {
                    Id = Guid.NewGuid(),
                    ParentUniqueId = uniqueId + "XYZ"
                };

                var personUniqueIdToIdCache = Stub<IPersonUniqueIdToIdCache>();
                var validator = new UniqueIdNotChangedEntityValidator(personUniqueIdToIdCache);

                A.CallTo(() => personUniqueIdToIdCache.GetUniqueId(A<string>._, A<Guid>._))
                    .Returns(uniqueId);

                var result = validator.ValidateObject(student);

                result.IsValid()
                    .ShouldBeFalse();

                result.Count.ShouldBe(1);

                result.First()
                    .ErrorMessage.ShouldBe("A person's UniqueId cannot be modified.");
            }
        }

        [TestFixture]
        public class When_validating_student_entity_with_changed_unique_id : TestFixtureBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                const string uniqueId = "ABC123";

                var student = new global::EdFi.Ods.Entities.NHibernate.StudentAggregate.EdFi.Student
                {
                    Id = Guid.NewGuid(),
                    StudentUniqueId = uniqueId + "XYZ"
                };

                var personUniqueIdToIdCache = Stub<IPersonUniqueIdToIdCache>();
                var validator = new UniqueIdNotChangedEntityValidator(personUniqueIdToIdCache);

                A.CallTo(() => personUniqueIdToIdCache.GetUniqueId(A<string>._, A<Guid>._))
                    .Returns(uniqueId);

                var result = validator.ValidateObject(student);

                result.IsValid()
                    .ShouldBeFalse();

                result.Count.ShouldBe(1);

                result.First()
                    .ErrorMessage.ShouldBe("A person's UniqueId cannot be modified.");
            }
        }

        [TestFixture]
        public class When_validating_staff_entity_with_changed_unique_id : TestFixtureBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                const string uniqueId = "ABC123";

                var student = new global::EdFi.Ods.Entities.NHibernate.StaffAggregate.EdFi.Staff
                {
                    Id = Guid.NewGuid(),
                    StaffUniqueId = uniqueId + "XYZ"
                };

                var personUniqueIdToIdCache = Stub<IPersonUniqueIdToIdCache>();
                var validator = new UniqueIdNotChangedEntityValidator(personUniqueIdToIdCache);

                A.CallTo(() => personUniqueIdToIdCache.GetUniqueId(A<string>._, A<Guid>._))
                    .Returns(uniqueId);

                var result = validator.ValidateObject(student);

                result.IsValid()
                    .ShouldBeFalse();

                result.Count.ShouldBe(1);

                result.First()
                    .ErrorMessage.ShouldBe("A person's UniqueId cannot be modified.");
            }
        }

        [TestFixture]
        public class When_validating_parent_entity_with_changed_unique_id : TestFixtureBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                const string uniqueId = "ABC123";

                var student = new global::EdFi.Ods.Entities.NHibernate.ParentAggregate.EdFi.Parent
                {
                    Id = Guid.NewGuid(),
                    ParentUniqueId = uniqueId + "XYZ"
                };

                var personUniqueIdToIdCache = Stub<IPersonUniqueIdToIdCache>();
                var validator = new UniqueIdNotChangedEntityValidator(personUniqueIdToIdCache);

                A.CallTo(() => personUniqueIdToIdCache.GetUniqueId(A<string>._, A<Guid>._))
                    .Returns(uniqueId);

                var result = validator.ValidateObject(student);

                result.IsValid()
                    .ShouldBeFalse();

                result.Count.ShouldBe(1);

                result.First()
                    .ErrorMessage.ShouldBe("A person's UniqueId cannot be modified.");
            }
        }

        [TestFixture]
        public class When_validating_student_resource_with_unchanged_unique_id : TestFixtureBase
        {
            [Test]
            public void Should_pass_validation()
            {
                const string uniqueId = "ABC123";

                var student = new Student
                {
                    Id = Guid.NewGuid(),
                    StudentUniqueId = uniqueId
                };

                var personUniqueIdToIdCache = Stub<IPersonUniqueIdToIdCache>();
                var validator = new UniqueIdNotChangedEntityValidator(personUniqueIdToIdCache);

                A.CallTo(() => personUniqueIdToIdCache.GetUniqueId(A<string>._, A<Guid>._))
                    .Returns(uniqueId);

                var result = validator.ValidateObject(student);

                result.IsValid()
                    .ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_validating_staff_resource_with_unchanged_unique_id : TestFixtureBase
        {
            [Test]
            public void Should_pass_validation()
            {
                const string uniqueId = "ABC123";

                var student = new Staff
                {
                    Id = Guid.NewGuid(),
                    StaffUniqueId = uniqueId
                };

                var personUniqueIdToIdCache = Stub<IPersonUniqueIdToIdCache>();
                var validator = new UniqueIdNotChangedEntityValidator(personUniqueIdToIdCache);

                A.CallTo(() => personUniqueIdToIdCache.GetUniqueId(A<string>._, A<Guid>._))
                    .Returns(uniqueId);

                var result = validator.ValidateObject(student);

                result.IsValid()
                    .ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_validating_parent_resource_with_unchanged_unique_id : TestFixtureBase
        {
            [Test]
            public void Should_pass_validation()
            {
                const string uniqueId = "ABC123";

                var student = new Parent
                {
                    Id = Guid.NewGuid(),
                    ParentUniqueId = uniqueId
                };

                var personUniqueIdToIdCache = Stub<IPersonUniqueIdToIdCache>();
                var validator = new UniqueIdNotChangedEntityValidator(personUniqueIdToIdCache);

                A.CallTo(() => personUniqueIdToIdCache.GetUniqueId(A<string>._, A<Guid>._))
                    .Returns(uniqueId);

                var result = validator.ValidateObject(student);

                result.IsValid()
                    .ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_validating_student_entity_with_unchanged_unique_id : TestFixtureBase
        {
            [Test]
            public void Should_pass_validation()
            {
                const string uniqueId = "ABC123";

                var student = new global::EdFi.Ods.Entities.NHibernate.StudentAggregate.EdFi.Student
                {
                    Id = Guid.NewGuid(),
                    StudentUniqueId = uniqueId
                };

                var personUniqueIdToIdCache = Stub<IPersonUniqueIdToIdCache>();
                var validator = new UniqueIdNotChangedEntityValidator(personUniqueIdToIdCache);

                A.CallTo(() => personUniqueIdToIdCache.GetUniqueId(A<string>._, A<Guid>._))
                    .Returns(uniqueId);

                var result = validator.ValidateObject(student);

                result.IsValid()
                    .ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_validating_staff_entity_with_unchanged_unique_id : TestFixtureBase
        {
            [Test]
            public void Should_pass_validation()
            {
                const string uniqueId = "ABC123";

                var student = new global::EdFi.Ods.Entities.NHibernate.StaffAggregate.EdFi.Staff
                {
                    Id = Guid.NewGuid(),
                    StaffUniqueId = uniqueId
                };

                var personUniqueIdToIdCache = Stub<IPersonUniqueIdToIdCache>();
                var validator = new UniqueIdNotChangedEntityValidator(personUniqueIdToIdCache);

                A.CallTo(() => personUniqueIdToIdCache.GetUniqueId(A<string>._, A<Guid>._))
                    .Returns(uniqueId);

                var result = validator.ValidateObject(student);

                result.IsValid()
                    .ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_validating_parent_entity_with_unchanged_unique_id : TestFixtureBase
        {
            [Test]
            public void Should_pass_validation()
            {
                const string uniqueId = "ABC123";

                var student = new global::EdFi.Ods.Entities.NHibernate.ParentAggregate.EdFi.Parent
                {
                    Id = Guid.NewGuid(),
                    ParentUniqueId = uniqueId
                };

                var personUniqueIdToIdCache = Stub<IPersonUniqueIdToIdCache>();
                var validator = new UniqueIdNotChangedEntityValidator(personUniqueIdToIdCache);

                A.CallTo(() => personUniqueIdToIdCache.GetUniqueId(A<string>._, A<Guid>._))
                    .Returns(uniqueId);

                var result = validator.ValidateObject(student);

                result.IsValid()
                    .ShouldBeTrue();
            }
        }
    }
}
