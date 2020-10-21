namespace EdFi.Ods.Features.IdentityManagement.Models
{
    public class IdentitySearchResponse
    {
        public SearchResponseStatus Status { get; set; }

        public IdentitySearchResponses[] SearchResponses { get; set; }
    }
}