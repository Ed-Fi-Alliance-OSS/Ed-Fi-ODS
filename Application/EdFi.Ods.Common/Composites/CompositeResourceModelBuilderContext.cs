﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Common.Composites
{
    public class CompositeResourceModelBuilderContext
    {
        public Resource RootResource { get; set; }

        public ResourceClassBase ParentResource { get; set; }

        public ResourceClassBase CurrentResource { get; set; }
    }
}
