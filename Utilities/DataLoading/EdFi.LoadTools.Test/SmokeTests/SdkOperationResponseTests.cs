// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using EdFi.LoadTools.SmokeTest.SdkTests;
using NUnit.Framework;
using Shouldly;

namespace EdFi.LoadTools.Test.SmokeTests
{
    /// <summary>
    ///     Exercises <see cref="SdkOperationResponse" /> over both SDK response families using local
    ///     stub shapes: a new-generator object (HttpStatusCode StatusCode, RawContent,
    ///     HttpResponseHeaders Headers, public Ok()) and an old-generator ApiResponse (int StatusCode,
    ///     Data, dictionary/multimap Headers, optional RawContent), plus a bare payload.
    /// </summary>
    [TestFixture]
    public class SdkOperationResponseTests
    {
        [Test]
        public void New_generator_response_normalizes_status_payload_rawcontent_and_location()
        {
            var payload = new List<string> { "a", "b" };
            using var message = new HttpResponseMessage();
            message.Headers.TryAddWithoutValidation("Location", "http://api/schools/123");

            var raw = new NewGenResponseStub
            {
                StatusCode = HttpStatusCode.Created,
                RawContent = "{}",
                Headers = message.Headers,
                PayloadValue = payload
            };

            var response = new SdkOperationResponse(raw);

            response.HasStatusCode.ShouldBeTrue();
            response.StatusCode.ShouldBe(HttpStatusCode.Created);
            response.RawContent.ShouldBe("{}");
            response.Payload.ShouldBeSameAs(payload);
            response.TryGetHeader("location", out var values).ShouldBeTrue(); // case-insensitive
            values.ShouldBe(new[] { "http://api/schools/123" });
        }

        [Test]
        public void Old_generator_response_normalizes_int_status_data_and_multimap_location()
        {
            var payload = new List<string> { "x" };
            var headers = new Dictionary<string, IList<string>>
            {
                ["Location"] = new List<string> { "http://api/schools/9" }
            };

            var raw = new OldGenListHeaderStub
            {
                StatusCode = 201,
                Data = payload,
                Headers = headers
            };

            var response = new SdkOperationResponse(raw);

            response.HasStatusCode.ShouldBeTrue();
            response.StatusCode.ShouldBe(HttpStatusCode.Created);
            response.RawContent.ShouldBeNull();
            response.Payload.ShouldBeSameAs(payload);
            response.TryGetHeader("LOCATION", out var values).ShouldBeTrue();
            values.ShouldBe(new[] { "http://api/schools/9" });
        }

        [Test]
        public void Old_generator_string_dictionary_headers_are_supported()
        {
            var raw = new OldGenStringHeaderStub
            {
                StatusCode = 200,
                Data = new List<string>(),
                Headers = new Dictionary<string, string> { ["Location"] = "http://api/x/1" }
            };

            var response = new SdkOperationResponse(raw);

            response.TryGetHeader("Location", out var values).ShouldBeTrue();
            values.ShouldBe(new[] { "http://api/x/1" });
        }

        [Test]
        public void Missing_location_header_returns_false_and_empty_values()
        {
            var raw = new OldGenListHeaderStub
            {
                StatusCode = 204,
                Data = null,
                Headers = new Dictionary<string, IList<string>>()
            };

            var response = new SdkOperationResponse(raw);

            response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
            response.TryGetHeader("Location", out var values).ShouldBeFalse();
            values.ShouldBeEmpty();
        }

        [Test]
        public void Bare_list_payload_is_the_shape_that_previously_crashed()
        {
            var bare = new List<string> { "only", "data" };

            // The original code did (HttpStatusCode)((dynamic)result).StatusCode, which threw a
            // RuntimeBinderException ("List<...> does not contain a definition for StatusCode").
            Should.Throw<Exception>(() =>
            {
                dynamic d = bare;
                _ = d.StatusCode;
            });

            // The adapter handles the same shape without throwing.
            var response = new SdkOperationResponse(bare);

            response.HasStatusCode.ShouldBeFalse();
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            response.Payload.ShouldBeSameAs(bare);
            response.RawContent.ShouldBeNull();
            response.TryGetHeader("Location", out _).ShouldBeFalse();
        }

        [Test]
        public void Null_raw_result_is_handled_defensively()
        {
            var response = new SdkOperationResponse(null);

            response.HasStatusCode.ShouldBeFalse();
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            response.Payload.ShouldBeNull();
            response.RawContent.ShouldBeNull();
            response.TryGetHeader("Location", out _).ShouldBeFalse();
        }

        [Test]
        public void New_generator_response_with_null_headers_returns_false_for_location()
        {
            // A response object whose Headers property is present but null must not throw and must
            // report no Location (new-generator POST can carry null headers on non-2xx paths).
            var raw = new NewGenResponseStub
            {
                StatusCode = HttpStatusCode.Created,
                PayloadValue = new object()
                // Headers deliberately left null.
            };

            var response = new SdkOperationResponse(raw);

            response.StatusCode.ShouldBe(HttpStatusCode.Created);
            response.TryGetHeader("Location", out var values).ShouldBeFalse();
            values.ShouldBeEmpty();
        }

        // ----- stub response shapes -----

        private sealed class NewGenResponseStub
        {
            public HttpStatusCode StatusCode { get; set; }
            public string RawContent { get; set; }
            public HttpResponseHeaders Headers { get; set; }
            public object PayloadValue { get; set; }
            public object Ok() => PayloadValue;
        }

        private sealed class OldGenListHeaderStub
        {
            public int StatusCode { get; set; }
            public object Data { get; set; }
            public IDictionary<string, IList<string>> Headers { get; set; }
        }

        private sealed class OldGenStringHeaderStub
        {
            public int StatusCode { get; set; }
            public object Data { get; set; }
            public IDictionary<string, string> Headers { get; set; }
        }
    }
}
