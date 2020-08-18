// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Tests.EdFi.Ods.WebApi.Common
{
    // TODO: GKM - review these tests
    //[TestFixture]
    //public class SandboxAccessManagerTests
    //{
    //    [Test]
    //    public void Should_Return_False_When_Token_Is_Not_Found()
    //    {
    //        using (var simulatedContext = new HttpSimulator())
    //        {
    //            var badOrMissingTokenHeader = new NameValueCollection
    //            {
    //                {OAuthStringConstants.AuthorizationHeaderName, "TotalNonsense"}
    //            };
    //            simulatedContext.SimulateRequest(new Uri("http://edfi.org/api/student"), HttpVerb.POST, badOrMissingTokenHeader);

    //            var sut = new SandboxAccessManager(new StubDbAccessManager());
    //            sut.BearerTokenInHeaderisValid().ShouldBeFalse();
    //        }
    //    }

    //    [Test]
    //    public void Should_Return_True_When_Token_Is_Found()
    //    {
    //        using (var context = new HttpSimulator())
    //        {
    //            var goodtoken = Guid.NewGuid();
    //            var goodTokenHeader = new NameValueCollection
    //            {
    //                {OAuthStringConstants.AuthorizationHeaderName, OAuthStringConstants.BearerTokenPrefix + goodtoken}
    //            };
    //            context.SimulateRequest(new Uri("http://awesome"), HttpVerb.POST, goodTokenHeader);

    //            var sut = new SandboxAccessManager(new StubDbAccessManager(goodtoken));
    //            sut.BearerTokenInHeaderisValid().ShouldBeTrue();
    //        }
    //   }

    //    [Test]
    //    public void Should_return_false_When_User_is_Authorized()
    //    {
    //        using (var contextSim = new HttpSimulator())
    //        {
    //            var goodtoken = Guid.NewGuid();
    //            var goodTokenHeader = new NameValueCollection
    //            {
    //                {OAuthStringConstants.AuthorizationHeaderName, OAuthStringConstants.BearerTokenPrefix + goodtoken}
    //            };
    //            contextSim.SimulateRequest(new Uri("http://awesome"), HttpVerb.POST, goodTokenHeader);
    //            HttpContext.Current.Items.Add(OAuthStringConstants.Token, goodtoken);

    //            var sut = new SandboxAccessManager(new StubDbAccessManager(goodtoken));
    //            sut.CurrentUserUnauthorized().ShouldBeFalse();
    //        }
    //    }

    //    [Test]
    //    public void Should_return_true_When_User_is_Unauthorized()
    //    {
    //        using (var contextSim = new HttpSimulator())
    //        {
    //            var bad = "BADDIE";
    //            var badTokenHeader = new NameValueCollection
    //            {
    //                {OAuthStringConstants.AuthorizationHeaderName, OAuthStringConstants.BearerTokenPrefix + bad}
    //            };
    //            contextSim.SimulateRequest(new Uri("http://awesome"), HttpVerb.POST, badTokenHeader);

    //            var sut = new SandboxAccessManager(new StubDbAccessManager());
    //            sut.CurrentUserUnauthorized().ShouldBeTrue();
    //        }

    //    }

    //    [Test]
    //    public void Should_Not_use_DB_If_Token_In_Request_Cache()
    //    {
    //        using (var simulatedContext = new HttpSimulator())
    //        {
    //            var token = Guid.NewGuid();
    //            var tokenHeader = new NameValueCollection
    //            {
    //                {OAuthStringConstants.AuthorizationHeaderName, OAuthStringConstants.BearerTokenPrefix + token}
    //            };
    //            simulatedContext.SimulateRequest(new Uri("http://awesome"), HttpVerb.POST, tokenHeader);
    //            HttpContext.Current.CacheInRequest(OAuthStringConstants.Token, token);
    //            IOAuthDbAccessManager youShouldNotBeUsingMe = null;
    //            // ReSharper disable once ExpressionIsAlwaysNull
    //            var sut = new SandboxAccessManager(youShouldNotBeUsingMe);
    //            sut.BearerTokenInHeaderisValid().ShouldBeTrue();
    //        }
    //    }

    //    [Test]
    //    public void Should_Return_working_connection_String_When_User_is_Authorized()
    //    {
    //        using (var contextSim = new HttpSimulator())
    //        {
    //            var expected_Connection_String = "I AM SO VALID";
    //            var goodtoken = Guid.NewGuid();
    //            var goodTokenHeader = new NameValueCollection
    //            {
    //                {OAuthStringConstants.AuthorizationHeaderName, OAuthStringConstants.BearerTokenPrefix + goodtoken}
    //            };
    //            contextSim.SimulateRequest(new Uri("http://awesome"), HttpVerb.POST, goodTokenHeader);
    //            HttpContext.Current.Items.Add(OAuthStringConstants.Token, goodtoken);

    //            var sut = new SandboxAccessManager(new StubDbAccessManager(goodtoken, expected_Connection_String));
    //            if(sut.CurrentUserUnauthorized()) Assert.Fail("The current user is not authorized");
    //            sut.GetSandboxConnectionString().ShouldNotBeEmpty();
    //        }

    //    }

    //    [Test]
    //    public void Should_Cache_Connection_String_In_HTTPContext_When_Getting_From_Access_Manager()
    //    {
    //        using (var context = new HttpSimulator())
    //        {
    //            var connectionString = "I should be cached";
    //            var token = Guid.NewGuid();
    //            var tokenHeader = new NameValueCollection
    //            {
    //                {OAuthStringConstants.AuthorizationHeaderName, OAuthStringConstants.BearerTokenPrefix + token}
    //            };
    //            context.SimulateRequest(new Uri("http://nice"), HttpVerb.POST, tokenHeader);
    //            HttpContext.Current.Items.Add(OAuthStringConstants.Token, token);

    //            var sut = new SandboxAccessManager(new StubDbAccessManager(token, connectionString));
    //            sut.GetSandboxConnectionString();
    //            HttpContext.Current.Items[OAuthStringConstants.SandboxConnectionString].ShouldBe(connectionString);
    //        }
    //    }

    //    [Test]
    //    public void Should_Return_Cached_Connection_String_If_In_Cache()
    //    {
    //        using (var context = new HttpSimulator())
    //        {
    //            var cachedConnectionString = "I am cached";
    //            var unexpectedValue = "I am unpredictable and wrong";
    //            var token = Guid.NewGuid();
    //            var tokenHeader = new NameValueCollection
    //            {
    //                {OAuthStringConstants.AuthorizationHeaderName, OAuthStringConstants.BearerTokenPrefix + token}
    //            };
    //            context.SimulateRequest(new Uri("http://cached"), HttpVerb.POST, tokenHeader);
    //            HttpContext.Current.Items.Add(OAuthStringConstants.Token, token);
    //            HttpContext.Current.Items.Add(OAuthStringConstants.SandboxConnectionString, cachedConnectionString);
    //            var sut = new SandboxAccessManager(new StubDbAccessManager(token, unexpectedValue));
    //            var result = sut.GetSandboxConnectionString();
    //            result.ShouldBe(cachedConnectionString);
    //        }
    //    }

    //    [Test]
    //    public void Should_throw_HttpResponseException_Unauthorized_When_User_is_Unauthorized()
    //    {
    //        using (var contextSim = new HttpSimulator())
    //        {
    //            var bad = "BADDIE";
    //            var badTokenHeader = new NameValueCollection
    //            {
    //                {OAuthStringConstants.AuthorizationHeaderName, OAuthStringConstants.BearerTokenPrefix + bad}
    //            };
    //            contextSim.SimulateRequest(new Uri("http://awesome"), HttpVerb.POST, badTokenHeader);

    //            var sut = new SandboxAccessManager(new StubDbAccessManager());
    //            try
    //            {
    //                sut.GetSandboxConnectionString().ShouldBeEmpty();
    //            }
    //            catch (HttpResponseException re)
    //            {
    //                re.Response.StatusCode.ShouldBe(HttpStatusCode.Unauthorized);
    //            }
    //            catch (Exception e)
    //            {
    //                Assert.Fail("Unexpected Exception thrown: {0}", e.Message);
    //            }
    //        }

    //    }
    //}

    //public class StubDbAccessManager : IOAuthDbAccessManager
    //{
    //    private Guid _validToken;
    //    private bool _everythingIsInvalid;
    //    private string _connectionString;

    //    public StubDbAccessManager()
    //    {
    //        _everythingIsInvalid = true;
    //    }

    //    public StubDbAccessManager(Guid validToken)
    //    {
    //        _validToken = validToken;
    //        _everythingIsInvalid = false;
    //    }

    //    public StubDbAccessManager(Guid validToken, string validConnectionString)
    //    {
    //        _everythingIsInvalid = false;
    //        _validToken = validToken;
    //        _connectionString = validConnectionString;
    //    }

    //    public bool IsTokenValid(Guid token)
    //    {
    //        if (_everythingIsInvalid) return false;
    //        return (_validToken == token);
    //    }

    //    public string GetConnectionStringForToken(Guid token)
    //    {
    //        if (_everythingIsInvalid) return string.Empty;
    //        if (_validToken != token) return string.Empty;
    //        return _connectionString;
    //    }
    //}
}
