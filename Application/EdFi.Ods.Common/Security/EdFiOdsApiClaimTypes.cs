// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Security
{
    /// <summary>
    /// Defines the claim types (as URI values) used by the Ed-Fi ODS API.
    /// </summary>
    public static class EdFiOdsApiClaimTypes
    {
        /// <summary>
        /// The prefix of the namespace assigned to callers of the Ed-Fi ODS API.  This is used to establish and authorize "ownership" of certain data within the underlying ODS.
        /// </summary>
        public const string NamespacePrefix = @"http://ed-fi.org/claims/namespacePrefix";

        /// <summary>
        /// The name of an assigned Ed-Fi API profile.
        /// </summary>
        public const string Profile = @"http://ed-fi.org/claims/profile";
    }
}
