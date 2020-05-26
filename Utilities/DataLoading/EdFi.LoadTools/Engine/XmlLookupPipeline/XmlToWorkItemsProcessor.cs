// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;
using System.Xml;
using System.Xml.Linq;

namespace EdFi.LoadTools.Engine.XmlLookupPipeline
{
    public class XmlToWorkItemsProcessor
    {
        private readonly Regex _regex = new Regex(Constants.ReferenceRegex);

        public IPropagatorBlock<XmlReader, XmlLookupWorkItem> CreateBlock()
        {
            return new TransformManyBlock<XmlReader, XmlLookupWorkItem>(
                xr => GetLookupWorkItems(xr),
                new ExecutionDataflowBlockOptions
                {
                    BoundedCapacity = 1
                });
        }

        public IEnumerable<XmlLookupWorkItem> GetLookupWorkItems(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType != XmlNodeType.Element || !_regex.IsMatch(reader.Name))
                {
                    continue;
                }

                using (var r = reader.ReadSubtree())
                {
                    var xElement = XElement.Parse(XElement.Load(r).ToString());

                    foreach (var workItem in GetLookupWorkItems(xElement))
                    {
                        yield return workItem;
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="xElement">a ReferenceType xElement</param>
        /// <returns>A list of work items that should be looked up</returns>
        private IEnumerable<XmlLookupWorkItem> GetLookupWorkItems(XElement xElement)
        {
            var result = new List<XmlLookupWorkItem>();
            var typeName = _regex.Match(xElement.Name.LocalName).Groups["TypeName"].Value;
            var ns = xElement.Name.Namespace;

            // We only need to perform the lookup if they don't have an identity
            var identity = xElement.Element(ns + $"{typeName}Identity");
            var lookup = xElement.Element(ns + $"{typeName}Lookup");

            if (identity != null)
            {
                return GetLookupWorkItems(identity);
            }

            if (lookup != null)
            {
                result.Add(new XmlLookupWorkItem(lookup));
            }

            result.AddRange(
                xElement.Elements()
                        .Where(x => x.HasElements)
                        .SelectMany(GetLookupWorkItems)
            );

            return result;
        }
    }
}
