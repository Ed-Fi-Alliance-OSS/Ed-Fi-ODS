// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.LoadTools.ApiClient
{
    public class FileContext
    {
        public string FileType { get; set; }

        public string FileName { get; set; }

        public int NumberOfIdRefs { get; set; }

        public bool IsValid { get; set; }

        public HashSet<string> Resources { get; set; }
    }
}
