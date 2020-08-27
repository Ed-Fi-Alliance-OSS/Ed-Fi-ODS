// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;

namespace EdFi.Ods.Common
{
    /// <summary>
    /// Defines a property for accessing named extensions to an Ed-Fi Standard resource or entity.
    /// </summary>
    public interface IHasExtensions
    {
        /// <summary>
        /// Gets or sets the named entity extensions to the containing Ed-Fi Standard resource or entity.
        /// </summary>
        IDictionary Extensions { get; set; }
    }
}
