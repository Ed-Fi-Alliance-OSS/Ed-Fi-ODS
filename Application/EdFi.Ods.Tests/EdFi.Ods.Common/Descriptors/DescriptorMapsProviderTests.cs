// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Descriptors;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Descriptors;

using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

[TestFixture]
public class DescriptorMapsProviderTests
{
    [TestCase(true)]
    [TestCase(false)]
    public void GetMaps_ReturnsExpectedDescriptorMaps(bool useCaseInsensitiveCollation)
    {
        // Arrange
        var descriptorDetailsProvider = A.Fake<IDescriptorDetailsProvider>();
        var equalityComparerProvider = A.Fake<IDatabaseEngineSpecificEqualityComparerProvider<string>>();
        
        A.CallTo(() => descriptorDetailsProvider.GetAllDescriptorDetails()).Returns(GetSampleDescriptorDetails());
        
        A.CallTo(() => equalityComparerProvider.GetEqualityComparer())
            .Returns(useCaseInsensitiveCollation ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
        
        var provider = new DescriptorMapsProvider(descriptorDetailsProvider, equalityComparerProvider);

        // Act
        var maps = provider.GetMaps();

        // Assert
        maps.ShouldNotBeNull();
        maps.DescriptorIdByUri.ShouldNotBeNull();
        maps.UriByDescriptorId.ShouldNotBeNull();

        maps.DescriptorIdByUri.Count.ShouldBe(2);
        maps.UriByDescriptorId.Count.ShouldBe(2);

        maps.DescriptorIdByUri["http://ed-fi.org/TestDescriptor#1"].ShouldBe(1);
        maps.DescriptorIdByUri["http://ed-fi.org/TestDescriptor#2"].ShouldBe(2);

        // Ensure correct collation was used
        maps.DescriptorIdByUri.ContainsKey("http://ed-fi.org/TestDescriptor#1".ToUpper()).ShouldBe(useCaseInsensitiveCollation);
        maps.DescriptorIdByUri.ContainsKey("http://ed-fi.org/TestDescriptor#2".ToUpper()).ShouldBe(useCaseInsensitiveCollation);
        
        maps.UriByDescriptorId[1].ShouldBe("http://ed-fi.org/TestDescriptor#1");
        maps.UriByDescriptorId[2].ShouldBe("http://ed-fi.org/TestDescriptor#2");
    }

    private static List<DescriptorDetails> GetSampleDescriptorDetails()
    {
        return new List<DescriptorDetails>
        {
            new() { DescriptorId = 1, Namespace = "http://ed-fi.org/TestDescriptor", CodeValue = "1" },
            new() { DescriptorId = 2, Namespace = "http://ed-fi.org/TestDescriptor", CodeValue = "2" },
        };
    }
}
