// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Xml.Linq;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.CodeGen.Metadata
{
    public abstract class MetadataValidatorBase<T>
    {
        protected MetadataValidatorBase(ResourceModel resourceModel, T[] validationObjectInstances, XDocument documentToValidate)
        {
            ResourceModel = resourceModel;
            ValidationObjectInstances = validationObjectInstances;
            DocumentToValidate = documentToValidate;
        }

        public ResourceModel ResourceModel { get; }

        public T[] ValidationObjectInstances { get; }

        public XDocument DocumentToValidate { get; }

        public abstract void ValidateMetadata();
    }
}
