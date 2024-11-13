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
using NHibernate.Engine;

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

        if (count == 0)
        {
            return extensionDictionary;
        }

        IList<string> missingExtensionEntries;

        if (GeneratedArtifactStaticDependencies.EntityExtensionRegistrar.AggregateExtensionEntityNamesByType.TryGetValue(_containingType, out var aggregateExtensionByName))
        {
            missingExtensionEntries = new List<string>(aggregateExtensionByName.Keys);
        }
        else
        {
            missingExtensionEntries = Array.Empty<string>();
        }

        for (int i = 0; i < count; i++)
        {
            string extensionCollectionName = reader.ReadString();

            if (aggregateExtensionByName?.TryGetValue(extensionCollectionName, out var extensionEntity) != true)
            {
                throw new Exception($"Unable to find the deserialized aggregate extension '{extensionCollectionName}' on '{_containingType.Name}' in the current model.");
            }

            missingExtensionEntries.Remove(extensionCollectionName);

            Type extensionEntityType = (extensionEntity as dynamic).NHibernateEntityType;

            var extensionObjectList = (IList) new List<object>();

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

        // If there are any extensions that weren't included in the deserialized data, we need to initialize them properly
        if (missingExtensionEntries.Count > 0)
        {
            foreach (string missingExtensionEntry in missingExtensionEntries)
            {
                extensionDictionary.Add(missingExtensionEntry, new DeserializedPersistentGenericBag<object>(
                    GeneratedArtifactStaticDependencies.SessionFactory,
                    new List<object>()));
            }
        }

        return extensionDictionary;
    }

    private static object CreatePersistentBag<T>(IList<T> extensionObjects)
    {
        // TODO: ODS-6551 - Now that we've identified that the generic type can be reduced to object in many places, can we eliminate the extra wrapper and generic type usage here to simplify and optimize the code?
        var list = new List<T>(extensionObjects.Count);
        
        foreach (T item in extensionObjects)
        {
            list.Add(item);
        }

        var bag = new DeserializedPersistentGenericBag<T>(GeneratedArtifactStaticDependencies.SessionFactory, list); //, extensionObjects);
        return bag;
    }
}
