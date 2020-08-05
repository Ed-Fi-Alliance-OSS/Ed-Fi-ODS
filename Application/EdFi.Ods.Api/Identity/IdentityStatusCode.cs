﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Identity
{
    public enum IdentityStatusCode
    {
        Success,
        Incomplete,
        InvalidProperties,
        NotFound
    }

    public class IdentityResponseStatus<TResponse>
    {
        public TResponse Data { get; set; }

        public IdentityStatusCode StatusCode { get; set; }
    }

    public class IdentityResponseErrorStatus<TResponse> : IdentityResponseStatus<TResponse>
    {
        public IdentityError[] Error { get; set; }
    }
}
