// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

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
        _hashIdGenerator = A.Fake<IOdsInstanceHashIdGenerator>();
        _overridesApplicator = A.Fake<IConnectionStringOverridesApplicator>();

        _configurationProvider = new OdsInstanceConfigurationProvider(
            _dataRowDataProvider,
            _hashIdGenerator,
            _overridesApplicator);
    }

    private IEdFiAdminRawOdsInstanceConfigurationDataProvider _dataRowDataProvider;
    private IOdsInstanceHashIdGenerator _hashIdGenerator;
    private IConnectionStringOverridesApplicator _overridesApplicator;
    private OdsInstanceConfigurationProvider _configurationProvider;

    [Test]
    public async Task GetByIdAsync_WithValidOdsInstanceId_ReturnsCorrectConfiguration()
    {
        // Arrange
        int odsInstanceId = 123;
        var rawDataRows = GetRawDataRows();

        A.CallTo(() => _dataRowDataProvider.GetByIdAsync(odsInstanceId)).Returns(Task.FromResult(rawDataRows));

        A.CallTo(() => _hashIdGenerator.GenerateHashId(odsInstanceId)).Returns(456UL);

        var expectedConfiguration = new OdsInstanceConfiguration(
            odsInstanceId: 123,
            odsInstanceHashId: 456UL,
            connectionString: "TestConnectionString",
            contextValueByKey: new Dictionary<string, string>
            {
                { "ContextKey1", "ContextValue1" },
                { "ContextKey2", "ContextValue2" }
            },
            connectionStringByDerivativeType: new Dictionary<DerivativeType, string>
            {
                { DerivativeType.Snapshot, "SnapshotConnectionString" },
                { DerivativeType.ReadReplica, "ReadReplicaConnectionString" }
            });

        // Act
        var result = await _configurationProvider.GetByIdAsync(odsInstanceId);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeEquivalentTo(expectedConfiguration);
        A.CallTo(() => _overridesApplicator.ApplyOverrides(A<OdsInstanceConfiguration>.Ignored)).MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task GetByIdAsync_WithInvalidDerivativeType_ReturnsEmptyConnectionStringsByDerivativeType()
    {
        // Arrange
        int odsInstanceId = 123;
        var rawDataRows = GetRawDataRowsWithInvalidDerivativeType();

        A.CallTo(() => _dataRowDataProvider.GetByIdAsync(odsInstanceId)).Returns(Task.FromResult(rawDataRows));

        A.CallTo(() => _hashIdGenerator.GenerateHashId(odsInstanceId)).Returns(456UL);

        // Act
        var result = await _configurationProvider.GetByIdAsync(odsInstanceId);

        // Assert
        result.ShouldNotBeNull();
        result.ConnectionStringByDerivativeType.ShouldBeEmpty();
    }

    private static RawOdsInstanceConfigurationDataRow[] GetRawDataRows()
    {
        return new[]
        {
            new RawOdsInstanceConfigurationDataRow
            {
                OdsInstanceId = 123,
                ConnectionString = "TestConnectionString",
                ContextKey = "ContextKey1",
                ContextValue = "ContextValue1",
                DerivativeType = DerivativeType.Snapshot.DisplayName,
                ConnectionStringByDerivativeType = "SnapshotConnectionString"
            },
            new RawOdsInstanceConfigurationDataRow
            {
                OdsInstanceId = 123,
                ConnectionString = "TestConnectionString",
                ContextKey = "ContextKey1",
                ContextValue = "ContextValue1",
                DerivativeType = DerivativeType.ReadReplica.DisplayName,
                ConnectionStringByDerivativeType = "ReadReplicaConnectionString"
            },
            new RawOdsInstanceConfigurationDataRow
            {
                OdsInstanceId = 123,
                ConnectionString = "TestConnectionString",
                ContextKey = "ContextKey2",
                ContextValue = "ContextValue2",
                DerivativeType = DerivativeType.Snapshot.DisplayName,
                ConnectionStringByDerivativeType = "SnapshotConnectionString"
            },
            new RawOdsInstanceConfigurationDataRow
            {
                OdsInstanceId = 123,
                ConnectionString = "TestConnectionString",
                ContextKey = "ContextKey2",
                ContextValue = "ContextValue2",
                DerivativeType = DerivativeType.ReadReplica.DisplayName,
                ConnectionStringByDerivativeType = "ReadReplicaConnectionString"
            }
        };
    }

    private static RawOdsInstanceConfigurationDataRow[] GetRawDataRowsWithInvalidDerivativeType()
    {
        return new[]
        {
            new RawOdsInstanceConfigurationDataRow
            {
                OdsInstanceId = 123,
                ConnectionString = "TestConnectionString",
                ContextKey = "ContextKey1",
                ContextValue = "ContextValue1",
                DerivativeType = string.Empty,
                ConnectionStringByDerivativeType = "SnapshotConnectionString"
            },
            new RawOdsInstanceConfigurationDataRow
            {
                OdsInstanceId = 123,
                ConnectionString = "TestConnectionString",
                ContextKey = "ContextKey1",
                ContextValue = "ContextValue1",
                DerivativeType = "ReadRepIica",
                ConnectionStringByDerivativeType = "ReadReplicaConnectionString"
            },
            new RawOdsInstanceConfigurationDataRow
            {
                OdsInstanceId = 123,
                ConnectionString = "TestConnectionString",
                ContextKey = "ContextKey2",
                ContextValue = "ContextValue2",
                DerivativeType = "Sapshot",
                ConnectionStringByDerivativeType = "SnapshotConnectionString"
            }
        };
    }
}
