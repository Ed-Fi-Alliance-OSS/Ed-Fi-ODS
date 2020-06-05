// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Common.IdentityValueMappers;

namespace EdFi.Ods.Features.UniqueIdIntegration.IdentityValueMappers
{
    /// <summary>
    /// Sample value mapper that is used for testing.
    /// </summary>
    public class ParsedGuidUniqueIdToIdValueMapper : IUniqueIdToIdValueMapper
    {
        public PersonIdentifiersValueMap GetId(string personType, string uniqueId)
        {
            return new PersonIdentifiersValueMap
                   {
                       Id = Guid.Parse(uniqueId), UniqueId = uniqueId
                   };
        }

        public PersonIdentifiersValueMap GetUniqueId(string personType, Guid id)
        {
            return new PersonIdentifiersValueMap
                   {
                       Id = id, UniqueId = id.ToString("N")
                   };
        }
    }
}
