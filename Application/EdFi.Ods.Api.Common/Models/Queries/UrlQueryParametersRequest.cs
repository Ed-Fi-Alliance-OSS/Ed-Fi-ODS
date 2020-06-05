// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Common.Models.Queries
{
    public class UrlQueryParametersRequest
    {
        public int? Offset { get; set; }

        public int? Limit { get; set; }

        public bool TotalCount { get; set; }

        public long? MinChangeVersion { get; set; }

        public long? MaxChangeVersion { get; set; }

        public string Q { get; set; }
    }
}
