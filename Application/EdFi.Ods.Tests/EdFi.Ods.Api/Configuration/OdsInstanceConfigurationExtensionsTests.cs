// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Configuration.Sections;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Configuration;

[TestFixture]
public class OdsInstanceConfigurationExtensionsTests
{
    [Test]
    public void ApplyOdsConnectionStringOverrides_WithMatchingOdsInstanceId_OverridesConnectionString()
    {
        // Arrange
        var baseOdsInstanceConfiguration = new OdsInstanceConfiguration(1, 12345, "BaseConnectionString", null, null);

        var odsInstances = new Dictionary<string, OdsInstance>
        {
            ["1"] = new() { ConnectionString = "OverrideConnectionString" }
        };

        // Act
        baseOdsInstanceConfiguration.ApplyOdsConnectionStringOverrides(odsInstances);

        // Assert
        baseOdsInstanceConfiguration.ConnectionString.ShouldBe("OverrideConnectionString");
    }

    [Test]
    public void ApplyOdsConnectionStringOverrides_WithMatchingOdsInstanceId_InitializesDerivativeConnectionStrings()
    {
        // Arrange
        var baseOdsInstanceConfiguration = new OdsInstanceConfiguration(1, 12345, "BaseConnectionString", null, 
            new Dictionary<DerivativeType, string>());

        var odsInstances = new Dictionary<string, OdsInstance>
        {
            ["1"] = new()
            {
                ConnectionStringByDerivativeType = new Dictionary<string, string>
                {
                    ["ReadReplica"] = "OverrideReadReplicaConnectionString",
                    ["Snapshot"] = "OverrideSnapshotConnectionString",
                }
            }
        };

        // Act
        baseOdsInstanceConfiguration.ApplyOdsConnectionStringOverrides(odsInstances);

        // Assert
        baseOdsInstanceConfiguration.ConnectionStringByDerivativeType[DerivativeType.ReadReplica]
            .ShouldBe("OverrideReadReplicaConnectionString");

        baseOdsInstanceConfiguration.ConnectionStringByDerivativeType[DerivativeType.Snapshot]
            .ShouldBe("OverrideSnapshotConnectionString");
    }

    [Test]
    public void ApplyOdsConnectionStringOverrides_WithMatchingOdsInstanceId_OverridesDerivativeConnectionStrings()
    {
        // Arrange
        var baseOdsInstanceConfiguration = new OdsInstanceConfiguration(1, 12345, "BaseConnectionString", null, 
            new Dictionary<DerivativeType, string>
                {
                    [DerivativeType.ReadReplica] = "BaseReadReplicaConnectionString",
                    [DerivativeType.Snapshot] = "BaseSnapshotConnectionString",
                }
            );

        var odsInstances = new Dictionary<string, OdsInstance>
        {
            ["1"] = new()
            {
                ConnectionStringByDerivativeType = new Dictionary<string, string>
                {
                    ["ReadReplica"] = "OverrideReadReplicaConnectionString",
                    ["Snapshot"] = "OverrideSnapshotConnectionString",
                }
            }
        };

        // Act
        baseOdsInstanceConfiguration.ApplyOdsConnectionStringOverrides(odsInstances);

        // Assert
        baseOdsInstanceConfiguration.ConnectionStringByDerivativeType[DerivativeType.ReadReplica]
            .ShouldBe("OverrideReadReplicaConnectionString");

        baseOdsInstanceConfiguration.ConnectionStringByDerivativeType[DerivativeType.Snapshot]
            .ShouldBe("OverrideSnapshotConnectionString");
    }

    [Test]
    public void ApplyOdsConnectionStringOverrides_WithNoMatchingOdsInstanceId_DoesNotOverrideConnectionString()
    {
        // Arrange
        var baseOdsInstanceConfiguration = new OdsInstanceConfiguration(1, 12345, "BaseConnectionString", null, null);

        var odsInstances = new Dictionary<string, OdsInstance>
        {
            ["2"] = new()
            {
                ConnectionString = "OverrideConnectionString"
            }
        };

        // Act
        baseOdsInstanceConfiguration.ApplyOdsConnectionStringOverrides(odsInstances);

        // Assert
        baseOdsInstanceConfiguration.ConnectionString.ShouldBe("BaseConnectionString");
    }

    [Test]
    public void ApplyOdsConnectionStringOverrides_WithNoMatchingOdsInstanceId_DoesNotInitializeDerivativeConnectionStrings()
    {
        // Arrange
        var baseOdsInstanceConfiguration = new OdsInstanceConfiguration(1, 12345, "BaseConnectionString", null, 
            new Dictionary<DerivativeType, string>());

        var odsInstances = new Dictionary<string, OdsInstance>
        {
            ["2"] = new()
            {
                ConnectionStringByDerivativeType = new Dictionary<string, string>
                {
                    ["ReadReplica"] = "OverrideReadReplicaConnectionString",
                    ["Snapshot"] = "OverrideSnapshotConnectionString",
                }
            }
        };

        // Act
        baseOdsInstanceConfiguration.ApplyOdsConnectionStringOverrides(odsInstances);

        // Assert
        baseOdsInstanceConfiguration.ConnectionStringByDerivativeType.ShouldNotContainKey(DerivativeType.ReadReplica);
        baseOdsInstanceConfiguration.ConnectionStringByDerivativeType.ShouldNotContainKey(DerivativeType.Snapshot);
    }

    [Test]
    public void ApplyOdsConnectionStringOverrides_WithNoMatchingOdsInstanceId_DoesNotOverrideDerivativeConnectionStrings()
    {
        // Arrange
        var baseOdsInstanceConfiguration = new OdsInstanceConfiguration(1, 12345, "BaseConnectionString", null, 
            new Dictionary<DerivativeType, string>
            {
                [DerivativeType.ReadReplica] = "BaseReadReplicaConnectionString",
                [DerivativeType.Snapshot] = "BaseSnapshotConnectionString",
            }
        );

        var odsInstances = new Dictionary<string, OdsInstance>
        {
            ["2"] = new()
            {
                ConnectionStringByDerivativeType = new Dictionary<string, string>
                {
                    ["ReadReplica"] = "OverrideReadReplicaConnectionString",
                    ["Snapshot"] = "OverrideSnapshotConnectionString",
                }
            }
        };

        // Act
        baseOdsInstanceConfiguration.ApplyOdsConnectionStringOverrides(odsInstances);

        // Assert
        baseOdsInstanceConfiguration.ConnectionStringByDerivativeType[DerivativeType.ReadReplica].ShouldBe("BaseReadReplicaConnectionString");
        baseOdsInstanceConfiguration.ConnectionStringByDerivativeType[DerivativeType.Snapshot].ShouldBe("BaseSnapshotConnectionString");
    }
}
