using System;

namespace EdFi.Ods.Features.IdentityManagement.Models
{
    [Flags]
    public enum IdentityServiceCapabilities
    {
        None = 0x0,
        Create = 0x1,
        Find = 0x2,
        Search = 0x4,
        Results = Find | Search
    }
}