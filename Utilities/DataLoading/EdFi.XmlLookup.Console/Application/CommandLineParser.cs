// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.IO;
using System.Linq;
using EdFi.XmlLookup.Console.Properties;
using Fclp;

namespace EdFi.XmlLookup.Console.Application
{
    public class CommandLineParser : FluentCommandLineParser<Configuration>
    {
        public CommandLineParser()
        {
            Setup(arg => arg.ApiUrl).As('a', "apiurl")
                                    .WithDescription("The web API url (i.e. http://server/v3)")
                                    .SetDefault(Settings.Default.ApiUrl);

            Setup(arg => arg.SchoolYear).As('y', "year")
                                        .WithDescription("The target school year for the web API (i.e. 2016)")
                                        .SetDefault(null);

            Setup(arg => arg.DataFolder).As('d', "data")
                                        .WithDescription("Path to folder containing the XML data files to with lookups to be resolved")
                                        .SetDefault(
                                             GetFirstValue(
                                                 Settings.Default.DataFolder,
                                                 Directory.GetCurrentDirectory()));

            Setup(arg => arg.OauthKey).As('k', "key")
                                      .WithDescription("The web API OAuth key")
                                      .SetDefault(Settings.Default.OAuthKey);

            Setup(arg => arg.Metadata).As('f')
                                      .WithDescription("Force reload of metadata from metadata url")
                                      .SetDefault(false);

            Setup(arg => arg.MetadataUrl).As('m', "metadataurl")
                                         .WithDescription("The metadata url (i.e. http://server/metadata)")
                                         .SetDefault(Settings.Default.SwaggerUrl);

            Setup(arg => arg.OauthUrl).As('o', "oauthurl")
                                      .WithDescription("The OAuth url (i.e. http://server/oauth)")
                                      .SetDefault(Settings.Default.OAuthUrl);

            Setup(arg => arg.Profile).As('p', "profile")
                                     .WithDescription("The name of an API profile to use (optional)");

            Setup(arg => arg.OauthSecret).As('s', "secret")
                                         .WithDescription("The web API OAuth secret")
                                         .SetDefault(Settings.Default.OAuthSecret);

            Setup(arg => arg.WorkingFolder).As('w', "working")
                                           .WithDescription("Path to the folder where working files are located")
                                           .SetDefault(
                                                GetFirstValue(
                                                    Settings.Default.WorkingFolder,
                                                    Directory.GetCurrentDirectory()));

            Setup(arg => arg.XsdFolder).As('x', "xsd")
                                       .WithDescription("Path to a folder containing the Ed-Fi Xsd Schema files")
                                       .SetDefault(
                                            GetFirstValue(
                                                Settings.Default.XsdFolder,
                                                Path.Combine(Settings.Default.WorkingFolder, "Schema"),
                                                Path.Combine(Directory.GetCurrentDirectory(), "Schema")
                                            ));
        }

        private static string GetFirstValue(params string[] defaults)
        {
            return defaults.FirstOrDefault(x => !string.IsNullOrEmpty(x));
        }

        private static T GetFirstValue<T>(params T[] defaults)
        {
            return defaults.FirstOrDefault(x => !Equals(x, default(T)));
        }
    }
}
