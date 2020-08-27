// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.LoadTools.SmokeTest;
using Fclp;

namespace EdFi.SmokeTest.Console.Application
{
    public class CommandLineParser : FluentCommandLineParser<Configuration>
    {
        public CommandLineParser()
        {
            Setup(arg => arg.ApiUrl).As('a', "apiurl")
                                    .WithDescription("The web API url (i.e. http://server/v3)")
                                    .Required();

            Setup(arg => arg.OAuthKey).As('k', "key")
                                      .WithDescription("The web API OAuth key")
                                      .Required();

            Setup(arg => arg.SdkLibraryPath).As('l', "library")
                                            .WithDescription("The complete path to a compiled Ed-Fi SDK library");

            Setup(arg => arg.MetadataUrl).As('m', "metadataurl")
                                         .WithDescription("The OpenAPI (Swagger) metadata url (i.e. http://server/swagger)");

            Setup(arg => arg.NamespacePrefix).As('n', "namespace")
                                             .WithDescription("Overrride the URI to use when generating namespace values (i.e. uri://ed-fi.org)")
                                             .SetDefault("uri://ed-fi.org");

            Setup(arg => arg.OAuthUrl).As('o', "oauthurl")
                                      .WithDescription("The OAuth url (i.e. http://server/oauth)")
                                      .Required();

            Setup(arg => arg.OAuthSecret).As('s', "secret")
                                         .WithDescription("The web API OAuth secret")
                                         .Required();

            Setup(arg => arg.TestSet).As('t', "testset")
                                     .WithDescription($"The test set to run (i.e. {TestSets})")
                                     .Required();

            Setup(arg => arg.SchoolYear).As('y', "year")
                                        .WithDescription("The target school year for the web API (i.e. 2016)");

            SetupHelp("?", "Help").Callback(text => { System.Console.WriteLine(text); });
        }

        private static string TestSets => string.Join(
            ", ", Enum.GetValues(typeof(TestSet))
                      .Cast<TestSet>().Select(x => x.ToString()));
    }
}
