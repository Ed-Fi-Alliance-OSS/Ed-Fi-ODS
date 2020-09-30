using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Services.Authorization;
using EdFi.Ods.Api.Services.Filters;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Api.Services.Authentication
{
    public class BearerTokenHeaderProcessor : IBearerTokenHeaderProcessor
    {
        private const string AuthenticationScheme = "Bearer";
        
        private readonly Lazy<bool?> _expectedUseSandboxValue;

        private readonly IOAuthTokenValidator _oAuthTokenValidator;

        public BearerTokenHeaderProcessor(IOAuthTokenValidator oAuthTokenValidator, IConfigValueProvider configValueProvider)
        {
            _oAuthTokenValidator = oAuthTokenValidator;
            
            const string ExpectedUseSandboxValue = "ExpectedUseSandboxValue";
            
            _expectedUseSandboxValue = new Lazy<bool?>(
                () => configValueProvider.GetValue(ExpectedUseSandboxValue) == null
                    ? (bool?) null
                    : Convert.ToBoolean(configValueProvider.GetValue(ExpectedUseSandboxValue)));
        }
        
        public async Task<BearerTokenProcessingResult> ProcessAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // 1. Look for credentials in the request.
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            // 2. If there are no credentials, do nothing.
            if (authorization == null)
            {
                return new BearerTokenProcessingResult(new AuthenticationFailureResult("Missing credentials", request));
            }

            // 3. If there are credentials but the filter does not recognize the 
            //    authentication scheme, do nothing.
            if (!authorization.Scheme.EqualsIgnoreCase(AuthenticationScheme))
            {
                return new BearerTokenProcessingResult();
            }

            // 4. If there are credentials that the filter understands, try to validate them.
            // 5. If the credentials are bad, set the error result.
            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                return new BearerTokenProcessingResult(new AuthenticationFailureResult("Missing parameter", request));
            }

            // Validate the token and get the corresponding API key details
            var apiClientDetails = await _oAuthTokenValidator.GetClientDetailsForTokenAsync(authorization.Parameter);

            if (!apiClientDetails.IsTokenValid)
            {
                return new BearerTokenProcessingResult(new AuthenticationFailureResult("Invalid token", request));
            }

            if (_expectedUseSandboxValue.Value.HasValue &&
                apiClientDetails.IsSandboxClient != _expectedUseSandboxValue.Value.Value)
            {
                var message = apiClientDetails.IsSandboxClient
                    ? "Sandbox credentials used in call to Production API"
                    : "Production credentials used in call to Sandbox API";

                return new BearerTokenProcessingResult(new AuthenticationFailureResult(message, request));
            }
            
            return new BearerTokenProcessingResult(apiClientDetails);
        }
    }
}
