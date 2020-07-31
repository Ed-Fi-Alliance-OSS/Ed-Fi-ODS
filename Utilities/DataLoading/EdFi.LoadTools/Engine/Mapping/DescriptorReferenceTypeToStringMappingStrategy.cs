// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Xml.Linq;

namespace EdFi.LoadTools.Engine.Mapping
{
    public class DescriptorReferenceTypeToStringMappingStrategy : MappingStrategy
    {
        public override void MapElement(XElement source, string path, XElement target)
        {
            SetValueOnPathForElement(source.Value, path, target);
        }

        public override void ReverseMapElement(XElement source, string path, XElement target)
        {
            var values = source.Value.Split(
                new[]
                {
                    '/'
                }, StringSplitOptions.None);

            if (values.Length == 1)
            {
                SetValueOnPathForElement(values[0], $"{path}/CodeValue", target);
            }
            else
            {
                SetValueOnPathForElement(values[0], $"{path}/Namespace", target);
                SetValueOnPathForElement(values[1], $"{path}/CodeValue", target);
            }
        }
    }
}
