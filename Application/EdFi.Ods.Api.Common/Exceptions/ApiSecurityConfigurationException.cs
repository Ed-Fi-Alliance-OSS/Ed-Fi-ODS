// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Runtime.Serialization;

namespace EdFi.Ods.Api.Common.Exceptions
{
    /// <summary>
    /// Thrown when a problem is detected in the API security configuration that prevents API requests from safely being served. 
    /// </summary>
    [Serializable]
    public class ApiSecurityConfigurationException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ApiSecurityConfigurationException()
        {
        }

        public ApiSecurityConfigurationException(string message) : base(message)
        {
        }

        public ApiSecurityConfigurationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ApiSecurityConfigurationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
