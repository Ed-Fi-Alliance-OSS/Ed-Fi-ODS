// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Net;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Api.Common.ExceptionHandling.Translators
{
    public abstract class TypeBasedExceptionTranslatorBase : IExceptionTranslator
    {
        protected abstract Type[] ExceptionTypes { get; }

        protected abstract HttpStatusCode ResponseCode { get; }

        public bool TryTranslateMessage(Exception ex, out RESTError webServiceError)
        {
            Preconditions.ThrowIfNull(ex, nameof(ex));

            webServiceError = null;

            if (!ExceptionTypes.Contains(ex.GetType()))
            {
                return false;
            }

            webServiceError = new RESTError
            {
                Code = (int) ResponseCode,
                Type = ResponseCode.ToString().NormalizeCompositeTermForDisplay(),
                Message = ex.GetAllMessages()
            };

            return true;
        }
    }
}
