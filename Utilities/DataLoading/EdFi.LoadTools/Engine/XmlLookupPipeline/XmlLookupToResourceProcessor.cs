// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;
using System.Xml;
using System.Xml.Linq;

namespace EdFi.LoadTools.Engine.XmlLookupPipeline
{
    public class XmlLookupToResourceProcessor
    {
        private readonly IDictionary<string, XElement> _hashIdentities;
        private readonly IHashProvider _hashProvider;

        private readonly Regex _regex = new Regex(Constants.ReferenceRegex);

        public XmlLookupToResourceProcessor(IHashProvider hashProvider, IDictionary<string, XElement> hashIdentities)
        {
            _hashProvider = hashProvider;
            _hashIdentities = hashIdentities;
        }

        public ITargetBlock<XmlIoPair> CreateBlock()
        {
            return new ActionBlock<XmlIoPair>(
                s => CopyXmlLookupsToResources(s.Source, s.Destination),
                new ExecutionDataflowBlockOptions
                {
                    BoundedCapacity = 1
                });
        }

        public void CopyXmlLookupsToResources(XmlReader reader, XmlWriter writer)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && _regex.IsMatch(reader.Name))
                {
                    using (var r = reader.ReadSubtree())
                    {
                        var xElement = XElement.Parse(XElement.Load(r).ToString());
                        ReplaceReferenceLookupsWithIdentities(xElement);

                        using (var t2 = new StringReader(xElement.ToString()))
                        {
                            using (var r2 = new XmlTextReader(t2))
                            {
                                while (r2.Read())
                                {
                                    WriteShallowNode(r2, writer, true);
                                }
                            }
                        }
                    }

                    continue;
                }

                WriteShallowNode(reader, writer);
            }

            writer.Flush();
        }

        /// <summary>
        ///     Starting with the innermost nodes, replace all lookups with identities
        /// </summary>
        /// <param name="xElement"></param>
        private void ReplaceReferenceLookupsWithIdentities(XElement xElement)
        {
            XElement newIdentity = null;

            var ns = xElement.Name.Namespace;

            if (_regex.IsMatch(xElement.Name.LocalName))
            {
                var typeName = _regex.Match(xElement.Name.LocalName).Groups["TypeName"].Value;
                var lookup = xElement.Element(ns + $"{typeName}Lookup");
                var identity = xElement.Element(ns + $"{typeName}Identity");

                if (lookup != null && identity == null)
                {
                    var hashBytes = _hashProvider.Hash(lookup.ToString());
                    var hash = _hashProvider.BytesToStr(hashBytes);

                    if (_hashIdentities.ContainsKey(hash) && _hashIdentities[hash] != null)
                    {
                        newIdentity = XElement.Parse(_hashIdentities[hash].ToString());

                        lookup.AddBeforeSelf(
                            new XComment(
                                $"This {typeName}Lookup entity was used to populate its {typeName}Identity sibling"));
                    }
                    else
                    {
                        lookup.AddBeforeSelf(
                            new XComment(
                                $"No {typeName}Identity could be retrieved for this {typeName}Lookup entity"));
                    }
                }

                foreach (var element in xElement.Elements())
                {
                    ReplaceReferenceLookupsWithIdentities(element);
                }

                if (newIdentity == null)
                {
                    return;
                }

                xElement.Add(newIdentity);

                newIdentity.AddBeforeSelf(
                    new XComment(
                        $"This {typeName}Identity entity was retrieved from the API using the provided {typeName}Lookup information"));
            }
            else
            {
                foreach (var element in xElement.Elements())
                {
                    ReplaceReferenceLookupsWithIdentities(element);
                }
            }
        }

        private static void WriteShallowNode(XmlReader reader, XmlWriter writer, bool skipXmlns = false)
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Element:

                    if (skipXmlns)
                    {
                        writer.WriteStartElement(reader.LocalName);

                        if (reader.HasAttributes)
                        {
                            reader.MoveToFirstAttribute();

                            do
                            {
                                if (reader.Name != "xmlns")
                                {
                                    writer.WriteAttributeString(reader.Name, reader.Value);
                                }
                            }
                            while (reader.MoveToNextAttribute());
                        }
                    }
                    else
                    {
                        writer.WriteStartElement(reader.Prefix, reader.LocalName, reader.NamespaceURI);
                        writer.WriteAttributes(reader, true);
                    }

                    if (reader.IsEmptyElement)
                    {
                        writer.WriteEndElement();
                    }

                    break;
                case XmlNodeType.Text:
                    writer.WriteString(reader.Value);
                    break;
                case XmlNodeType.Whitespace:
                case XmlNodeType.SignificantWhitespace:
                    writer.WriteWhitespace(reader.Value);
                    break;
                case XmlNodeType.CDATA:
                    writer.WriteCData(reader.Value);
                    break;
                case XmlNodeType.EntityReference:
                    writer.WriteEntityRef(reader.Name);
                    break;
                case XmlNodeType.XmlDeclaration:
                case XmlNodeType.ProcessingInstruction:
                    writer.WriteProcessingInstruction(reader.Name, reader.Value);
                    break;
                case XmlNodeType.DocumentType:

                    // ReSharper disable once AssignNullToNotNullAttribute
                    writer.WriteDocType(
                        reader.Name, reader.GetAttribute("PUBLIC"), reader.GetAttribute("SYSTEM"),
                        reader.Value);

                    break;
                case XmlNodeType.Comment:
                    writer.WriteComment(reader.Value);
                    break;
                case XmlNodeType.EndElement:
                    writer.WriteFullEndElement();
                    break;
            }
        }
    }
}
