// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Configuration;

/// <summary>
/// Contains configuration information for an ODS instance.
/// </summary>
public class OdsInstanceConfiguration : IContextHashBytesSource
{
    private readonly byte[] _hashBytes;

    public OdsInstanceConfiguration(
        int odsInstanceId,
        ulong odsInstanceHashId,
        string connectionString,
        IDictionary<string, string> contextValueByKey,
        IDictionary<DerivativeType, string> connectionStringByDerivativeType)
    {
        OdsInstanceId = odsInstanceId;
        OdsInstanceIdAsString = odsInstanceId.ToString();

        OdsInstanceHashId = odsInstanceHashId;
        _hashBytes = new byte[8];
        BitConverter.TryWriteBytes(_hashBytes, OdsInstanceHashId);

        ConnectionString = connectionString;
        ContextValueByKey = contextValueByKey;
        ConnectionStringByDerivativeType = connectionStringByDerivativeType;
    }

    /// <summary>
    /// Gets the assigned tenant-specific identifier of the ODS instance.
    /// </summary>
    public int OdsInstanceId { get; }
    
    /// <summary>
    /// Gets the string representation of the ODS instance identifier.
    /// </summary>
    public string OdsInstanceIdAsString { get; }

    /// <summary>
    /// Gets a hashed identifier of the ODS for use as a global identifier (i.e. across multiple tenants).
    /// </summary>
    public ulong OdsInstanceHashId { get; }

    /// <summary>
    /// Gets or sets the connection string to use to connect to the ODS database.
    /// </summary>
    public string ConnectionString { get; set; }

    /// <summary>
    /// Gets the <see cref="DerivativeType.ReadReplica" /> connection string.
    /// </summary>
    public string ReadReplicaConnectionString
    {
        get => ConnectionStringByDerivativeType.GetValueOrDefault(DerivativeType.ReadReplica);
    }

    /// <summary>
    /// Gets the map of the defined ODS context values by key.
    /// </summary>
    public IDictionary<string, string> ContextValueByKey { get; }

    /// <summary>
    /// Gets the map of connection strings by <see cref="DerivativeType" /> for related variants of the ODS database. 
    /// </summary>
    public IDictionary<DerivativeType, string> ConnectionStringByDerivativeType { get; }

    byte[] IContextHashBytesSource.HashBytes
    {
        get => _hashBytes;
    }
}
