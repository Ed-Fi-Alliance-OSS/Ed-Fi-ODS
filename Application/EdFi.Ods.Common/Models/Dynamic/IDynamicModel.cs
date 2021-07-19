using System.Collections.Generic;

namespace EdFi.Ods.Common.Models.Dynamic
{
    public interface IDynamicModel
    {
        IDictionary<string, object> DynamicProperties { get; }
    }
}