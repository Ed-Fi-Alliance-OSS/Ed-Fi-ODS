// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using EdFi.Ods.Common;

namespace EdFi.Ods.Features.ChangeQueries.Resources
{
    [DataContract]
    public class DeletedResourceItem
    {
        [DataMember(Name="id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }

        [DataMember(Name="changeVersion")]
        public long ChangeVersion { get; set; }

        [DataMember(Name="keyValues")]
        public IDictionary<string, object> KeyValues { get; set; }
    }}
