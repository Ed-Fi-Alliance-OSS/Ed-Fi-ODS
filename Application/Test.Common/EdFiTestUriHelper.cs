// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace Test.Common
{
    public class EdFiTestUriHelper
    {
        private const string EdFiOrganizationCode = "ed-fi";
        private const string ApiVersion = "3";
        private const string CompositeVersion = "1";
        private const string OdsArea = "data";
        private const string CompositesArea = "composites";
        private const string IdentityArea = "identity";

        private readonly string _uriWithoutSchema;
        private readonly string _uriWithSchema;

        private readonly string _uriWithSchoolYear;
        private readonly string _uriDependenciesWithoutSchema;
        private readonly string _uriDependenciesWithSchema;
        private readonly string _uriDependenciesWithSchoolYear;

        public EdFiTestUriHelper(string baseUrl)
        {
            _uriWithoutSchema = baseUrl + "{0}/v{1}/{2}{3}";
            _uriWithSchema = baseUrl + "{0}/v{1}/{2}/{3}{4}";
            _uriWithSchoolYear = baseUrl + "{0}/v{1}/{2}{3}/{4}{5}";
            _uriDependenciesWithoutSchema = baseUrl + "metadata/{0}/v{1}/{2}{3}";
            _uriDependenciesWithSchema = baseUrl + "{0}/v{1}/{2}/{3}{4}";
            _uriDependenciesWithSchoolYear = baseUrl + "{0}/v{1}/{2}{3}/{4}{5}";
        }

        public string BuildOdsUri(string resourceName, int? schoolYear = null, string queryString = null,
            bool metadata = false)
        {
            return BuildApiUri(
                OdsArea, ApiVersion, resourceName, metadata
                    ? ""
                    : EdFiOrganizationCode, schoolYear, queryString, metadata);
        }

        public string BuildCompositeUri(
            string compositeName,
            string organizationCode = EdFiOrganizationCode,
            int? schoolYear = null,
            string queryString = null)
        {
            return BuildApiUri(CompositesArea, CompositeVersion, compositeName, organizationCode, schoolYear, queryString);
        }

        public string BuildIdentityUri(string resourceName, int? schoolYear = null, string queryString = null)
        {
            return BuildIdentityUri(resourceName, "2", schoolYear, queryString);
        }

        public string BuildIdentityUri(string resourceName, string version, int? schoolYear = null, string queryString = null)
        {
            return BuildApiUri(IdentityArea, version, resourceName, null, schoolYear, queryString);
        }

        private string BuildApiUri(
            string area,
            string version,
            string resourceName,
            string schema = null,
            int? schoolYear = null,
            string queryString = null,
            bool metaData = false)
        {
            return schoolYear != null
                ? string.Format(
                    metaData
                        ? _uriDependenciesWithSchoolYear
                        : _uriWithSchoolYear,
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
                    ? string.Format(
                        metaData
                            ? _uriDependenciesWithoutSchema
                            : _uriWithoutSchema,
                        area,
                        version,
                        resourceName,
                        string.IsNullOrWhiteSpace(queryString)
                            ? ""
                            : "?" + queryString)
                    : string.Format(
                        metaData
                            ? _uriDependenciesWithSchema
                            : _uriWithSchema,
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
