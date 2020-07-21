// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Admin.Initialization
{
    public class InitializationModel
    {
        /// <summary>
        /// true to perform any automatic population of users and sandboxes
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// CRON expression for when to refresh the databases <see cref="https://en.wikipedia.org/wiki/Cron#CRON_expression"/>
        /// </summary>
        /// <example>"0 8 * * *" is every day at 8am</example>
        public string Recurrence { get; set; }

        public IEnumerable<UserInitializationModel> Users { get; set; }
    }
}
