// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Configuration;
using EdFi.Admin.DataAccess;

namespace EdFi.Ods.Admin.Initialization
{
    public sealed class SandboxElement : ConfigurationElement
    {
        private static readonly ConfigurationProperty _name;
        private static readonly ConfigurationProperty _key;
        private static readonly ConfigurationProperty _secret;
        private static readonly ConfigurationProperty _refresh;
        private static readonly ConfigurationProperty _type;
        private static readonly ConfigurationPropertyCollection _properties;

        static SandboxElement()
        {
            _name = new ConfigurationProperty("name", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            _key = new ConfigurationProperty("key", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            _secret = new ConfigurationProperty("secret", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            _refresh = new ConfigurationProperty("refresh", typeof(bool), false, ConfigurationPropertyOptions.None);

            _type = new ConfigurationProperty(
                "type",
                typeof(SandboxType),
                SandboxType.Minimal,
                new GenericEnumConverter(typeof(SandboxType)),
                new EnumValidator<SandboxType>(),
                ConfigurationPropertyOptions.IsRequired
            );

            _properties = new ConfigurationPropertyCollection
            {
                _name,
                _key,
                _secret,
                _refresh,
                _type
            };
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get => (string) base[_name];
        }

        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get => (string) base[_key];
        }

        [ConfigurationProperty("secret", IsRequired = true)]
        public string Secret
        {
            get => (string) base[_secret];
        }

        [ConfigurationProperty("refresh", IsRequired = false)]
        public bool Refresh
        {
            get => (bool) base[_refresh];
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public SandboxType Type
        {
            get => (SandboxType) base[_type];
        }
    }
}
