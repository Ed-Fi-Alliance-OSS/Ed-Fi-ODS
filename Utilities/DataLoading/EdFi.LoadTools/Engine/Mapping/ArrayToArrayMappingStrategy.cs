// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Linq;
using System.Xml.Linq;

namespace EdFi.LoadTools.Engine.Mapping
{
    public class ArrayToArrayMappingStrategy : MappingStrategy
    {
        private readonly XNamespace _json = "http://james.newtonking.com/projects/json";

        public override void MapElement(XElement source, string path, XElement target)
        {
            var newElement = SetValueOnPathForElement(null, path, target);
            var attributes = newElement.Attributes().ToList();
            attributes.Insert(0, new XAttribute(_json + "Array", true));
            newElement.ReplaceAttributes(attributes);
        }

        public override void ReverseMapElement(XElement source, string path, XElement target)
        {
            throw new NotImplementedException();
        }
    }
}
