// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Startup;
using EdFi.Ods.Common.Configuration;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Startup;

[TestFixture]
public class CorsOptionsConfiguratorTests
{
    private static CorsPolicy GetPolicy(List<string> corsAllowedOrigins)
    {
        var configurator = new CorsOptionsConfigurator(new ApiSettings { CorsAllowedOrigins = corsAllowedOrigins });
        var options = new CorsOptions();

        configurator.Configure(options);

        return options.GetPolicy(CorsOptionsConfigurator.PolicyName);
    }

    [Test]
    public void Should_allow_any_origin_when_no_origins_are_configured()
    {
        var policy = GetPolicy(new List<string>());

        policy.ShouldNotBeNull();
        policy.AllowAnyOrigin.ShouldBeTrue();
        policy.AllowAnyMethod.ShouldBeTrue();
        policy.AllowAnyHeader.ShouldBeTrue();
        policy.ExposedHeaders.ShouldBe(new[] { "*" });
        policy.SupportsCredentials.ShouldBeFalse();
    }

    [Test]
    public void Should_allow_any_origin_when_the_setting_is_null()
    {
        var policy = GetPolicy(null);

        policy.AllowAnyOrigin.ShouldBeTrue();
    }

    [Test]
    public void Should_allow_any_origin_when_only_blank_origins_are_configured()
    {
        var policy = GetPolicy(new List<string> { "", "  " });

        policy.AllowAnyOrigin.ShouldBeTrue();
    }

    [Test]
    public void Should_allow_only_the_configured_origins()
    {
        var policy = GetPolicy(new List<string> { "https://swagger.example.org", "http://localhost:5002" });

        policy.AllowAnyOrigin.ShouldBeFalse();
        policy.Origins.ShouldBe(new[] { "https://swagger.example.org", "http://localhost:5002" });
        policy.IsOriginAllowed("https://swagger.example.org").ShouldBeTrue();
        policy.IsOriginAllowed("https://evil.example.com").ShouldBeFalse();
        policy.AllowAnyMethod.ShouldBeTrue();
        policy.AllowAnyHeader.ShouldBeTrue();
        policy.SupportsCredentials.ShouldBeFalse();
    }

    [Test]
    public void Should_trim_whitespace_and_trailing_slashes_from_configured_origins()
    {
        var policy = GetPolicy(new List<string> { " https://swagger.example.org/ " });

        policy.Origins.ShouldBe(new[] { "https://swagger.example.org" });
        policy.IsOriginAllowed("https://swagger.example.org").ShouldBeTrue();
    }

    [Test]
    public void Should_ignore_duplicate_origins()
    {
        var policy = GetPolicy(new List<string> { "https://swagger.example.org", "https://SWAGGER.example.org/" });

        policy.Origins.Count.ShouldBe(1);
    }

    [TestCase("*")]
    [TestCase("swagger.example.org")]
    [TestCase("ftp://swagger.example.org")]
    [TestCase("https://swagger.example.org/swagger")]
    [TestCase("https://swagger.example.org?x=1")]
    [TestCase("https://user@swagger.example.org")]
    public void Should_reject_an_invalid_origin(string origin)
    {
        var configurator = new CorsOptionsConfigurator(new ApiSettings { CorsAllowedOrigins = new List<string> { origin } });

        Should.Throw<InvalidOperationException>(() => configurator.Configure(new CorsOptions()))
            .Message.ShouldContain(nameof(ApiSettings.CorsAllowedOrigins));

        Should.Throw<InvalidOperationException>(() => configurator.AllowsAnyOrigin);
    }

    [Test]
    public void Should_register_the_policy_with_the_options_pipeline()
    {
        // Mirrors the registration in OdsStartupBase
        var services = new ServiceCollection();
        services.AddCors();
        services.AddSingleton<IConfigureOptions<CorsOptions>>(
            new CorsOptionsConfigurator(new ApiSettings { CorsAllowedOrigins = new List<string> { "https://swagger.example.org" } }));

        using var serviceProvider = services.BuildServiceProvider();

        var policy = serviceProvider.GetRequiredService<IOptions<CorsOptions>>().Value.GetPolicy(CorsOptionsConfigurator.PolicyName);

        policy.ShouldNotBeNull();
        policy.Origins.ShouldBe(new[] { "https://swagger.example.org" });
    }

    [Test]
    public void AllowsAnyOrigin_should_reflect_the_configured_origins()
    {
        new CorsOptionsConfigurator(new ApiSettings()).AllowsAnyOrigin.ShouldBeTrue();

        new CorsOptionsConfigurator(new ApiSettings { CorsAllowedOrigins = new List<string> { "https://swagger.example.org" } })
            .AllowsAnyOrigin.ShouldBeFalse();
    }
}
