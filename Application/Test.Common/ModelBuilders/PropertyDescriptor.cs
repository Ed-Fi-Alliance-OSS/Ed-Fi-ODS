using System.Data;
using EdFi.Ods.Common.Models.Domain;

namespace Test.Common.ModelBuilders;

public class PropertyDescriptor
{
    private readonly PropertyCollectionDescriptor _propertyCollectionDescriptor;

    protected internal readonly string PropertyName;
    protected internal PropertyType PropertyType;
    protected internal bool IsIdentifying;
    protected internal bool IsServerAssigned;

    protected internal PropertyDescriptor(PropertyCollectionDescriptor propertyCollectionDescriptor, string name)
    {
        _propertyCollectionDescriptor = propertyCollectionDescriptor;
        PropertyName = name;
            
        // By default, it's a string
        AsString();
    }

    public PropertyDescriptor Identifying()
    {
        IsIdentifying = true;

        return this;
    }
        
    public PropertyDescriptor ServerAssigned()
    {
        IsServerAssigned = true;

        return this;
    }
        
    public PropertyCollectionDescriptor AsString(int length = 20, bool isNullable = false)
    {
        PropertyType = new PropertyType(DbType.String, length, isNullable: isNullable);
            
        return _propertyCollectionDescriptor;
    }

    public PropertyCollectionDescriptor AsInteger(bool isNullable = false)
    {
        PropertyType = new PropertyType(DbType.Int32, isNullable: isNullable);
            
        return _propertyCollectionDescriptor;
    }
        
    public PropertyCollectionDescriptor AsDecimal(int precision, int scale, bool isNullable = false)
    {
        PropertyType = new PropertyType(DbType.Decimal, precision: precision, scale: scale, isNullable: isNullable);
            
        return _propertyCollectionDescriptor;
    }
}