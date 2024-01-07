// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.ProblemDetails;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Extensions;

public static class HttpResponseExtensions
{
    private static readonly string[] _baseParts = { EdFiProblemDetailsExceptionBase.BaseTypePrefix };

    private static readonly JsonSerializerOptions _serializerOptions = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    public static Task WriteProblemDetailsAsync( this HttpResponse response, EdFiProblemDetailsExceptionBase ex)
    {
        response.StatusCode = ex.Status;
        response.ContentType = "application/problem+json";

        return response.WriteAsync(JsonSerializer.Serialize(ex.AsSerializableModel(), _serializerOptions));
    }

    public static Task WriteProblemDetailsAsync(
        this HttpResponse response,
        int status,
        string title,
        string detail,
        string[] errors,
        string correlationId,
        params string[] typeUrnPartsFromBase)
    {
        response.StatusCode = status;
        response.ContentType = "application/problem+json";

        return response.WriteAsync(
            JsonSerializer.Serialize(
                new EdFiProblemDetails()
                {
                    Detail = detail,
                    Type = string.Join(':', _baseParts.Concat(typeUrnPartsFromBase)),
                    Title = title,
                    Status = status,
                    CorrelationId = correlationId,
                    Errors = errors,
                }.AsSerializableModel(),
                _serializerOptions));
    }

    public static Task WriteProblemDetailsAsync(
        this HttpResponse response,
        int status,
        string title,
        string detail,
        string correlationId,
        params string[] typeUrnPartsFromBase)
    {
        return WriteProblemDetailsAsync(
            response,
            status,
            title,
            detail,
            null,
            correlationId,
            typeUrnPartsFromBase);
    }
}
