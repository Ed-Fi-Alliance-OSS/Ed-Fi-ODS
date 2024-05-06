// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Exceptions
{
    public class ConcurrencyException : ConflictException
    {
        // Fields containing override values for Problem Details
        private const string TypePart = "multi-user-conflict";
        private const string TitleText = "Multi-User Conflict";

        private const string DetailText = "The resource item was modified or deleted by another user while processing the request. Resending this request will either recreate the item, or introduce of copy with a different identifier.";

        public ConcurrencyException(Exception innerException)
            : base(DetailText, innerException) { }

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
