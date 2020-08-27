// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Models.Resource
{
    public class ResourcePropertyMapping
    {
        public ResourcePropertyMapping(ResourceProperty thisProperty, ResourceProperty otherProperty)
        {
            ThisProperty = thisProperty;
            OtherProperty = otherProperty;
        }

        public ResourceProperty ThisProperty { get; }

        public ResourceProperty OtherProperty { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return ThisProperty + " <---> " + OtherProperty;
        }
    }
}
