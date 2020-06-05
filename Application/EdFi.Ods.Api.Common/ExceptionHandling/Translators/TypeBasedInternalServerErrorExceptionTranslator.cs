// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using EdFi.Ods.Api.Common.Exceptions;

namespace EdFi.Ods.Api.Common.ExceptionHandling.Translators
{
    public class TypeBasedInternalServerErrorExceptionTranslator : TypeBasedExceptionTranslatorBase
    {
        // Exception types to be translated to a 500 status response with the error message intact.
        private readonly Type[] _exceptionTypes =
        {
            typeof(ApiSecurityConfigurationException)
        };

        protected override Type[] ExceptionTypes
        {
            get => _exceptionTypes;
        }

        protected override HttpStatusCode ResponseCode
        {
            get => HttpStatusCode.InternalServerError;
        }
    }
}
