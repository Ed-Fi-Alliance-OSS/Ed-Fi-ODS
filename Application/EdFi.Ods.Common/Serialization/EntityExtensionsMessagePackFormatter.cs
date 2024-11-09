// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using MessagePack;
using MessagePack.Formatters;

namespace EdFi.Ods.Common.Serialization;

public class EntityExtensionsMessagePackFormatter : IMessagePackFormatter<IDictionary>
{
    private static readonly Lazy<string[]> _availableExtensionSchemas = new(
        () => ResourceModelHelper.ResourceModel.Value.SchemaNameMapProvider.GetSchemaNameMaps()
            .Select(snm => snm.ProperCaseName)
            .ToArray());

    private readonly string _entityName;
    private readonly string _aggregateName;

    public EntityExtensionsMessagePackFormatter(string aggregateName, string entityName)
    {
        _aggregateName = aggregateName;
        _entityName = entityName;
    }

    public void Serialize(ref MessagePackWriter writer, IDictionary value, MessagePackSerializerOptions options)
    {
        var extensionByName = value as IDictionary<string, object>;

        if (extensionByName == null)
        {
            writer.WriteNil();
            return;
        }

        writer.WriteMapHeader(extensionByName.Count);

        foreach (string key in extensionByName.Keys)
        {
            writer.Write(key);

            object extensionObjectSet = extensionByName[key];
            IList extensionObjectSetAsList = extensionObjectSet as IList;

            if (extensionObjectSetAsList == null || extensionObjectSetAsList.Count == 0)
            {
                writer.WriteNil();
                continue;
            }

            var extensionObject = extensionObjectSetAsList[0]; 
            var type = extensionObject.GetType();
            MessagePackSerializer.Serialize(type, ref writer, extensionObject, options);
        }
    }

    private static ConcurrentDictionary<string, Type> _implicitExtensionEntityTypeByClassTypeName = new();

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

            string extensionClassTypeName = Namespaces.Entities.NHibernate.GetAggregateNamespace(_aggregateName, matchingExtension, isExtensionEntity: true) 
                + $".{_entityName}Extension";

            // Get the system type using NHibernate (works for all mapped classes)
            Type extensionObjectType = GeneratedArtifactStaticDependencies.SessionFactory.GetClassMetadata(extensionClassTypeName)
                ?.MappedClass;

            // Are we dealing with an implicit entity extension?
            if (extensionObjectType == null)
            {
                // This indicates the extension type is an implicit entity extension (there's no mapped entity because it has
                // no underlying table because it has no columns/properties)
                extensionObjectType = _implicitExtensionEntityTypeByClassTypeName.GetOrAdd(
                    extensionClassTypeName,
                    (tn, args) =>
                    {
                        if (!GeneratedArtifactStaticDependencies.DomainModelProvider.GetDomainModel()
                                .EntityByFullName.TryGetValue(
                                    new FullName(EdFiConventions.PhysicalSchemaName, args._entityName),
                                    out var entity))
                        {
                            throw new Exception($"Could not find entity '{EdFiConventions.PhysicalSchemaName}.{args._entityName}'.");
                        }

                        var standardType = (Type) (entity as dynamic).NHibernateEntityType;
                        
                        string fullTypeName = ExtensionsConventions.GetExtensionClassAssemblyQualifiedName(standardType, args.extensionName);

                        return Type.GetType(fullTypeName);
                    },
                    (_aggregateName, _entityName, extensionName));
            }

            // Wrap the standard collection in a GenericPersistentSet<T> compatible with NHibernate
            // TODO: ODS-6551 - Optimize, create dictionary containing generic method by type
            var method = GetType()!.GetMethod(nameof(CreatePersistentCollection), BindingFlags.NonPublic | BindingFlags.Static)!
                .MakeGenericMethod(typeof(object));

            if (reader.TryReadNil())
            {
                extensionDictionary[matchingExtension] = method.Invoke(null, [null]);
                continue;
            }

            // Use the serializer to populate the extension object
            var extensionObject = MessagePackSerializer.Deserialize(extensionObjectType, ref reader, options);

            extensionDictionary[matchingExtension] = method.Invoke(null, [extensionObject]);
        }

        return extensionDictionary;
    }

    private static object CreatePersistentCollection<T>(T extensionObject)
    {
        var list = new List<T>();
        
        if (extensionObject != null)
        {
            list.Add(extensionObject);
        };

        var bag = new DeserializedPersistentGenericBag<T>(GeneratedArtifactStaticDependencies.SessionFactory, list);

        return bag;
    }

    protected virtual string[] GetExtensionSchemas()
    {
        return _availableExtensionSchemas.Value;
    }
}
