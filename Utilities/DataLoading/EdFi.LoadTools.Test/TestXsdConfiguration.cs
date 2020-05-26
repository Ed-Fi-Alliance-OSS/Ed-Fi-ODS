// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using EdFi.LoadTools.Engine;

namespace EdFi.LoadTools.Test
{
    public class TestXsdConfiguration : IXsdConfiguration, IInterchangeOrderConfiguration
    {
        public string Folder { get; set; }

        public bool DoNotValidateXml { get; }
    }
}
