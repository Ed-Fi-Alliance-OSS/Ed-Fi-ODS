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
    public class SecurityDataPolicyException : EdFiProblemDetailsExceptionBase
    {
        // Fields containing override values for Problem Details
        private const string TypePart = "security:data-policy";
        private const string TitleText = "Data Policy Failure Due to Incorrect Usage";
        private const int StatusValue = StatusCodes.Status403Forbidden;

        public const string DefaultDetail = "A Data Policy failure was encountered.";

        /// <summary>
        /// Initializes a new instance of the ProblemDetails-based <see cref="SecurityDataPolicyException"/> class using
        /// the supplied detail, and error (which is made available in the <see cref="IEdFiProblemDetails.Errors" /> collection
        /// as well as used for the exception's <see cref="Exception.Message" /> property to be used for exception logging).
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="error"></param>
        public SecurityDataPolicyException(string detail, string error)
            : base(detail, error)
        {
            if (error != null)
            {
                ((IEdFiProblemDetails)this).Errors = new[] { error };
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
