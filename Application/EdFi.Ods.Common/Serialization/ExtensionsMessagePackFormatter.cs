// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;


using MessagePack;
using MessagePack.Formatters;
using System.Collections.Concurrent;
using System.Collections.Specialized;

namespace EdFi.Ods.Common.Serialization;

public class ExtensionsMessagePackFormatter : IMessagePackFormatter<IDictionary> 
{
    private static readonly ConcurrentDictionary<string, Type> _typeByTypeName = new();

    private static readonly Lazy<string[]> _availableExtensionSchemas = new(
        () => ResourceModelHelper.ResourceModel.Value.SchemaNameMapProvider.GetSchemaNameMaps()
            .Select(snm => snm.ProperCaseName)
            .ToArray());

    private readonly string _resourceClassName;
    private readonly string _resourceName;

    public ExtensionsMessagePackFormatter(string resourceName, string resourceClassName)
    {
        _resourceName = resourceName;
        _resourceClassName = resourceClassName;
    }

    public void Serialize(ref MessagePackWriter writer, IDictionary value, MessagePackSerializerOptions options)
    {
        // var extensionByName = value as IDictionary<string, object>;
        var extensionByName = value as OrderedDictionary;

        if (extensionByName == null)
        {
            writer.WriteNil();
            return;
        }

        writer.WriteMapHeader(extensionByName.Count);

        foreach (string key in extensionByName.Keys)
        {
            writer.Write(key);

            object extensionObject = extensionByName[key];
            
            if (extensionObject == null)
            {
                writer.WriteNil();
                continue;
            }

            var type = extensionObject.GetType();
            MessagePackSerializer.Serialize(type, ref writer, extensionObject, options);
        }
    }

    public IDictionary Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.TryReadNil())
        {
            return null;
        }

        var extensionDictionary = new Dictionary<string, object>();

        int count = reader.ReadMapHeader();

        for (int i = 0; i < count; i++)
        {
            string extensionName = reader.ReadString();

            var matchingExtension = GetExtensionSchemas().SingleOrDefault(ae => ae.EqualsIgnoreCase(extensionName));

            object extensionObject = null;

            if (matchingExtension != null
                && TryActivateObject(options, GetExtensionClassAssemblyQualifiedName(matchingExtension), out extensionObject))
            {
                // Use the serializer to populate the extension object
                extensionObject = MessagePackSerializer.Deserialize(extensionObject.GetType(), ref reader, options);
                extensionDictionary[matchingExtension] = extensionObject;
            }
            else
            {
                reader.Skip();
            }
        }

        return extensionDictionary;
    }

    private static bool TryActivateObject(MessagePackSerializerOptions options, string typeName, out object @object)
    {
        @object = null;

        var extensionObjectType = _typeByTypeName.GetOrAdd(typeName, Type.GetType);

        if (extensionObjectType == null)
        {
            return false;
        }

        @object = Activator.CreateInstance(extensionObjectType);
        return @object != null;
    }

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
}
