// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using MessagePack;
using System.Runtime.Serialization;

namespace EdFi.Ods.Api.Models
{
    /// <summary>
    /// Contains hyperlink details for a related resource.
    /// </summary>
    [DataContract]
    [MessagePackObject]
    public class Link
    {
        /// <summary>
        /// Gets or sets the description of the relationship of the link to the containing resource.
        /// </summary>
        [Key(0)]
        [DataMember(Name = "rel")]
        public string Rel { get; set; }

        /// <summary>
        /// Gets or sets the hyperlink to the related resource.
        /// </summary>
        [Key(1)]
        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}
