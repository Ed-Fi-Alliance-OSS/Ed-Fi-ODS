// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Configuration;

namespace EdFi.Ods.Admin.Initialization
{
    public sealed class UserElement : ConfigurationElement
    {
        private static readonly ConfigurationProperty _propAdmin;
        private static readonly ConfigurationProperty _propPassword;
        private static readonly ConfigurationProperty _propName;
        private static readonly ConfigurationProperty _propEmail;
        private static readonly ConfigurationProperty _propSandboxes;
        private static readonly ConfigurationPropertyCollection _properties;

        static UserElement()
        {
            _propAdmin = new ConfigurationProperty("admin", typeof(bool), false, ConfigurationPropertyOptions.None);
            _propEmail = new ConfigurationProperty("email", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            _propName = new ConfigurationProperty("name", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            _propPassword = new ConfigurationProperty("password", typeof(string), null, ConfigurationPropertyOptions.IsRequired);

            _propSandboxes = new ConfigurationProperty(
                "sandboxes", typeof(InitializationSandboxes), null, ConfigurationPropertyOptions.None);

            _properties = new ConfigurationPropertyCollection
            {
                _propAdmin,
                _propEmail,
                _propName,
                _propPassword,
                _propSandboxes
            };
        }

        [ConfigurationProperty("admin")]
        public bool Admin
        {
            get => (bool) base[_propAdmin];
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get => (string) base[_propName];
        }

        [ConfigurationProperty("email", IsRequired = true)]
        public string Email
        {
            get => (string) base[_propEmail];
        }

        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get => (string) base[_propPassword];
        }

        [ConfigurationProperty("sandboxes")]
        public InitializationSandboxes Sandboxes
        {
            get => (InitializationSandboxes) base[_propSandboxes];
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get => _properties;
        }
    }
}
