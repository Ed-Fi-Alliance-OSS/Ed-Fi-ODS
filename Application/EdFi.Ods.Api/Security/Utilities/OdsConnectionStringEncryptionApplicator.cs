// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Providers;

namespace EdFi.Ods.Api.Security.Utilities;

/// <summary>
/// Defines an class for applying encryption to the ODS connection strings in the Admin database.
/// </summary>
/// <remarks>
/// This class is used to facilitate the encryption and decryption
/// of ODS connection strings in the Admin database.</remarks>
public class OdsConnectionStringEncryptionApplicator : IOdsConnectionStringEncryptionApplicator
{
    private readonly byte[] _privateKey;
    private readonly ISymmetricStringEncryptionProvider _encryptionProvider;
    
    public OdsConnectionStringEncryptionApplicator(byte[] privateKey, ISymmetricStringEncryptionProvider encryptionProvider)
    {
        _privateKey = privateKey;
        _encryptionProvider = encryptionProvider;
    }
    
    /// <summary>
    /// Applies encryption to the specified connection string, if necessary, otherwise
    /// decrypts the connection string. Returns a plain-text version of the connection string.
    /// </summary>
    /// <para name="configurationDataRow">A row of data from the Admin database containing the ODS connection string
    /// in either encrypted or plain-text form.</para>
    /// <para name="rowHasChanged">Boolean indicating if the <paramref name="configurationDataRow" /> has been modified to
    /// replace the plain-text version of the ODS connection string with the encrypted version.</para>
    /// <returns>The connection string from the data row as plain-text.</returns>
    public string DecryptOrApplyEncryption(RawOdsInstanceConfigurationDataRow configurationDataRow, out bool rowHasChanged)
    {
        rowHasChanged = false;

        if(_encryptionProvider.TryDecrypt(configurationDataRow.ConnectionString, out string connectionStringPlainText, _privateKey))
        {
            return connectionStringPlainText;
        }
        
        connectionStringPlainText = configurationDataRow.ConnectionString;
        string encryptedConnectionString = _encryptionProvider.Encrypt(connectionStringPlainText, _privateKey);
        
        configurationDataRow.ConnectionString = encryptedConnectionString;
        rowHasChanged = true;

        return connectionStringPlainText;
    }
}
