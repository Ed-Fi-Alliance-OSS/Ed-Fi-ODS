#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
namespace EdFi.Ods.Common.Services
{
    public interface IHostedService
    {
        /// <summary>
        /// Provides the description to be displayed in Windows Services Console or other management programs
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Provides the name to be displayed in Windows Services Console or other management programs
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Provides the name to be shown in the Windows Services Console as the Service Name - may be the same or different from display name
        /// </summary>
        string ServiceName { get; }

        void Start();

        void Stop();
    }
}
#endif