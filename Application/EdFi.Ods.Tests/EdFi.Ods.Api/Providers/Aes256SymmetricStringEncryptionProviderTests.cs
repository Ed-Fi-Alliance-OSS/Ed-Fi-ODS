// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Security.Cryptography;
using EdFi.Ods.Api.Providers;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Providers;

using System;
using NUnit.Framework;

public class Aes256SymmetricStringEncryptionProviderTests
{
    private Aes256SymmetricStringEncryptionProvider _encryptionProvider;
    private byte[] _staticKey;
    [SetUp]
    public void SetUp()
    {
        _encryptionProvider = new Aes256SymmetricStringEncryptionProvider();
        _staticKey = Convert.FromBase64String("t3OD+5YCKzCdGSaWBAvkQ9+d9R4ZbZnC9YG8L/ar8vA=");
    }

    [Test]
    public void Encrypt_ShouldProduceSamePlaintextAfterEncryptionThenDecryption()
    {
        // Arrange
        var plainText = "Hello World";

        // Act
        string encryptedString = _encryptionProvider.Encrypt(plainText, _staticKey);
        bool decryptedSuccessfully = _encryptionProvider.TryDecrypt(encryptedString, out string decryptionResult, _staticKey);

        // Assert
        decryptedSuccessfully.ShouldBeTrue();
        decryptionResult.ShouldBe(plainText);
    }
    
    [Test]
    public void Decrypt_ShouldProduceExpectedPlaintextValueGivenValidStaticInput()
    {
        // Arrange
        var cipherText = "Gx5FXSHSelzRF2quaCOaNw==.RlK3dR28TP/dbslPezxa4w==.D7VcBfHXG0iPkPR36QDvv9W7SGiGWUUe7WBu5neV/fo=";

        // Act
        bool decryptionSuccessful = _encryptionProvider.TryDecrypt(cipherText, out string output, _staticKey);

        // Assert
        decryptionSuccessful.ShouldBeTrue();
        output.ShouldBe("Hello World");
    }
    
    [Test]
    public void Decrypt_ShouldProduceExpectedResultGivenInvalidHmac()
    {
        // Arrange
        var cipherText = "Gx5FXSHSelzRF2quaCOaNw==.RlK3dR28TP/dbslPezxa4w==.D7VcBfHXG0iPkPR36QDvv8W7SGiGWUUe7WBu5neV/fo=";

        // Act
        bool decryptionSuccessful = _encryptionProvider.TryDecrypt(cipherText, out string output, _staticKey);

        // Assert
        decryptionSuccessful.ShouldBeFalse();
        output.ShouldBeNull();
    }
    
    [Test]
    public void Decrypt_ShouldProduceExpectedResultGivenInvalidInputFormat()
    {
        // Arrange
        var cipherText = "Not a valid format for decryption";

        // Act
        bool decryptionSuccessful = _encryptionProvider.TryDecrypt(cipherText, out string output, _staticKey);

        // Assert
        decryptionSuccessful.ShouldBeFalse();
        output.ShouldBeNull();
    }
}
