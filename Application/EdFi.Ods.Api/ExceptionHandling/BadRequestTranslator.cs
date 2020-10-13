// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EdFi.Ods.Api.ExceptionHandling
{
    public static class ErrorTranslator
    {
        // Attempts to translate the API error response to ASP.NET MVC error response format to maintain compatibility for the consumers. 
        public static object GetErrorMessage(ModelStateDictionary modelState)
        {
            if (modelState.Keys.All(string.IsNullOrEmpty) && modelState.Values.Any())
            {
                return new {Message = string.Join(",", modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)))};
            }

            var modelStateMessage = modelState
                .ToDictionary(
                    kvp => "request." + kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            return new
            {
                Message = "The request is invalid.",
                ModelState = modelStateMessage
            };
        }

        public static object GetErrorMessage(string message)
        {
            return new {Message = message};
        }
    }
}
