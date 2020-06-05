// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Runtime.Serialization;

namespace EdFi.Ods.Api.Common.Models
{
    public class DeletedResource
    {
        [DataMember(Name="id")]
        public Guid Id { get; set; }

        [DataMember(Name="changeVersion")]
        public long ChangeVersion { get; set; }
    }
}
