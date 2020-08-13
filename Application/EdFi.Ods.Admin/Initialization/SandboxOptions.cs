using EdFi.Admin.DataAccess;

namespace EdFi.Ods.Admin.Initialization
{
    public class SandboxOptions
    {
        public string Name { get; set; }

        public string Key { get; set; }

        public string Secret { get; set; }

        public SandboxType Type { get; set; }

        public bool Refresh { get; set; }
    }
}
