using System.Threading.Tasks;

namespace EdFi.Ods.Features.IdentityManagement.Models
{
    /// <summary>
    /// Implement this interface if the supporting service supports asynchronous methods 
    /// </summary>
    public interface IIdentityServiceAsync
    {
        /// <summary>
        /// Which IdentityServices does the supporting service implement
        /// </summary>
        IdentityServiceCapabilities IdentityServiceCapabilities { get; }

        /// <summary>
        /// Begin an asynchronous request to find existing identities by their identifiers
        /// </summary>
        /// <param name="findRequest"></param>
        /// <returns>An identity response status of: Success</returns>
        Task<IdentityResponseStatus<string>> Find(params string[] findRequest);

        /// <summary>
        /// Begin an asynchronous request to search for exact and potential identity matches
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns>An identity response status of: Success</returns>
        Task<IdentityResponseStatus<string>> Search(params IdentitySearchRequest[] searchRequest);

        /// <summary>
        /// Retrieve the results from a previously submitted search
        /// </summary>
        /// <param name="requestToken">a unique string representing the request</param>
        /// <returns>An identity response status of: Incomplete, Success with IdentityResponse[], or NotFound</returns>
        Task<IdentityResponseStatus<IdentitySearchResponse>> Response(string requestToken);
    }
}