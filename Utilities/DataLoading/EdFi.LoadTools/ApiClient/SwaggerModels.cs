// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using Swashbuckle.Swagger;

namespace EdFi.LoadTools.ApiClient
{
    public class Metadata
    {
        public string Name { get; set; }

        public string EndpointUri { get; set; }

        public string Prefix { get; set; }
    }

    public class Resource
    {
        public string Name { get; set; }

        public string Schema { get; set; }

        public PathItem Path { get; set; }

        public string BasePath { get; set; }

        public Schema Definition { get; set; }
    }

    public class Entity
    {
        public string Name { get; set; }

        public string Schema { get; set; }

        public Schema Definition { get; set; }
    }
}
