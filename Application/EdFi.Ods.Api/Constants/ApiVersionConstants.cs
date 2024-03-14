// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Reflection;

namespace EdFi.Ods.Api.Constants
{
    public static class ApiVersionConstants
    {
        /// <summary>
        /// Current version of the ods api.
        /// </summary>
        public const string Ods = "3";

        /// <summary>
        /// Current version of the composite api.
        /// </summary>
        public const string Composite = "1";

        /// <summary>
        /// Current version of the profile api.
        /// </summary>
        public const string Profile = "1";

        /// <summary>
        /// Informational version of the ods api.
        /// </summary>
        public const string InformationalVersion = "5.4";

        /// <summary>
        /// Semantic version of the ods api.
        /// </summary>
        public const string Version = "5.4";

        /// <summary>
        /// Suite version of the ods api.
        /// </summary>
        public const string Suite = "3";

        /// <summary>
        /// Assembly version of the ods api.
        /// </summary>
        public static readonly string Build = Assembly.GetEntryAssembly()
            .GetName()
            .Version.ToString();
    }
}
