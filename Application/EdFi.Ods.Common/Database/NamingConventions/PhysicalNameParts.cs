// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Database.NamingConventions
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