// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Configuration;

namespace EdFi.Ods.Admin.Initialization
{
    public sealed class InitializationSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty _propEnabled;
        private static readonly ConfigurationProperty _propUsers;
        private static readonly ConfigurationPropertyCollection _properties;

        static InitializationSection()
        {
            _propEnabled = new ConfigurationProperty("enabled", typeof(bool), false, ConfigurationPropertyOptions.None);
            _propUsers = new ConfigurationProperty("users", typeof(InitializationUsers), null, ConfigurationPropertyOptions.None);

            _properties = new ConfigurationPropertyCollection
            {
                _propEnabled,
                _propUsers
            };
        }

        [ConfigurationProperty("enabled")]
        public bool Enabled
        {
            get => (bool) base[_propEnabled];
        }

        [ConfigurationProperty("users")]
        public InitializationUsers Users
        {
            get => (InitializationUsers) base[_propUsers];
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get => _properties;
        }
    }
}
