// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Configuration;

namespace EdFi.Ods.Admin.Initialization
{
    public sealed class UserElement : ConfigurationElement
    {
        private static readonly ConfigurationProperty _admin;
        private static readonly ConfigurationProperty _password;
        private static readonly ConfigurationProperty _name;
        private static readonly ConfigurationProperty _email;
        private static readonly ConfigurationProperty _sandboxes;
        private static readonly ConfigurationProperty _namespacePrefixes;
        private static readonly ConfigurationPropertyCollection _properties;

        static UserElement()
        {
            _admin = new ConfigurationProperty("admin", typeof(bool), false, ConfigurationPropertyOptions.None);
            _email = new ConfigurationProperty("email", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            _name = new ConfigurationProperty("name", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            _password = new ConfigurationProperty("password", typeof(string), null, ConfigurationPropertyOptions.IsRequired);

            _sandboxes = new ConfigurationProperty(
                "sandboxes", typeof(InitializationSandboxes), null, ConfigurationPropertyOptions.None);

            _namespacePrefixes = new ConfigurationProperty(
                "namespacePrefixes", typeof(InitializationNamespacePrefixes), null, ConfigurationPropertyOptions.None);

            _properties = new ConfigurationPropertyCollection
            {
                _admin,
                _email,
                _name,
                _password,
                _sandboxes,
                _namespacePrefixes
            };
        }

        [ConfigurationProperty("admin")]
        public bool Admin
        {
            get => (bool) base[_admin];
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get => (string) base[_name];
        }

        [ConfigurationProperty("email", IsRequired = true)]
        public string Email
        {
            get => (string) base[_email];
        }

        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get => (string) base[_password];
        }

        [ConfigurationProperty("sandboxes")]
        public InitializationSandboxes Sandboxes
        {
            get => (InitializationSandboxes) base[_sandboxes];
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get => _properties;
        }

        [ConfigurationProperty("namespacePrefixes")]
        public InitializationNamespacePrefixes NamespacePrefixes
        {
            get => (InitializationNamespacePrefixes) base[_namespacePrefixes];
        }
    }
}
