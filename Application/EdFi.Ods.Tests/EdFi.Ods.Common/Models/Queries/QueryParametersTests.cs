// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models.Queries;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Queries;

[TestFixture]
public class QueryParametersTests
{
    [TestCase("firstName:john", "firstName", "john", TextMatchMode.Exact)]
    [TestCase("firstName:jo*", "firstName", "jo", TextMatchMode.Start)]
    [TestCase("lastName:*son", "lastName", "son", TextMatchMode.End)]
    [TestCase("lastName:*ohn*", "lastName", "ohn", TextMatchMode.Anywhere)]
    [TestCase("LastName:SMITH", "LastName", "SMITH", TextMatchMode.Exact)]
    public void Should_parse_a_text_expression_into_a_text_criteria(
        string q,
        string expectedPropertyName,
        string expectedValue,
        TextMatchMode expectedMatchMode)
    {
        var queryParameters = new QueryParameters { Q = q };

        var criteria = queryParameters.QueryCriteria.ShouldHaveSingleItem().ShouldBeOfType<TextCriteria>();
        criteria.PropertyName.ShouldBe(expectedPropertyName);
        criteria.Value.ShouldBe(expectedValue);
        criteria.MatchMode.ShouldBe(expectedMatchMode);
    }

    [Test]
    public void Should_parse_each_text_expression_and_skip_range_and_quoted_expressions()
    {
        var queryParameters = new QueryParameters
        {
            Q = "firstName:jo*,age:[1 to 10],birthDate:[2010-01-01 to 2011-01-01],city:'new york',lastName:smith"
        };

        queryParameters.QueryCriteria.Cast<TextCriteria>()
            .Select(c => c.PropertyName)
            .ShouldBe(["firstName", "lastName"]);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("no expression here")]
    public void Should_produce_no_criteria_when_there_is_no_text_expression(string q)
    {
        var queryParameters = new QueryParameters { Q = q };

        queryParameters.QueryCriteria.ShouldBeEmpty();
    }

    [Test]
    public void Should_parse_a_query_value_as_long_as_the_default_request_line_limit()
    {
        // Kestrel's default MaxRequestLineSize is 8 KB.
        string q = string.Join(",", Enumerable.Repeat("firstName:*abc*", 250)) + "," + new string('a', 4096);

        var queryParameters = new QueryParameters { Q = q };

        queryParameters.QueryCriteria.Count.ShouldBe(250);
    }

    [Test]
    public void Should_return_a_bad_request_when_matching_times_out()
    {
        // A long run of letters with no ':' makes "[a-z]+\:" retry from every position (quadratic time).
        string q = new string('a', 1_000_000);

        var exception = Should.Throw<BadRequestParameterException>(() => new QueryParameters { Q = q });

        exception.InnerException.ShouldBeOfType<RegexMatchTimeoutException>();
        ((IEdFiProblemDetails)exception).Errors.ShouldBe(["The query expression parameter 'q' could not be processed."]);
    }

    [Test]
    public void Should_match_the_query_expression_with_a_timeout_and_reuse_the_same_regex()
    {
        var regexFactory = typeof(QueryParameters).GetMethod(
            "QueryExpressionRegex",
            BindingFlags.NonPublic | BindingFlags.Static);

        regexFactory.ShouldNotBeNull();

        var regex = (Regex)regexFactory.Invoke(null, null);

        regex.MatchTimeout.ShouldBe(TimeSpan.FromSeconds(1));
        regexFactory.Invoke(null, null).ShouldBeSameAs(regex);
    }
}
