// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using Newtonsoft.Json;

namespace EdFi.Ods.Common.Serialization
{
    /// <summary>
    /// Deserializes JSON for <see cref="T:IDictionary{string,object}"/> properties to strongly-typed 
    /// extension resource classes using conventions.
    /// </summary>
    public class ExtensionsConverter : JsonConverter
    {
        private static readonly ConcurrentDictionary<string, Type> _typeByTypeName
            = new ConcurrentDictionary<string, Type>();
        private static readonly Lazy<string[]> _availableExtensionSchemas = new Lazy<string[]>(
            () => ResourceModelHelper.ResourceModel.Value.SchemaNameMapProvider.GetSchemaNameMaps().Select(snm => snm.ProperCaseName).ToArray());

        private readonly string _resourceClassName;
        private readonly string _resourceName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionsConverter" /> class using the provided 
        /// name of the API resource and the name of the class containing the extensions.
        /// </summary>
        /// <param name="resourceName">The name of the resource, as determined by the root resource class of the resource.</param>
        /// <param name="resourceClassName">The name of the resource class within the specified resource.</param>
        /// <remarks>This constructor is invoked dynamically by JSON.NET based on the arguments supplied in the 
        /// <see cref="JsonConverterAttribute"/> applied to Extensions properties.</remarks>
        public ExtensionsConverter(string resourceName, string resourceClassName)
        {
            _resourceName = resourceName;
            _resourceClassName = resourceClassName;
        }

        /// <summary>
        /// Returns <b>false</b>, indicating that the converter only deserializes (reads) JSON.
        /// </summary>
        public override bool CanWrite
        {
            get { return false; }
        }

        /// <summary>
        /// Throws a <see cref="NotImplementedException" /> indicating that serialization is not supported.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException(typeof(ExtensionsConverter).Name + " only supports deserialization.");
        }

        /// <summary>
        /// Deserializes the JSON for Ed-Fi extensions into strongly-typed extension classes based on convention, 
        /// overriding the default JSON.NET behavior of deserializing the remainder of the JSON to dictionaries.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns>A dictionary keyed by the extensions' schemas (using their ProperCaseName representations), 
        /// and containing the strongly-typed extension classes.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            IDictionary<string, object> extensionDictionary = new Dictionary<string, object>();

            // Advance to the first property
            reader.Read();

            while (reader.TokenType == JsonToken.PropertyName)
            {
                string extensionName = (string) reader.Value;

                var matchingExtension = GetExtensionSchemas().SingleOrDefault(ae => ae.EqualsIgnoreCase(extensionName));

                // Read the value for the properties on the extension property
                reader.Read();

                object extensionObject;

                if (matchingExtension != null
                    && TryActivateObject(serializer, GetExtensionClassAssemblyQualifiedName(matchingExtension), out extensionObject))
                {
                    // Use the serializer to populate the extension object
                    serializer.Populate(reader, extensionObject);

                    // Assign the extension value
                    extensionDictionary[matchingExtension] = extensionObject;
                }
                else
                {
                    string path = reader.Path;

                    // We could not create the target object, so skip it
                    do { }
                    while (reader.Read() && !(reader.Path == path && reader.TokenType == JsonToken.EndObject));
                }

                // Advance to the next extension or past the EndObject token
                reader.Read();
            }

            return extensionDictionary;
        }

        /// <summary>
        /// Gets the assembly qualified name of the extension class name to be used for deserialization.
        /// </summary>
        /// <param name="extensionName">The name of the extension.</param>
        /// <returns>The assembly qualified name of the extension class name to be used for deserialization.</returns>
        protected virtual string GetExtensionClassAssemblyQualifiedName(string extensionName)
        {
            return ExtensionsConventions.GetExtensionResourceClassAssemblyQualifiedName(
                extensionName,
                _resourceName,
                _resourceClassName);
        }

        protected virtual string[] GetExtensionSchemas()
        {
            return _availableExtensionSchemas.Value;
        }

        private static bool TryActivateObject(JsonSerializer serializer, string typeName, out object @object)
        {
            @object = null;

            var extensionObjectType = _typeByTypeName.GetOrAdd(
                typeName,
                Type.GetType);

            if (extensionObjectType == null)
            {
                return false;
            }

            @object = serializer.ContractResolver.ResolveContract(extensionObjectType)
                                .DefaultCreator();

            return @object != null;
        }

        /// <summary>
        /// Indicates whether this converter can convert the specified type.
        /// </summary>
        /// <param name="objectType">The Type of the object to be converted.</param>
        /// <returns><b>true</b> if the converter handles the specified type; otherwise <b>false</b>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IDictionary<string, object>);
        }
    }
}
