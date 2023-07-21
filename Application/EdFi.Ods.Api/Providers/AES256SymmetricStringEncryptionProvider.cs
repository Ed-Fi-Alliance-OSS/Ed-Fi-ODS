// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using EdFi.Ods.Common.Caching;
using Quartz.Util;

namespace EdFi.Ods.Api.Providers;

/// <summary>
/// Implements AES 256 bit symmetric encryption of string values.
/// </summary>
/// <remarks>
/// This class is used to facilitate the encryption of string values using the AES 256 bit
/// encryption algorithm. HMAC signing of the encrypted value is used to mitigate potential
/// timing-based padding oracle attacks on AES in CBC mode (as discussed here
/// https://learn.microsoft.com/en-us/dotnet/standard/security/vulnerabilities-cbc-mode)
/// by verifying the authenticity of the encrypted content before decryption is attempted.</remarks>
public class Aes256SymmetricStringEncryptionProvider : ISymmetricStringEncryptionProvider
{
    /// <summary>
    /// Encrypt the specified string value using the specified key.
    /// </summary>
    /// <para name="value">The string value to be encrypted.</para>
    /// <para name="key">The 256 bit private key to be used for encryption.</para>
    /// <returns>A string representing the input in encrypted form along with the other information
    /// necessary to decrypt it (aside from the private key). The output is three strings concatenated in
    /// the format "IV.EncryptedMessage.HMACSignature"</returns>
    public string Encrypt(string value, byte[] key)
    {
        //Incorporates code from https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-7.0
        if (value.IsNullOrWhiteSpace())
            throw new ArgumentException("Input value cannot be null or whitespace.", nameof(value));

        if (key == null || key.Length != 32)
            throw new ArgumentException("Key must be 256 bits (32 bytes) in length.", nameof(key));

        using Aes aesInstance = Aes.Create();

        aesInstance.Key = key;
        aesInstance.GenerateIV();
        byte[] encryptedBytes;

        ICryptoTransform encryptor = aesInstance.CreateEncryptor(aesInstance.Key, aesInstance.IV);

        using (MemoryStream msEncrypt = new MemoryStream())
        {
            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(value);
                }

                encryptedBytes = msEncrypt.ToArray();
            }
        }

        byte[] hmacSignatureValue = GenerateHmacSignature();

        return
            $"{Convert.ToBase64String(aesInstance.IV)}.{Convert.ToBase64String(encryptedBytes)}.{Convert.ToBase64String(hmacSignatureValue)}";

        byte[] GenerateHmacSignature()
        {
            byte[] hmacSignature;

            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                hmacSignature = hmac.ComputeHash(encryptedBytes);
            }

            return hmacSignature;
        }
    }
}
