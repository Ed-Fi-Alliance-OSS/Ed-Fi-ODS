// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Linq;
using EdFi.ApiLoader.Console.Properties;
using EdFi.LoadTools.BulkLoadClient.Application;
using Fclp;

namespace EdFi.BulkLoadClient.Console.Application
{
    public class CommandLineParser : FluentCommandLineParser<Configuration>
    {
        public CommandLineParser()
        {
            Setup(arg => arg.ApiUrl).As('a', "apiurl")
                .WithDescription("The web API url (i.e. http://server/)")
                .SetDefault(new Uri(new Uri(Settings.Default.BaseUrl), "/data/v3/").ToString());

            Setup(arg => arg.SchoolYear).As('y', "year")
                .WithDescription("The target school year for the web API (i.e. 2016)")
                .SetDefault(GetFirstValue(Settings.Default.SchoolYear, DateTime.Today.Year));

            Setup(arg => arg.Retries).As('r', "retries")
                .WithDescription("The number of times to retry submitting a resource")
                .SetDefault(GetFirstValue(Settings.Default.MaxRetries, 3));

            Setup(arg => arg.DataFolder).As('d', "data")
                .WithDescription("Path to folder containing the data files to be submitted")
                .SetDefault(GetFirstValue(Settings.Default.DataFolder, Directory.GetCurrentDirectory()));

            Setup(arg => arg.OauthKey).As('k', "key")
                .WithDescription("The web API OAuth key")
                .SetDefault(Settings.Default.OAuthKey);

            Setup(arg => arg.Metadata).As('f', "force")
                .WithDescription("Force reload of metadata from metadata url")
                .SetDefault(false);

            Setup(arg => arg.MetadataUrl).As('m', "metadataurl")
                .WithDescription("The metadata url (i.e. http://server/metadata)")
                .SetDefault(new Uri(new Uri(Settings.Default.BaseUrl), "/metadata").ToString());

            Setup(arg => arg.OauthUrl).As('o', "oauthurl")
                .WithDescription("The OAuth url (i.e. http://server/oauth)")
                .SetDefault(new Uri(new Uri(Settings.Default.BaseUrl), "/oauth").ToString());

            Setup(arg => arg.Profile).As('p', "profile")
                .WithDescription("The name of an API profile to use (optional)");

            Setup(arg => arg.OauthSecret).As('s', "secret")
                .WithDescription("The web API OAuth secret")
                .SetDefault(Settings.Default.OAuthSecret);

            Setup(arg => arg.WorkingFolder).As('w', "working")
                .WithDescription("Path to a writable folder containing the working files")
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
                        Path.Combine(Directory.GetCurrentDirectory(), "Schema")));

            Setup(arg => arg.DoNotValidateXml).As('n', "novalidation")
                .WithDescription("Do not validate incoming XML documents against the XSD Schema")
                .SetDefault(false);

            Setup(arg => arg.ConnectionLimit).As('c', "connectionlimit")
                .WithDescription("Max number of simultaneous API requests")
                .SetDefault(Settings.Default.ConnectionLimit);

            Setup(arg => arg.TaskCapacity).As('t', "taskcapacity")
                .WithDescription("Maximum concurrent tasks to be buffered")
                .SetDefault(GetFirstValue(Settings.Default.TaskCapacity, 50));

            Setup(arg => arg.MaxSimultaneousRequests).As('l', "maxRequests")
                .WithDescription("Max number of simultaneous API requests")
                .SetDefault(GetFirstValue(Settings.Default.MaxSimultaneousApiRequests, 1));

            Setup(arg => arg.DependenciesUrl).As('g', "dependenciesUrl")
                .WithDescription("The Dependencies endpoint url")
                .SetDefault(new Uri(new Uri(Settings.Default.BaseUrl), "/metadata/data/v3/dependencies").ToString());

            Setup(arg => arg.IncludeStats).As("include-stats")
                .WithDescription("Include timing stats");
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
