// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace EdFi.LoadTools.Engine.Mapping
{
    public class SchoolYearPropertyMappingStrategy : CopySimplePropertyMappingStrategy
    {
        private readonly Regex _regex = new Regex(Constants.SchoolYearRegex);

        public override void MapElement(XElement source, string path, XElement target)
        {
            var match = _regex.Match(source.Value);

            if (match.Success)
            {
                var value = match.Groups["Year"].Value;
                SetValueOnPathForElement(value, path, target);
            }
            else
            {
                base.MapElement(source, path, target);
            }
        }

        public override void ReverseMapElement(XElement source, string path, XElement target)
        {
            SetValueOnPathForElement(source.Value, path, target);
        }
    }
}
