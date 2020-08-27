// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Models.Resource
{
    public class IncludeAllMemberFilter : IMemberFilter
    {
        public bool ShouldInclude(string memberName)
        {
            return true;
        }

        public bool ShouldIncludeExtension(string extensionName)
        {
            return true;
        }
    }
}
