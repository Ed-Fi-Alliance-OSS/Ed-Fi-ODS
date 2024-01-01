// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Common.Exceptions
{
    public class SecurityException : EdFiProblemDetailsExceptionBase
    {
        // Fields containing override values for Problem Details
        private const string TypePart = "security";
        private const string TitleText = "Authorization Denied";
        private const int StatusValue = StatusCodes.Status403Forbidden;

        public const string DefaultTechnicalProblemDetail = "There was a problem authorizing the request.";
        public const string DefaultDetail = "Access to the resource could not be authorized.";

        public SecurityException(string message)
            : base(DefaultDetail, message) { }

        public SecurityException(string detail, string error)
            : base(detail, error) { }

        public SecurityException(string detail, string error, string message)
            : base(detail, message)
        {
            ((IEdFiProblemDetails)this).Errors = new[] { error };
        }

        // public EdFiSecurityException(string message, string resource, string action)
        //     : base(message)
        // {
        //     Resource = resource;
        //     Action = action;
        // }
        //
        // public EdFiSecurityException(string message, string resource, string action, string apiKey)
        //     : base(message)
        // {
        //     Resource = resource;
        //     Action = action;
        //     ApiKey = apiKey;
        // }
        //
        // public EdFiSecurityException(string message, string resource, string action, string apiKey, Exception inner)
        //     : base(message, inner)
        // {
        //     Resource = resource;
        //     Action = action;
        //     ApiKey = apiKey;
        // }
        //
        // public EdFiSecurityException(string message, Exception inner)
        //     : base(message, inner) { }
        //
        // protected EdFiSecurityException(
        //     SerializationInfo info,
        //     StreamingContext context)
        //     : base(info, context) { }
        //
        
        // TODO: Review usage. Is this for logged detail only?
        // public string ApiKey { get; }
        //
        // public string Resource { get; }
        //
        // public string Action { get; }
        
        // ---------------------------
        //  Boilerplate for overrides
        // ---------------------------
        public override string Title { get => TitleText; }

        public override int Status { get => StatusValue; }
    
        protected override IEnumerable<string> GetTypeParts()
        {
            foreach (var part in base.GetTypeParts())
            {
                yield return part;
            }

            yield return TypePart;
        }
        // ---------------------------
    }
}
