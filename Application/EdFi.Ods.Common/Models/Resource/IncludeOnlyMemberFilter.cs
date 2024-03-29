// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;

namespace EdFi.Ods.Common.Models.Resource
{
    public class IncludeOnlyMemberFilter : IMemberFilter
    {
        private readonly string[] _includedExtensionNames;
        private readonly string[] _includedMemberNames;

        public IncludeOnlyMemberFilter(string[] includedMemberNames, string[] includedExtensionNames)
        {
            _includedMemberNames = includedMemberNames;
            _includedExtensionNames = includedExtensionNames;
        }

        public bool ShouldInclude(string memberName)
        {
            return memberName == "Id" || _includedMemberNames.Contains(memberName, StringComparer.OrdinalIgnoreCase);
        }

        public bool ShouldIncludeExtension(string extensionName)
        {
            return _includedExtensionNames.Contains(extensionName, StringComparer.OrdinalIgnoreCase);
        }
    }
}
