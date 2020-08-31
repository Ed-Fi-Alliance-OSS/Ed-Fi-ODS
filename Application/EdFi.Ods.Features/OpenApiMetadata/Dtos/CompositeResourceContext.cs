// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Xml.Linq;

namespace EdFi.Ods.Features.OpenApiMetadata.Dtos
{
    public class CompositeResourceContext
    {
        public string OrganizationCode { get; set; }

        public string BaseResource { get; set; }

        public XElement Specification { get; set; }
    }
}
