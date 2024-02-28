// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Exceptions
{
    /// <summary>
    /// Thrown when a problem is detected in the API security configuration that prevents API requests from safely being served.
    /// </summary>
    [Serializable]
    public class SecurityConfigurationException : SystemConfigurationException
    {
        // Fields containing override values for Problem Details
        private const string TypePart = "security";
        private const string TitleText = "Security Configuration Error";
        public new const string DefaultDetail = "A security configuration problem was detected. The request cannot be authorized.";

        public SecurityConfigurationException(string detail, string error) 
            : base(detail, error)
        {
            this.SetErrors(error);
        }

        // ---------------------------
        //  Boilerplate for overrides
        // ---------------------------
        public override string Title { get => TitleText; }

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
