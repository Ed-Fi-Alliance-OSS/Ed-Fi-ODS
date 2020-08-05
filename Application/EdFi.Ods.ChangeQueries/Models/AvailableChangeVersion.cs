// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Runtime.Serialization;

namespace EdFi.Ods.ChangeQueries.Models
{
    /// <summary>
    /// Contains the earliest (oldest) and most recent (newest) change versions available.
    /// </summary>
    public class AvailableChangeVersion
    {
        /// <summary>
        /// Gets or sets the earliest (oldest) change version that is available, or 0 if no version is available.
        /// </summary>
        [DataMember(Name = "oldestChangeVersion")]
        public long OldestChangeVersion { get; set; }

        /// <summary>
        /// Gets or sets the most recent (newest) change version that is available, or 0 if no version is available.
        /// </summary>
        [DataMember(Name = "newestChangeVersion")]
        public long NewestChangeVersion { get; set; }
    }
}
