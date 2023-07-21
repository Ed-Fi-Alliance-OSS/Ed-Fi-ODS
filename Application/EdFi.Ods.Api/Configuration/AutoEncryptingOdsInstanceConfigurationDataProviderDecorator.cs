// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Security.Authentication;

namespace EdFi.Ods.Api.Configuration;

/// <summary>
/// Implements a decorator for <see cref="IEdFiAdminRawOdsInstanceConfigurationDataProvider"/> that automatically encrypts connection strings in the Admin Database.
/// </summary>
public class AutoEncryptingOdsInstanceConfigurationDataProviderDecorator : IEdFiAdminRawOdsInstanceConfigurationDataProvider
{
    private readonly ISymmetricStringEncryptionProvider _symmetricStringEncryptionProvider;
    private readonly ISymmetricStringDecryptionProvider _symmetricStringDecryptionProvider;
    private readonly IEdFiOdsConnectionStringWriter _edFiOdsConnectionStringWriter;
    private readonly IEdFiAdminRawOdsInstanceConfigurationDataProvider _edFiAdminRawOdsInstanceConfigurationDataProvider;
    private readonly Lazy<byte[]> _privateKeyBytesLazy;

    public AutoEncryptingOdsInstanceConfigurationDataProviderDecorator(
        ISymmetricStringEncryptionProvider symmetricStringEncryptionProvider,
        ISymmetricStringDecryptionProvider symmetricStringDecryptionProvider,
        IEdFiOdsConnectionStringWriter edFiOdsConnectionStringWriter, 
        IAdminDatabaseConnectionStringProvider adminDatabaseConnectionStringProvider,
        DbProviderFactory dbProviderFactory,
        Lazy<byte[]> privateKeyBytesLazy)
    {
        _symmetricStringEncryptionProvider = symmetricStringEncryptionProvider;
        _symmetricStringDecryptionProvider = symmetricStringDecryptionProvider;
        _edFiOdsConnectionStringWriter = edFiOdsConnectionStringWriter;
        _edFiAdminRawOdsInstanceConfigurationDataProvider = new EdFiAdminRawOdsInstanceConfigurationDataProvider(adminDatabaseConnectionStringProvider, dbProviderFactory);
        _privateKeyBytesLazy = privateKeyBytesLazy;
    }

    /// <inheritdoc cref="IEdFiAdminRawOdsInstanceConfigurationDataProvider.GetByIdAsync" />
    public async Task<RawOdsInstanceConfigurationDataRow[]> GetByIdAsync(int odsInstanceId)
    {
        var rawDataRows = await _edFiAdminRawOdsInstanceConfigurationDataProvider.GetByIdAsync(odsInstanceId);

        if (!System.Diagnostics.Debugger.IsAttached)
        {
            foreach (var row in rawDataRows)
            {
                row.ConnectionString = ApplyConnectionStringEncryptionLogic(row);
            }
        }

        return rawDataRows;
    }

    /// <summary>
    /// Encrypts the connection string in the database if it is not already encrypted, and returns the plaintext connection string.
    /// </summary>
    /// <param name="rawDataRow">
    /// The <see cref="RawOdsInstanceConfigurationDataRow"/> containing the connection string to which the encryption logic should be applied.
    /// </param>
    /// <returns>
    /// Plaintext connection string.
    /// </returns>
    private string ApplyConnectionStringEncryptionLogic(RawOdsInstanceConfigurationDataRow rawDataRow)
    {
        var privateKey = _privateKeyBytesLazy.Value;
        
        if (_symmetricStringDecryptionProvider.TryDecrypt(
                rawDataRow.ConnectionString, out string decryptedConnectionString, privateKey))
        {
            return decryptedConnectionString;
        }

        // If decryption fails, then we assume the connection string is not encrypted, so we encrypt it and write it to the database.
        var plaintextConnectionString = rawDataRow.ConnectionString;
        var encryptedConnectionString = _symmetricStringEncryptionProvider.Encrypt(rawDataRow.ConnectionString, privateKey);

        _edFiOdsConnectionStringWriter.WriteConnectionString(
            rawDataRow.OdsInstanceId, encryptedConnectionString, rawDataRow.DerivativeType);

        return plaintextConnectionString;
    }
}
