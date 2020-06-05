// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using EdFi.Ods.Api.Common.ExternalTasks;
using EdFi.Ods.Common;
using EdFi.Ods.Security.Profiles;

namespace EdFi.Ods.Features.Profiles
{
    public class ProfileNamePublisher : IExternalTask
    {
        private readonly IAdminProfileNamesPublisher _adminProfileNamesPublisher;

        public ProfileNamePublisher(IAdminProfileNamesPublisher adminProfileNamesPublisher)
        {
            _adminProfileNamesPublisher = Preconditions.ThrowIfNull(adminProfileNamesPublisher, nameof(adminProfileNamesPublisher));
        }

        public void Execute()
        {
            _adminProfileNamesPublisher.PublishProfilesAsync();
        }
    }
}
#endif