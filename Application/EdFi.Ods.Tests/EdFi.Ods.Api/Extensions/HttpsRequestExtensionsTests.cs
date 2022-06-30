using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using FakeItEasy;
using EdFi.Ods.Api.Extensions;
using Shouldly;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Extensions
{
    public class HttpsRequestExtensionsTests
    {
        [TestFixture]
        public class When_extracting_proxy_forwarded_scheme_from_an_http_request
        {

            [TestFixture]
            public class Given_proxy_headers_are_not_being_enforced
            {
                [TestCase("https")]
                [TestCase("http")]
                public void Then_it_returns_the_request_scheme(string requestProtocol)
                {
                    // Arrange
                    var httpRequest = A.Fake<HttpRequest>();
                    A.CallTo(() => httpRequest.Scheme).Returns(requestProtocol);

                    // Act
                    var result = httpRequest.Scheme(new ReverseProxySettings(false, null, null));

                    // Assert
                    result.ShouldBe(requestProtocol);
                }

            }


            [TestFixture]
            public class Given_proxy_headers_are_being_enforced
            {
                [TestCase("https", "http", "http")]
                [TestCase("http", "http", "http")]
                [TestCase("https", "https", "https")]
                [TestCase("http", "https", "https")]
                [TestCase("https", "https, http", "https")]
                [TestCase("http", "https, https", "https")]
                public void Then_it_returns_the_originating_xforwardedprotovalue_regardless_of_request_scheme_value(
                    string requestProtocol, 
                    string forwardedProtocol, 
                    string expectedProtocol
                )
                {
                    // Arrange
                    var httpRequest = A.Fake<HttpRequest>();
                    A.CallTo(() => httpRequest.Scheme).Returns(requestProtocol);
                    A.CallTo(() => httpRequest.Headers).Returns(new HeaderDictionary(new Dictionary<string, StringValues> 
                        { 
                            { "X-Forwarded-Proto", new StringValues(forwardedProtocol) } 
                        }
                    ));

                    // Act
                    var result = httpRequest.Scheme(new ReverseProxySettings(true, "localhost", 80));

                    // Assert
                    result.ShouldBe(expectedProtocol);
                }
            }
        }

        [TestFixture]
        public class When_extracting_proxy_forwarded_host_from_an_http_request
        {

            [TestFixture]
            public class Given_proxy_headers_are_not_being_enforced
            {
                [Test]
                public void Then_it_returns_the_request_host()
                {
                    const string requestHost = "myserver";

                    // Arrange
                    var httpRequest = A.Fake<HttpRequest>();
                    A.CallTo(() => httpRequest.Host).Returns(new HostString(requestHost));

                    // Act
                    var result = httpRequest.Host(new ReverseProxySettings(false, null, null));

                    // Assert
                    result.ShouldBe(requestHost);
                }

            }


            [TestFixture]
            public class Given_proxy_headers_are_being_enforced
            {
                [TestFixture]
                public class Given_x_fowarded_host_value_exists
                {
                    [Test]
                    public void Then_it_returns_the_x_fowarded_host_value()
                    {
                        const string requestHost = "myserver";
                        const string forwardedHost = "public.server";
                        const string defaultHost = "workstation";

                        // Arrange
                        var httpRequest = A.Fake<HttpRequest>();
                        A.CallTo(() => httpRequest.Host).Returns(new HostString(requestHost));
                        A.CallTo(() => httpRequest.Headers).Returns(new HeaderDictionary(new Dictionary<string, StringValues>
                                {
                                    { "X-Forwarded-Host", new StringValues(forwardedHost) }
                                }
                        ));

                        // Act
                        var result = httpRequest.Host(new ReverseProxySettings(true, defaultHost, 80));

                        // Assert
                        result.ShouldBe(forwardedHost);

                    }
                }

                [TestFixture]
                public class Given_x_fowarded_host_value_is_blank
                {
                    [Test]
                    public void Then_it_returns_the_default_value()
                    {
                        const string requestHost = "myserver";
                        const string forwardedHost = "";
                        const string defaultHost = "workstation";

                        // Arrange
                        var httpRequest = A.Fake<HttpRequest>();
                        A.CallTo(() => httpRequest.Host).Returns(new HostString(requestHost));
                        A.CallTo(() => httpRequest.Headers).Returns(new HeaderDictionary(new Dictionary<string, StringValues>
                                {
                                    { "X-Forwarded-Host", new StringValues(forwardedHost) }
                                }
                        ));

                        // Act
                        var result = httpRequest.Host(new ReverseProxySettings(true, defaultHost, 80));

                        // Assert
                        result.ShouldBe(defaultHost);

                    }
                }

                [TestFixture]
                public class Given_x_fowarded_host_value_is_missing
                {
                    [Test]
                    public void Then_it_returns_the_default_value()
                    {
                        const string requestHost = "myserver";
                        const string defaultHost = "workstation";

                        // Arrange
                        var httpRequest = A.Fake<HttpRequest>();
                        A.CallTo(() => httpRequest.Host).Returns(new HostString(requestHost));

                        // Act
                        var result = httpRequest.Host(new ReverseProxySettings(true, defaultHost, 80));

                        // Assert
                        result.ShouldBe(defaultHost);

                    }
                }
            }
        }

        [TestFixture]
        public class When_extracting_proxy_forwarded_port_from_an_http_request
        {

            [TestFixture]
            public class Given_proxy_headers_are_not_being_enforced
            {
                [Test]
                public void Then_it_returns_the_request_host()
                {
                    const string requestHost = "myserver";
                    const int requestPort = 554;

                    // Arrange
                    var httpRequest = A.Fake<HttpRequest>();
                    A.CallTo(() => httpRequest.Host).Returns(new HostString(requestHost, requestPort));

                    // Act
                    var result = httpRequest.Port(new ReverseProxySettings(false, null, null));

                    // Assert
                    result.ShouldBe(requestPort);
                }

            }


            [TestFixture]
            public class Given_proxy_headers_are_being_enforced
            {
                [TestFixture]
                public class Given_x_fowarded_port_value_exists
                {
                    [Test]
                    public void Then_it_returns_the_x_fowarded_host_value()
                    {
                        const string requestHost = "myserver";
                        const int requestPort = 554;
                        const int defaultPort = 443;
                        const int forwardedPort = 665;

                        // Arrange
                        var httpRequest = A.Fake<HttpRequest>();
                        A.CallTo(() => httpRequest.Host).Returns(new HostString(requestHost, requestPort));
                        A.CallTo(() => httpRequest.Headers).Returns(new HeaderDictionary(new Dictionary<string, StringValues>
                                {
                                    { "X-Forwarded-Port", new StringValues(forwardedPort.ToString()) }
                                }
                        ));

                        // Act
                        var result = httpRequest.Port(new ReverseProxySettings(true, "localhost", defaultPort));

                        // Assert
                        result.ShouldBe(forwardedPort);
                    }
                }

                [TestFixture]
                public class Given_x_fowarded_port_value_is_missing
                {
                    [Test]
                    public void Then_it_returns_the_default_value()
                    {
                        const string requestHost = "myserver";
                        const int requestPort = 554;
                        const int defaultPort = 443;

                        // Arrange
                        var httpRequest = A.Fake<HttpRequest>();
                        A.CallTo(() => httpRequest.Host).Returns(new HostString(requestHost, requestPort));

                        // Act
                        var result = httpRequest.Port(new ReverseProxySettings(true, "localhost", defaultPort));

                        // Assert
                        result.ShouldBe(defaultPort);
                    }
                }

                [TestFixture]
                public class Given_x_fowarded_port_value_is_blank
                {
                    [Test]
                    public void Then_it_returns_the_default_value()
                    {
                        const string requestHost = "myserver";
                        const int requestPort = 554;
                        const int defaultPort = 443;

                        // Arrange
                        var httpRequest = A.Fake<HttpRequest>();
                        A.CallTo(() => httpRequest.Host).Returns(new HostString(requestHost, requestPort));
                        A.CallTo(() => httpRequest.Headers).Returns(new HeaderDictionary(new Dictionary<string, StringValues>
                                {
                                    { "X-Forwarded-Port", new StringValues("   ") }
                                }
                            ));

                        // Act
                        var result = httpRequest.Port(new ReverseProxySettings(true, "localhost", defaultPort));

                        // Assert
                        result.ShouldBe(defaultPort);
                    }
                }
            }
        }
    }
}
