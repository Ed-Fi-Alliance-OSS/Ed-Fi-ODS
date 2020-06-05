// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Web.Http.Controllers;
using EdFi.Ods.Api.Extensions;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Extensions
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class RequestExtensionsTests
    {
        public class When_calling_a_secure_endpoint_using_proxy_forwarding : TestFixtureBase
        {
            private HttpRequestMessage _request;
            private string _actualHost;
            private int _actualPort;
            private string _actualScheme;

            protected override void Arrange()
            {
                _request = new HttpRequestMessage();
                _request.Headers.Add("X-Forwarded-Host", "api.com");
                _request.Headers.Add("X-Forwarded-Port", "443");
                _request.Headers.Add("X-Forwarded-Proto", "https");
                _request.RequestUri = new Uri("http://api1.com:007");
            }

            protected override void Act()
            {
                _actualHost = _request.Host(useProxyHeaders: true);
                _actualPort = _request.Port(useProxyHeaders: true);
                _actualScheme = _request.Scheme(useProxyHeaders: true);
            }

            [Assert]
            public void Should_return_the_forwarded_scheme() => Assert.That(_actualScheme, Is.EqualTo("https"));

            [Assert]
            public void Should_return_the_forwarded_host() => Assert.That(_actualHost, Is.EqualTo("api.com"));

            [Assert]
            public void Should_return_the_forwarded_port() => Assert.That(_actualPort, Is.EqualTo(443));
        }

        public class When_calling_a_secure_endpoint_using_proxy_forwarding_having_an_empty_host : TestFixtureBase
        {
            private HttpRequestMessage _request;
            private string _actualHost;

            protected override void Arrange()
            {
                _request = new HttpRequestMessage();
                _request.Headers.Add("X-Forwarded-Host", "");
                _request.Headers.Add("X-Forwarded-Port", "443");
                _request.Headers.Add("X-Forwarded-Proto", "https");
                _request.RequestUri = new Uri("http://api1.com:007");
            }

            protected override void Act()
            {
                _actualHost = _request.Host(useProxyHeaders: true);
            }

            [Assert]
            public void Should_return_the_forwarded_host() => Assert.That(_actualHost, Is.EqualTo(""));
        }

        public class When_calling_a_secure_endpoint_using_proxy_forwarding_having_an_empty_port : TestFixtureBase
        {
            private HttpRequestMessage _request;
            private int _actualPort;

            protected override void Arrange()
            {
                _request = new HttpRequestMessage();
                _request.Headers.Add("X-Forwarded-Host", "api.com");
                _request.Headers.Add("X-Forwarded-Port", "");
                _request.Headers.Add("X-Forwarded-Proto", "https");
                _request.RequestUri = new Uri("http://api1.com:007");
            }

            protected override void Act()
            {
                _actualPort = _request.Port(useProxyHeaders: true);
            }

            [Assert]
            public void Should_return_the_forwarded_port() => Assert.That(_actualPort, Is.EqualTo(7));
        }

        public class When_calling_a_secure_endpoint_using_proxy_forwarding_having_an_empty_scheme : TestFixtureBase
        {
            private HttpRequestMessage _request;
            private string _actualScheme;

            protected override void Arrange()
            {
                _request = new HttpRequestMessage();
                _request.Headers.Add("X-Forwarded-Host", "api.com");
                _request.Headers.Add("X-Forwarded-Port", "443");
                _request.Headers.Add("X-Forwarded-Proto", "");
                _request.RequestUri = new Uri("http://api1.com:007");
            }

            protected override void Act()
            {
                _actualScheme = _request.Scheme(useProxyHeaders: true);
            }

            [Assert]
            public void Should_return_the_forwarded_scheme() => Assert.That(_actualScheme, Is.EqualTo(""));
        }

        public class When_calling_a_secure_endpoint_without_using_proxy_forwarding_and_proxy_headers_are_present : TestFixtureBase
        {
            private HttpRequestMessage _request;
            private string _actualHost;
            private int _actualPort;
            private string _actualScheme;

            protected override void Arrange()
            {
                _request = new HttpRequestMessage();
                _request.Headers.Add("X-Forwarded-Host", "api.com");
                _request.Headers.Add("X-Forwarded-Port", "443");
                _request.Headers.Add("X-Forwarded-Proto", "https");
                _request.RequestUri = new Uri("http://api1.com:127");
            }

            protected override void Act()
            {
                _actualHost = _request.Host(useProxyHeaders: false);
                _actualPort = _request.Port(useProxyHeaders: false);
                _actualScheme = _request.Scheme(useProxyHeaders: false);
            }

            [Assert]
            public void Should_return_the_request_scheme() => Assert.That(_actualScheme, Is.EqualTo("http"));

            [Assert]
            public void Should_return_the_request_host() => Assert.That(_actualHost, Is.EqualTo("api1.com"));

            [Assert]
            public void Should_return_the_request_port() => Assert.That(_actualPort, Is.EqualTo(127));
        }

        public class When_calling_a_secure_endpoint_without_using_proxy_forwarding : TestFixtureBase
        {
            private HttpRequestMessage _request;
            private string _actualHost;
            private int _actualPort;
            private string _actualScheme;

            protected override void Arrange()
            {
                _request = new HttpRequestMessage();

                _request.SetRequestContext(
                    new HttpRequestContext
                    {
                        VirtualPathRoot = "/"
                    });

                _request.RequestUri = new Uri("http://api1.com:127");
            }

            protected override void Act()
            {
                _actualHost = _request.Host(useProxyHeaders: false);
                _actualPort = _request.Port(useProxyHeaders: false);
                _actualScheme = _request.Scheme(useProxyHeaders: false);
            }

            [Assert]
            public void Should_return_the_request_scheme() => Assert.That(_actualScheme, Is.EqualTo("http"));

            [Assert]
            public void Should_return_the_request_host() => Assert.That(_actualHost, Is.EqualTo("api1.com"));

            [Assert]
            public void Should_return_the_request_port() => Assert.That(_actualPort, Is.EqualTo(127));
        }

        public class When_getting_root_url_using_proxy_forwarding_and_virtual_path_with_default_https_port : TestFixtureBase
        {
            private HttpRequestMessage _request;
            private string _rootUrl;

            protected override void Arrange()
            {
                _request = new HttpRequestMessage();

                _request.SetRequestContext(
                    new HttpRequestContext
                    {
                        VirtualPathRoot = "/api"
                    });

                _request.Headers.Add("X-Forwarded-Host", "api.com");
                _request.Headers.Add("X-Forwarded-Port", "443");
                _request.Headers.Add("X-Forwarded-Proto", "https");
                _request.RequestUri = new Uri("http://api1.com:007");
            }

            protected override void Act()
            {
                _rootUrl = _request.RootUrl(useProxyHeaders: true);
            }

            [Assert]
            public void Should_return_the_forwarded_root_url_with_no_port() => Assert.That(_rootUrl, Is.EqualTo("https://api.com/api"));
        }

        public class When_getting_root_url_using_proxy_forwarding_and_virtual_path_with_default_http_port : TestFixtureBase
        {
            private HttpRequestMessage _request;
            private string _rootUrl;

            protected override void Arrange()
            {
                _request = new HttpRequestMessage();

                _request.SetRequestContext(
                    new HttpRequestContext
                    {
                        VirtualPathRoot = "/api"
                    });

                _request.Headers.Add("X-Forwarded-Host", "api.com");
                _request.Headers.Add("X-Forwarded-Port", "80");
                _request.Headers.Add("X-Forwarded-Proto", "http");
                _request.RequestUri = new Uri("https://api1.com:007");
            }

            protected override void Act()
            {
                _rootUrl = _request.RootUrl(useProxyHeaders: true);
            }

            [Assert]
            public void Should_return_the_forwarded_root_url_with_no_port() => Assert.That(_rootUrl, Is.EqualTo("http://api.com/api"));
        }

        public class When_calling_a_secure_endpoint_without_using_proxy_forwarding_and_using_a_virtual_path : TestFixtureBase
        {
            private HttpRequestMessage _request;
            private string _rootUrl;

            protected override void Arrange()
            {
                _request = new HttpRequestMessage();

                _request.SetRequestContext(
                    new HttpRequestContext
                    {
                        VirtualPathRoot = "/api"
                    });

                _request.RequestUri = new Uri("http://api1.com:127/metadata");
            }

            protected override void Act()
            {
                _rootUrl = _request.RootUrl(useProxyHeaders: true);
            }

            [Assert]
            public void Should_return_the_forwarded_root_url() => Assert.That(_rootUrl, Is.EqualTo("http://api1.com:127/api"));
        }
    }
}
