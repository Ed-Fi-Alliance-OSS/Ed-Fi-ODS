namespace EdFi.Ods.Generator.Common.Database.NamingConventions
{
    public class PhysicalNameParts
    {
        public PhysicalNameParts(string name, string prefix = null, string suffix = null)
        {
            Prefix = prefix;
            Name = name;
            Suffix = suffix;
        }
        
        /// <summary>
        /// Gets or sets the physical naming convention's applied prefix.
        /// </summary>
        public string Prefix { get; set; }
        
        /// <summary>
        /// The core physical name of the object.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets the physical naming convention's applied suffix.
        /// </summary>
        public string Suffix { get; set; }

        public override string ToString()
        {
            return $"{Prefix}{Name}{Suffix}";
        }
    }
}