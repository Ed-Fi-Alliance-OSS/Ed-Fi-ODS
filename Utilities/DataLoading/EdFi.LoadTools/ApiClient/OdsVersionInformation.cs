// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.LoadTools
{
    public class OdsVersionInformation
    {
        public string Version { get; set; }

        public string InformationalVersion { get; set; }

        public string Suite { get; set; }

        public string Build { get; set; }

        public string ApiMode { get; set; }

        public List<Dictionary<string,string>> DataModels { get; set; }

        public Dictionary<string,string> Urls { get; set; }
    }
}
