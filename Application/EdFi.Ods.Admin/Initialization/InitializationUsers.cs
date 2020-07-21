// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Configuration;

namespace EdFi.Ods.Admin.Initialization
{
    [ConfigurationCollection(typeof(UserElement), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public sealed class InitializationUsers : ConfigurationElementCollection
    {
        private static readonly ConfigurationPropertyCollection _properties;

        static InitializationUsers()
        {
            _properties = new ConfigurationPropertyCollection();
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get => _properties;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get => ConfigurationElementCollectionType.AddRemoveClearMap;
        }

        public UserElement this[int index]
        {
            get => (UserElement) BaseGet(index);
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
}
