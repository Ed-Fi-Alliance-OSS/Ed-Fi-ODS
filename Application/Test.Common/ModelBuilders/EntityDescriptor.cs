using System;
using System.Collections.Generic;

namespace Test.Common.ModelBuilders;

public class EntityDescriptor
{
    protected internal readonly string Schema;
    protected internal readonly string Name;
    protected internal List<PropertyDescriptor> Properties = new();

    protected internal EntityDescriptor(string schema, string name)
    {
        Schema = schema;
        Name = name;
    }

    public EntityDescriptor WithProperties(Action<PropertyCollectionDescriptor> d)
    {
        d(new PropertyCollectionDescriptor(this));

        return this;
    }
}