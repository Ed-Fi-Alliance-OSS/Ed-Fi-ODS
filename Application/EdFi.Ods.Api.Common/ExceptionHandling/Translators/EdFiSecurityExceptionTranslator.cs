// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;

namespace EdFi.Ods.Api.Common.ExceptionHandling.Translators
{
    public class EdFiSecurityExceptionTranslator : IExceptionTranslator
    {
        public bool TryTranslateMessage(Exception ex, out RESTError webServiceError)
        {
            webServiceError = null;

            if (ex is EdFiSecurityException)
            {
                webServiceError = new RESTError
                                  {
                                      Code = (int) HttpStatusCode.Forbidden, Type = "Forbidden", Message = ex.GetAllMessages()
                                  };

                return true;
            }

            return false;
        }
    }
}
