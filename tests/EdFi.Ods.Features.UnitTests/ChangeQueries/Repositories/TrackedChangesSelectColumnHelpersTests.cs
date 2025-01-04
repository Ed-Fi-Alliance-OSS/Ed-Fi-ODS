// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Features.ChangeQueries.Repositories;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Features.UnitTests.ChangeQueries.Repositories;

[TestFixture]
public class TrackedChangesSelectColumnHelpersTests
{
    private IDatabaseNamingConvention? _namingConvention = null;

    [SetUp]
    public void SetUp()
    {
        _namingConvention = A.Fake<IDatabaseNamingConvention>();
    }
    
    [Test]
    public void GetSelectColumnsForSurrogateIdentifierUsage_ShouldHandleDescriptorsContainingNaturalIdentifierPropertyNames()
    {
        // See ODS-6490 

        // Arrange
        string entityPropertyName = "ImmunizationCodeDescriptorId";
        var naturalIdentifyingPropertyNames = new[] { "Namespace", "CodeValue" };

        A.CallTo(() => _namingConvention!.ColumnName(A<string>.Ignored, A<string>.Ignored))
            .ReturnsLazily((string input, string suffix) => input);

        // Act
        var result = TrackedChangesSelectColumnHelpers.GetSelectColumnsForSurrogateIdentifierUsage(
            entityPropertyName,
            naturalIdentifyingPropertyNames,
            _namingConvention)
            .ToList();

        // Assert
        result.ShouldNotBeNull();
        result.Count.ShouldBe(4); // 2 natural properties x 2 column groups (OldValue, NewValue)

        // Validate Old and New groups
        result[0].ColumnName.ShouldBe("OldImmunizationCodeDescriptorNamespace");
        result[0].ColumnGroup.ShouldBe(ColumnGroups.OldValue);

        result[1].ColumnName.ShouldBe("NewImmunizationCodeDescriptorNamespace");
        result[1].ColumnGroup.ShouldBe(ColumnGroups.NewValue);
        
        result[2].ColumnName.ShouldBe("OldImmunizationCodeDescriptorCodeValue");
        result[2].ColumnGroup.ShouldBe(ColumnGroups.OldValue);
        
        result[3].ColumnName.ShouldBe("NewImmunizationCodeDescriptorCodeValue");
        result[3].ColumnGroup.ShouldBe(ColumnGroups.NewValue);
    }

    [Test]
    public void GetSelectColumnsForSurrogateIdentifierUsage_ShouldHandleUniqueIdsContainingNaturalIdentifierPropertyNames()
    {
        // Arrange
        string entityPropertyName = "ReportingStaffUSI";
        var naturalIdentifyingPropertyNames = new[] { "StaffUniqueId" };

        A.CallTo(() => _namingConvention!.ColumnName(A<string>.Ignored, A<string>.Ignored))
            .ReturnsLazily((string input, string suffix) => input);

        // Act
        var result = TrackedChangesSelectColumnHelpers.GetSelectColumnsForSurrogateIdentifierUsage(
            entityPropertyName,
            naturalIdentifyingPropertyNames,
            _namingConvention)
            .ToList();

        // Assert
        result.ShouldNotBeNull();
        result.Count.ShouldBe(2); // 1 natural properties x 2 column groups (OldValue, NewValue)

        // Validate Old and New groups
        result[0].ColumnName.ShouldBe("OldReportingStaffUniqueId");
        result[0].ColumnGroup.ShouldBe(ColumnGroups.OldValue);

        result[1].ColumnName.ShouldBe("NewReportingStaffUniqueId");
        result[1].ColumnGroup.ShouldBe(ColumnGroups.NewValue);
    }
}
