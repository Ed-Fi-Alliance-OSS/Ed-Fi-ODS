namespace EdFi.Ods.Admin.Initialization
{
    public class UserOptions
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Admin { get; set; }

        public string[] NamespacePrefixes { get; set; }

        public SandboxOptions[] Sandboxes { get; set; }
    }
}
