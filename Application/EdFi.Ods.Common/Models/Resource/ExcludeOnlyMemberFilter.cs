// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;

namespace EdFi.Ods.Common.Models.Resource
{
    public class ExcludeOnlyMemberFilter : IMemberFilter
    {
        private readonly string[] _excludedExtensionNames;
        private readonly string[] _excludedMemberNames;

        public ExcludeOnlyMemberFilter(string[] excludedMemberNames, string[] excludedExtensionNames)
        {
            _excludedMemberNames = excludedMemberNames;
            _excludedExtensionNames = excludedExtensionNames;
        }

        public bool ShouldInclude(string memberName)
        {
            return memberName == "Id" || !_excludedMemberNames.Contains(memberName);
        }

        public bool ShouldIncludeExtension(string extensionName)
        {
            return !_excludedExtensionNames.Contains(extensionName);
        }
    }
}
