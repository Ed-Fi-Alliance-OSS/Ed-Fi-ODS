// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Dependencies;
using MessagePack;
using MessagePack.Formatters;

namespace EdFi.Ods.Common.Serialization;

public class PersistentCollectionFormatter<T> : IMessagePackFormatter<ICollection<T>>
{
    public void Serialize(ref MessagePackWriter writer, ICollection<T> value, MessagePackSerializerOptions options)
    {
        // Use the default formatter for ICollection<T> for serialization
        options.Resolver.GetFormatterWithVerify<ICollection<T>>().Serialize(ref writer, value, options);
    }

    public ICollection<T> Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        // Deserialize to a standard collection
        var sourceSet = options.Resolver.GetFormatterWithVerify<HashSet<T>>().Deserialize(ref reader, options);

        // Wrap the standard collection in a GenericPersistentSet<T> compatible with NHibernate
        var persistentCollection = new DeserializedPersistentGenericSet<T>(
            GeneratedArtifactStaticDependencies.SessionFactory,
            sourceSet);

        return persistentCollection;
    }
}
