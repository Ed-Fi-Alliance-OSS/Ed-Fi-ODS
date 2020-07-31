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
    public class HttpActionResultWithError : IHttpActionResult
    {
        private readonly string _errorMessage;
        private readonly IHttpActionResult _innerResult;
        private readonly Action<HttpResponseMessage> _responseAction;

        public HttpActionResultWithError(IHttpActionResult inner, Action<HttpResponseMessage> responseAction)
            : this(inner, null, responseAction) { }

        public HttpActionResultWithError(IHttpActionResult inner, string errorMessage, Action<HttpResponseMessage> responseAction = null)
        {
            _innerResult = inner;
            _errorMessage = errorMessage;
            _responseAction = responseAction;
        }

        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = await _innerResult.ExecuteAsync(cancellationToken);
            var retvalue = response.RequestMessage.CreateErrorResponse(response.StatusCode, _errorMessage);

            if (_responseAction != null)
            {
                _responseAction(retvalue);
            }

            return retvalue;
        }
    }
}
