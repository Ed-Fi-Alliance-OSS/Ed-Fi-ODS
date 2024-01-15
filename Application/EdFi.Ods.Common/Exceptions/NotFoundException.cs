// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Common.Exceptions
{
    /// <summary>
    ///     Indicates that a resource or persistent model identified for an operation was not found.
    /// </summary>
    public class NotFoundException : EdFiProblemDetailsExceptionBase
    {
        // Fields containing override values for Problem Details
        public const string TypePart = "not-found";
        public const string TitleText = "Not Found";
        private const int StatusValue = StatusCodes.Status404NotFound;

        public const string DefaultDetail = "The specified resource could not be found.";
        public const string DefaultItemDetail = "The specified resource item could not be found.";
        
        public NotFoundException() : base(DefaultDetail, DefaultDetail) { }

        public NotFoundException(string detail)
            : base(detail, detail) { }

        public NotFoundException(string detail, string message)
            : base(detail, message) { }

        public NotFoundException(string detail, string message, string typeName, string identifier)
            : base(detail, message)
        {
            TypeName = typeName;
            Identifier = identifier;
        }

        public NotFoundException(string detail, Exception inner)
            : base(detail, detail, inner) { }

        public string TypeName { get; set; }

        public string Identifier { get; set; }
        
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
