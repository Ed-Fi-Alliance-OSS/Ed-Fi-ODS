// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Newtonsoft.Json.Linq;

namespace EdFi.Ods.Api.Common.Models
{
    public abstract class ResourceAsJsonObject<TId>
    {
        /// <summary>
        /// Gets or sets the aggregate root identifier.
        /// </summary>
        public abstract TId Id { get; set; }

        /// <summary>
        /// Gets or sets the JSON data associated with PATCH request.
        /// </summary>
        public abstract JObject Data { get; set; }

        //[ApiMember(Name = "If-Match", ParameterType = "header", DataType = "string", Description = "The ETag header value used to prevent the PATCH from overwriting another consumer's changes in an unexpected way.", IsRequired = true, Verb = "PATCH")]
        [Obsolete("This property is not intended to be used.  It is an affordance for ServiceStack in providing metadata to Swagger-UI.", true)]
        public virtual string IfMatch { get; set; }
    }
}
