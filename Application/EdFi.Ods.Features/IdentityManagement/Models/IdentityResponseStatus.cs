using Microsoft.AspNetCore.Identity;

namespace EdFi.Ods.Features.IdentityManagement.Models
{
    public class IdentityResponseStatus<TResponse>
    {
        public TResponse Data { get; set; }

        public IdentityStatusCode StatusCode { get; set; }

        public IdentityError[] Errors { get; set; }
    }
}