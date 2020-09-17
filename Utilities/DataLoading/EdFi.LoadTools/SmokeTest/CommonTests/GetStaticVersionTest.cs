// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Net.Http;
using System.Text.RegularExpressions;
using EdFi.LoadTools.Engine;

namespace EdFi.LoadTools.SmokeTest.CommonTests
{
    public class GetStaticVersionTest : GetStaticBaseTest
    {
        // https://regex101.com/r/G3zh52/1
        private const string MetadataRegex = @"/metadata/*$";

        private static string GetPath(string basePath)
            => !string.IsNullOrWhiteSpace(basePath)
                ? Regex.Replace(basePath, MetadataRegex, "/")
                : null;

        public GetStaticVersionTest(IApiMetadataConfiguration configuration,HttpClient client)
            : base(GetPath(configuration.Url),client) { }
    }
}
