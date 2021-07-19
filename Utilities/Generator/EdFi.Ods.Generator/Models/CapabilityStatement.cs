// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Generator.Models
{
    public class CapabilityStatement
    {
        public Rest[] rest { get; set; }
    }

    public class Rest
    {
        public Mode mode { get; set; }
        public Resource[] resource { get; set; }
    }

    public enum Mode
    {
        // client,
        server
    }

    public class Resource
    {
        public string type { get; set; }

        public bool readHistory { get; set; }
    }
}
