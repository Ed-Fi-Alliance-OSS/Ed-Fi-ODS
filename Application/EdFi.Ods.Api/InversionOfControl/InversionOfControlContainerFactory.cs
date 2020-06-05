// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using EdFi.Ods.Common.InversionOfControl;
#if NETFRAMEWORK
using Castle.Windsor.Installer;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.InversionOfControl
{
    /// <summary>
    /// Creates and initializes a Castle Windsor container using the installers configured for the application.
    /// </summary>

    //[Obsolete("Use explicit installers - to be deleted")]
    public class InversionOfControlContainerFactory
    {
        private readonly IConfigSectionProvider configSectionProvider;
        private readonly IConfigValueProvider configValueProvider;

        // private readonly ILog logger = LogManager.GetLogger(typeof(InversionOfControlContainerFactory));

        /// <summary>
        /// Initializes a new instance of the <see cref="InversionOfControlContainerFactory"/> class using the default values.
        /// </summary>
        public InversionOfControlContainerFactory()
            : this(new AppConfigSectionProvider(), new AppConfigValueProvider()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InversionOfControlContainerFactory"/> class with the specified 
        /// configuration section and value providers, as well as the assembly to scan for additional installers.
        /// </summary>
        /// <param name="configSectionProvider">A provider that enables access to configuration sections.</param>
        /// <param name="configValueProvider">A provider that enables access to configuration values in the 'appSettings' section.</param>
        public InversionOfControlContainerFactory(IConfigSectionProvider configSectionProvider, IConfigValueProvider configValueProvider)
        {
            this.configSectionProvider = configSectionProvider;
            this.configValueProvider = configValueProvider;
        }

        /// <summary>
        /// Creates the Castle Windsor container using the "castle" section from the application configuration file (if it exists). 
        /// </summary>
        /// <returns>The newly initialized container.</returns>
        public IWindsorContainer CreateContainer()
        {
            return CreateContainer(null, null);
        }

        /// <summary>
        /// Creates the Castle Windsor container using the "castle" section from the application configuration file (if it exists),
        /// and then executes all the "installers" found in the specified assembly to register all components with the container. 
        /// </summary>
        /// <param name="assemblyToScanForAdditionalInstallers">The assembly to scan for additional installers.</param>
        /// <returns>The newly initialized container.</returns>
        public IWindsorContainer CreateContainer(Assembly assemblyToScanForAdditionalInstallers)
        {
            return CreateContainer(null, assemblyToScanForAdditionalInstallers);
        }

        /// <summary>
        /// Creates the Castle Windsor container using the "castle" section from the application configuration file (if it exists),
        /// calls the provided <paramref name="onExecutingInstallers"/> delegate, and then executes all the "installers" found in the 
        /// specified assembly (if supplied) to register all components with the container. 
        /// </summary>
        /// <param name="onExecutingInstallers">An action delegate to be executed after the container is created, but before any of 
        /// the installers are executed.  Provides an opportunity for the caller to install facilities, subresolvers, etc. prior
        /// to the full registration of components.</param>
        /// <param name="assemblyToScanForAdditionalInstallers">The assembly to scan for additional installers.</param>
        /// <param name="allowableEmptyCollectionItemTypes"></param>
        /// <returns>The newly initialized container.</returns>
        public IWindsorContainer CreateContainer(
            Action<IWindsorContainer> onExecutingInstallers,
            Assembly assemblyToScanForAdditionalInstallers = null)
        {
            var castleSection = configSectionProvider.GetSection("castle");

            // Determine if the "castle" section of the web.config file exists
            bool hasXmlConfig = !(castleSection == null
                                  || string.IsNullOrWhiteSpace(
                                      ((ConfigurationSection) castleSection)
                                     .SectionInformation.GetRawXml()));

            // Create the container (and initialize from config file section, if present)
            var container = hasXmlConfig
                ? new WindsorContainerEx(new XmlInterpreter())
                : new WindsorContainerEx();

            // Add collection support
            container.AddSupportForEmptyCollections();

            if (onExecutingInstallers != null)
            {
                onExecutingInstallers(container);
            }

            // Install other components into the container, using installers
            var allConfiguredInstallers = GetConfiguredInstallers();

            // logger.Debug("Installing " + allConfiguredInstallers.Length + " installers from config file.");
            container.Install(allConfiguredInstallers);

            // Scan for other installers in the assembly, if provided
            // TODO: We will want to remove this functionality altogether once all uses of this behavior are removed
            if (assemblyToScanForAdditionalInstallers != null)
            {
                container.Install(FromAssembly.Instance(assemblyToScanForAdditionalInstallers, new CustomInstallerFactory(allConfiguredInstallers)));
            }

            return container;
        }

        private IWindsorInstaller[] GetConfiguredInstallers()
        {
            IEnumerable<string> installerTypeNames = GetInstallerTypeNames();

            var installers = new List<IWindsorInstaller>();

            string configurationName = configValueProvider.GetValue("IoC.Configuration") ?? "Development";

            var entryAssembly = Assembly.GetEntryAssembly();

            string entryAssemblyName = entryAssembly == null
                ? "{Error: EntryAssembly was null. Use explicit assembly name for this application.}"
                : entryAssembly.GetName()
                               .Name;

            foreach (string installerTypeName in installerTypeNames
               .Select(
                    t =>
                    {
                        string replacedInstallerTypeName = t.Replace("{Configuration}", configurationName);

                        if (entryAssemblyName != null)
                        {
                            replacedInstallerTypeName = replacedInstallerTypeName.Replace("{EntryAssembly}", entryAssemblyName);
                        }

                        return replacedInstallerTypeName;
                    }))
            {
                Type t = Type.GetType(installerTypeName);

                if (t == null)
                {
                    throw new InvalidOperationException(string.Format("Could not locate configured type '{0}'.", installerTypeName));
                }

                var installer = Activator.CreateInstance(t) as IWindsorInstaller;

                if (installer == null)
                {
                    throw new InvalidOperationException(
                        string.Format("Configured type '{0}' does not implement IWindsorInstaller.", installerTypeName));
                }

                installers.Add(installer);
            }

            return installers.ToArray();
        }

        private IEnumerable<string> GetInstallerTypeNames()
        {
            IEnumerable<string> installerTypeNames;

            // First check for new installer mechanism (config section)
            var inversionOfControlConfig =
                configSectionProvider.GetSection(InversionOfControlConfiguration.SectionName) as InversionOfControlConfiguration;

            if (inversionOfControlConfig == null)
            {
                // Revert to legacy mechanism of parsing out an appSetting value
                string installersText = configValueProvider.GetValue("WindsorInstallers");

                if (installersText == null)
                {
                    return new string[0];
                }

                installerTypeNames =
                    from rawInstaller in installersText.Split(';')
                    select rawInstaller.Trim('\r', '\n', ' ', '\t');
            }
            else
            {
                // Get installers from "inversionOfControl" config section
                installerTypeNames =
                    from i in inversionOfControlConfig.Installers.OfType<WindsorInstaller>()
                    select i.TypeName;
            }

            return installerTypeNames;
        }

        private class CustomInstallerFactory : InstallerFactory
        {
            private readonly IWindsorInstaller[] alreadyInstalledInstallers;

            public CustomInstallerFactory(IWindsorInstaller[] alreadyInstalledInstallers)
            {
                this.alreadyInstalledInstallers = alreadyInstalledInstallers;
            }

            public override IEnumerable<Type> Select(IEnumerable<Type> installerTypes)
            {
                //Filter out already installed installers.
                var filteredTypesThatHaventBeenInstalled =
                    installerTypes.Where(
                        t => alreadyInstalledInstallers.All(installed => installed.GetType() != t));

                //Filter out any installer that is of type RegistrationMethodsInstallerBase
                var filteredTypes =
                    filteredTypesThatHaventBeenInstalled.Where(
                        t => !typeof(RegistrationMethodsInstallerBase).IsAssignableFrom(t));

                return filteredTypes;
            }
        }
    }
}
#endif
