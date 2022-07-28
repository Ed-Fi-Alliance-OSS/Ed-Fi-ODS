// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace Test.Common.ModelBuilders;

public class AggregateCollectionDescriptor
{
    private readonly SchemaDescriptor _schemaDescriptor;

    public AggregateCollectionDescriptor(SchemaDescriptor schemaDescriptor)
    {
        _schemaDescriptor = schemaDescriptor;
    }

    public AggregateRootDescriptor AggregateRoot(string name)
    {
        return AggregateRoot(_schemaDescriptor.PhysicalName, name);
    }

    public AggregateRootDescriptor AggregateRoot(string schema, string name)
    {
        var aggregateRoot = new AggregateRootDescriptor(schema, name);
        _schemaDescriptor.AggregateRoots.Add(aggregateRoot);

        return aggregateRoot;
    }
}