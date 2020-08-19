// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Xml.Linq;

namespace EdFi.LoadTools.Engine.Mapping
{
    public class NoOperationMappingStrategy : IMappingStrategy
    {
        public void MapElement(XElement source, string path, XElement target)
        {
            // do nothing
        }

        public void ReverseMapElement(XElement source, string path, XElement target)
        {
            // do nothing;
        }
    }
}
