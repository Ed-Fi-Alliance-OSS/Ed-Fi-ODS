// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Common.Models.Tokens
{
    public class TokenRequest
    {
        public string Client_id { get; set; }

        public string Client_secret { get; set; }

        public string Grant_type { get; set; }

        public string Scope { get; set; }
    }
}
