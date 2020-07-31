// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Xml.Linq;

namespace EdFi.LoadTools.Engine.Mapping
{
    /// <summary>
    /// xsd:boolean accepts true, false, 1, and 0.
    /// json boolean accepts true false as strings and 1, 0 as numbers.
    /// Since the loader only sends strings we map "1" and "0" to "true" and "false".
    /// </summary>
    public class BooleanPropertyMappingStrategy : CopySimplePropertyMappingStrategy
    {
        public override void MapElement(XElement source, string path, XElement target)
        {
            if (source.Value == "0")
            {
                SetValueOnPathForElement("false", path, target);
            }
            else if (source.Value == "1")
            {
                SetValueOnPathForElement("true", path, target);
            }
            else
            {
                base.MapElement(source, path, target);
            }
        }
    }
}
