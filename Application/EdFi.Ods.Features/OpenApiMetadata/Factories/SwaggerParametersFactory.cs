// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Features.OpenApiMetadata.Models;

namespace EdFi.Ods.Features.OpenApiMetadata.Factories
{
    public class SwaggerParametersFactory
    {
        public IDictionary<string, Parameter> Create(bool isCompositeContext)
        {
            var parameters = new Dictionary<string, Parameter>
            {
                {
                    "offset", new Parameter
                    {
                        name = "offset",
                        description = "Indicates how many items should be skipped before returning results.",
                        @in = "query",
                        type = "integer",
                        format = "int32",
                        required = false,
                        @default = 0
                    }
                },
                {
                    "limit", new Parameter
                    {
                        name = "limit",
                        description =
                            "Indicates the maximum number of items that should be returned in the results.",
                        @in = "query",
                        type = "integer",
                        format = "int32",
                        minItems = 1,
                        maxItems = 100,
                        required = false,
                        @default = 25
                    }
                },
                {
                    "MinChangeVersion", new Parameter
                    {
                        name = "minChangeVersion",
                        description =
                            "Used in synchronization to set sequence minimum ChangeVersion",
                        @in = "query",
                        type = "integer",
                        format = "int32",
                        required = false
                    }
                },
                {
                    "MaxChangeVersion", new Parameter
                    {
                        name = "maxChangeVersion",
                        description =
                            "Used in synchronization to set sequence maximum ChangeVersion",
                        @in = "query",
                        type = "integer",
                        format = "int32",
                        required = false
                    }
                },
                {
                    "If-None-Match", new Parameter
                    {
                        name = "If-None-Match",
                        description =
                            "The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                        @in = "header",
                        type = "string",
                        required = false
                    }
                },
                {
                    "fields", new Parameter
                    {
                        name = "fields",
                        @in = "query",
                        description =
                            "Specifies a subset of properties that should be returned for each entity (e.g. \"property1,collection1(collProp1,collProp2)\").",
                        type = "string",
                        required = false
                    }
                },
                {
                    "queryExpression", new Parameter
                    {
                        @in = "query",
                        name = "q",
                        description =
                            "Specifies a query filter expression for the request. Currently only supports range-based queries on dates and numbers (e.g. \"schoolId:[255901000...255901002]\" and \"BeginDate:[2016-03-07...2016-03-10]\").",
                        type = "string",
                        required = false
                    }
                }
            };

            if (!isCompositeContext)
            {
                parameters.Add(
                    "totalCount", new Parameter
                    {
                        name = "totalCount",
                        description =
                            "Indicates if the total number of items available should be returned in the 'Total-Count' header of the response.  If set to false, 'Total-Count' header will not be provided.",
                        @in = "query",
                        type = "boolean",
                        required = false,
                        @default = false
                    }
                );
            }

            return parameters;
        }
    }
}
