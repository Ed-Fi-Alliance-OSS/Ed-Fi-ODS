using System.Collections.Generic;

namespace EdFi.Ods.Security.Utilities
{
    public interface IAuthorizationViewsProvider
    {
        IList<string> GetAuthorizationViews();
    }
}
