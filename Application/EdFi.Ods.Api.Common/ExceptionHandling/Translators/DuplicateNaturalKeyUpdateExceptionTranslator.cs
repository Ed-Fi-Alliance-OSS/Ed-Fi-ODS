// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using EdFi.Ods.Api.Common.Models;
using NHibernate;

namespace EdFi.Ods.Api.Common.ExceptionHandling.Translators
{
    public class DuplicateNaturalKeyUpdateExceptionTranslator : IExceptionTranslator
    {
        public bool TryTranslateMessage(Exception ex, out RESTError webServiceError)
        {
            webServiceError = null;

            if (ex is StaleObjectStateException)
            {
                webServiceError = new RESTError
                                  {
                                      Code = (int) HttpStatusCode.Conflict, Type = HttpStatusCode.Conflict.ToString(), Message =
                                          "A natural key conflict occurred when attempting to update a new resource with a duplicate key. This is likely caused by multiple resources with the same key in the same file. Exactly one of these resources was updated."
                                  };

                return true;
            }

            return false;
        }
    }
}
