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
        private static readonly ConfigurationProperty _propName;
        private static readonly ConfigurationProperty _propKey;
        private static readonly ConfigurationProperty _propSecret;
        private static readonly ConfigurationProperty _propRefresh;
        private static readonly ConfigurationProperty _propType;
        private static readonly ConfigurationPropertyCollection _properties;

        static SandboxElement()
        {
            _propName = new ConfigurationProperty("name", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            _propKey = new ConfigurationProperty("key", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            _propSecret = new ConfigurationProperty("secret", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            _propRefresh = new ConfigurationProperty("refresh", typeof(bool), false, ConfigurationPropertyOptions.None);

            _propType = new ConfigurationProperty(
                "type",
                typeof(SandboxType),
                SandboxType.Minimal,
                new GenericEnumConverter(typeof(SandboxType)),
                new EnumValidator<SandboxType>(),
                ConfigurationPropertyOptions.IsRequired
            );

            _properties = new ConfigurationPropertyCollection
            {
                _propName,
                _propKey,
                _propSecret,
                _propRefresh,
                _propType
            };
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get => (string) base[_propName];
        }

        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get => (string) base[_propKey];
        }

        [ConfigurationProperty("secret", IsRequired = true)]
        public string Secret
        {
            get => (string) base[_propSecret];
        }

        [ConfigurationProperty("refresh", IsRequired = false)]
        public bool Refresh
        {
            get => (bool) base[_propRefresh];
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public SandboxType Type
        {
            get => (SandboxType) base[_propType];
        }
    }
}
