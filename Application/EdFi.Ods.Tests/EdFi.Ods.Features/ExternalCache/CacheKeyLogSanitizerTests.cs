// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Features.ExternalCache;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.ExternalCache;

[TestFixture]
public class CacheKeyLogSanitizerTests
{
    private const string Prefix = ApiClientDetailsCacheKeyProvider.CacheKeyPrefix;

    // A representative bearer token; deliberately non-hex so no fragment can coincidentally
    // match the uppercase-hex correlation hash in the sanitized output.
    private const string Token = "super-secret-oauth-token-value";

    [Test]
    public void SanitizeKeyForLogging_Should_never_emit_any_part_of_the_token()
    {
        string sanitized = CacheKeyLogSanitizer.SanitizeKeyForLogging(Prefix + Token);

        AssertHelper.All(
            () => sanitized.ShouldStartWith(Prefix),
            () => sanitized.ShouldNotContain(Token),
            () => sanitized.ShouldNotContain(Token[^6..]),
            () => sanitized.ShouldContain("<hashed:"));
    }

    [Test]
    public void SanitizeKeyForLogging_Should_produce_a_stable_hash_for_correlation()
    {
        string first = CacheKeyLogSanitizer.SanitizeKeyForLogging(Prefix + Token);
        string second = CacheKeyLogSanitizer.SanitizeKeyForLogging(Prefix + Token);
        string other = CacheKeyLogSanitizer.SanitizeKeyForLogging(Prefix + "a-different-token");

        AssertHelper.All(
            () => second.ShouldBe(first),
            () => other.ShouldNotBe(first));
    }

    [Test]
    public void SanitizeKeyForLogging_Should_fully_redact_a_short_token()
    {
        string sanitized = CacheKeyLogSanitizer.SanitizeKeyForLogging(Prefix + "shorty");

        AssertHelper.All(
            () => sanitized.ShouldStartWith(Prefix),
            () => sanitized.ShouldNotContain("shorty"));
    }

    [Test]
    public void SanitizeKeyForLogging_Should_pass_through_keys_that_carry_no_secret()
    {
        var tupleKey = (odsInstanceHashId: 123UL, personType: "Student");

        AssertHelper.All(
            () => CacheKeyLogSanitizer.SanitizeKeyForLogging("Descriptors.uri://ed-fi.org").ShouldBe("Descriptors.uri://ed-fi.org"),
            () => CacheKeyLogSanitizer.SanitizeKeyForLogging(9876543210UL).ShouldBe("9876543210"),
            () => CacheKeyLogSanitizer.SanitizeKeyForLogging(tupleKey).ShouldBe(tupleKey.ToString()));
    }

    [Test]
    public void SanitizeKeyForLogging_Should_render_null_as_a_placeholder()
    {
        CacheKeyLogSanitizer.SanitizeKeyForLogging(null).ShouldBe("<null>");
    }

    [Test]
    public void SanitizeExceptionMessageForLogging_Should_redact_a_key_embedded_in_a_redis_timeout_message()
    {
        // StackExchange.Redis timeout messages embed the full cache key followed by comma-separated detail.
        var ex = new TimeoutException($"Timeout performing GET {Prefix}{Token}, inst: 0, qu: 0");

        string sanitized = CacheKeyLogSanitizer.SanitizeExceptionMessageForLogging(ex);

        AssertHelper.All(
            () => sanitized.ShouldStartWith(nameof(TimeoutException)),
            () => sanitized.ShouldNotContain(Token),
            () => sanitized.ShouldContain(", inst: 0"),
            // The embedded key is replaced with the same hash SanitizeKeyForLogging produces, so the
            // exception can be correlated with the Debug hit/miss entries for the same token.
            () => sanitized.ShouldContain(CacheKeyLogSanitizer.SanitizeKeyForLogging(Prefix + Token)));
    }

    [Test]
    public void SanitizeExceptionForLogging_Should_redact_keys_in_the_full_detail_including_inner_exceptions()
    {
        var ex = new InvalidOperationException(
            $"outer failure for {Prefix}{Token}",
            new TimeoutException($"Timeout performing GET {Prefix}{Token}"));

        string sanitized = CacheKeyLogSanitizer.SanitizeExceptionForLogging(ex);

        AssertHelper.All(
            () => sanitized.ShouldNotContain(Token),
            () => sanitized.ShouldContain(typeof(InvalidOperationException).FullName),
            () => sanitized.ShouldContain(typeof(TimeoutException).FullName));
    }

    [Test]
    public void Sanitizing_a_null_exception_Should_render_a_placeholder()
    {
        AssertHelper.All(
            () => CacheKeyLogSanitizer.SanitizeExceptionMessageForLogging(null).ShouldBe("<null>"),
            () => CacheKeyLogSanitizer.SanitizeExceptionForLogging(null).ShouldBe("<null>"));
    }
}
