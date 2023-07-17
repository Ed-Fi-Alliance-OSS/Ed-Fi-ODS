// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Configuration;

namespace EdFi.Ods.Api.Security.Utilities;

/// <summary>
/// Defines an interface for applying encryption to the ODS connection strings in the Admin database.
/// </summary>
/// <remarks>
/// This interface and its implementations are used to facilitate the encryption and decryption
/// of ODS connection strings in the Admin database.</remarks>
public interface IOdsConnectionStringEncryptionApplicator
{
    /// <summary>
    /// Applies encryption to the specified connection string. Encrypting it in the provided row, if necessary,
    /// and returning a plain-text version of the connection string.
    /// </summary>
    /// <para name="configurationDataRow">A row of data from the Admin database with the ODS connection string needing encryption/decryption performed.</para>
    /// <para name="rowHasChanged">Boolean indicating if the <paramref name="configurationDataRow" /> has been modified.</para>
    /// <returns>The connection string from the data row as plain-text.</returns>
    public string DecryptOrApplyEncryption(RawOdsInstanceConfigurationDataRow configurationDataRow, out bool rowHasChanged);
}
