// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Controllers.Partitions.Controllers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Features.OpenApiMetadata.Models;

namespace EdFi.Ods.Features.OpenApiMetadata.Factories
{
    public class OpenApiMetadataParametersFactory
    {
        private readonly IDefaultPageSizeLimitProvider _defaultPageSizeLimitProvider;

        public OpenApiMetadataParametersFactory(IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
        {
            _defaultPageSizeLimitProvider = defaultPageSizeLimitProvider;
        }

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
                        required = false
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
                        minimum = 0,
                        maximum  = _defaultPageSizeLimitProvider.GetDefaultPageSizeLimit(),
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
                        format = "int64",
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
                        format = "int64",
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
                            "Indicates if the total number of items available should be returned in the 'Total-Count' header of the response.  If set to false, 'Total-Count' header will not be provided. Must be false when using cursor paging (with pageToken).",
                        @in = "query",
                        type = "boolean",
                        required = false,
                        @default = false
                    }
                );

                parameters.Add(
                    "pageToken", new Parameter
                    {
                        name = "pageToken",
                        description = "The token of the page to retrieve, obtained either from the \"Next-Page-Token\" header of the previous request, or from the \"partitions\" endpoint for the resource. Cannot be used with limit/offset paging.",
                        @in = "query",
                        type = "string",
                        required = false
                    }
                );

                parameters.Add(
                    "pageSize", new Parameter
                    {
                        name = "pageSize",
                        description = "The maximum number of items to retrieve in the page. For use with pageToken (cursor paging) only.",
                        @in = "query",
                        type = "integer",
                        format = "int32",
                        minimum = 0,
                        required = false,
                        @default = 25
                    }
                );

                parameters.Add(
                    "numberOfPartitions", new Parameter
                    {
                        name = "number",
                        description = "The number of evenly distributed partitions to provide for client-side parallel processing. If unspecified, a reasonable set of partitions will be determined based on the total number of accessible items.",
                        @in = "query",
                        type = "integer",
                        format = "int32",
                        minimum = PartitionsController.MinPartitions,
                        maximum = PartitionsController.MaxPartitions,
                        required = false
                    }
                );
            }

            return parameters;
        }
    }
}