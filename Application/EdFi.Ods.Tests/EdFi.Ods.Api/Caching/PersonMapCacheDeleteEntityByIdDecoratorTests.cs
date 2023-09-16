// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Repositories;
using FakeItEasy;
using NUnit.Framework;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Caching;

public class PersonMapCacheDeleteEntityByIdDecoratorTests
{
    // Define your test subject and dependencies
    private PersonMapCacheDeleteEntityByIdDecorator<FakePerson> _decorator;
    private IDeleteEntityById<FakePerson> _next;
    private IMapCache<(ulong, string, PersonMapType), string, int> _usiByUniqueIdByPersonType;
    private IMapCache<(ulong, string, PersonMapType), int, string> _uniqueIdByUsiByPersonType;
    private IContextProvider<OdsInstanceConfiguration> _odsInstanceConfigurationProvider;

    [SetUp]
    public void SetUp()
    {
        // Create fake instances for dependencies
        _next = A.Fake<IDeleteEntityById<FakePerson>>();
        _usiByUniqueIdByPersonType = A.Fake<IMapCache<(ulong, string, PersonMapType), string, int>>();
        _uniqueIdByUsiByPersonType = A.Fake<IMapCache<(ulong, string, PersonMapType), int, string>>();
        _odsInstanceConfigurationProvider = A.Fake<IContextProvider<OdsInstanceConfiguration>>();
        
        // Create the decorator instance to be tested
        _decorator = new PersonMapCacheDeleteEntityByIdDecorator<FakePerson>(
            _next,
            _usiByUniqueIdByPersonType,
            _uniqueIdByUsiByPersonType,
            _odsInstanceConfigurationProvider);
    }

    [Test]
    public async Task DeleteByIdAsync_WithPersonTypeAndIdentifiableEntity_DeletesFromCache()
    {
        // Arrange
        var entity = new FakePerson
        {
            Id = Guid.NewGuid(),
            FakePersonUSI = 12345,
            FakePersonUniqueId = "12345",
        };

        // Configure the expected behavior of your dependencies
        A.CallTo(() => _next.DeleteByIdAsync(entity.Id, A<string>._, A<CancellationToken>._))
            .Returns(entity);

        // Act
        var result = await _decorator.DeleteByIdAsync(entity.Id, "etag", CancellationToken.None);

        // Assert
        // Verify that the DeleteByIdAsync method of the decorated instance was called with the expected arguments
        A.CallTo(() => _next.DeleteByIdAsync(entity.Id, "etag", CancellationToken.None)).MustHaveHappenedOnceExactly();

        // Verify that the DeleteMapEntryAsync method of _usiByUniqueIdByPersonType was called
        var usiByUniqueIdTuple = (0UL, nameof(FakePerson), PersonMapType.UsiByUniqueId);
        A.CallTo(() => _usiByUniqueIdByPersonType.DeleteMapEntryAsync(usiByUniqueIdTuple, entity.FakePersonUniqueId))
            .MustHaveHappenedOnceExactly();

        // Verify that the DeleteMapEntryAsync method of _uniqueIdByUsiByPersonType was called
        var uniqueIdByUsiTuple = (0UL, nameof(FakePerson), PersonMapType.UniqueIdByUsi);
        A.CallTo(() => _uniqueIdByUsiByPersonType.DeleteMapEntryAsync(uniqueIdByUsiTuple, entity.FakePersonUSI))
            .MustHaveHappenedOnceExactly();

        // Verify that the deleted entity is returned as expected
        Assert.AreEqual(entity, result);
    }

    [Test]
    public async Task DeleteByIdAsync_WithNonPersonType_DoesNotDeleteFromCache()
    {
        // Arrange
        var entity = new NonPersonEntity
        {
            Id = Guid.NewGuid(),
        };

        var next = A.Fake<IDeleteEntityById<NonPersonEntity>>();

        // Create the decorator instance to be tested
        var decorator = new PersonMapCacheDeleteEntityByIdDecorator<NonPersonEntity>(
            next,
            _usiByUniqueIdByPersonType,
            _uniqueIdByUsiByPersonType,
            _odsInstanceConfigurationProvider);
        
        // Configure the expected behavior of your dependencies
        A.CallTo(() => next.DeleteByIdAsync(entity.Id, A<string>._, A<CancellationToken>._))
            .Returns(entity);

        // Act
        var result = await decorator.DeleteByIdAsync(entity.Id, "etag", CancellationToken.None);

        // Assert
        // Verify that the DeleteByIdAsync method of the decorated instance was called with the expected arguments
        A.CallTo(() => next.DeleteByIdAsync(entity.Id, "etag", CancellationToken.None)).MustHaveHappenedOnceExactly();

        // Verify that the DeleteMapEntryAsync method of _usiByUniqueIdByPersonType was not called
        A.CallTo(() => _usiByUniqueIdByPersonType.DeleteMapEntryAsync(A<(ulong, string, PersonMapType)>.Ignored, A<string>.Ignored))
            .MustNotHaveHappened();

        // Verify that the DeleteMapEntryAsync method of _uniqueIdByUsiByPersonType was not called
        A.CallTo(() => _uniqueIdByUsiByPersonType.DeleteMapEntryAsync(A<(ulong, string, PersonMapType)>.Ignored, A<int>.Ignored))
            .MustNotHaveHappened();

        // Verify that the deleted entity is returned as expected
        Assert.AreEqual(entity, result);
    }

    // Define a sample Person entity class for testing
    public class FakePerson : DomainObjectBase, IHasIdentifier, IDateVersionedEntity, IIdentifiablePerson
    {
        public int FakePersonUSI { get; set; }
        public string FakePersonUniqueId { get; set; }

        string IIdentifiablePerson.UniqueId
        {
            get => FakePersonUniqueId;
        }

        protected override IEnumerable<PropertyInfo> GetTypeSpecificSignatureProperties() => throw new NotImplementedException();

        public Guid Id { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }

    // Define a sample non-Person entity class for testing
    public class NonPersonEntity : DomainObjectBase, IHasIdentifier, IDateVersionedEntity
    {
        public Guid Id { get; set; }

        protected override IEnumerable<PropertyInfo> GetTypeSpecificSignatureProperties() => throw new NotImplementedException();

        public DateTime LastModifiedDate { get; set; }
    }
}
