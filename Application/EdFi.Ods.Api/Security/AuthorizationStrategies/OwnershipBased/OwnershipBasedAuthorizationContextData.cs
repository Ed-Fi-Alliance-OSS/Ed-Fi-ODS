using System;
using System.Collections.Generic;
using System.Text;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.OwnershipBased
{
    public class OwnershipBasedAuthorizationContextData
    {
        public short? CreatedByOwnershipTokenId { get; set; }
    }
}
