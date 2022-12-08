// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Metadata.Profiles;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Models.Validation;

namespace EdFi.Ods.Common.Models;

public class ProfileResourceModelProvider : IProfileResourceModelProvider
{
    private readonly ConcurrentDictionary<string, ProfileResourceModel> _modelByProfileName =
        new(StringComparer.InvariantCultureIgnoreCase);

    private readonly IProfileMetadataProvider _profileMetadataProvider;
    private readonly IProfileValidationReporter _profileValidationReporter;

    private readonly Lazy<ResourceModel> _resourceModel;

    public ProfileResourceModelProvider(
        IResourceModelProvider resourceModelProvider,
        IProfileMetadataProvider profileMetadataProvider,
        IProfileValidationReporter profileValidationReporter)
    {
        _profileMetadataProvider = profileMetadataProvider;
        _profileValidationReporter = profileValidationReporter;

        _resourceModel = new Lazy<ResourceModel>(resourceModelProvider.GetResourceModel);
    }

    public ProfileResourceModel GetProfileResourceModel(string profileName)
    {
        return _modelByProfileName.GetOrAdd(
            profileName,
            pn =>
                new ProfileResourceModel(
                    _resourceModel.Value,
                    _profileMetadataProvider.GetProfileDefinition(profileName),
                    _profileValidationReporter));
    }
}
