// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Models.Domain;
using MessagePack;
using MessagePack.Formatters;

namespace EdFi.Ods.Common.Serialization;

public class AggregateExtensionsMessagePackFormatter : IMessagePackFormatter<IDictionary>
{
    private readonly Type _containingType;

    public AggregateExtensionsMessagePackFormatter(string aggregateName, string entityName)
    {
        if (GeneratedArtifactStaticDependencies.DomainModelProvider.GetDomainModel().EntityByFullName.TryGetValue(new FullName(EdFiConventions.PhysicalSchemaName, entityName), out var entity))
        {
            _containingType = (entity as dynamic).NHibernateEntityType;
        }
    }

    public void Serialize(ref MessagePackWriter writer, IDictionary value, MessagePackSerializerOptions options)
    {
        var extensionCollectionByName = value as IDictionary<string, object>;

        if (extensionCollectionByName == null)
        {
            writer.WriteNil();
            return;
        }

        writer.WriteMapHeader(extensionCollectionByName.Count);

        foreach (string key in extensionCollectionByName.Keys)
        {
            writer.Write(key);

            object extensionCollectionEntry = extensionCollectionByName[key];

            if (extensionCollectionEntry == null)
            {
                writer.WriteNil();
                continue;
            }

            var extensionObjects = extensionCollectionEntry as IList<object>;

            writer.WriteArrayHeader(extensionObjects.Count);

            foreach (object extensionObject in extensionObjects)
            {
                if (extensionObject == null)
                {
                    writer.WriteNil();
                    continue;
                }

                var type = extensionObject.GetType();
                MessagePackSerializer.Serialize(type, ref writer, extensionObject, options);
            }
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
            string extensionCollectionName = reader.ReadString();

            if (!GeneratedArtifactStaticDependencies.EntityExtensionRegistrar.AggregateExtensionEntityNamesByType.TryGetValue(_containingType, out var aggregateExtensionByName))
            {
                throw new Exception($"Unable to find aggregate extension by type '{_containingType.Name}'");
            }

            if (!aggregateExtensionByName.TryGetValue(extensionCollectionName, out var extensionEntity))
            {
                throw new Exception($"Unable to find aggregate extension for '{_containingType.Name}' by name '{extensionCollectionName}'.");
            }

            Type extensionEntityType = (extensionEntity as dynamic).NHibernateEntityType;

            // TODO: ODS-6551 - Optimize, create dictionary containing generic method by type
            Type listType = typeof(List<>).MakeGenericType(typeof(object));
            var extensionObjectList = (IList) Activator.CreateInstance(listType);

            int itemCount = reader.ReadArrayHeader();

            for (int j = 0; j < itemCount; j++)
            {
                // Use the serializer to populate the extension object
                var extensionObject = MessagePackSerializer.Deserialize(extensionEntityType, ref reader, options);
                extensionObjectList!.Add(extensionObject);
            }

            var method = GetType()!.GetMethod(nameof(CreatePersistentBag), BindingFlags.NonPublic | BindingFlags.Static)!
                .MakeGenericMethod(typeof(object));

            var persistentList = method.Invoke(null, [extensionObjectList]);
            extensionDictionary.Add(extensionCollectionName, persistentList);
        }

        return extensionDictionary;
    }

    private static object CreatePersistentBag<T>(IList<T> extensionObjects)
    {
        var list = new List<T>(extensionObjects.Count);
        
        foreach (T item in extensionObjects)
        {
            list.Add(item);
        }

        var bag = new DeserializedPersistentGenericBag<T>(GeneratedArtifactStaticDependencies.SessionFactory, list); //, extensionObjects);
        return bag;
    }
}
