// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Common.Configuration;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Configuration;

[TestFixture]
public class OdsInstanceConfigurationProviderTests
{
    [SetUp]
    public void SetUp()
    {
        _dataRowDataProvider = A.Fake<IEdFiAdminRawOdsInstanceConfigurationDataProvider>();
        _dataRowDataTransformer = A.Fake<IEdFiAdminRawOdsInstanceConfigurationDataTransformer>();
        _overridesApplicator = A.Fake<IConnectionStringOverridesApplicator>();

        _configurationProvider = new OdsInstanceConfigurationProvider(
            _dataRowDataProvider,
            _dataRowDataTransformer,
            _overridesApplicator);
    }
    
    private IEdFiAdminRawOdsInstanceConfigurationDataProvider _dataRowDataProvider;
    private IEdFiAdminRawOdsInstanceConfigurationDataTransformer _dataRowDataTransformer;
    private IConnectionStringOverridesApplicator _overridesApplicator;
    private OdsInstanceConfigurationProvider _configurationProvider;

    [Test]
    public async Task GetByIdAsync_GetsRawData_TransformsItToOdsConfiguration_and_AppliesOverrides()
    {
        // Arrange
        int suppliedOdsInstanceId = 123;
        var suppliedRawDataRows = Array.Empty<RawOdsInstanceConfigurationDataRow>();
        var suppliedOdsConfiguration = new OdsInstanceConfiguration(123, 456, "the-connection-string",
            new Dictionary<string, string>(), new Dictionary<DerivativeType, string>());
        
        A.CallTo(() => _dataRowDataProvider.GetByIdAsync(suppliedOdsInstanceId)).Returns(Task.FromResult(suppliedRawDataRows));
        A.CallTo(() => _dataRowDataTransformer.TransformAsync(suppliedRawDataRows)).Returns(Task.FromResult(suppliedOdsConfiguration));

        // Act
        var result = await _configurationProvider.GetByIdAsync(suppliedOdsInstanceId);

        // Assert
        
        // Must get the raw data, transform it, apply overrides and then return.
        A.CallTo(() => _dataRowDataProvider.GetByIdAsync(123)).MustHaveHappenedOnceExactly();
        A.CallTo(() => _dataRowDataTransformer.TransformAsync(suppliedRawDataRows)).MustHaveHappenedOnceExactly();
        A.CallTo(() => _overridesApplicator.ApplyOverrides(suppliedOdsConfiguration)).MustHaveHappenedOnceExactly();
        result.ShouldBe(suppliedOdsConfiguration);
    }

    [TestCase(null)]
    [TestCase("")]
    public void GetByIdAsync_WhenOdsConnectionStringIsNullOrEmpty_ThrowsException(string suppliedConnectionString)
    {
        // Arrange
        int suppliedOdsInstanceId = 123;
        var suppliedRawDataRows = Array.Empty<RawOdsInstanceConfigurationDataRow>();
        var suppliedOdsConfiguration = new OdsInstanceConfiguration(123, 456, suppliedConnectionString,
            new Dictionary<string, string>(), new Dictionary<DerivativeType, string>());
        
        A.CallTo(() => _dataRowDataProvider.GetByIdAsync(suppliedOdsInstanceId)).Returns(Task.FromResult(suppliedRawDataRows));
        A.CallTo(() => _dataRowDataTransformer.TransformAsync(suppliedRawDataRows)).Returns(Task.FromResult(suppliedOdsConfiguration));
        
        // Act
        Should.Throw<Exception>(async () => await _configurationProvider.GetByIdAsync(suppliedOdsInstanceId))
            .Message.ShouldBe("ODS connection string has not been initialized.");
    }
    
    [TestCase(null)]
    [TestCase("")]
    public void GetByIdAsync_WhenDerivativeOdsConnectionStringIsNullOrEmpty_ThrowsException(string suppliedConnectionString)
    {
        // Arrange
        int suppliedOdsInstanceId = 123;
        var suppliedRawDataRows = Array.Empty<RawOdsInstanceConfigurationDataRow>();
        var suppliedOdsConfiguration = new OdsInstanceConfiguration(123, 456, "the-connection-string",
            new Dictionary<string, string>(), 
            new Dictionary<DerivativeType, string>()
            {
                { DerivativeType.ReadReplica, suppliedConnectionString }
            });
        
        A.CallTo(() => _dataRowDataProvider.GetByIdAsync(suppliedOdsInstanceId)).Returns(Task.FromResult(suppliedRawDataRows));
        A.CallTo(() => _dataRowDataTransformer.TransformAsync(suppliedRawDataRows)).Returns(Task.FromResult(suppliedOdsConfiguration));
        
        // Act
        Should.Throw<Exception>(async () => await _configurationProvider.GetByIdAsync(suppliedOdsInstanceId))
            .Message.ShouldBe($"Derivative ODS connection string '{DerivativeType.ReadReplica}' has not been initialized.");
    }
}
