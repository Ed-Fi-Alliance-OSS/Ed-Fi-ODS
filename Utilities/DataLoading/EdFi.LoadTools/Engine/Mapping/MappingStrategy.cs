// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;
using System.Xml.Linq;

namespace EdFi.LoadTools.Engine.Mapping
{
    public abstract class MappingStrategy : IMappingStrategy
    {
        public abstract void MapElement(XElement source, string path, XElement target);

        public abstract void ReverseMapElement(XElement source, string path, XElement target);

        protected static XElement SetValueOnPathForElement(string value, string path, XElement element)
        {
            var segments = path.Split('/');
            var currentElement = element;

            for (var i = 0; i < segments.Length - 1; i++)
            {
                var tmp = currentElement.Elements(segments[i]).LastOrDefault();

                if (tmp == null)
                {
                    tmp = new XElement(segments[i]);
                    currentElement.Add(tmp);
                }

                currentElement = tmp;
            }

            var newElement = new XElement(segments.Last(), value);
            currentElement.Add(newElement);
            return newElement;
        }
    }
}
