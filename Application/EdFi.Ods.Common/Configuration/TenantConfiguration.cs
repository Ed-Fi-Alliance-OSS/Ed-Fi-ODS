// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Extensions;
using Standart.Hash.xxHash;

namespace EdFi.Ods.Common.Configuration;

/// <summary>
/// Contains details related to the tenant configuration and associated database connection strings.
/// </summary>
public class TenantConfiguration : IContextHashBytesSource
{
    private string _tenantIdentifier;
    private Lazy<ulong> _tenantHashId;
    private Lazy<byte[]> _hashBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="TenantConfiguration"/> class.
    /// </summary>
    public TenantConfiguration()
    {
        _tenantHashId = new Lazy<ulong>(ComputeHashId);
        _hashBytes = new Lazy<byte[]>(GetHashIdBytes);
    }

    private byte[] GetHashIdBytes()
    {
        var buffer = new byte[8];
        BitConverter.TryWriteBytes(buffer, _tenantHashId.Value);
        return buffer;
    }

    private ulong ComputeHashId()
    {
        var hashResult = new HashResult();

        TenantIdentifier.ApplyReadOnlySpanInvariant(
            (byteSpan, arg) => arg.Value = xxHash3.ComputeHash(byteSpan, byteSpan.Length),
            hashResult);

        return hashResult.Value;
    }

    /// <summary>
    /// Gets or sets the identifier used to uniquely identify the tenant.
    /// </summary>
    public string TenantIdentifier
    { 
        get => _tenantIdentifier;
        set
        {
            _tenantIdentifier = value;
            _tenantHashId = new Lazy<ulong>(ComputeHashId);
            _hashBytes = new Lazy<byte[]>(GetHashIdBytes);
        } 
    }

    /// <summary>
    /// An unsigned-long value used to globally uniquely identify the tenant that can be used in hash calculations without
    /// the use of strings.
    /// </summary>
    public ulong TenantHashId
    {
        get => _tenantHashId.Value;
    }

    /// <summary>
    /// Gets or sets the connection string for the EdFi_Admin database for the tenant.
    /// </summary>
    public string AdminConnectionString { get; set; }

    /// <summary>
    /// Gets or sets the connection string for the EdFi_Security database for the tenant.
    /// </summary>
    public string SecurityConnectionString { get; set; }

    private class HashResult
    {
        public ulong Value { get; set; }
    }

    /// <summary>
    /// Provides uniquely identifying bytes that can be incorporated into other identifying hash computations for unique
    /// identification of other artifacts without using strings.
    /// </summary>
    public byte[] HashBytes
    {
        get => _hashBytes.Value;
    }
}

