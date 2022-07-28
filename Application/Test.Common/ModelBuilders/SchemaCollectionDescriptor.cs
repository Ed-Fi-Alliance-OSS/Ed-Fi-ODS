// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace Test.Common.ModelBuilders;

public class SchemaCollectionDescriptor
{
    private readonly FluentDomainModelBuilder _fluentDomainModelBuilder;
    
    public SchemaCollectionDescriptor(FluentDomainModelBuilder fluentDomainModelBuilder)
    {
        _fluentDomainModelBuilder = fluentDomainModelBuilder;
    }

    public SchemaDescriptor Schema(string physicalName)
    {
        return Schema(physicalName, physicalName);
    }

    public SchemaDescriptor Schema(string physicalName, string logicalName)
    {
        var schema = new SchemaDescriptor(physicalName, logicalName);
        _fluentDomainModelBuilder.Schemas.Add(schema);

        return schema;
    }
}
