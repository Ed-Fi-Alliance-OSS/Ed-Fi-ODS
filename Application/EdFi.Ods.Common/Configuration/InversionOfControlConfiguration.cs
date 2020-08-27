// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Configuration;

namespace EdFi.Ods.Common.Configuration
{
    public class InversionOfControlConfiguration : ConfigurationSection
    {
        public const string SectionName = "inversionOfControl";

        [ConfigurationProperty("installers", IsRequired = true)]
        public WindsorInstallers Installers
        {
            get { return this["installers"] as WindsorInstallers; }
        }
    }

    public class WindsorInstallers : ConfigurationElementCollection
    {
        public new WindsorInstaller this[string name]
        {
            get { return (WindsorInstaller) BaseGet(name); }
        }

        public WindsorInstaller this[int index]
        {
            get { return BaseGet(index) as WindsorInstaller; }
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
            return new WindsorInstaller();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((WindsorInstaller) element).Name;
        }
    }

    public class WindsorInstaller : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return this["name"] as string; }
        }

        [ConfigurationProperty("typeName", IsRequired = true)]
        public string TypeName
        {
            get { return this["typeName"] as string; }
        }
    }
}
