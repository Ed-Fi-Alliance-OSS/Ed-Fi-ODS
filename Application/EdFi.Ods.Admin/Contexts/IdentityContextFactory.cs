using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdFi.Ods.Admin.Contexts
{
    public class IdentityContextFactory : IIdentityContextFactory
    {
        public IdentityContextFactory() { }

        public IdentityContext CreateContext()
        {
            return Activator.CreateInstance(typeof(IdentityContext)) as IdentityContext;
        }
    }
}
