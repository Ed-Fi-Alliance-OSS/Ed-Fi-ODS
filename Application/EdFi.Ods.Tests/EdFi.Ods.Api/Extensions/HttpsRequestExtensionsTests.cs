// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Api.Startup;
using EdFi.Ods.Common.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Extensions
{
    public class HttpsRequestExtensionsTests
    {
        private const string RequestScheme = "http";
        private const string RequestHost = "backend";
        private const int RequestPort = 5000;

        private static readonly IPAddress ProxyAddress = IPAddress.Parse("10.0.0.2");
        private static readonly IPAddress ClientAddress = IPAddress.Parse("203.0.113.7");

        /// <summary>
        /// Builds a request as received by the API host and runs it through the same reverse proxy middleware the API
        /// uses when UseReverseProxyHeaders is enabled.
        /// </summary>
        private static async Task<HttpRequest> ReceiveRequest(
            ApiSettings apiSettings,
            IPAddress remoteIpAddress,
            Dictionary<string, string> headers)
        {
            var context = new DefaultHttpContext();
            context.Connection.RemoteIpAddress = remoteIpAddress;
            context.Request.Scheme = RequestScheme;
            context.Request.Host = new HostString(RequestHost, RequestPort);

            foreach (var header in headers)
            {
                context.Request.Headers[header.Key] = header.Value;
            }

            if (apiSettings.UseReverseProxyHeaders == true)
            {
                var options = new ForwardedHeadersOptions();
                new ForwardedHeadersOptionsConfigurator(apiSettings).Configure(options);

                var forwardedHeadersMiddleware = new ForwardedHeadersMiddleware(
                    _ => Task.CompletedTask,
                    NullLoggerFactory.Instance,
                    Options.Create(options));

                var forwardedPortMiddleware = new ForwardedPortMiddleware(
                    forwardedHeadersMiddleware.Invoke,
                    Options.Create(options));

                await forwardedPortMiddleware.InvokeAsync(context);
            }

            return context.Request;
        }

        private static ApiSettings ProxyHeadersEnforced(
            string[] knownProxies = null,
            string[] knownNetworks = null,
            string overrideForHost = null,
            int? overrideForPort = null)
        {
            return new ApiSettings
            {
                UseReverseProxyHeaders = true,
                KnownProxies = new List<string>(knownProxies ?? []),
                KnownNetworks = new List<string>(knownNetworks ?? []),
                OverrideForForwardingHostServer = overrideForHost,
                OverrideForForwardingHostPort = overrideForPort
            };
        }

        private static ApiSettings ProxyHeadersNotEnforced() => new() { UseReverseProxyHeaders = false };

        private static Dictionary<string, string> NginxHeaders(string proto = "https", string host = "api.example.org", string port = "8443")
        {
            var headers = new Dictionary<string, string> { { "X-Forwarded-For", ClientAddress.ToString() } };

            if (proto != null)
            {
                headers.Add("X-Forwarded-Proto", proto);
            }

            if (host != null)
            {
                headers.Add("X-Forwarded-Host", host);
            }

            if (port != null)
            {
                headers.Add("X-Forwarded-Port", port);
            }

            return headers;
        }

        [TestFixture]
        public class When_extracting_the_scheme_from_an_http_request
        {
            [Test]
            public async Task Given_proxy_headers_are_not_being_enforced_then_it_ignores_the_forwarded_scheme()
            {
                var apiSettings = ProxyHeadersNotEnforced();
                var request = await ReceiveRequest(apiSettings, ClientAddress, NginxHeaders());

                request.Scheme(apiSettings.GetReverseProxySettings()).ShouldBe(RequestScheme);
            }

            [TestCase("http", "http")]
            [TestCase("https", "https")]
            [TestCase("https, http", "https")]
            [TestCase("https,http", "https")]
            public async Task Given_proxy_headers_are_being_enforced_without_known_proxies_then_it_returns_the_originating_forwarded_scheme(
                string forwardedProto,
                string expectedScheme)
            {
                var apiSettings = ProxyHeadersEnforced();

                var request = await ReceiveRequest(
                    apiSettings,
                    ProxyAddress,
                    new Dictionary<string, string> { { "X-Forwarded-Proto", forwardedProto } });

                request.Scheme(apiSettings.GetReverseProxySettings()).ShouldBe(expectedScheme);
            }

            [Test]
            public async Task Given_a_chain_of_proxies_without_known_proxies_then_it_returns_the_originating_forwarded_scheme()
            {
                // Load balancer terminating TLS in front of another proxy (ODS-5481)
                var apiSettings = ProxyHeadersEnforced();

                var request = await ReceiveRequest(
                    apiSettings,
                    ProxyAddress,
                    new Dictionary<string, string>
                    {
                        { "X-Forwarded-For", "203.0.113.7, 10.0.0.1" },
                        { "X-Forwarded-Proto", "https, http" }
                    });

                request.Scheme(apiSettings.GetReverseProxySettings()).ShouldBe("https");
            }

            [Test]
            public async Task Given_the_request_comes_from_a_known_proxy_then_it_returns_the_forwarded_scheme()
            {
                var apiSettings = ProxyHeadersEnforced(knownProxies: [ProxyAddress.ToString()]);
                var request = await ReceiveRequest(apiSettings, ProxyAddress, NginxHeaders());

                request.Scheme(apiSettings.GetReverseProxySettings()).ShouldBe("https");
            }

            [Test]
            public async Task Given_the_request_does_not_come_from_a_known_proxy_then_it_ignores_the_forwarded_scheme()
            {
                var apiSettings = ProxyHeadersEnforced(knownProxies: [ProxyAddress.ToString()]);
                var request = await ReceiveRequest(apiSettings, ClientAddress, NginxHeaders());

                request.Scheme(apiSettings.GetReverseProxySettings()).ShouldBe(RequestScheme);
            }
        }

        [TestFixture]
        public class When_extracting_the_host_from_an_http_request
        {
            [Test]
            public async Task Given_proxy_headers_are_not_being_enforced_then_it_ignores_the_forwarded_host()
            {
                var apiSettings = ProxyHeadersNotEnforced();
                var request = await ReceiveRequest(apiSettings, ClientAddress, NginxHeaders());

                request.Host(apiSettings.GetReverseProxySettings()).ShouldBe(RequestHost);
            }

            [Test]
            public async Task Given_proxy_headers_are_being_enforced_without_known_proxies_then_it_returns_the_forwarded_host()
            {
                var apiSettings = ProxyHeadersEnforced();
                var request = await ReceiveRequest(apiSettings, ProxyAddress, NginxHeaders());

                request.Host(apiSettings.GetReverseProxySettings()).ShouldBe("api.example.org");
            }

            [Test]
            public async Task Given_proxy_headers_are_being_enforced_and_no_forwarded_host_is_sent_then_it_returns_the_request_host()
            {
                var apiSettings = ProxyHeadersEnforced();
                var request = await ReceiveRequest(apiSettings, ProxyAddress, NginxHeaders(host: null));

                request.Host(apiSettings.GetReverseProxySettings()).ShouldBe(RequestHost);
            }

            [TestCase("api.example.org")]
            [TestCase(null)]
            public async Task Given_an_override_value_exists_then_it_always_uses_the_override(string forwardedHost)
            {
                var apiSettings = ProxyHeadersEnforced(overrideForHost: "workstation");
                var request = await ReceiveRequest(apiSettings, ProxyAddress, NginxHeaders(host: forwardedHost));

                request.Host(apiSettings.GetReverseProxySettings()).ShouldBe("workstation");
            }

            [Test]
            public async Task Given_the_request_comes_from_a_known_network_then_it_returns_the_forwarded_host()
            {
                var apiSettings = ProxyHeadersEnforced(knownNetworks: ["10.0.0.0/8"]);
                var request = await ReceiveRequest(apiSettings, ProxyAddress, NginxHeaders());

                request.Host(apiSettings.GetReverseProxySettings()).ShouldBe("api.example.org");
            }

            [Test]
            public async Task Given_the_request_does_not_come_from_a_known_network_then_it_ignores_the_forwarded_host()
            {
                var apiSettings = ProxyHeadersEnforced(knownNetworks: ["10.0.0.0/8"]);
                var request = await ReceiveRequest(apiSettings, ClientAddress, NginxHeaders(host: "evil.example"));

                request.Host(apiSettings.GetReverseProxySettings()).ShouldBe(RequestHost);
            }
        }

        [TestFixture]
        public class When_extracting_the_port_from_an_http_request
        {
            [Test]
            public async Task Given_proxy_headers_are_not_being_enforced_then_it_ignores_the_forwarded_port()
            {
                var apiSettings = ProxyHeadersNotEnforced();
                var request = await ReceiveRequest(apiSettings, ClientAddress, NginxHeaders());

                request.Port(apiSettings.GetReverseProxySettings()).ShouldBe(RequestPort);
            }

            [Test]
            public async Task Given_proxy_headers_are_being_enforced_without_known_proxies_then_it_returns_the_forwarded_port()
            {
                var apiSettings = ProxyHeadersEnforced();
                var request = await ReceiveRequest(apiSettings, ProxyAddress, NginxHeaders());

                request.Port(apiSettings.GetReverseProxySettings()).ShouldBe(8443);
            }

            [TestCase("8443")]
            [TestCase(null)]
            public async Task Given_an_override_value_exists_then_it_always_uses_the_override(string forwardedPort)
            {
                var apiSettings = ProxyHeadersEnforced(overrideForPort: 999);
                var request = await ReceiveRequest(apiSettings, ProxyAddress, NginxHeaders(port: forwardedPort));

                request.Port(apiSettings.GetReverseProxySettings()).ShouldBe(999);
            }

            [TestCase("https", 443)]
            [TestCase("http", 80)]
            public async Task Given_a_forwarded_host_without_a_port_is_sent_then_it_uses_the_forwarded_scheme_to_determine_the_port(
                string forwardedProto,
                int expectedPort)
            {
                var apiSettings = ProxyHeadersEnforced();
                var request = await ReceiveRequest(apiSettings, ProxyAddress, NginxHeaders(proto: forwardedProto, port: null));

                request.Port(apiSettings.GetReverseProxySettings()).ShouldBe(expectedPort);
            }

            [Test]
            public async Task Given_the_request_comes_from_a_known_proxy_then_it_returns_the_forwarded_port()
            {
                var apiSettings = ProxyHeadersEnforced(knownProxies: [ProxyAddress.ToString()]);
                var request = await ReceiveRequest(apiSettings, ProxyAddress, NginxHeaders());

                request.Port(apiSettings.GetReverseProxySettings()).ShouldBe(8443);
            }

            [Test]
            public async Task Given_the_request_comes_from_a_known_proxy_as_an_ipv4_mapped_address_then_it_returns_the_forwarded_port()
            {
                var apiSettings = ProxyHeadersEnforced(knownProxies: [ProxyAddress.ToString()]);
                var request = await ReceiveRequest(apiSettings, ProxyAddress.MapToIPv6(), NginxHeaders());

                request.Port(apiSettings.GetReverseProxySettings()).ShouldBe(8443);
            }

            [Test]
            public async Task Given_the_request_comes_from_a_known_ipv4_mapped_network_then_it_returns_the_forwarded_port()
            {
                var apiSettings = ProxyHeadersEnforced(knownNetworks: ["::ffff:10.0.0.0/104"]);
                var request = await ReceiveRequest(apiSettings, ProxyAddress.MapToIPv6(), NginxHeaders());

                request.Host(apiSettings.GetReverseProxySettings()).ShouldBe("api.example.org");
                request.Port(apiSettings.GetReverseProxySettings()).ShouldBe(8443);
            }

            [Test]
            public async Task Given_the_request_does_not_come_from_a_known_proxy_then_it_ignores_the_forwarded_port()
            {
                var apiSettings = ProxyHeadersEnforced(knownProxies: [ProxyAddress.ToString()]);
                var request = await ReceiveRequest(apiSettings, ClientAddress, NginxHeaders());

                request.Port(apiSettings.GetReverseProxySettings()).ShouldBe(RequestPort);
            }
        }

        [TestFixture]
        public class When_building_the_root_url_of_an_http_request
        {
            [Test]
            public async Task Given_the_request_comes_from_a_trusted_proxy_then_it_uses_the_forwarded_values()
            {
                var apiSettings = ProxyHeadersEnforced(knownProxies: [ProxyAddress.ToString()]);
                var request = await ReceiveRequest(apiSettings, ProxyAddress, NginxHeaders());

                request.RootUrl(apiSettings.GetReverseProxySettings()).ShouldBe("https://api.example.org:8443");
            }

            [Test]
            public async Task Given_the_request_does_not_come_from_a_trusted_proxy_then_it_ignores_the_forwarded_values()
            {
                var apiSettings = ProxyHeadersEnforced(knownProxies: [ProxyAddress.ToString()]);
                var request = await ReceiveRequest(apiSettings, ClientAddress, NginxHeaders(host: "evil.example"));

                request.RootUrl(apiSettings.GetReverseProxySettings()).ShouldBe("http://backend:5000");
            }
        }

        [TestFixture]
        public class When_configuring_the_forwarded_headers_options
        {
            [Test]
            public void Then_it_processes_the_forwarded_for_host_and_proto_headers()
            {
                var options = new ForwardedHeadersOptions();
                new ForwardedHeadersOptionsConfigurator(ProxyHeadersEnforced()).Configure(options);

                options.ForwardedHeaders.ShouldBe(
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedHost | ForwardedHeaders.XForwardedProto);

                options.ForwardLimit.ShouldBeNull();
            }

            [Test]
            public void Given_no_known_proxies_or_networks_then_it_does_not_restrict_the_proxies()
            {
                var options = new ForwardedHeadersOptions();
                new ForwardedHeadersOptionsConfigurator(ProxyHeadersEnforced()).Configure(options);

                options.KnownProxies.ShouldBeEmpty();
                options.KnownIPNetworks.ShouldBeEmpty();
            }

            [Test]
            public void Given_known_proxies_and_networks_then_it_only_trusts_them()
            {
                var options = new ForwardedHeadersOptions();

                new ForwardedHeadersOptionsConfigurator(
                        ProxyHeadersEnforced(knownProxies: ["10.0.0.2", "::1"], knownNetworks: ["172.16.0.0/12"]))
                    .Configure(options);

                options.KnownProxies.ShouldBe([IPAddress.Parse("10.0.0.2"), IPAddress.IPv6Loopback]);
                options.KnownIPNetworks.ShouldBe([System.Net.IPNetwork.Parse("172.16.0.0/12")]);
            }

            [Test]
            public void Given_an_invalid_known_proxy_then_it_throws()
            {
                var configurator = new ForwardedHeadersOptionsConfigurator(ProxyHeadersEnforced(knownProxies: ["proxy.local"]));

                Should.Throw<System.InvalidOperationException>(() => configurator.Configure(new ForwardedHeadersOptions()))
                    .Message.ShouldContain("proxy.local");
            }

            [Test]
            public void Given_an_invalid_known_network_then_it_throws()
            {
                var configurator = new ForwardedHeadersOptionsConfigurator(ProxyHeadersEnforced(knownNetworks: ["10.0.0.0"]));

                Should.Throw<System.InvalidOperationException>(() => configurator.Configure(new ForwardedHeadersOptions()))
                    .Message.ShouldContain("10.0.0.0");
            }
        }
    }
}
