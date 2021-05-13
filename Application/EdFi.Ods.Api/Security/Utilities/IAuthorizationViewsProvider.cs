using System.Collections.Generic;

namespace EdFi.Ods.Api.Security.Utilities
{
    public interface IAuthorizationViewsProvider
    {
        IList<string> GetAuthorizationViews();
    }
}
