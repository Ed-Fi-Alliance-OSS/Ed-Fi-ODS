// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
#if NETFRAMEWORK
using System.Web.Http;
using EdFi.Ods.Api.Common.ExternalTasks;
using EdFi.Ods.Api.ContainerBuilders;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Api.Startup;
using log4net;
using log4net.Config;
using Microsoft.Owin.Logging;
using Owin;
using System;
using Castle.Windsor;

namespace EdFi.Ods.Api
{
    public abstract class StartupBase : IDisposable
    {
        protected IWindsorContainer Container;
        protected ILog Logger = LogManager.GetLogger(typeof(StartupBase));

        public void Dispose()
        {
            Container?.Dispose();
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            // install logging
            XmlConfigurator.Configure();

            bool isValidConfig;

            try
            {
                EnsureAssembliesLoaded();

                // configure container
                var containerBuilder = new WindsorContainerBuilder();

                Container = containerBuilder.Build();

                ConfigurationSpecificRegistration();

                isValidConfig = true;
            }
            catch (Exception e)
            {
                // we swallow the container exceptions so we can still return a valid api with a status of 500. c.f. (ODS-3240)
                Logger.Warn("The container could not be built.");
                Logger.Error(e);
                isValidConfig = false;
            }

            appBuilder.SetLoggerFactory(new Log4NetLoggerFactory());

            if (isValidConfig)
            {
                Logger.Info("Starting ODS/API with a valid container.");

                appBuilder
                    .Use<RemoveServerHeaderMiddleware>()
                    .UseWebApi(Container.Resolve<HttpConfiguration>());

                // invoke any external tasks if they are installed
                foreach (var externalTask in Container.ResolveAll<IExternalTask>())
                {
                    Logger.Info($"Executing task {externalTask.GetType().Name}.");
                    externalTask.Execute();
                }
            }
            else
            {
                // Invalid windsor container
                Logger.Info("Starting ODS/API to redirect to a 500.");

                appBuilder
                    .Use<InvalidWindsorContainerMiddleware>();
            }

            Logger.Info("ODS/Api is running.");
        }

        /// <summary>
        /// Location to reference types in assemblies to ensure the assemblies are loaded. Recommendation is to use AssemblyLoader.EnsureLoaded<T>.
        /// </summary>
        protected virtual void EnsureAssembliesLoaded() { }

        /// <summary>
        /// Apply custom registration overrides.
        /// </summary>
        protected virtual void ConfigurationSpecificRegistration() { }
    }
}
#endif
