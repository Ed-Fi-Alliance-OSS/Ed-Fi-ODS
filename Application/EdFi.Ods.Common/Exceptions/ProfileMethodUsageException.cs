// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Utils.Profiles;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Common.Exceptions
{
    public class ProfileMethodUsageException : EdFiProblemDetailsExceptionBase
    {
        // Fields containing override values for Problem Details
        private const string TypePart = "profile:method-usage";
        private const string TitleText = "Method Not Allowed with Profile";
        private const int StatusValue = StatusCodes.Status405MethodNotAllowed;

        private const string DefaultDetailFormat = "The request construction was invalid with respect to usage of a data policy. An attempt was made to access a resource that is not {0} using the profile.";

        public ProfileMethodUsageException(ContentTypeUsage usage, string error)
            : base(string.Format(DefaultDetailFormat, usage.ToString().ToLower()), error)
        {
            if (error != null)
            {
                this.SetErrors(error);
            }
        }

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
