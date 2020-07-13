// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Configuration;

namespace EdFi.Ods.Admin.Initialization
{
    [ConfigurationCollection(typeof(NamespacePrefixElement), AddItemName = "namespacePrefix", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public sealed class InitializationNamespacePrefixes : ConfigurationElementCollection
    {
        private static readonly ConfigurationPropertyCollection _properties;

        static InitializationNamespacePrefixes()
        {
            _properties = new ConfigurationPropertyCollection();
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get => _properties;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get => ConfigurationElementCollectionType.BasicMap;
        }

        protected override string ElementName
        {
            get => "namespacePrefix";
        }

        protected override bool IsElementName(string elementName)
        {
            return elementName == "namespacePrefix";
        }

        public NamespacePrefixElement this[int index]
        {
            get => (NamespacePrefixElement) BaseGet(index);
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }

                BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement() => new NamespacePrefixElement();

        protected override object GetElementKey(ConfigurationElement element) => ((NamespacePrefixElement) element).Name;
    }
}
