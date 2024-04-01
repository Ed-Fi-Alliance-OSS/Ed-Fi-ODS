// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Common.Exceptions
{
    public class SecurityAuthorizationException : EdFiProblemDetailsExceptionBase
    {
        // Fields containing override values for Problem Details
        private const string TypePart = "security:authorization";
        private const string TitleText = "Authorization Denied";
        private const int StatusValue = StatusCodes.Status403Forbidden;

        public const string DefaultTechnicalProblemDetail = "There was a problem authorizing the request.";
        public const string DefaultDetail = "Access to the resource could not be authorized.";

        /// <summary>
        /// Initializes a new instance of the ProblemDetails-based <see cref="SecurityAuthorizationException"/> class using
        /// the supplied detail, and error (which is made available in the <see cref="IEdFiProblemDetails.Errors" /> collection
        /// as well as used for the exception's <see cref="Exception.Message" /> property to be used for exception logging).
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="error"></param>
        public SecurityAuthorizationException(string detail, string error)
            : base(detail, error)
        {
            if (error != null)
            {
                this.SetErrors(error);
            }
        }

        /// <summary>
        /// Initializes a new instance of the ProblemDetails-based <see cref="SecurityAuthorizationException"/> class using
        /// the supplied detail, and error and message (for exception logging).
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="error"></param>
        /// <param name="message"></param>
        public SecurityAuthorizationException(string detail, string error, string message)
            : base(detail, message)
        {
            if (error != null)
            {
                this.SetErrors(error);
            }
        }

        /// <summary>
        /// Initializes a new instance of the ProblemDetails-based <see cref="SecurityAuthorizationException"/> class using
        /// the supplied detail, and error and inner exception.
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="error"></param>
        /// <param name="innerException"></param>
        public SecurityAuthorizationException(string detail, string error, Exception innerException)
            : base(detail, error, innerException)
        {
            if (error != null)
            {
                this.SetErrors(error);
            }
        }

        /// <summary>
        /// Additional type parts to be appended to this exception instance.
        /// </summary>
        public IEnumerable<string> InstanceTypeParts { get; set; } = Enumerable.Empty<string>();

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

            foreach (var part in InstanceTypeParts)
            {
                yield return part;
            }
        }
        // ---------------------------
    }
}
