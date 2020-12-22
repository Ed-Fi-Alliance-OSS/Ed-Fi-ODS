// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using EdFi.Common.Extensions;
using EdFi.Common.Inflection;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using Newtonsoft.Json;

namespace EdFi.Ods.Api.Controllers.DataManagement.ResponseBuilding
{
    public class ResourceData
    {
        public ResourceData(IList<ResourceClassQueryResults> results)
        {
            Results = results;
        }

        public IList<ResourceClassQueryResults> Results { get; }

        public string ToJson()
        {
            var sb = new StringBuilder();

            var jw = new JsonTextWriter(new StringWriter(sb))
            {
                Formatting = Formatting.Indented,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
            };

            jw.WriteStartArray();

            var resourceRootData = Results.First();

            var resourceClass = resourceRootData.ResourceClass;

            foreach (IDictionary<string, object> item in resourceRootData.Results)
            {
                WriteObject(jw, resourceClass, item);
            }

            jw.WriteEndArray();

            jw.Flush();

            return sb.ToString();
        }

        private void WriteObject(JsonTextWriter jw, ResourceClassBase resourceClass, IDictionary<string, object> item)
        {
            jw.WriteStartObject();

            // TODO: Write the id first 
            if (resourceClass is Resource)
            {
                WriteResourceProperty(jw, resourceClass.PropertyByName["Id"], item);
            }
            
            // Write the properties
            foreach (var resourceProperty in resourceClass.Properties)
            {
                if (resourceProperty.PropertyName.EqualsIgnoreCase("Id"))
                {
                    continue;
                }
                
                WriteResourceProperty(jw, resourceProperty, item);
            }

            // Write the references
            foreach (var reference in resourceClass.References)
            {
                WriteReference(jw, reference, item);
            }

            // Write the collections
            foreach (var collection in resourceClass.Collections)
            {
                var resourceClassQuery = Results.SingleOrDefault(rcq => collection.ItemType == rcq.ResourceClass);

                if (resourceClassQuery == null)
                {
                    continue;
                }

                WriteCollection(jw, item, resourceClassQuery.Results, collection);
            }

            jw.WriteEndObject(); // item
        }

        private void WriteCollection(
            JsonTextWriter jw,
            IDictionary<string, object> parentItem,
            List<object> collectionItems,
            Collection collection)
        {
            jw.WritePropertyName(collection.JsonPropertyName);
            jw.WriteStartArray();

            foreach (IDictionary<string, object> collectionItem in collectionItems)
            {
                bool isIncluded = IsChildItemIncluded(parentItem, collectionItem, collection.ItemType);

                if (!isIncluded)
                {
                    continue;
                }

                WriteObject(jw, collection.ItemType, collectionItem);
            }

            jw.WriteEndArray(); // collection items
        }

        private void WriteReference(JsonTextWriter jw, Reference reference, IDictionary<string, object> item)
        {
            var id = (Guid?) item[$"{reference.PropertyName}_Id"];

            if (id == null)
            {
                return;
            }

            jw.WritePropertyName(reference.JsonPropertyName);
            jw.WriteStartObject();

            foreach (var resourceProperty in reference.Properties)
            {
                WriteResourceProperty(jw, resourceProperty, item);
            }

            jw.WritePropertyName("link");

            jw.WriteStartObject();
            jw.WritePropertyName("rel");

            string discriminator;
            string referencedCollectionName;

            if (reference.Association.OtherEntity.IsAbstract)
            {
                // Write the reference's Discriminator
                discriminator = ((string) item[$"{reference.PropertyName}_Discriminator"]).Split(',')[1];
                jw.WriteValue(discriminator);
                referencedCollectionName = CompositeTermInflector.MakePlural(discriminator).ToCamelCase();
            }
            else
            {
                jw.WriteValue(reference.Association.OtherEntity.Name);
                referencedCollectionName = reference.Association.OtherEntity.PluralName.ToCamelCase();
            }

            jw.WritePropertyName("href");

            jw.WriteValue($"/{reference.Association.OtherEntity.SchemaUriSegment()}/{referencedCollectionName}/{id:N}");

            jw.WriteEndObject(); // link
            jw.WriteEndObject(); // reference object
        }

        private void WriteResourceProperty(
            JsonTextWriter jw,
            ResourceProperty resourceProperty,
            IDictionary<string, object> item)
        {
            object value = null;

            if (resourceProperty.IsLookup)
            {
                var descriptorNamespace = item[$"{resourceProperty.PropertyName}_Namespace"];
                var descriptorCodeValue = item[$"{resourceProperty.PropertyName}_CodeValue"];

                if (descriptorNamespace != null && descriptorCodeValue != null)
                {
                    value = $"{descriptorNamespace}#{descriptorCodeValue}";
                }
            }
            else
            {
                value = item[resourceProperty.PropertyName];
            }

            // Don't write null values
            if (value == null)
            {
                return;
            }

            jw.WritePropertyName(resourceProperty.JsonPropertyName);

            var propertyType = resourceProperty.PropertyType;

            if (propertyType.DbType == DbType.Date)
            {
                jw.WriteValue(((DateTime) value).ToString("yyyy-MM-dd"));
            }
            else if (propertyType.DbType == DbType.Guid)
            {
                jw.WriteValue(((Guid) value).ToString("n"));
            }
            // else if (propertyType.DbType == DbType.Decimal)
            // {
            //     jw.WriteRawValue(((Decimal) value).ToString($"F{propertyType.Scale}"));
            // }
            else
            {
                jw.WriteValue(value);
            }
        }

        private bool IsChildItemIncluded(
            IDictionary<string, object> parentItem,
            IDictionary<string, object> collectionItem,
            ResourceClassBase childResourceClass)
        {
            foreach (var propertyMapping in childResourceClass.Entity.ParentAssociation.PropertyMappings)
            {
                if (!collectionItem[propertyMapping.ThisProperty.PropertyName]
                    .Equals(parentItem[propertyMapping.OtherProperty.PropertyName]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
