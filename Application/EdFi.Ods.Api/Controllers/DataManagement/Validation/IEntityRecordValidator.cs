// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.Validation
{
    public interface IEntityRecordValidator
    {
        FullName SupportedEntityName { get; }
            
        void Validate(Entity entity, IDictionary<string, object> proposedValues, IList<string> validationMessages);
    }
}
