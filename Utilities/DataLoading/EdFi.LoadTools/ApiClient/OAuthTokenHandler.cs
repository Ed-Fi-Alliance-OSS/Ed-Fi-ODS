// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Reflection;
using System.Threading.Tasks;
using log4net;

namespace EdFi.LoadTools.ApiClient
{
    public interface IOAuthTokenHandler
    {
        string GetBearerToken();
    }

    public class OAuthTokenHandler : IOAuthTokenHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ITokenRetriever _tokenRetriever;

        public OAuthTokenHandler(ITokenRetriever tokenRetriever)
        {
            _tokenRetriever = tokenRetriever;
        }

        public string GetBearerToken()
        {
            _log.Debug("Getting a new OAuth token");
            var task = Task.Run(() => _tokenRetriever.ObtainNewBearerToken());
            task.Wait();

            var bearerToken = task.Result;

            return bearerToken.Access_token;
        }
    }
}
