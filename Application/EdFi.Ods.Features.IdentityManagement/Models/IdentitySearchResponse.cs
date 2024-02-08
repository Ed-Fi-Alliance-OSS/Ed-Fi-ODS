namespace EdFi.Ods.Features.IdentityManagement.Models
{
    public class IdentitySearchResponse<TIdentityResponse>
        where TIdentityResponse : IdentityResponse
    {
        public SearchResponseStatus Status { get; set; }

        public IdentitySearchResponses<TIdentityResponse>[] SearchResponses { get; set; }
    }
}