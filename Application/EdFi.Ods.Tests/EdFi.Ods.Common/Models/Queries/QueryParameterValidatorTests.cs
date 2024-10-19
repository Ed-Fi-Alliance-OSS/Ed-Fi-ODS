// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Models.Queries;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Queries;

[TestFixture]
public class QueryParametersValidatorTests
{
    private const int DefaultPageLimitSize = 100;
    
    [Flags]
    public enum Parameters
    {
        None = 0,
        PageSize = 1, 
        PageToken = 2,
        Limit = 4,
        Offset = 8,
    }

    [TestCase(true, Parameters.None)]
    [TestCase(false, Parameters.PageSize, "pageToken is required when pageSize is specified.")]
    [TestCase(true, Parameters.PageToken)]
    [TestCase(true, Parameters.PageToken | Parameters.PageSize)]
    [TestCase(true, Parameters.Limit)]
    [TestCase(true, Parameters.Limit | Parameters.PageSize)]
    [TestCase(false, Parameters.Limit | Parameters.PageToken, "Use pageSize instead of limit when using cursor paging with pageToken.")]
    [TestCase(true, Parameters.Limit | Parameters.PageToken | Parameters.PageSize)]
    [TestCase(true, Parameters.Offset)]
    [TestCase(false, Parameters.Offset | Parameters.PageSize, "pageSize cannot be used with limit/offset paging.")]
    [TestCase(false, Parameters.Offset | Parameters.PageToken, "Both offset and pageToken parameters were provided, but they support alternative paging approaches and cannot be used together.")]
    [TestCase(false, Parameters.Offset | Parameters.PageToken | Parameters.PageSize, "Both offset and pageToken parameters were provided, but they support alternative paging approaches and cannot be used together.")]
    [TestCase(true, Parameters.Offset | Parameters.Limit)]
    [TestCase(true, Parameters.Offset | Parameters.Limit | Parameters.PageSize)]
    [TestCase(false, Parameters.Offset | Parameters.Limit | Parameters.PageToken, "Both offset and pageToken parameters were provided, but they support alternative paging approaches and cannot be used together.")]
    [TestCase(false, Parameters.Offset | Parameters.Limit | Parameters.PageToken | Parameters.PageSize, "Both offset and pageToken parameters were provided, but they support alternative paging approaches and cannot be used together.")]
    public void When_valid_parameters_are_provided_in_various_combinations(bool isValid, Parameters parameters, string validationMessage = null)
    {
        // Arrange
        var queryParameters = A.Fake<IQueryParameters>();

        if ((parameters & Parameters.Limit) != Parameters.None)
        {
            queryParameters.Limit = 50;
        }

        if ((parameters & Parameters.Offset) != Parameters.None)
        {
            queryParameters.Offset = 50;
        }

        if ((parameters & Parameters.PageToken) != Parameters.None)
        {
            queryParameters.MinAggregateId = 1;
            queryParameters.MaxAggregateId = 100;
        }

        if ((parameters & Parameters.PageSize) != Parameters.None)
        {
            queryParameters.PageSize = 50;
        }

        string errorMessage;

        // Act
        var result = QueryParametersValidator.IsValid(queryParameters, DefaultPageLimitSize, out errorMessage);

        // Assert
        if (isValid)
        {
            result.ShouldBeTrue();
            errorMessage.ShouldBeNull();
        }
        else
        {
            result.ShouldBeFalse();
            errorMessage.ShouldBe(validationMessage);
        }
    }

    [Test]
    public void IsValid_WithNegativeOffset_ShouldReturnFalseWithErrorMessage()
    {
        // Arrange
        var queryParameters = A.Fake<IQueryParameters>();
        queryParameters.Offset = -1;

        string errorMessage;

        // Act
        var result = QueryParametersValidator.IsValid(queryParameters, DefaultPageLimitSize, out errorMessage);

        // Assert
        result.ShouldBeFalse();
        errorMessage.ShouldBe("offset cannot be a negative value.");
    }

    [Test]
    public void IsValid_WithNegativeLimit_ShouldReturnFalseWithErrorMessage()
    {
        // Arrange
        var queryParameters = A.Fake<IQueryParameters>();
        queryParameters.Limit = -1;

        string errorMessage;

        // Act
        var result = QueryParametersValidator.IsValid(queryParameters, DefaultPageLimitSize, out errorMessage);

        // Assert
        result.ShouldBeFalse();
        errorMessage.ShouldBe("limit cannot be a negative value.");
    }

    [Test]
    public void IsValid_WithLimitGreaterThanDefaultPageLimit_ShouldReturnFalseWithErrorMessage()
    {
        // Arrange
        var queryParameters = A.Fake<IQueryParameters>();
        queryParameters.Limit = DefaultPageLimitSize + 1;

        string errorMessage;

        // Act
        var result = QueryParametersValidator.IsValid(queryParameters, DefaultPageLimitSize, out errorMessage);

        // Assert
        result.ShouldBeFalse();
        errorMessage.ShouldBe($"limit cannot be greater than {DefaultPageLimitSize}.");
    }

    [Test]
    public void IsValid_WithLimitEqualToTheDefaultPageLimit_ShouldReturnTrueWithNullMessage()
    {
        // Arrange
        var queryParameters = A.Fake<IQueryParameters>();
        queryParameters.Limit = DefaultPageLimitSize;

        string errorMessage;

        // Act
        var result = QueryParametersValidator.IsValid(queryParameters, DefaultPageLimitSize, out errorMessage);

        // Assert
        result.ShouldBeTrue();
        errorMessage.ShouldBeNull();
    }

    [Test]
    public void IsValid_WithNegativePageSize_ShouldReturnFalseWithErrorMessage()
    {
        // Arrange
        var queryParameters = A.Fake<IQueryParameters>();
        queryParameters.MinAggregateId = 1;
        queryParameters.MaxAggregateId = 100;
        queryParameters.PageSize = -1;

        string errorMessage;

        // Act
        var result = QueryParametersValidator.IsValid(queryParameters, DefaultPageLimitSize, out errorMessage);

        // Assert
        result.ShouldBeFalse();
        errorMessage.ShouldBe("pageSize cannot be a negative value.");
    }

    [Test]
    public void IsValid_WithPageSizeGreaterThanDefaultLimit_ShouldReturnFalseWithErrorMessage()
    {
        // Arrange
        var queryParameters = A.Fake<IQueryParameters>();
        queryParameters.MinAggregateId = 1;
        queryParameters.MaxAggregateId = 100;
        queryParameters.PageSize = DefaultPageLimitSize + 1;

        string errorMessage;

        // Act
        var result = QueryParametersValidator.IsValid(queryParameters, DefaultPageLimitSize, out errorMessage);

        // Assert
        result.ShouldBeFalse();
        errorMessage.ShouldBe($"pageSize cannot be greater than {DefaultPageLimitSize}.");
    }

    [Test]
    public void IsValid_WithPageSizeEqualToDefaultLimit_ShouldReturnTrueWithNullMessage()
    {
        // Arrange
        var queryParameters = A.Fake<IQueryParameters>();
        queryParameters.MinAggregateId = 1;
        queryParameters.MaxAggregateId = 100;
        queryParameters.PageSize = DefaultPageLimitSize;

        string errorMessage;

        // Act
        var result = QueryParametersValidator.IsValid(queryParameters, DefaultPageLimitSize, out errorMessage);

        // Assert
        result.ShouldBeTrue();
        errorMessage.ShouldBeNull();
    }
}
