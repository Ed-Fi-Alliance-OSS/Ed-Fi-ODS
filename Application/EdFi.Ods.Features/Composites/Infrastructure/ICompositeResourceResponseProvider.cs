// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace EdFi.Ods.Features.Composites.Infrastructure
{
    public interface ICompositeResourceResponseProvider
    {
        object Get(
            XElement compositeDefinition,
            IDictionary<string, CompositeSpecificationParameter> specParameters,
            IDictionary<string, object> queryStringParameters,
            NullValueHandling nullValueHandling = NullValueHandling.Ignore);
    }
}