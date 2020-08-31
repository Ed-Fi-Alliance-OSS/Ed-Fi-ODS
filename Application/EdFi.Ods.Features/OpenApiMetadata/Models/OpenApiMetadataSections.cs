// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Features.OpenApiMetadata.Models
{
    public static class OpenApiMetadataSections
    {
        public const string SwaggerUi = "SwaggerUI";
        public const string Other = "Other";
        public const string Composites = "Composites";
        public const string Profiles = "Profiles";
        public const string Extensions = "Extensions";
        public const string SdkGen = "SDKGen";

        public static int GetSort(string section)
        {
            switch (section)
            {
                case SwaggerUi:
                    return 10;
                case Other:
                    return 20;
                case Composites:
                    return 30;
                case Profiles:
                    return 40;
                case SdkGen:
                    return 50;
                default:
                    return 99;
            }
        }
    }
}
