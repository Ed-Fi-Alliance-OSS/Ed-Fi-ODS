// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
namespace EdFi.Ods.WebService.Tests.Owin
{
    internal class OwinUriHelper
    {
        private const string EdFiOrganizationCode = "ed-fi";
        private const string ApiVersion = "3";
        private const string CompositeVersion = "1";
        private const string ChangeQueriesVersion = "1";
        private const string OdsArea = "data";
        private const string CompositesArea = "composites";
        private const string IdentityArea = "identity";
        private const string ChangeQueriesArea = "changequeries";
        private const string UriWithoutSchema = "http://owin/{0}/v{1}/{2}{3}";
        private const string UriWithSchema = "http://owin/{0}/v{1}/{2}/{3}{4}";
        private const string UriWithSchoolYear = "http://owin/{0}/v{1}/{2}{3}/{4}{5}";
        private const string UriDependenciesWithoutSchema = "http://owin/metadata/{0}/v{1}/{2}{3}";
        private const string UriDependenciesWithSchema = "http://owin/metadata/{0}/v{1}/{2}/{3}{4}";
        private const string UriDependenciesWithSchoolYear = "http://owin/metadata/{0}/v{1}/{2}{3}/{4}{5}";

        internal static string BuildOdsUri(string resourceName, int? schoolYear = null, string queryString = null , bool metadata = false)
        {
            return BuildApiUri(OdsArea, ApiVersion, resourceName, metadata ? "" : EdFiOrganizationCode, schoolYear, queryString ,metadata);
        }

        internal static string BuildIdentityUri(string resourceName, int? schoolYear = null, string queryString = null)
        {
            return BuildIdentityUri(resourceName, "2", schoolYear, queryString);
        }

        internal static string BuildIdentityUri(string resourceName, string version, int? schoolYear = null, string queryString = null)
        {
            return BuildApiUri(IdentityArea, version, resourceName, null, schoolYear, queryString);
        }

        internal static string BuildCompositeUri(
            string compositeName,
            string organizationCode = EdFiOrganizationCode,
            int? schoolYear = null,
            string queryString = null)
        {
            return BuildApiUri(CompositesArea, CompositeVersion, compositeName, organizationCode, schoolYear, queryString);
        }

        internal static string CreateAvailableChangeVersionUri()
        {
            return string.Format(UriWithoutSchema, ChangeQueriesArea, ChangeQueriesVersion, "AvailableChangeVersions", string.Empty);
        }

        private static string BuildApiUri(
            string area,
            string version,
            string resourceName,
            string schema = null,
            int? schoolYear = null,
            string queryString = null,
            bool metaData = false)
        {
            return schoolYear != null
                ? string.Format(metaData ? UriDependenciesWithSchoolYear : UriWithSchoolYear ,
                    area,
                    version,
                    schoolYear + (schema != null
                        ? "/"
                        : string.Empty),
                    schema,
                    resourceName,
                    string.IsNullOrWhiteSpace(queryString)
                        ? ""
                        : "?" + queryString)
                : string.IsNullOrWhiteSpace(schema)
                    ? string.Format(metaData ? UriDependenciesWithoutSchema : UriWithoutSchema ,
                        area,
                        version,
                        resourceName,
                        string.IsNullOrWhiteSpace(queryString)
                            ? ""
                            : "?" + queryString)
                    : string.Format(metaData ? UriDependenciesWithSchema : UriWithSchema,
                        area,
                        version,
                        schema,
                        resourceName,
                        string.IsNullOrWhiteSpace(queryString)
                            ? ""
                            : "?" + queryString);
        }
    }
}
