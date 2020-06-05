// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Text;

namespace EdFi.Ods.Api.Common.IdentityValueMappers
{
    public class ByteStringIdValueMapper : IUniqueIdToIdValueMapper
    {
        public PersonIdentifiersValueMap GetId(string personType, string uniqueId)
        {
            var byteArray = Encoding.ASCII.GetBytes(uniqueId);
            Array.Resize(ref byteArray, 16);

            return new PersonIdentifiersValueMap
                   {
                       Id = new Guid(byteArray), UniqueId = uniqueId
                   };
        }

        public PersonIdentifiersValueMap GetUniqueId(string personType, Guid id)
        {
            return new PersonIdentifiersValueMap
                   {
                       Id = id, UniqueId = Encoding.ASCII.GetString(id.ToByteArray()).TrimEnd(new[] {'\0'})
                   };
        }
    }
}
