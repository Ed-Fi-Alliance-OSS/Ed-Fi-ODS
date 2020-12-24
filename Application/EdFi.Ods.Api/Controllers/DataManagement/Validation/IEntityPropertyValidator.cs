using System.Collections.Generic;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.Validation
{
    public interface IEntityPropertyValidator
    {
        void Validate(EntityProperty property, object proposedValueAsObject, string resourcePropertyName, IList<string> validationMessages);
    }
}