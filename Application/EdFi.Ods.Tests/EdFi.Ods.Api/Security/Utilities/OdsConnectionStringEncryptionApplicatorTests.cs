// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Security.Utilities;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Utilities;

public class OdsConnectionStringEncryptionApplicatorTests
{
    private ISymmetricStringEncryptionProvider _stringEncryptionProvider;
    private OdsConnectionStringEncryptionApplicator _odsConnectionStringEncryptionApplicator;
    
    [SetUp]
    public void SetUp()
    {
        _stringEncryptionProvider = A.Fake<ISymmetricStringEncryptionProvider>();
        var key = Convert.FromBase64String("t3OD+5YCKzCdGSaWBAvkQ9+d9R4ZbZnC9YG8L/ar8vA=");
        _odsConnectionStringEncryptionApplicator = new OdsConnectionStringEncryptionApplicator(key, _stringEncryptionProvider);
    }

    [Test]
    public void DecryptOrApplyEncryption_ShouldEncryptAnUndecryptableConnectionString()
    {
        // Arrange
        A.CallTo(() => _stringEncryptionProvider.Encrypt(A<string>._, A<byte[]>._))
            .Returns("encrypted");
        string decryptedString = null;

        A.CallTo(() => _stringEncryptionProvider.TryDecrypt(A<string>._, out decryptedString, A<byte[]>._))
            .Returns(false);

        // Act
        var dataRow = new RawOdsInstanceConfigurationDataRow() { OdsInstanceId = 1, ConnectionString = "plaintext"};
        var result = _odsConnectionStringEncryptionApplicator.DecryptOrApplyEncryption(dataRow, out bool rowChanged);

        // Assert
        result.ShouldBe("plaintext");
        rowChanged.ShouldBeTrue();
        dataRow.ConnectionString.ShouldBe("encrypted");
    }
    
    [Test]
    public void DecryptOrApplyEncryption_ShouldDecryptValidEncryptedConnectionString()
    {
        // Arrange
        string decryptedString = "plaintext";
        A.CallTo(() => _stringEncryptionProvider.TryDecrypt(A<string>._, out decryptedString, A<byte[]>._))
            .Returns(true);

        // Act
        var dataRow = new RawOdsInstanceConfigurationDataRow() { OdsInstanceId = 1, ConnectionString = "encrypted"};
        var result = _odsConnectionStringEncryptionApplicator.DecryptOrApplyEncryption(dataRow, out bool rowChanged);

        // Assert
        result.ShouldBe("plaintext");
        rowChanged.ShouldBeFalse();
        dataRow.ConnectionString.ShouldBe("encrypted");
    }
}
