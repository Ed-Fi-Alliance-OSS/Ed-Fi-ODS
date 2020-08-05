﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Security
{
    public class ApiClientIdentity
    {
        public string ClaimSetName { get; set; }

        public IList<int> EducationOrganizationIds { get; set; }

        public string Key { get; set; }

        public IList<string> NamespacePrefixes { get; set; }

        public IList<string> Profiles { get; set; }
    }
}
