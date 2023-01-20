// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Net;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Utils.Profiles;

namespace EdFi.Ods.Api.ExceptionHandling.Translators;

public class TypeBasedMethodNotAllowedExceptionTranslator : IExceptionTranslator
{
    private readonly Type[] _exceptionTypes =
    {
        typeof(ProfileContentTypeUsageException),
    };

    public bool TryTranslateMessage(Exception ex, out RESTError webServiceError)
    {
        webServiceError = null;

        if (!_exceptionTypes.Contains(ex.GetType()))
        {
            return false;
        }

        string profileAvailableMethodsMessage = null;
        
        if (ex is ProfileContentTypeUsageException usageException)
        {
            if (usageException.ContentTypeUsage == ContentTypeUsage.Readable)
            {
                profileAvailableMethodsMessage =
                    $"The allowed methods for this resource with the '{usageException.ProfileName}' profile are PUT, POST, DELETE and OPTIONS.";
            }
            else if (usageException.ContentTypeUsage == ContentTypeUsage.Writable)
            {
                profileAvailableMethodsMessage =
                    $"The allowed methods for this resource with the '{usageException.ProfileName}' profile are GET, DELETE and OPTIONS.";
            }
            else
            {
                throw new NotSupportedException(
                    $"Unexpected ContentTypeUsage of '{usageException.ContentTypeUsage}' encountered during exception translation.");
            }
        }
        
        webServiceError = new RESTError
        {
            Code = (int) HttpStatusCode.MethodNotAllowed,
            Type = HttpStatusCode.MethodNotAllowed.ToString(),
            Message = profileAvailableMethodsMessage ?? ex.GetAllMessages()
        };

        return true;
    }
}
