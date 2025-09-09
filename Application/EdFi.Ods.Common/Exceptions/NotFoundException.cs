// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Common.Exceptions
{
    /// <summary>
    ///     Indicates that a resource or persistent model identified for an operation was not found.
    /// </summary>
    public class NotFoundException : Exception
    {
        // For guidelines regarding the creation of new exception types, see
        //    https://learn.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions

        public NotFoundException() { }

        public NotFoundException(string message)
            : base(message) { }

        public NotFoundException(string message, string typeName, string identifier)
            : base(message)
        {
            TypeName = typeName;
            Identifier = identifier;
        }

        public NotFoundException(string message, Exception inner)
            : base(message, inner) { }

        public string TypeName { get; set; }

        public string Identifier { get; set; }
    }
}