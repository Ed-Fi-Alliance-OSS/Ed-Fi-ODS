// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Resource
{
    /// <summary>
    /// A base class that provides most of the behavior needed to test the IMemberFilter subclasses
    /// </summary>
    public static class FilterTestsHelper
    {
        public static readonly string[] PropertyNameArray =
        {
            "How", "top", "trainers", "would", "prepare"
        };
        public static readonly string[] ExtensionNameArray =
        {
            "Shortstop", "miss", "weeks", "torn", "thumb", "ligament"
        };

        public static IncludeOnlyMemberFilter CreateIncludeOnlyMemberFilter()
        {
            return new IncludeOnlyMemberFilter(PropertyNameArray, ExtensionNameArray);
        }

        public static ExcludeOnlyMemberFilter CreateExcludeOnlyMemberFilter()
        {
            return new ExcludeOnlyMemberFilter(PropertyNameArray, ExtensionNameArray);
        }
    }
}
