// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections;

namespace EdFi.Ods.Api.NHibernate.Composites
{
    /// <summary>
    /// Defines a property for determining whether the enumeration of an enumerator has completed.
    /// </summary>
    public interface IEnumeratorWithCompletion : IEnumerator
    {
        /// <summary>
        /// Indicates whether enumeration of the enumerator has completed.
        /// </summary>
        bool IsComplete { get; }
    }
}
