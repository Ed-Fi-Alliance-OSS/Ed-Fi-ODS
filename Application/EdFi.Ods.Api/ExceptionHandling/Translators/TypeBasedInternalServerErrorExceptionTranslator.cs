// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using EdFi.Ods.Common.Exceptions;
using log4net;

namespace EdFi.Ods.Api.ExceptionHandling.Translators
{
    public class TypeBasedInternalServerErrorExceptionTranslator : TypeBasedExceptionTranslatorBase
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(TypeBasedInternalServerErrorExceptionTranslator));
        
        // Exception types to be translated to a 500 status response with the error message intact.
        private static readonly Type[] _exceptionTypes;

        static TypeBasedInternalServerErrorExceptionTranslator()
        {
            _exceptionTypes = new[] { typeof(ApiSecurityConfigurationException) };
        }

        protected override Type[] ExceptionTypes
        {
            get => _exceptionTypes;
        }

        protected override HttpStatusCode ResponseCode
        {
            get => HttpStatusCode.InternalServerError;
        }

        protected override string GetMessage(Exception ex)
        {
            _logger.Error(ex);

            return "The request cannot be authorized due to a security misconfiguration.";
        }
    }
}
