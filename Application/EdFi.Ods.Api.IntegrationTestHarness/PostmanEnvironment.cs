// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Api.IntegrationTestHarness
{
    public class PostmanEnvironment
    {
        public PostmanEnvironment()
        {
            Values = new List<ValueItem>();
        }

        public string Name = "Localhost";

        public List<ValueItem> Values;
    }

    public class ValueItem
    {
        public string Key { get; set; }

        public object Value { get; set; }

        public bool Enabled { get; set; }
    }
}
