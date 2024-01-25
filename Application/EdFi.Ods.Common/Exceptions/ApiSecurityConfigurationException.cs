// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Common.Exceptions
{
    /// <summary>
    /// Thrown when a problem is detected in the API security configuration that prevents API requests from safely being served.
    /// </summary>
    public class ApiSecurityConfigurationException : Exception
    {
        // For guidelines regarding the creation of new exception types, see
        //    https://learn.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions

        public ApiSecurityConfigurationException()
        {
        }

        public ApiSecurityConfigurationException(string message) : base(message)
        {
        }

        public ApiSecurityConfigurationException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
