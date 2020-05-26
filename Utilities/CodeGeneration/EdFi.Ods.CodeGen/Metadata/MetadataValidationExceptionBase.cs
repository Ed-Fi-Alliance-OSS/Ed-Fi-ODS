// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;

namespace EdFi.Ods.CodeGen.Metadata
{
    public abstract class MetadataValidationException<T> : Exception
    {
        protected MetadataValidationException(string message)
            : base(message) { }

        protected MetadataValidationException(string message, T validationObjectInstance)
            : base(message)
        {
            ValidationObjectInstance = validationObjectInstance;
        }

        public T ValidationObjectInstance { get; }
    }
}
