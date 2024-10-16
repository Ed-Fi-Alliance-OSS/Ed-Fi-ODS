// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Caching;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Caching;

using NUnit.Framework;
using Shouldly;
using Standart.Hash.xxHash;

[TestFixture]
public class XxHash3CodeTests
{
    [Test]
    public void Combine_OneParameter_ShouldReturnExpectedHash()
    {
        // Arrange
        var value1 = "test string";
        int value1Length = value1.GetByteLength();

        var buffer = new byte[value1Length];
        value1.CopyTo(buffer.AsSpan());

        // Act
        ulong result = XxHash3Code.Combine(value1);

        // Assert
        result.ShouldBe(xxHash3.ComputeHash(buffer, value1Length));
    }

    [Test]
    public void Combine_TwoParameters_ShouldReturnExpectedHash()
    {
        // Arrange
        var value1 = 12345;
        var value2 = "another test";

        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();

        var buffer = new byte[value1Length + value2Length];
        value1.CopyTo(buffer.AsSpan(0, value1Length));
        value2.CopyTo(buffer.AsSpan(value1Length, value2Length));

        // Act
        ulong result = XxHash3Code.Combine(value1, value2);

        // Assert
        result.ShouldBe(xxHash3.ComputeHash(buffer, value1Length + value2Length));
    }

    [Test]
    public void Combine_ThreeParameters_ShouldReturnExpectedHash()
    {
        // Arrange
        var value1 = 12345;
        var value2 = "test value";
        var value3 = DateTime.UtcNow;

        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();
        int value3Length = value3.GetByteLength();

        var buffer = new byte[value1Length + value2Length + value3Length];
        value1.CopyTo(buffer.AsSpan(0, value1Length));
        value2.CopyTo(buffer.AsSpan(value1Length, value2Length));
        value3.CopyTo(buffer.AsSpan(value1Length + value2Length, value3Length));

        // Act
        ulong result = XxHash3Code.Combine(value1, value2, value3);

        // Assert
        result.ShouldBe(xxHash3.ComputeHash(buffer, value1Length + value2Length + value3Length));
    }

    [Test]
    public void Combine_FourParameters_ShouldReturnExpectedHash()
    {
        // Arrange
        var value1 = 12345;
        var value2 = "test value";
        var value3 = DateTime.UtcNow;
        var value4 = 98765;

        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();
        int value3Length = value3.GetByteLength();
        int value4Length = value4.GetByteLength();

        var buffer = new byte[value1Length + value2Length + value3Length + value4Length];
        value1.CopyTo(buffer.AsSpan(0, value1Length));
        value2.CopyTo(buffer.AsSpan(value1Length, value2Length));
        value3.CopyTo(buffer.AsSpan(value1Length + value2Length, value3Length));
        value4.CopyTo(buffer.AsSpan(value1Length + value2Length + value3Length, value4Length));

        // Act
        ulong result = XxHash3Code.Combine(value1, value2, value3, value4);

        // Assert
        result.ShouldBe(xxHash3.ComputeHash(buffer, value1Length + value2Length + value3Length + value4Length));
    }

    [Test]
    public void Combine_FiveParameters_ShouldReturnExpectedHash()
    {
        // Arrange
        var value1 = 12345;
        var value2 = "test value";
        var value3 = DateTime.UtcNow;
        var value4 = 98765;
        var value5 = TimeSpan.FromHours(2);

        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();
        int value3Length = value3.GetByteLength();
        int value4Length = value4.GetByteLength();
        int value5Length = value5.GetByteLength();

        var buffer = new byte[value1Length + value2Length + value3Length + value4Length + value5Length];
        value1.CopyTo(buffer.AsSpan(0, value1Length));
        value2.CopyTo(buffer.AsSpan(value1Length, value2Length));
        value3.CopyTo(buffer.AsSpan(value1Length + value2Length, value3Length));
        value4.CopyTo(buffer.AsSpan(value1Length + value2Length + value3Length, value4Length));
        value5.CopyTo(buffer.AsSpan(value1Length + value2Length + value3Length + value4Length, value5Length));

        // Act
        ulong result = XxHash3Code.Combine(value1, value2, value3, value4, value5);

        // Assert
        result.ShouldBe(xxHash3.ComputeHash(buffer, value1Length + value2Length + value3Length + value4Length + value5Length));
    }

    [Test]
    public void Combine_SixParameters_ShouldReturnExpectedHash()
    {
        // Arrange
        var value1 = 12345;
        var value2 = "test value";
        var value3 = DateTime.UtcNow;
        var value4 = 98765;
        var value5 = TimeSpan.FromHours(2);
        var value6 = "final value";

        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();
        int value3Length = value3.GetByteLength();
        int value4Length = value4.GetByteLength();
        int value5Length = value5.GetByteLength();
        int value6Length = value6.GetByteLength();

        var buffer = new byte[value1Length + value2Length + value3Length + value4Length + value5Length + value6Length];
        value1.CopyTo(buffer.AsSpan(0, value1Length));
        value2.CopyTo(buffer.AsSpan(value1Length, value2Length));
        value3.CopyTo(buffer.AsSpan(value1Length + value2Length, value3Length));
        value4.CopyTo(buffer.AsSpan(value1Length + value2Length + value3Length, value4Length));
        value5.CopyTo(buffer.AsSpan(value1Length + value2Length + value3Length + value4Length, value5Length));
        value6.CopyTo(buffer.AsSpan(value1Length + value2Length + value3Length + value4Length + value5Length, value6Length));

        // Act
        ulong result = XxHash3Code.Combine(value1, value2, value3, value4, value5, value6);

        // Assert
        result.ShouldBe(xxHash3.ComputeHash(buffer, value1Length + value2Length + value3Length + value4Length + value5Length + value6Length));
    }

    [Test]
    public void Combine_TwoStringListsWithSameLinearTextSplitDifferently_ShouldReturnDifferentHashes()
    {
        // Arrange
        var list1 = new List<string>
        {
            "AB",
            "CD",
            "EF"
        };

        var list2 = new List<string>
        {
            "ABC",
            "DEF"
        };

        // Act
        ulong result1 = XxHash3Code.Combine(list1);
        ulong result2 = XxHash3Code.Combine(list2);

        // Assert
        result1.ShouldNotBe(result2);
    }

    [Test]
    public void Combine_TwoStringListsWithNullVsEmptyItem_ShouldReturnSameHash()
    {
        // Arrange
        var list1 = new List<string>
        {
            "AB",
            "",
            "EF"
        };

        var list2 = new List<string>
        {
            "AB",
            null,
            "EF"
        };

        // Act
        ulong result1 = XxHash3Code.Combine(list1);
        ulong result2 = XxHash3Code.Combine(list2);

        // Assert
        result1.ShouldBe(result2);
    }
}
