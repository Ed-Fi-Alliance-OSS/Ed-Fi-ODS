// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Collections.Generic;

namespace EdFi.LoadTools.ApiClient
{
    public class Dependency
    {
        public string Resource { get; set; }
        public string Namespace { get; set; }
        public int Order { get; set; }
        public string[] Operations { get; set; }
    }
}
