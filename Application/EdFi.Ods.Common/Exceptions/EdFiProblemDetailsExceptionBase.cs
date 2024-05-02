// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Exceptions;

/*
┌─────────────────────────────────┐
| EdFiProblemDetailsExceptionBase |
└─────────────────────────────────┘
  △
  │  ┌─────────────────────┐
  ├──┤ BadRequestException | 400 Bad Request
  │  └─────────────────────┘
  │    △
  │    │  ┌─────────────────────────┐
  │    ├──┤ BadRequestDataException | (Maybe consider using 422 Unprocessable Entity?)
  │    │  └─────────────────────────┘
  │    │    △
  │    │    │  ┌────────────────────────────────┐
  │    │    └──┤ KeyChangeNotSupportedException |
  │    │       └────────────────────────────────┘
  │    │  ┌──────────────────────────────┐
  │    ├──┤ BadRequestParameterException |
  │    │  └──────────────────────────────┘
  │    │  ┌─────────────────────┐
  │    └──┤ DataPolicyException |
  │       └─────────────────────┘
  │  ┌─────────────────────────────────┐
  ├──┤ SecurityAuthenticationException | 401 Unauthorized
  │  └─────────────────────────────────┘
  │  ┌────────────────────────────────┐
  ├──┤ SecurityAuthorizationException | 403 Forbidden
  │  └────────────────────────────────┘
  │    △
  │    │  ┌───────────────────────────────────────┐
  │    └──┤ CompositeResourceNotReadableException | 405 Method Not Allowed (TODO: ODS-6143 - Change back to 403.)
  │       └───────────────────────────────────────┘
  │  ┌─────────────────────────────┐
  ├──┤ SecurityDataPolicyException | 403 Forbidden
  │  └─────────────────────────────┘
  │  ┌───────────────────┐
  ├──┤ NotFoundException | 404 Not Found
  │  └───────────────────┘
  │  ┌───────────────────┐
  ├──┤ ConflictException | 409 Conflict
  │  └───────────────────┘
  │    △
  │    │  ┌──────────────────────┐
  │    ├──┤ ConcurrencyException |
  │    │  └──────────────────────┘
  │    │  ┌──────────────────────────────────────┐
  │    ├──┤ DependentResourceItemExistsException |
  │    │  └──────────────────────────────────────┘
  │    │  ┌────────────────────────────┐
  │    ├──┤ NonUniqueIdentityException |
  │    │  └────────────────────────────┘
  │    │  ┌──────────────────────────┐
  │    ├──┤ NonUniqueValuesException |
  │    │  └──────────────────────────┘
  │    │  ┌──────────────────────────────┐
  │    └──┤ UnresolvedReferenceException |
  │       └──────────────────────────────┘
  │  ┌─────────────────────────┐
  ├──┤ OptimisticLockException | 412 Precondition Failed
  │  └─────────────────────────┘
  │  ┌──────────────────────────────┐
  ├──┤ InternalServerErrorException | 500 Internal Server Error
  │  └──────────────────────────────┘
  │    △
  │    │  ┌─────────────────────────────┐
  │    ├──┤ DatabaseConnectionException |
  │    │  └─────────────────────────────┘
  │    │  ┌──────────────────────────────┐
  │    ├──┤ ClientConfigurationException |
  │    │  └──────────────────────────────┘
  │    │  ┌──────────────────────────────┐
  │    └──┤ SystemConfigurationException |
  │       └──────────────────────────────┘
  │         △
  │         │  ┌──────────────────────────┐
  │         ├──┤ FeatureDisabledException |
  │         │  └──────────────────────────┘
  │         │  ┌─────────────────────────────────────┐
  │         ├──┤ InvalidSystemConfigurationException |
  │         │  └─────────────────────────────────────┘
  │         │    △
  │         │    │  ┌──────────────────────────┐
  │         │    └──┤ InvalidApiModelException |
  │         │       └──────────────────────────┘
  │         │  ┌────────────────────────────────┐
  │         └──┤ SecurityConfigurationException |
  │            └────────────────────────────────┘
  │  ┌──────────────────────────────────┐
  ├──┤ ProfileContentTypeUsageException | 400 Bad Request
  │  └──────────────────────────────────┘
  │  ┌─────────────────────────────┐
  ├──┤ ProfileMethodUsageException | 405 Method Not Allowed
  │  └─────────────────────────────┘
  │  ┌───────────────────────────────┐
  ├──┤ SnapshotsAreReadOnlyException | 405 Method Not Allowed
  │  └───────────────────────────────┘
  │  ┌───────────────────────────┐
  ├──┤ MethodNotAllowedException | 405 Method Not Allowed
  │  └───────────────────────────┘
  │  ┌──────────────────────┐
  ├──┤ NotModifiedException | 304 Not Modified
  │  └──────────────────────┘
  │
*/

public abstract class EdFiProblemDetailsExceptionBase : Exception, IEdFiProblemDetails
{
    public const string BaseTypePrefix = "urn:ed-fi:api";

    private string _type;

    protected EdFiProblemDetailsExceptionBase(string detail, string message)
        : base(message)
    {
        Detail = detail;
    }

    protected EdFiProblemDetailsExceptionBase(string detail, string[] errors)
        : base(detail)
    {
        Detail = detail;
        this.SetErrors(errors);
    }

    protected EdFiProblemDetailsExceptionBase(string detail, string message, Exception innerException)
        : base(message, innerException)
    {
        Detail = detail;
    }

    /// <inheritdoc cref="IEdFiProblemDetails.Detail" />
    public string Detail { get; }

    /// <inheritdoc cref="IEdFiProblemDetails.Type" />
    public string Type
    {
        get => _type ??= string.Join(':', GetTypeParts());
    }

    /// <inheritdoc cref="IEdFiProblemDetails.Title" />
    public abstract string Title { get; }

    /// <inheritdoc cref="IEdFiProblemDetails.Status" />
    public abstract int Status { get; }

    /// <inheritdoc cref="IEdFiProblemDetails.CorrelationId" />
    public string CorrelationId { get; set; }

    /// <inheritdoc cref="IEdFiProblemDetails.ValidationErrors" />
    Dictionary<string, string[]> IEdFiProblemDetails.ValidationErrors { get; set; }

    /// <inheritdoc cref="IEdFiProblemDetails.Errors" />
    string[] IEdFiProblemDetails.Errors { get; set; }

    protected virtual IEnumerable<string> GetTypeParts()
    {
        yield return BaseTypePrefix;
    }
}
