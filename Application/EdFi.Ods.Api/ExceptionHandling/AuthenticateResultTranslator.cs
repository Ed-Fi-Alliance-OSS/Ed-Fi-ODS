// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.ProblemDetails;
using Microsoft.AspNetCore.Authentication;

namespace EdFi.Ods.Api.ExceptionHandling;

public class AuthenticateResultTranslator
{
    private readonly IEdFiProblemDetailsProvider _problemDetailsProvider;

    public AuthenticateResultTranslator(IEdFiProblemDetailsProvider problemDetailsProvider)
    {
        _problemDetailsProvider = problemDetailsProvider;
    }

    public IEdFiProblemDetails GetProblemDetails(AuthenticateResult result)
    {
        if (result.None)
        {
            return new SecurityAuthenticationException(
                SecurityAuthenticationException.DefaultDetail,
                "Authorization header is missing.");
        }

        return new SecurityAuthenticationException(
                SecurityAuthenticationException.DefaultDetail,
                result.Failure.Message,
                result.Failure);
    }
}