// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using log4net;

namespace EdFi.LoadTools.SmokeTest.ApiTests
{
    public class GetSessionTokenGenerator : ITestGenerator, ITest
    {
        private readonly IOAuthSessionToken _sessionToken;
        private readonly IOAuthTokenHandler _tokenHandler;

        public GetSessionTokenGenerator(IOAuthTokenHandler tokenHandler, IOAuthSessionToken sessionToken)
        {
            _tokenHandler = tokenHandler;
            _sessionToken = sessionToken;
        }

        private ILog Log => LogManager.GetLogger(GetType().Name);

        public Task<bool> PerformTest()
        {
            try
            {
                _sessionToken.SessionToken = _tokenHandler.GetBearerToken();
                Log.Info("Success");
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return Task.FromResult(false);
            }
        }

        public IEnumerable<ITest> GenerateTests()
        {
            yield return this;
        }
    }
}
