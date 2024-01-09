// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Infrastructure.Pipelines.Steps;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EdFi.Ods.Api.Validation;

/// <summary>
/// Implements a decorator over the default IObjectModelValidator that prevents the normal validation
/// process that ASP.NET performs with model binding. We defer validation to
/// the <see cref="ValidateResourceModel{TContext,TResult,TResourceModel,TEntityModel}" /> step of the
/// configured processing pipeline.
/// </summary>
public class DataManagementObjectModelValidatorDecorator : IObjectModelValidator
{
    private readonly IObjectModelValidator _objectModelValidator;
    private readonly IContextProvider<DataManagementResourceContext> _resourceContextProvider;

    public DataManagementObjectModelValidatorDecorator(
        IObjectModelValidator objectModelValidator,
        IContextProvider<DataManagementResourceContext> resourceContextProvider)
    {
        _objectModelValidator = objectModelValidator;
        _resourceContextProvider = resourceContextProvider;
    }

    public void Validate(ActionContext actionContext, ValidationStateDictionary validationState, string prefix, object model)
    {
        // If this is not a data management request, pass the call through
        if (_resourceContextProvider.Get() == null)
        {
            _objectModelValidator.Validate(actionContext, validationState, prefix, model);
        }
    }
}
