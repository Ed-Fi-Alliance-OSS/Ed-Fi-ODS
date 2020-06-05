// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Common.Models.Requests
{
    /// <summary>
    /// Provides and abstract base class for concrete "Null" request objects that are generated for
    /// readable-only or writable-only resources in a Profile definition.  The concrete versions for
    /// writable-only should apply an attribute.
    /// </summary>
    public abstract class NullRequestBase : IHasIdentifier, IHasETag
    {
        public string ETag { get; set; }

        public Guid Id { get; set; }
    }
}
