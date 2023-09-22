// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EdFi.Ods.Api.Models
{
    [Serializable]
    [DataContract]
    public class RESTError
    {
        [DataMember(Name = "code")]
        public int? Code { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "correlationId")]
        public string CorrelationId { get; set; }

        // See ErrorTranslator.GetErrorMessage
        public Dictionary<string, string[]> ModelState { get; set; }
    }
}
