// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Caching;

namespace EdFi.Ods.WebApi.ProfileSpecFlowTests.Fakes
{
    public class FakeDescriptorsCache : IDescriptorsCache
    {
        public int GetId(string descriptorName, string descriptorValue)
        {
            return 0;
        }

        public string GetValue(string descriptorName, int id)
        {
            return descriptorName;
        }
    }
}
