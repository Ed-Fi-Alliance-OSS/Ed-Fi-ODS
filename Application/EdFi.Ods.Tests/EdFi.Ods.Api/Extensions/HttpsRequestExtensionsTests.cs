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
                public class And_given_override_value_exists
                {
                    [TestCase("forwardedHost")]
                    [TestCase("")]
                    [TestCase(null)]
                    public void Then_always_use_the_override(string xForwardedHostValue)
                    {
                        const string requestHost = "myserver";
                        const string overrideForHost = "workstation";

                        // Arrange
                        var httpRequest = A.Fake<HttpRequest>();
                        A.CallTo(() => httpRequest.Host).Returns(new HostString(requestHost));

                        if (xForwardedHostValue != null)
                        {
                            A.CallTo(() => httpRequest.Headers).Returns(new HeaderDictionary(new Dictionary<string, StringValues>
                                    {
                                        { "X-Forwarded-Host", new StringValues(xForwardedHostValue) }
                                    }
                            ));
                        }

                        // Act
                        var result = httpRequest.Host(new ReverseProxySettings(true, overrideForHost, null));

                        // Assert
                        result.ShouldBe(overrideForHost);
                    }
                }

                [TestFixture]
                public class And_given_override_was_not_set
                {
                    [TestFixture]
                    public class And_given_forwarding_host_was_sent
                    {
                        [Test]
                        public void Then_use_the_forwarding_host()
                        {
                            const string requestHost = "myserver";
                            const string xForwardedHostValue = "forwardedServer";
                            const string overrideForHost = null;

                            // Arrange
                            var httpRequest = A.Fake<HttpRequest>();
                            A.CallTo(() => httpRequest.Host).Returns(new HostString(requestHost));
                            A.CallTo(() => httpRequest.Headers).Returns(new HeaderDictionary(new Dictionary<string, StringValues>
                                {
                                    { "X-Forwarded-Host", new StringValues(xForwardedHostValue) }
                                }
                            ));

                            // Act
                            var result = httpRequest.Host(new ReverseProxySettings(true, overrideForHost, null));

                            // Assert
                            result.ShouldBe(xForwardedHostValue);

                        }
                    }

                    [TestFixture]
                    public class And_given_forwarding_host_is_not_sent
                    {
                        [TestCase("")]
                        [TestCase(null)]
                        public void Then_use_the_request_host(string xForwardedHostValue)
                        {
                            const string requestHost = "myserver";
                            const string overrideForHost = null;

                            // Arrange
                            var httpRequest = A.Fake<HttpRequest>();
                            A.CallTo(() => httpRequest.Host).Returns(new HostString(requestHost));

                            if (xForwardedHostValue != null)
                            {
                                A.CallTo(() => httpRequest.Headers).Returns(new HeaderDictionary(new Dictionary<string, StringValues>
                                    {
                                        { "X-Forwarded-Host", new StringValues(xForwardedHostValue) }
                                    }
                                ));
                            }

                            // Act
                            var result = httpRequest.Host(new ReverseProxySettings(true, overrideForHost, null));

                            // Assert
                            result.ShouldBe(requestHost);

                        }
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
                public class And_given_override_value_exists
                {
                    [TestCase("999")]
                    [TestCase("")]
                    [TestCase(null)]
                    public void Then_always_use_the_override(string xForwardedPortValue)
                    {
                        const string requestHost = "myserver";
                        const int overrideForPort = 8983;

                        // Arrange
                        var httpRequest = A.Fake<HttpRequest>();
                        A.CallTo(() => httpRequest.Host).Returns(new HostString(requestHost));

                        if (xForwardedPortValue != null)
                        {
                            A.CallTo(() => httpRequest.Headers).Returns(new HeaderDictionary(new Dictionary<string, StringValues>
                                    {
                                        { "X-Forwarded-Port", new StringValues(xForwardedPortValue) }
                                    }
                            ));
                        }

                        // Act
                        var result = httpRequest.Port(new ReverseProxySettings(true, null, overrideForPort));

                        // Assert
                        result.ShouldBe(overrideForPort);
                    }
                }

                [TestFixture]
                public class And_given_override_was_not_set
                {
                    [TestFixture]
                    public class And_given_forwarding_port_was_sent
                    {
                        [Test]
                        public void Then_use_the_forwarding_port()
                        {
                            const string requestHost = "myserver";
                            const int xForwardedPortValue = 9876;

                            // Arrange
                            var httpRequest = A.Fake<HttpRequest>();
                            A.CallTo(() => httpRequest.Host).Returns(new HostString(requestHost));
                            A.CallTo(() => httpRequest.Headers).Returns(new HeaderDictionary(new Dictionary<string, StringValues>
                                {
                                    { "X-Forwarded-Port", new StringValues(xForwardedPortValue.ToString()) }
                                }
                            ));

                            // Act
                            var result = httpRequest.Port(new ReverseProxySettings(true, null, null));

                            // Assert
                            result.ShouldBe(xForwardedPortValue);

                        }
                    }

                    [TestFixture]
                    public class And_given_forwarding_port_is_not_sent
                    {
                        [TestCase(true, "https", 443)]
                        [TestCase(true, "http", 80)]
                        [TestCase(false, "https", 443)]
                        [TestCase(false, "http", 80)]
                        public void Then_use_the_scheme_to_determine_port(bool blankHeaderWasSent, string scheme, int expectedPort)
                        {
                            const string requestHost = "myserver";

                            // Arrange
                            var httpRequest = A.Fake<HttpRequest>();
                            A.CallTo(() => httpRequest.Scheme).Returns(scheme);
                            A.CallTo(() => httpRequest.Host).Returns(new HostString(requestHost));

                            if (blankHeaderWasSent)
                            {
                                A.CallTo(() => httpRequest.Headers).Returns(new HeaderDictionary(new Dictionary<string, StringValues>
                                    {
                                        { "X-Forwarded-Port", new StringValues("  ") }
                                    }
                                ));
                            }

                            // Act
                            var result = httpRequest.Port(new ReverseProxySettings(true, null, null));

                            // Assert
                            result.ShouldBe(expectedPort);

                        }
                    }
                }
            }
        }
    }
}
