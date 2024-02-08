namespace EdFi.Ods.Features.IdentityManagement.Models
{
    public class IdentitySearchResponses<TIdentityResponse>
        where TIdentityResponse : IdentityResponse
    {
        public TIdentityResponse[] Responses { get; set; }
    }
}