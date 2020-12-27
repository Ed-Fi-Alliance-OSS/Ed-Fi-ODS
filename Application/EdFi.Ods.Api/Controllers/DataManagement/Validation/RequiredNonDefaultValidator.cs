using System;
using System.Collections.Generic;
using System.Data;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.Validation
{
    public class RequiredNonDefaultValidator : IEntityPropertyValidator
    {
        public void Validate(EntityProperty property, object proposedValueAsObject, string resourcePropertyName, IList<string> validationMessages)
        {
            // Validation only applies to non-nullable values
            if (property.PropertyType.IsNullable)
            {
                return;
            }
            
            if (proposedValueAsObject == null)
            {
                AddRequiredValidationFailure();

                return;
            }

            // Handle descriptors specially since they are handled as strings for validation purposes
            if (property.IsLookup)
            {
                if (string.IsNullOrEmpty((string) proposedValueAsObject))
                {
                    AddRequiredValidationFailure();
                }

                return;
            }
            
            // TODO: API Simplification - Need to handle UniqueId properties that are resource-level expansions from USIs on the entity
            
            // Ensure proposed value is not the default value for the target type
            switch (property.PropertyType.DbType)
            {
                case DbType.Boolean:
                case DbType.Currency:
                case DbType.Decimal:
                case DbType.Double:
                case DbType.Single:
                    // Default values on these types are deemed acceptable
                    return;

                
                case DbType.Int16:
                    if ((short) proposedValueAsObject == default)
                    {
                        AddRequiredValidationFailure();
                    }

                    return;

                case DbType.Int32:
                    if ((int) proposedValueAsObject == default)
                    {
                        AddRequiredValidationFailure();
                    }

                    return;
                
                case DbType.Int64:
                    if ((long) proposedValueAsObject == default)
                    {
                        AddRequiredValidationFailure();
                    }

                    return;

                case DbType.AnsiString:
                case DbType.String:
                case DbType.StringFixedLength:
                case DbType.AnsiStringFixedLength:
                    if (string.IsNullOrEmpty((string) proposedValueAsObject))
                    {
                        AddRequiredValidationFailure();
                    }

                    return;
                
                case DbType.Guid:
                    if ((Guid) proposedValueAsObject == default)
                    {
                        AddRequiredValidationFailure();
                    }

                    return;

                case DbType.Byte:
                    if ((byte) proposedValueAsObject == default)
                    {
                        AddRequiredValidationFailure();
                    }

                    return;
                
                case DbType.Date:
                case DbType.DateTime:
                case DbType.DateTime2:

                    if ((DateTime) proposedValueAsObject == default)
                    {
                        AddRequiredValidationFailure();
                    }

                    return;
            }

            void AddRequiredValidationFailure()
            {
                validationMessages.Add($"{resourcePropertyName} is required.");
            }
        }
    }
}