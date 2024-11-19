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

        IList<string> missingExtensionEntries;

        if (GeneratedArtifactStaticDependencies.EntityExtensionRegistrar?.AggregateExtensionEntityNamesByType.TryGetValue(_containingType, out var aggregateExtensionByName) == true)
        {
            missingExtensionEntries = new List<string>(aggregateExtensionByName.Keys);
        }
        else
        {
            missingExtensionEntries = Array.Empty<string>();
            aggregateExtensionByName = null;
        }

        int count = reader.ReadMapHeader();

        for (int i = 0; i < count; i++)
        {
            string extensionCollectionName = reader.ReadString();

            if (aggregateExtensionByName?.TryGetValue(extensionCollectionName, out var extensionEntity) != true)
            {
                throw new Exception($"Unable to find the deserialized aggregate extension '{extensionCollectionName}' on '{_containingType.Name}' in the current model.");
            }

            missingExtensionEntries.Remove(extensionCollectionName);

            Type extensionEntityType = (extensionEntity as dynamic).NHibernateEntityType;

            var extensionObjectList = new List<object>();

            int itemCount = reader.ReadArrayHeader();

            for (int j = 0; j < itemCount; j++)
            {
                // Use the serializer to populate the extension object
                var extensionObject = MessagePackSerializer.Deserialize(extensionEntityType, ref reader, options);
                extensionObjectList!.Add(extensionObject);
            }

            var persistentList = new DeserializedPersistentGenericBag<object>(
                GeneratedArtifactStaticDependencies.SessionFactory, 
                extensionObjectList);

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
}
