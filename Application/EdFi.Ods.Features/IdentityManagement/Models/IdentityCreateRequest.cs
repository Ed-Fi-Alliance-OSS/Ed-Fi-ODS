using System;
using EdFi.Ods.Common.Expando;

namespace EdFi.Ods.Features.IdentityManagement.Models
{
    public class IdentityCreateRequest : Expando
    {
        public string LastSurname { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string GenerationCodeSuffix { get; set; }

        public string SexType { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? BirthOrder { get; set; }

        public Location BirthLocation { get; set; }
    }
}