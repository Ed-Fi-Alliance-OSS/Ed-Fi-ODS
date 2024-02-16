﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.AspNetCore.Identity;

namespace EdFi.Ods.Features.IdentityManagement.Models
{
    public class IdentityResponseStatus<TResponse>
    {
        public TResponse Data { get; set; }

        public IdentityStatusCode StatusCode { get; set; }

        public IEnumerable<IdentityError> Errors { get; set; }
    }
}
