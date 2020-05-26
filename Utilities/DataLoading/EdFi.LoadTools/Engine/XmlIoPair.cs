// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Xml;

namespace EdFi.LoadTools.Engine
{
    public class XmlIoPair : IDisposable
    {
        public XmlReader Source { get; set; }

        public XmlWriter Destination { get; set; }

        public void Dispose()
        {
            Source?.Dispose();
            Destination?.Dispose();
        }
    }
}
