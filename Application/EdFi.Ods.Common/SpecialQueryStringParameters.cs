// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common
{
    /// <summary>
    /// Provides access to the special query string parameters supported by the API.
    /// </summary>
    public static class SpecialQueryStringParameters
    {
        /// <summary>
        /// Gets the name of the parameter used to create filter expressions.
        /// </summary>
        public static readonly string Q = "q";

        /// <summary>
        /// Gets the name of the parameter used to create field selection expressions.
        /// </summary>
        public static readonly string Fields = "fields";

        /// <summary>
        /// Gets the name of the parameter used to limit page size.
        /// </summary>
        public static readonly string Limit = "limit";

        /// <summary>
        /// Gets the name of the parameter used to define an offset before results are returned (used for paging).
        /// </summary>
        public static readonly string Offset = "offset";

        /// <summary>
        /// Gets the name of the parameter used for debugging/diagnostic correlation of request with thier log entries.
        /// </summary>
        public static readonly string CorrelationId = "$correlationId";

        /// <summary>
        /// Gets the names of all of the supported special parameters.
        /// </summary>
        public static readonly HashSet<string> Names =
            new HashSet<string>(StringComparer.InvariantCultureIgnoreCase)
            {
                Q, Limit, Offset, CorrelationId
            };
    }
}
