// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace EdFi.Ods.Api.Services.CustomActionResults
{
    public class HttpActionResultWithAction : IHttpActionResult
    {
        private readonly IHttpActionResult _innerResult;
        private readonly Action<HttpResponseMessage> _responseAction;
        private readonly string _responsePhrase;

        public HttpActionResultWithAction(IHttpActionResult inner, Action<HttpResponseMessage> responseAction)
            : this(inner, null, responseAction) { }

        public HttpActionResultWithAction(IHttpActionResult inner, string responsePhrase, Action<HttpResponseMessage> responseAction = null)
        {
            _innerResult = inner;
            _responsePhrase = responsePhrase;
            _responseAction = responseAction;
        }

        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = await _innerResult.ExecuteAsync(cancellationToken);

            if (!string.IsNullOrWhiteSpace(_responsePhrase))
            {
                response.ReasonPhrase = _responsePhrase;
            }

            if (_responseAction != null)
            {
                _responseAction(response);
            }

            return response;
        }
    }
}
