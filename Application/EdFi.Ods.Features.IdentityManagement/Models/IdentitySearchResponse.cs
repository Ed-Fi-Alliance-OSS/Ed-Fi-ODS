namespace EdFi.Ods.Features.IdentityManagement.Models
{
    public class IdentitySearchResponse<TSearchResponses, TIdentityResponse>
        where TSearchResponses : IdentitySearchResponses<TIdentityResponse>
        where TIdentityResponse : IdentityResponse
    {
        public SearchResponseStatus Status { get; set; }

        public TSearchResponses[] SearchResponses { get; set; }
    }
}