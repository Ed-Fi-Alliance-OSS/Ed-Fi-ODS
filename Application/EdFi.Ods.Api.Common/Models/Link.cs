// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Runtime.Serialization;

namespace EdFi.Ods.Api.Common.Models
{
    /// <summary>
    /// Contains hyperlink details for a related resource.
    /// </summary>
    [DataContract]
    public class Link
    {
        /// <summary>
        /// Gets or sets the description of the relationship of the link to the containing resource.
        /// </summary>
        [DataMember(Name = "rel")]
        public string Rel { get; set; }

        /// <summary>
        /// Gets or sets the hyperlink to the related resource.
        /// </summary>
        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}
