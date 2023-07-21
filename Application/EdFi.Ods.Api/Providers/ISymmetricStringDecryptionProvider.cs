// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Providers;

    /// <summary>
    /// Defines an interface for providing decryption of string values using a symmetric encryption algorithm.
    /// </summary>
    /// <remarks>
    /// This interface and its implementations are used to facilitate the decryption
    /// of string values using a symmetric encryption algorithm.</remarks>
public interface ISymmetricStringDecryptionProvider
{
    /// <summary>
    /// Decrypts the specified string value using the specified key.
    /// </summary>
    /// <para name="value">The string value to be decrypted.</para>
    /// <para name="output">TThe decrypted string value</para>
    /// <para name="key">The private key to be used for decryption.</para>
    /// <returns>Indicates if the decryption operation was successful</returns>
    public bool TryDecrypt(string value, out string output, byte[] key);
}
