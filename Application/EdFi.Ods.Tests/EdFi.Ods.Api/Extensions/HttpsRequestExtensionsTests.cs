using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using FakeItEasy;
using EdFi.Ods.Api.Extensions;
using Shouldly;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

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
                    var result = httpRequest.Scheme(false);

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
                    var result = httpRequest.Scheme(true);

                    // Assert
                    result.ShouldBe(expectedProtocol);
                }
            }
        }
    }
}
