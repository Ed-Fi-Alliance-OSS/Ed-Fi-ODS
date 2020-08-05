// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using EdFi.LoadTools.ApiClient;
using log4net;

// ReSharper disable CanBeReplacedWithTryCastAndCheckForNull

namespace EdFi.LoadTools.Engine.Factories
{
    /// <summary>
    ///     Create XSD metadata for all USED types. Doesn't include abstract or other types not referenced from the Interchange
    ///     files.
    /// </summary>
    public class XsdMetadataFactory : IMetadataFactory<XmlModelMetadata>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(XsdMetadataFactory).Name);

        private readonly Regex _typeRegex = new Regex(Constants.TypeRegex);

        public XsdMetadataFactory(XmlSchemaSet schemaSet)
        {
            Schemas = schemaSet;
        }

        public XmlSchemaSet Schemas { get; }

        public IEnumerable<XmlModelMetadata> GetMetadata()
        {
            Log.Info("Loading XSD Metadata");
            var results = new List<XmlModelMetadata>();

            //  Instead of rolling through all the types in the XSD...
            //
            //foreach (XmlSchemaType element in Schemas.GlobalTypes.Values)
            //{
            //    AddElementMetadata(element.Name, element, results);
            //}
            //
            // The following only looks at types that are actually used (not abstract ones)

            foreach (XmlSchema schema in Schemas.Schemas())
            {
                foreach (XmlSchemaElement element in schema.Elements.Values)
                {
                    AddElementMetadata(element.Name, element, results);
                }
            }

            return results
                  .Where(
                       x => !string.IsNullOrEmpty(x.Model)
                            && !string.IsNullOrEmpty(x.Property)
                            && !string.IsNullOrEmpty(x.Type))
                  .Distinct(new ModelMetadataEqualityComparer<XmlModelMetadata>());
        }

        protected virtual bool ShouldFilterOut(string model, XmlSchemaElement ele)
        {
            return false;
        }

        private void AddElementMetadata(string model, XmlSchemaObject obj, ICollection<XmlModelMetadata> results)
        {
            model = TypeRegexMatch(model);

            while (true)
            {
                if (obj is XmlSchemaComplexType)
                {
                    var ct = (XmlSchemaComplexType) obj;
                    obj = ct.ContentTypeParticle;
                    continue;
                }

                if (obj is XmlSchemaChoice)
                {
                    var choice = (XmlSchemaChoice) obj;

                    foreach (var item in choice.Items.Cast<XmlSchemaObject>())
                    {
                        AddElementMetadata(model, item, results);
                    }
                }
                else if (obj is XmlSchemaSequence)
                {
                    var seq = (XmlSchemaSequence) obj;

                    foreach (var item in seq.Items.Cast<XmlSchemaObject>())
                    {
                        AddElementMetadata(model, item, results);
                    }
                }
                else if (obj is XmlSchemaElement)
                {
                    var ele = (XmlSchemaElement) obj;
                    var part = (XmlSchemaParticle) obj;
                    var st = ele.ElementSchemaType as XmlSchemaSimpleType;

                    if (ShouldFilterOut(model, ele))
                    {
                        return;
                    }

                    var type = TypeRegexMatch(ele.ElementSchemaType.Name);

                    results.Add(
                        new XmlModelMetadata
                        {
                            Model = model, Property = ele.Name, Type = st?.TypeCode.ToString() ?? type, TypeName = st?.Name, IsAttribute = false,
                            IsArray = part.MaxOccurs > 1, IsRequired = part.MinOccurs > 0, IsSimpleType = st != null
                        });

                    if (st == null)
                    {
                        model = ele.ElementSchemaType.Name;
                        obj = ele.ElementSchemaType;
                        continue;
                    }
                }

                break;
            }
        }

        private string TypeRegexMatch(string resourceTypeName)
        {
            var typeMatch = _typeRegex.Match(resourceTypeName ?? string.Empty);

            return typeMatch.Success
                ? typeMatch.Groups["TypeName"].Value?.Replace("Extension", string.Empty)
                : resourceTypeName;
        }
    }
}
