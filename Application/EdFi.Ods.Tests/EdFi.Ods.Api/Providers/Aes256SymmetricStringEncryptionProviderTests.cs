// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Shouldly;
using NUnit.Framework;
using EdFi.Ods.Api.Providers;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Providers.StringEncryption
{
    [TestFixture]
    public class Aes256SymmetricStringEncryptionDecryptionProviderTests
    {
        private Aes256SymmetricStringEncryptionProvider _encryptionProvider;
        private Aes256SymmetricStringDecryptionProvider _decryptionProvider;
        private byte[] _staticKey;

        [SetUp]
        public void SetUp()
        {
            _encryptionProvider = new Aes256SymmetricStringEncryptionProvider();
            _decryptionProvider = new Aes256SymmetricStringDecryptionProvider();
            _staticKey = Convert.FromBase64String("t3OD+5YCKzCdGSaWBAvkQ9+d9R4ZbZnC9YG8L/ar8vA=");
        }

        [Test]
        public void Should_get_original_plaintext_back_when_encrypting_then_decrypting_a_string()
        {
            // Arrange
            var plainText = "Hello World";

            // Act
            string encryptedString = _encryptionProvider.Encrypt(plainText, _staticKey);
            bool decryptedSuccessfully = _decryptionProvider.TryDecrypt(encryptedString, _staticKey, out string decryptionResult);

            // Assert
            decryptedSuccessfully.ShouldBeTrue();
            decryptionResult.ShouldBe(plainText);
            encryptedString.ShouldNotBe(plainText);
        }

        [Test]
        public void Should_decrypt_successfully_when_decrypting_a_string_using_the_correct_key()
        {
            // Arrange

            // This is a valid ciphertext with a valid HMAC signature which was encrypted using the static key and decrypts to "Hello World"
            var cipherText = "Gx5FXSHSelzRF2quaCOaNw==|RlK3dR28TP/dbslPezxa4w==|D7VcBfHXG0iPkPR36QDvv9W7SGiGWUUe7WBu5neV/fo=";

            // Act
            bool decryptionSuccessful = _decryptionProvider.TryDecrypt(cipherText, _staticKey, out string output);

            // Assert
            decryptionSuccessful.ShouldBeTrue();
            output.ShouldBe("Hello World");
        }

        [Test]
        public void Sould_fail_to_decrypt_when_hmac_signature_of_ciphertext_is_invalid()
        {
            // Arrange

            // This is a valid ciphertext with a valid HMAC signature which was encrypted using the static key and decrypts to "Hello World"
            var ciphertextWithValidHmac =
                "Gx5FXSHSelzRF2quaCOaNw==|RlK3dR28TP/dbslPezxa4w==|D7VcBfHXG0iPkPR36QDvv9W7SGiGWUUe7WBu5neV/fo=";

            // Change the last character of the HMAC signature to make it invalid
            var cipherTextWithInvalidHmac =
                "Gx5FXSHSelzRF2quaCOaNw==|RlK3dR28TP/dbslPezxa4w==|D7VcBfHXG0iPkPR36QDvv9W7SGiGWUUe7WBu5neV/f0=";

            // Act
            bool decryptionOfValidCiphertextWithValidHmacSuccessful = _decryptionProvider.TryDecrypt(ciphertextWithValidHmac, _staticKey, out string vaildHmacOutput);

            bool decryptionOfValidCiphertextWithInvalidHmacSuccessful = _decryptionProvider.TryDecrypt(cipherTextWithInvalidHmac, _staticKey, out string invalidHmacOutput);

            // Assert
            decryptionOfValidCiphertextWithValidHmacSuccessful.ShouldBeTrue();
            vaildHmacOutput.ShouldBe("Hello World");
            decryptionOfValidCiphertextWithInvalidHmacSuccessful.ShouldBeFalse();
            invalidHmacOutput.ShouldBeNull();
        }

        [Test]
        public void Should_fail_to_decrypt_when_input_string_is_not_in_correct_format()
        {
            // Arrange
            var cipherText = "Not a valid format for decryption";

            // Act
            bool decryptionSuccessful = _decryptionProvider.TryDecrypt(cipherText, _staticKey, out string output);

            // Assert
            decryptionSuccessful.ShouldBeFalse();
            output.ShouldBeNull();
        }
    }
}