// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.LoadTools.Common
{
    public static class EdFiConstants
    {
        public const string CodeValue = "CodeValue";
        public const string ShortDescription = "ShortDescription";
        public const string Descriptor = "Descriptor";
        public const int TestEdOrgId = 255901;
        public const string SdkConfigurationNamespace = "EdFi.OdsApi.Sdk.Client.Configuration";
        public const string AccessToken = "AccessToken";
        public const string Authorization = "Authorization";
        public const string EdOrgReference = "EdFiEducationOrganizationReference";
        public const string Namespace = "Namespace";
        public static readonly Uri DefaultNamespaceUri = new Uri("uri://ed-fi.org/");
        public const string EdFiNamespace = "ed-fi";
        public const string CreateOperation = "Create";
        public const string UpdateOperation = "Update";
    }
}
