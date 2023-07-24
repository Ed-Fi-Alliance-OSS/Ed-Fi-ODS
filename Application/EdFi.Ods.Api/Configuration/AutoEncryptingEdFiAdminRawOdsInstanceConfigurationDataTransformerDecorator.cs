// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Security.Authentication;
using EdFi.Ods.Common.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace EdFi.Ods.Api.Configuration;

/// <summary>
/// Implements a decorator for <see cref="IEdFiAdminRawOdsInstanceConfigurationDataTransformer"/> that automatically encrypts
/// connection strings if they are stored as plaintext in the EdFi_Admin database.
/// </summary>
public class AutoEncryptingEdFiAdminRawOdsInstanceConfigurationDataTransformerDecorator
    : IEdFiAdminRawOdsInstanceConfigurationDataTransformer
{
    private readonly ApiSettings _apiSettings;
    private readonly IHostEnvironment _hostEnvironment;
    private readonly IEdFiOdsConnectionStringWriter _edFiOdsConnectionStringWriter;
    private readonly ISymmetricStringDecryptionProvider _symmetricStringDecryptionProvider;
    private readonly IEdFiAdminRawOdsInstanceConfigurationDataTransformer _edFiAdminRawOdsInstanceConfigurationDataTransformer;
    private readonly ISymmetricStringEncryptionProvider _symmetricStringEncryptionProvider;

    public AutoEncryptingEdFiAdminRawOdsInstanceConfigurationDataTransformerDecorator(
        IEdFiAdminRawOdsInstanceConfigurationDataTransformer edFiAdminRawOdsInstanceConfigurationDataTransformer,
        ISymmetricStringEncryptionProvider symmetricStringEncryptionProvider,
        ISymmetricStringDecryptionProvider symmetricStringDecryptionProvider,
        IEdFiOdsConnectionStringWriter edFiOdsConnectionStringWriter,
        IWebHostEnvironment hostEnvironment,
        ApiSettings apiSettings)
    {
        _edFiAdminRawOdsInstanceConfigurationDataTransformer = edFiAdminRawOdsInstanceConfigurationDataTransformer;
        _symmetricStringEncryptionProvider = symmetricStringEncryptionProvider;
        _symmetricStringDecryptionProvider = symmetricStringDecryptionProvider;
        _edFiOdsConnectionStringWriter = edFiOdsConnectionStringWriter;
        _apiSettings = apiSettings;
        _hostEnvironment = hostEnvironment;
    }

    public async Task<OdsInstanceConfiguration> TransformAsync(RawOdsInstanceConfigurationDataRow[] rawDataRows)
    {
        var odsInstanceConfiguration = await _edFiAdminRawOdsInstanceConfigurationDataTransformer.TransformAsync(rawDataRows);
        
        byte[] encryptionKey = _apiSettings.OdsConnectionStringEncryptionKeyBytes;
        
        if (encryptionKey == null)
        {
            // Only allow encryption to be disabled in Development environment
            if (!_hostEnvironment.IsDevelopment())
            {
                throw new InvalidOperationException(
                    $"Symmetric encryption key has not been supplied in the '{nameof(ApiSettings.OdsConnectionStringEncryptionKey)}' configuration setting.");
            }
        }
        else
        {
            // Process the main connection string
            odsInstanceConfiguration.ConnectionString = await DecryptOrEncryptAndPersistConnectionStringAsync(
                encryptionKey,
                odsInstanceConfiguration.ConnectionString,
                odsInstanceConfiguration.OdsInstanceId);

            // Process the ODS derivative connection strings
            foreach (var kvp in odsInstanceConfiguration.ConnectionStringByDerivativeType.ToList())
            {
                var derivativeType = kvp.Key;
                string connectionString = kvp.Value;
                
                string plaintextConnectionString = await DecryptOrEncryptAndPersistConnectionStringAsync(
                    encryptionKey,
                    connectionString,
                    odsInstanceConfiguration.OdsInstanceId,
                    derivativeType);

                // If the original connection string was encrypted, assign the plaintext value
                if (connectionString != plaintextConnectionString)
                {
                    odsInstanceConfiguration.ConnectionStringByDerivativeType[derivativeType] = plaintextConnectionString;
                }
            }
        }

        return odsInstanceConfiguration;
    }

    /// <summary>
    /// Encrypts the connection string in the database if it is not already encrypted, and returns the plaintext connection string.
    /// </summary>
    /// <param name="key">The symmetric encryption key.</param>
    /// <param name="connectionString">The raw connection string currently returned from the EdFi_Admin database.</param>
    /// <param name="odsInstanceId">The ODS instance identifier for the current configuration.</param>
    /// <param name="derivativeType">The type of derivative ODS the connection string is associated with, or <b>null</b> if it's the main connection string for the ODS.</param>
    /// <returns>
    /// The plaintext connection string for the ODS.
    /// </returns>
    private async Task<string> DecryptOrEncryptAndPersistConnectionStringAsync(byte[] key, string connectionString, int odsInstanceId, DerivativeType derivativeType = null)
    {
        if (_symmetricStringDecryptionProvider.TryDecrypt(connectionString, key, out string plaintextConnectionString))
        {
            return plaintextConnectionString;
        }

        // If decryption fails above, then we assume the connection string is not encrypted, so we encrypt it and write it to the database.
        var encryptedConnectionString = _symmetricStringEncryptionProvider.Encrypt(connectionString, key);

        await _edFiOdsConnectionStringWriter.WriteConnectionStringAsync(odsInstanceId, encryptedConnectionString, derivativeType);

        return connectionString;
    }
}
