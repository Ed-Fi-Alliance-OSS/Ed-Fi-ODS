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

public class AES256SymmetricStringEncryptionProvider : ISymmetricStringEncryptionProvider
{
    public string Encrypt(string value, string base64EncodedKey)
    {
        if (string.IsNullOrWhiteSpace(base64EncodedKey))
            throw new ArgumentException("Key value cannot be null or whitespace.", nameof(base64EncodedKey));

        return Encrypt(value, Convert.FromBase64String(base64EncodedKey));
    }
    
    public bool TryDecrypt(string value, out string output, string base64EncodedKey)
    {
        if (string.IsNullOrWhiteSpace(base64EncodedKey))
            throw new ArgumentException("Key value cannot be null or whitespace.", nameof(base64EncodedKey));

        return TryDecrypt(value, out output, Convert.FromBase64String(base64EncodedKey));
    }

    public string Encrypt(string value, byte[] key)
    {
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

        byte[] hashValue;

        using (HMACSHA256 hmac = new HMACSHA256(key))
        {
            hashValue = hmac.ComputeHash(encryptedBytes);
        }

        return $"{Convert.ToBase64String(aesInstance.IV)}.{Convert.ToBase64String(encryptedBytes)}.{Convert.ToBase64String(hashValue)}";
    }

    public bool TryDecrypt(string value, out string output, byte[] key)
    {
        if (String.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Input value cannot be null or whitespace.", nameof(value));

        if (key == null || key.Length != 32)
            throw new ArgumentException("Key must be 256 bits (32 bytes) in length.", nameof(key));

        string[] inputParts = value.Split('.');

        if (inputParts.Length != 3)
        {
            output = null;
            return false;
        }

        string base64IV = inputParts[0];
        string base64EncryptedBytes = inputParts[1];
        string base64HashValue = inputParts[2];
        byte[] iv;
        byte[] encryptedBytes;
        byte[] hashValue;

        try
        {
            iv = Convert.FromBase64String(base64IV);
            encryptedBytes = Convert.FromBase64String(base64EncryptedBytes);
            hashValue = Convert.FromBase64String(base64HashValue);
        }
        catch
        {
            output = null;
            return false;
        }

        using (HMACSHA256 hmac = new HMACSHA256(key))
        {
            byte[] computedHashValue = hmac.ComputeHash(encryptedBytes);

            if (!hashValue.SequenceEqual(computedHashValue))
            {
                output = null;
                return false;
            }
        }

        using Aes aesInstance = Aes.Create();

        aesInstance.Key = key;
        aesInstance.IV = iv;

        ICryptoTransform decryptor = aesInstance.CreateDecryptor(aesInstance.Key, aesInstance.IV);

        using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
        {
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    output = srDecrypt.ReadToEnd();
                }
            }
        }

        return true;
    }
}
