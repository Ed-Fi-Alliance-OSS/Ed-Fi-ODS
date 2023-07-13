// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Providers;

namespace EdFi.Ods.Api.Security.Utilities;

public class OdsConnectionStringEncryptionApplicator : IOdsConnectionStringEncryptionApplicator
{
    private readonly byte[] _privateKey;
    private readonly ISymmetricStringEncryptionProvider _encryptionProvider;
    
    public OdsConnectionStringEncryptionApplicator(byte[] privateKey, ISymmetricStringEncryptionProvider encryptionProvider)
    {
        _privateKey = privateKey;
        _encryptionProvider = encryptionProvider;
    }
    
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
