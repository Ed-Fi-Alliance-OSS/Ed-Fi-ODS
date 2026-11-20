// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Controllers.Partitions.Controllers;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Controllers.Partitions;

[TestFixture]
public class PartitionsParametersTests
{
    [TestCase("true", true)]
    [TestCase("True", true)]
    [TestCase(" true ", true)]
    [TestCase("false", false)]
    [TestCase("FALSE", false)]
    public void Should_read_a_boolean_value(string value, bool expected)
    {
        var parameters = new Dictionary<string, string> { [PartitionsParameters.AllowSmallPartitions] = value };

        PartitionsParameters.TryGetAllowSmallPartitions(parameters, out bool allowSmallPartitions).ShouldBeTrue();
        allowSmallPartitions.ShouldBe(expected);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void Should_treat_an_empty_value_as_not_supplied(string value)
    {
        var parameters = new Dictionary<string, string> { [PartitionsParameters.AllowSmallPartitions] = value };

        PartitionsParameters.TryGetAllowSmallPartitions(parameters, out bool allowSmallPartitions).ShouldBeTrue();
        allowSmallPartitions.ShouldBeFalse();
    }

    [Test]
    public void Should_not_allow_small_partitions_when_the_parameter_is_absent()
    {
        PartitionsParameters.TryGetAllowSmallPartitions(new Dictionary<string, string>(), out bool allowSmallPartitions)
            .ShouldBeTrue();

        allowSmallPartitions.ShouldBeFalse();

        PartitionsParameters.TryGetAllowSmallPartitions(null, out allowSmallPartitions).ShouldBeTrue();
        allowSmallPartitions.ShouldBeFalse();
    }

    [TestCase("yes")]
    [TestCase("1")]
    [TestCase("true,false")]
    [TestCase("true; DROP TABLE x")]
    public void Should_reject_a_value_that_is_not_a_boolean(string value)
    {
        var parameters = new Dictionary<string, string> { [PartitionsParameters.AllowSmallPartitions] = value };

        PartitionsParameters.TryGetAllowSmallPartitions(parameters, out bool allowSmallPartitions).ShouldBeFalse();
        allowSmallPartitions.ShouldBeFalse();
    }

    [TestCase("AllowSmallPartitions", "true", true, true)]
    [TestCase("ALLOWSMALLPARTITIONS", "true", true, true)]
    [TestCase("AllowSmallPartitions", "yes", false, false)]
    public void Should_match_the_parameter_name_in_any_case(
        string name,
        string value,
        bool expectedValid,
        bool expectedAllowSmallPartitions)
    {
        var parameters = new Dictionary<string, string> { [name] = value };

        PartitionsParameters.TryGetAllowSmallPartitions(parameters, out bool allowSmallPartitions).ShouldBe(expectedValid);
        allowSmallPartitions.ShouldBe(expectedAllowSmallPartitions);
    }
}
