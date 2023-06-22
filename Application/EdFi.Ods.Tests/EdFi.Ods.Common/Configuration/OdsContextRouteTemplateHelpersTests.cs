// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Common.Configuration;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Configuration;

[TestFixture]
public class OdsContextRouteTemplateHelpersTests
{
    // See: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-7.0#route-constraints
    private const string RegexRouteConstraint = "{ssn:regex(^\\d{{3}}-\\d{{2}}-\\d{{4}}$)}"; 
    private const string RangeRouteConstraint = "{age:range(18,120)}"; 
    private const string SimpleRouteConstraint = "{name:alpha}"; 
    
    [Test]
    public void GetRouteTemplateKeys_WithTemplateContainingRegexConstraint_ReturnsPathWithRouteConstraintRemoved()
    {
        string template = $"leadingPath/segmentPrefix-{RegexRouteConstraint}/{{anotherKey}}/trailingPath";

        var keys = OdsContextRouteTemplateHelpers.GetRouteTemplateKeys(template);
        
        keys.ShouldBe(new []{ "ssn", "anotherKey" });
    }

    [Test]
    public void GetRouteTemplateKeys_WithTemplateContainingRangeConstraint_ReturnsPathWithRouteConstraintRemoved()
    {
        string template = $"leadingPath/segmentPrefix-{RangeRouteConstraint}/{{anotherKey}}/trailingPath";

        var keys = OdsContextRouteTemplateHelpers.GetRouteTemplateKeys(template);
        
        keys.ShouldBe(new []{ "age", "anotherKey" });
    }

    [Test]
    public void GetRouteTemplateKeys_WithTemplateContainingSimpleConstraint_ReturnsPathWithRouteConstraintRemoved()
    {
        string template = $"leadingPath/segmentPrefix-{SimpleRouteConstraint}/{{anotherKey}}/trailingPath";

        var keys = OdsContextRouteTemplateHelpers.GetRouteTemplateKeys(template);
        
        keys.ShouldBe(new []{ "name", "anotherKey" });
    }

    [Test]
    public void GetPathCharacters_WithTemplateContainingMultipleConstraints_ReturnsCharactersForPathPreservingLiteralPathCharactersWithAllConstraintsStripped()
    {
        string template = $"leadingPath/{RegexRouteConstraint}/segmentPrefix-{SimpleRouteConstraint}/before-{{anotherKey}}-after/trailingPath";

        string result = new string(OdsContextRouteTemplateHelpers.GetOdsContextPathChars(template).ToArray());
        
        result.ShouldBe("leadingPath/{ssn}/segmentPrefix-{name}/before-{anotherKey}-after/trailingPath");
    }
    
    [TestCase($"leadingPath/{RegexRouteConstraint}/segmentPrefix-{{Unclosed")]
    [TestCase($"leadingPath/{RegexRouteConstraint}/segmentPrefix-{{Incomplete:range(")]
    public void GetPathCharacters_WithInvalidTemplate_ThrowsArgumentException(string invalidTemplate)
    {
        Should.Throw<ArgumentException>(() => OdsContextRouteTemplateHelpers.GetOdsContextPathChars(invalidTemplate).ToArray())
            .Message.ShouldBe("Invalid ODS context route template.");
    }
}
