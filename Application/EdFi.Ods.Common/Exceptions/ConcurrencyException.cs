// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Common.Exceptions
{
    public class ConcurrencyException : EdFiProblemDetailsExceptionBase
    {
        // Fields containing override values for Problem Details
        private const string TypePart = "multiuser-conflict";
        private const string TitleText = "Multiuser Conflict";
        private const int StatusValue = StatusCodes.Status412PreconditionFailed;

        private const string DetailText = "The resource was modified by another user while attempting to perform the current operation.";
        private const string MessageText = "Resource modification by another consumer was detected (due to inclusion of If-Match request header by API client).";
        
        public ConcurrencyException(string detail)
            : base(detail, MessageText) { }

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
