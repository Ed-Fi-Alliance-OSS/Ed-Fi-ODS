// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Configuration;

namespace EdFi.Ods.Admin.Initialization
{
    public sealed class NamespacePrefixElement : ConfigurationElement
    {
        private readonly ConfigurationProperty _name;
        private static ConfigurationPropertyCollection _properties;

        public NamespacePrefixElement()
        {
            _name = new ConfigurationProperty("name", typeof(string), null, ConfigurationPropertyOptions.IsRequired);

            _properties = new ConfigurationPropertyCollection {_name};
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get => (string) base[_name];
        }
    }
}
