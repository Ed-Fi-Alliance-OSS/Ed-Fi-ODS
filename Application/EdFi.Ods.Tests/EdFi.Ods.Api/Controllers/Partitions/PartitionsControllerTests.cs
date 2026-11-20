// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using EdFi.Ods.Api.Controllers.Partitions.Controllers;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Specifications;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Controllers.Partitions;

[TestFixture]
public class PartitionsControllerTests
{
    private const string CorrelationId = "ods-6881-correlation-id";
    private const string AllowSmallPartitionsError = "The 'allowSmallPartitions' parameter must be 'true' or 'false'.";
    private const string NumberError = "Number of partitions must be between 1 and 200.";

    private IContextProvider<DataManagementResourceContext> _resourceContextProvider;
    private PartitionsController _controller;

    [SetUp]
    public void SetUp()
    {
        var personTypesProvider = A.Fake<IPersonTypesProvider>();
        A.CallTo(() => personTypesProvider.PersonTypes).Returns(Array.Empty<string>());

        // With no resource in the context, a request that passes validation ends in a 404 before any database work.
        _resourceContextProvider = A.Fake<IContextProvider<DataManagementResourceContext>>();
        A.CallTo(() => _resourceContextProvider.Get()).Returns(null);

        var logContextAccessor = A.Fake<ILogContextAccessor>();
        A.CallTo(() => logContextAccessor.GetValue(CorrelationConstants.LogContextKey)).Returns(CorrelationId);

        _controller = new PartitionsController(
            A.Fake<DbProviderFactory>(),
            _resourceContextProvider,
            A.Fake<IOdsDatabaseConnectionStringProvider>(),
            logContextAccessor,
            A.Fake<IPartitionsQueryBuilderProvider>(),
            personTypesProvider,
            A.Fake<IContextProvider<UsiLookupsByUniqueIdContext>>(),
            A.Fake<IContextualPersonUsisResolver>());
    }

    [TestCase("allowSmallPartitions", "yes")]
    [TestCase("allowSmallPartitions", "1")]
    [TestCase("allowSmallPartitions", "true,false")]
    [TestCase("allowSmallPartitions", "true; DROP TABLE x")]
    [TestCase("AllowSmallPartitions", "yes")]
    public async Task Should_return_bad_request_when_allowSmallPartitions_is_not_a_boolean(string name, string value)
    {
        var result = await Get(null, new Dictionary<string, string> { [name] = value });

        ShouldBeBadRequest(result, AllowSmallPartitionsError);
    }

    [TestCase("true")]
    [TestCase("True")]
    [TestCase("false")]
    [TestCase("FALSE")]
    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public async Task Should_accept_a_boolean_or_empty_allowSmallPartitions(string value)
    {
        var result = await Get(null, new Dictionary<string, string> { [PartitionsParameters.AllowSmallPartitions] = value });

        ShouldPassValidation(result);
    }

    [Test]
    public async Task Should_accept_a_request_without_allowSmallPartitions()
    {
        var result = await Get(null, new Dictionary<string, string>());

        ShouldPassValidation(result);
    }

    [TestCase(0)]
    [TestCase(201)]
    public async Task Should_return_bad_request_when_the_number_of_partitions_is_out_of_range(int number)
    {
        var result = await Get(number, new Dictionary<string, string>());

        ShouldBeBadRequest(result, NumberError);
    }

    [Test]
    public async Task Should_report_the_number_of_partitions_first_when_both_parameters_are_invalid()
    {
        var result = await Get(0, new Dictionary<string, string> { [PartitionsParameters.AllowSmallPartitions] = "yes" });

        ShouldBeBadRequest(result, NumberError);
    }

    private Task<IActionResult> Get(int? number, Dictionary<string, string> additionalParameters)
        => _controller.Get(number, new UrlQueryParametersRequest(), additionalParameters);

    private void ShouldBeBadRequest(IActionResult result, string expectedError)
    {
        var badRequest = result.ShouldBeOfType<BadRequestObjectResult>();
        var problemDetails = badRequest.Value.ShouldBeAssignableTo<IEdFiProblemDetails>();

        problemDetails.ShouldSatisfyAllConditions(
            () => problemDetails.Status.ShouldBe(StatusCodes.Status400BadRequest),
            () => problemDetails.Type.ShouldEndWith("parameter-validation-failed"),
            () => problemDetails.Errors.ShouldBe([expectedError]),
            () => problemDetails.CorrelationId.ShouldBe(CorrelationId));

        A.CallTo(() => _resourceContextProvider.Get()).MustNotHaveHappened();
    }

    private void ShouldPassValidation(IActionResult result)
    {
        result.ShouldNotBeOfType<BadRequestObjectResult>();
        result.ShouldBeAssignableTo<IStatusCodeActionResult>().StatusCode.ShouldBe(StatusCodes.Status404NotFound);

        A.CallTo(() => _resourceContextProvider.Get()).MustHaveHappened();
    }
}
