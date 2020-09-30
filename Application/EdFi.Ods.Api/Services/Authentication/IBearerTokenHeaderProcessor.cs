using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using EdFi.Ods.Api.Services.Authorization;

namespace EdFi.Ods.Api.Services.Authentication
{
    public interface IBearerTokenHeaderProcessor
    {
        /// <summary>
        /// Processes the supplied HTTP request message for the authorization header containing the bearer token,
        /// returning the associated API client details or the recommended error response.
        /// </summary>
        /// <param name="request">The request to be processed.</param>
        /// <param name="cancellationToken">The cancellation token associated with the request.</param>
        /// <returns>The result of the processing.</returns>
        Task<BearerTokenProcessingResult> ProcessAsync(HttpRequestMessage request, CancellationToken cancellationToken);
    }
    
    /// <summary>
    /// Contains the results of bearer token processing with either API client details (when a valid token is present),
    /// or an error (if an error response should be given), or neither (if the processing could not be performed).
    /// </summary>
    public class BearerTokenProcessingResult
    {
        /// <summary>
        /// Creates a result that indicates that the bearer token could not be processed, but
        /// no error response is indicated.
        /// </summary>
        public BearerTokenProcessingResult() { }
        
        /// <summary>
        /// Creates a result that indicates that the bearer token was valid and resolved to
        /// the specified API client details.
        /// </summary>
        /// <param name="apiClientDetails"></param>
        public BearerTokenProcessingResult(ApiClientDetails apiClientDetails)
        {
            ApiClientDetails = apiClientDetails;
        }
    
        /// <summary>
        /// Creates a result that indicates an error occurred while processing the bearer token,
        /// which should be returned as the result of explicit authentication processing. 
        /// </summary>
        /// <param name="error"></param>
        public BearerTokenProcessingResult(IHttpActionResult error)
        {
            Error = error;
        }
    
        /// <summary>
        /// The API client details associated with the bearer token on the request.
        /// </summary>
        public ApiClientDetails ApiClientDetails { get; private set; }
        
        /// <summary>
        /// The error result for the response (to be used by client if relevant).
        /// </summary>
        public IHttpActionResult Error { get; private set; }
    }
}
