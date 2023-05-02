// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Caching;

namespace EdFi.Ods.Common.Configuration;

public class OdsInstanceConfiguration : IContextHashBytesSource
{
    private readonly byte[] _hashBytes;
    private readonly Lazy<string> _readReplicaConnectionString;

    public OdsInstanceConfiguration(
        int odsInstanceId,
        ulong odsInstanceHashId,
        string connectionString,
        IDictionary<string, string> contextValueByKey,
        IDictionary<DerivativeType, string> connectionStringByDerivativeType)
    {
        OdsInstanceId = odsInstanceId;

        OdsInstanceHashId = odsInstanceHashId;
        _hashBytes = OdsInstanceHashId.GetBytes();

        ConnectionString = connectionString;
        ContextValueByKey = contextValueByKey;
        ConnectionStringByDerivativeType = connectionStringByDerivativeType;

        _readReplicaConnectionString = new Lazy<string>(
            () =>
            {
                if (ConnectionStringByDerivativeType.TryGetValue(
                        DerivativeType.ReadReplica,
                        out string derivativeConnectionString))
                {
                    return derivativeConnectionString;
                }

                return null;
            });
    }

    public int OdsInstanceId { get; }

    public ulong OdsInstanceHashId { get; }

    public string ConnectionString { get; }

    public string ReadReplicaConnectionString
    {
        get => _readReplicaConnectionString.Value;
    }

    public IDictionary<string, string> ContextValueByKey { get; }

    public IDictionary<DerivativeType, string> ConnectionStringByDerivativeType { get; }

    byte[] IContextHashBytesSource.HashBytes
    {
        get => _hashBytes;
    }
}
