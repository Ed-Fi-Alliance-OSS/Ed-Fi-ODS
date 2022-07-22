using System;
using System.Collections.Generic;

namespace Test.Common.ModelBuilders;

public class SchemaDescriptor
{
    protected internal readonly string PhysicalName;
    protected internal readonly string LogicalName;

    public SchemaDescriptor(string physicalName, string logicalName)
    {
        PhysicalName = physicalName;
        LogicalName = logicalName;
    }
        
    protected internal List<AggregateRootDescriptor> AggregateRoots = new();

    public SchemaDescriptor WithAggregates(Action<AggregateCollectionDescriptor> d)
    {
        d(new AggregateCollectionDescriptor(this));

        return this;
    }
}