// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace EdFi.SdkGen.Console.Tests
{
    [TestFixture]
    public class OpenApiCodgenCliUpdaterTests
    {
        private const string JarContent = "fake openapi-generator-cli jar";

        private string _originalDirectory;
        private string _workingDirectory;
        private List<TimeSpan> _waits;

        [SetUp]
        public void SetUp()
        {
            _originalDirectory = Environment.CurrentDirectory;
            _workingDirectory = Path.Combine(Path.GetTempPath(), "sdkgen-tests-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_workingDirectory);
            Environment.CurrentDirectory = _workingDirectory;
            _waits = new List<TimeSpan>();
        }

        [TearDown]
        public void TearDown()
        {
            Environment.CurrentDirectory = _originalDirectory;
            Directory.Delete(_workingDirectory, recursive: true);
        }

        [Test]
        public void A_429_followed_by_success_waits_for_Retry_After_and_saves_the_jar()
        {
            var handler = new SequenceHandler(
                () => TooManyRequests(TimeSpan.FromSeconds(7)),
                Jar);

            CreateUpdater(handler).Run();

            File.ReadAllText(JarPath).ShouldBe(JarContent);
            handler.Requests.ShouldBe(2);
            _waits.ShouldBe(new[] { TimeSpan.FromSeconds(7) });
        }

        [Test]
        public void Server_errors_without_Retry_After_use_the_backoff()
        {
            var handler = new SequenceHandler(
                () => new HttpResponseMessage(HttpStatusCode.ServiceUnavailable),
                () => new HttpResponseMessage(HttpStatusCode.BadGateway),
                Jar);

            CreateUpdater(handler).Run();

            File.ReadAllText(JarPath).ShouldBe(JarContent);
            _waits.ShouldBe(new[] { TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(4) });
        }

        [Test]
        public void A_long_Retry_After_is_capped()
        {
            var handler = new SequenceHandler(
                () => TooManyRequests(TimeSpan.FromMinutes(10)),
                Jar);

            CreateUpdater(handler).Run();

            _waits.ShouldBe(new[] { OpenApiCodgenCliUpdater.MaxRetryAfter });
        }

        [Test]
        public void A_network_error_is_retried()
        {
            var handler = new SequenceHandler(
                () => throw new HttpRequestException("Connection refused"),
                Jar);

            CreateUpdater(handler).Run();

            File.ReadAllText(JarPath).ShouldBe(JarContent);
            handler.Requests.ShouldBe(2);
        }

        [Test]
        public void A_404_fails_without_retrying()
        {
            var handler = new SequenceHandler(() => new HttpResponseMessage(HttpStatusCode.NotFound), Jar);

            var exception = Should.Throw<InvalidOperationException>(() => CreateUpdater(handler).Run());

            exception.Message.ShouldContain("404");
            exception.Message.ShouldContain("https://example.test/maven/7.19.0/openapi-generator-cli-7.19.0.jar");
            handler.Requests.ShouldBe(1);
            _waits.ShouldBeEmpty();
            File.Exists(JarPath).ShouldBeFalse();
        }

        [Test]
        public void Repeated_429s_fail_after_the_last_attempt_with_the_url_and_status()
        {
            var handler = new SequenceHandler(
                Enumerable.Repeat<Func<HttpResponseMessage>>(() => TooManyRequests(null), 10).ToArray());

            var exception = Should.Throw<InvalidOperationException>(() => CreateUpdater(handler).Run());

            handler.Requests.ShouldBe(OpenApiCodgenCliUpdater.MaxAttempts);
            _waits.Count.ShouldBe(OpenApiCodgenCliUpdater.MaxAttempts - 1);
            exception.Message.ShouldContain("after 5 attempts");
            exception.Message.ShouldContain("429");
            exception.Message.ShouldContain("https://example.test/maven/7.19.0/openapi-generator-cli-7.19.0.jar");
        }

        [Test]
        public void A_failed_download_leaves_no_jar_or_partial_file()
        {
            var handler = new SequenceHandler(
                Enumerable.Repeat<Func<HttpResponseMessage>>(BrokenBody, 10).ToArray());

            Should.Throw<InvalidOperationException>(() => CreateUpdater(handler).Run());

            handler.Requests.ShouldBe(OpenApiCodgenCliUpdater.MaxAttempts);
            Directory.GetFiles(_workingDirectory).ShouldBeEmpty();
        }

        [Test]
        public void An_existing_jar_is_not_downloaded_again()
        {
            File.WriteAllText(JarPath, "already here");
            var handler = new SequenceHandler(Jar);

            CreateUpdater(handler).Run();

            handler.Requests.ShouldBe(0);
            File.ReadAllText(JarPath).ShouldBe("already here");
        }

        [Test]
        public void Forcing_the_update_replaces_an_existing_jar()
        {
            File.WriteAllText(JarPath, "old version");
            var handler = new SequenceHandler(Jar);

            CreateUpdater(handler, force: true).Run();

            File.ReadAllText(JarPath).ShouldBe(JarContent);
        }

        [Test]
        public void The_default_download_url_is_Maven_Central()
        {
            new Options { CliVersion = "7.19.0" }.CliDownloadUrl()
                .ShouldBe("https://repo1.maven.org/maven2/org/openapitools/openapi-generator-cli/7.19.0/openapi-generator-cli-7.19.0.jar");
        }

        private string JarPath => Path.Combine(_workingDirectory, "openapi-generator-cli.jar");

        private OpenApiCodgenCliUpdater CreateUpdater(HttpMessageHandler handler, bool force = false)
            => new(
                new Options
                {
                    CliVersion = "7.19.0",
                    CliDownloadBaseUrl = "https://example.test/maven/",
                    Force = force
                },
                handler,
                wait =>
                {
                    _waits.Add(wait);
                    return Task.CompletedTask;
                });

        private static HttpResponseMessage Jar()
            => new(HttpStatusCode.OK) { Content = new StringContent(JarContent, Encoding.UTF8) };

        private static HttpResponseMessage TooManyRequests(TimeSpan? retryAfter)
        {
            var response = new HttpResponseMessage(HttpStatusCode.TooManyRequests);

            if (retryAfter.HasValue)
            {
                response.Headers.RetryAfter = new RetryConditionHeaderValue(retryAfter.Value);
            }

            return response;
        }

        private static HttpResponseMessage BrokenBody()
            => new(HttpStatusCode.OK) { Content = new StreamContent(new BrokenStream()) };

        private sealed class SequenceHandler : HttpMessageHandler
        {
            private readonly Queue<Func<HttpResponseMessage>> _responses;

            public SequenceHandler(params Func<HttpResponseMessage>[] responses)
            {
                _responses = new Queue<Func<HttpResponseMessage>>(responses);
            }

            public int Requests { get; private set; }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Requests++;
                return Task.FromResult(_responses.Dequeue()());
            }
        }

        // A body that fails part way through, like a dropped connection
        private sealed class BrokenStream : Stream
        {
            private bool _sentFirstChunk;

            public override bool CanRead => true;
            public override bool CanSeek => false;
            public override bool CanWrite => false;
            public override long Length => throw new NotSupportedException();
            public override long Position { get => 0; set => throw new NotSupportedException(); }

            public override int Read(byte[] buffer, int offset, int count)
            {
                if (_sentFirstChunk)
                {
                    throw new IOException("The connection was closed.");
                }

                _sentFirstChunk = true;
                buffer[offset] = 1;
                return 1;
            }

            public override void Flush() { }
            public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
            public override void SetLength(long value) => throw new NotSupportedException();
            public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();
        }
    }
}
