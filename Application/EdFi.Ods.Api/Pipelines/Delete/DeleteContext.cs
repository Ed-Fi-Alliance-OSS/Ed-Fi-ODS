﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using EdFi.Ods.Common;

namespace EdFi.Ods.Pipelines.Delete
{
    public class DeleteContext : IHasIdentifier
    {
        public DeleteContext(Guid identifier)
        {
            Id = identifier;
        }

        public DeleteContext(Guid identifier, string etagValue)
        {
            Id = identifier;

            if (!string.IsNullOrWhiteSpace(etagValue))
            {
                ETag = etagValue;
            }
        }

        public string ETag { get; set; }

        public Guid Id { get; set; }
    }
}
