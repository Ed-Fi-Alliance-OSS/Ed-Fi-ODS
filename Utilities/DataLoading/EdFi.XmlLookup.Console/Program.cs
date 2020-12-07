// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using EdFi.LoadTools;
using EdFi.LoadTools.Engine;
using EdFi.XmlLookup.Console.Application;
using log4net;
using log4net.Config;

namespace EdFi.XmlLookup.Console
{
    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program).Name);

        private static async Task Main(string[] args)
        {
            XmlConfigurator.Configure();
            ConfigureTls();

            //BasicConfigurator.Configure();
            int exitCode;
            var p = new CommandLineParser();

            p.SetupHelp("?", "Help").Callback(
                text =>
                {
                    System.Console.WriteLine(text);
                    Environment.Exit(0);
                });

            var result = p.Parse(args);

            if (result.HasErrors || !p.Object.IsValid)
            {
                exitCode = 1;
                System.Console.Write(result.ErrorText);
                System.Console.Write(p.Object.ErrorText);
            }
            else
            {
                try
                {
                    // configure DI container
                    var container = RegisterContainer();
                    await using var scope = container.BeginLifetimeScope();

                    LogConfiguration(p.Object);

                    // retrieve application
                    var application = container.Resolve<XmlLookupApplication>();

                    // run application
                    exitCode = await application.Run();
                }
                catch (Exception ex)
                {
                    exitCode = 1;
                    Log.Error(ex);
                }
            }

            Environment.Exit(exitCode);

            ILifetimeScope RegisterContainer()
            {
                var builder = new ContainerBuilder();

                builder.RegisterInstance(p.Object)
                    .As<IApiConfiguration>()
                    .As<IDataConfiguration>()
                    .As<IOAuthTokenConfiguration>()
                    .As<IApiMetadataConfiguration>()
                    .As<IXsdConfiguration>()
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterModule(new XmlLookupModule());

                return builder.Build();
            }
        }

        private static void LogConfiguration(Configuration configuration)
        {
            Log.Info($"Api Url:        {configuration.ApiUrl}");
            Log.Info($"School Year:    {configuration.SchoolYear}");
            Log.Info($"Oauth Key:      {configuration.OauthKey}");
            Log.Info($"Metadata Url:   {configuration.MetadataUrl}");
            Log.Info($"Data Folder:    {configuration.DataFolder}");
            Log.Info($"Working Folder: {configuration.WorkingFolder}");
            Log.Info($"Xsd Folder:     {configuration.XsdFolder}");
        }

        /// <summary>
        /// Explicitly configures all outgoing network calls to use the latest version of TLS where possible.
        /// c.f https://docs.microsoft.com/en-us/dotnet/framework/network-programming/tls
        /// </summary>
        private static void ConfigureTls()
        {
            // TLS 1.2 is not available by default for version of the frameworks less that .NET 4.6.2
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }
    }
}
