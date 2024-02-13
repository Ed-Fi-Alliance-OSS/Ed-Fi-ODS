// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Reflection;
using EdFi.Ods.Common;
using EdFi.Ods.Features.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EdFi.Ods.Features.IdentityManagement;

/// <summary>
/// Implements a convention that looks for multiple controllers derived from the abstract <see cref="IdentitiesControllerBase{TCreateRequest, TSearchRequest, TSearchResponse, TIdentityResponse}" />
/// base controller class, and removes the <see cref="ControllerModel" /> entry for the default out-of-the-box <see cref="IdentitiesController" />
/// to prevent <see cref="AmbiguousMatchException" /> from occurring when resolving requests for identity management routes.
/// </summary>
public class IdentitiesControllerOverrideConvention : IApplicationModelConvention
{
    public void Apply(ApplicationModel application)
    {
        // Find all Identities controllers (should only be either 1 or 2, if custom implementation provided)
        var identitiesControllers = application.Controllers.Where(
                m =>
                {
                    // Eliminate most controllers using the namespace
                    if (!m.ControllerType.Namespace.StartsWith(Namespaces.Api.Controllers))
                    {
                        // Identities controllers (should) inherit from the IdentitiesControllerBase class that is generic
                        if (m.ControllerType.BaseType is { IsGenericType: true })
                        {
                            // Is it an identities controller?
                            if (m.ControllerType.BaseType.GetGenericTypeDefinition() == typeof(IdentitiesControllerBase<,,,>))
                            {
                                return true;
                            }
                        }
                    }

                    return false;
                })
            .ToArray();

        // Determine if we will have an ambiguous match, and remove the UnimplementedIdentitiesController from the model
        if (identitiesControllers.Length > 1)
        {
            foreach (var controllerModel in identitiesControllers)
            {
                if (controllerModel.ControllerType == typeof(IdentitiesController).GetTypeInfo())
                {
                    application.Controllers.Remove(controllerModel);
                }
            }
        }
    }
}
