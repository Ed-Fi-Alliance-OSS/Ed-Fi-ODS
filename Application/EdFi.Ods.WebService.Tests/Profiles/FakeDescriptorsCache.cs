// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.WebService.Tests.Profiles
{
    public class FakeDescriptorsCache : IDescriptorsCache
    {
        public int GetId(string descriptorName, string descriptorValue)
        {
            if (descriptorValue == null)
            {
                return 0;
            }

            return Convert.ToInt32(descriptorValue.Substring(descriptorValue.IndexOf("#") + 2));
        }

        public string GetValue(string descriptorName, int id)
        {
            if (id == 0)
            {
                return null;
            }

            return EdFiDescriptorReferenceSpecification.GetFullyQualifiedDescriptorReference(
                $"uri://ed-fi.org/{descriptorName}",
                descriptorName.Substring(0, 1) + id);
        }
    }
}
