// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Net;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Api.ExceptionHandling.Translators
{
    public abstract class TypeBasedExceptionTranslatorBase : IExceptionTranslator
    {
        protected abstract Type[] ExceptionTypes { get; }

        protected abstract HttpStatusCode ResponseCode { get; }
        
        public bool TryTranslateMessage(Exception ex, out ExceptionTranslationResult translationResult)
        {
            Preconditions.ThrowIfNull(ex, nameof(ex));

            translationResult = null;
            
            if (!ExceptionTypes.Contains(ex.GetType()))
            {
                return false;
            }

            var error = new RESTError
            {
                Code = (int) ResponseCode, 
                Type = ResponseCode.ToString().NormalizeCompositeTermForDisplay(), 
                Message = ex.GetAllMessages()
            };

            translationResult = new ExceptionTranslationResult(error, ex);
            
            return true;
        }
    }
}
