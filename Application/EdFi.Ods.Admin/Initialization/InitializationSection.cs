// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Configuration;
using EdFi.Admin.DataAccess;

// ReSharper disable InconsistentNaming
// justification: following naming conventions established in Microsoft Sample Code for .config sections

namespace EdFi.Ods.Admin.Initialization
{
    public sealed class InitializationSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty s_propEnabled;
        private static readonly ConfigurationProperty s_propUsers;
        private static readonly ConfigurationPropertyCollection _properties;

        static InitializationSection()
        {
            s_propEnabled = new ConfigurationProperty("enabled", typeof(bool), false, ConfigurationPropertyOptions.None);
            s_propUsers = new ConfigurationProperty("users", typeof(InitializationUsers), null, ConfigurationPropertyOptions.None);

            _properties = new ConfigurationPropertyCollection
                          {
                              s_propEnabled, s_propUsers
                          };
        }

        [ConfigurationProperty("enabled")]
        public bool Enabled
        {
            get { return (bool) base[s_propEnabled]; }
        }

        [ConfigurationProperty("users")]
        public InitializationUsers Users
        {
            get { return (InitializationUsers) base[s_propUsers]; }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }
    }

    public sealed class UserElement : ConfigurationElement
    {
        private static readonly ConfigurationProperty s_propAdmin;
        private static readonly ConfigurationProperty s_propPassword;
        private static readonly ConfigurationProperty s_propName;
        private static readonly ConfigurationProperty s_propEmail;
        private static readonly ConfigurationProperty s_propSandboxes;
        private static readonly ConfigurationPropertyCollection _properties;

        static UserElement()
        {
            s_propAdmin = new ConfigurationProperty("admin", typeof(bool), false, ConfigurationPropertyOptions.None);
            s_propEmail = new ConfigurationProperty("email", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            s_propName = new ConfigurationProperty("name", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            s_propPassword = new ConfigurationProperty("password", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            s_propSandboxes = new ConfigurationProperty("sandboxes", typeof(InitializationSandboxes), null, ConfigurationPropertyOptions.None);

            _properties = new ConfigurationPropertyCollection
                          {
                              s_propAdmin, s_propEmail, s_propName, s_propPassword, s_propSandboxes
                          };
        }

        [ConfigurationProperty("admin")]
        public bool Admin
        {
            get { return (bool) base[s_propAdmin]; }
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string) base[s_propName]; }
        }

        [ConfigurationProperty("email", IsRequired = true)]
        public string Email
        {
            get { return (string) base[s_propEmail]; }
        }

        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get { return (string) base[s_propPassword]; }
        }

        [ConfigurationProperty("sandboxes")]
        public InitializationSandboxes Sandboxes
        {
            get { return (InitializationSandboxes) base[s_propSandboxes]; }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }
    }

    [ConfigurationCollection(typeof(UserElement), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public sealed class InitializationUsers : ConfigurationElementCollection
    {
        private static readonly ConfigurationPropertyCollection m_properties;

        static InitializationUsers()
        {
            m_properties = new ConfigurationPropertyCollection();
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get { return m_properties; }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }

        public UserElement this[int index]
        {
            get { return (UserElement) BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }

                BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new UserElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((UserElement) element).Name;
        }
    }

    public sealed class SandboxElement : ConfigurationElement
    {
        private static readonly ConfigurationProperty s_propName;
        private static readonly ConfigurationProperty s_propKey;
        private static readonly ConfigurationProperty s_propSecret;
        private static readonly ConfigurationProperty s_propRefresh;
        private static readonly ConfigurationProperty s_propType;
        private static readonly ConfigurationPropertyCollection _properties;

        static SandboxElement()
        {
            s_propName = new ConfigurationProperty("name", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            s_propKey = new ConfigurationProperty("key", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            s_propSecret = new ConfigurationProperty("secret", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            s_propRefresh = new ConfigurationProperty("refresh", typeof(bool), false, ConfigurationPropertyOptions.None);

            s_propType = new ConfigurationProperty(
                "type",
                typeof(SandboxType),
                SandboxType.Minimal,
                new GenericEnumConverter(typeof(SandboxType)),
                new EnumValidator<SandboxType>(),
                ConfigurationPropertyOptions.IsRequired
            );

            _properties = new ConfigurationPropertyCollection
                          {
                              s_propName, s_propKey, s_propSecret, s_propRefresh, s_propType
                          };
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string) base[s_propName]; }
        }

        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get { return (string) base[s_propKey]; }
        }

        [ConfigurationProperty("secret", IsRequired = true)]
        public string Secret
        {
            get { return (string) base[s_propSecret]; }
        }

        [ConfigurationProperty("refresh", IsRequired = false)]
        public bool Refresh
        {
            get { return (bool) base[s_propRefresh]; }
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public SandboxType Type
        {
            get { return (SandboxType) base[s_propType]; }
        }
    }

    [ConfigurationCollection(typeof(SandboxElement), CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public sealed class InitializationSandboxes : ConfigurationElementCollection
    {
        private static readonly ConfigurationPropertyCollection m_properties;

        static InitializationSandboxes()
        {
            m_properties = new ConfigurationPropertyCollection();
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get { return m_properties; }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "sandbox"; }
        }

        public SandboxElement this[int index]
        {
            get { return (SandboxElement) BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }

                BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new SandboxElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SandboxElement) element).Name;
        }
    }
}
