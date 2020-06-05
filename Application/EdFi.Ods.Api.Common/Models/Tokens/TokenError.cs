// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Common.Models.Tokens
{
    public class TokenError
    {
        public TokenError(string tokenErrorType)
        {
            Error = tokenErrorType;
        }

        public TokenError(string tokenErrorType, string errorDescription)
        {
            Error = tokenErrorType;
            Error_description = errorDescription;
        }

        /// <summary>
        ///     REQUIRED. A single ASCII [USASCII] error code
        /// </summary>
        public string Error { get; }

        /// <summary>
        /// Gets a description of the error (if available) to assist a developer with troubleshooting authentication problems.
        /// </summary>
        public string Error_description { get; }
    }
}
