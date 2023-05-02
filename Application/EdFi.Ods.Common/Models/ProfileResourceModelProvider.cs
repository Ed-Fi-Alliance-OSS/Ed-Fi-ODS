// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata.Profiles;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Models.Validation;
using EdFi.Ods.Common.Profiles;
using log4net;
using MediatR;

namespace EdFi.Ods.Common.Models;

public class ProfileResourceModelProvider : IProfileResourceModelProvider
{
    private readonly IProfileMetadataProvider _profileMetadataProvider;
    private readonly IProfileValidationReporter _profileValidationReporter;

    private readonly Lazy<ResourceModel> _resourceModel;

    private readonly ILog _logger = LogManager.GetLogger(typeof(ProfileResourceModelProvider));
    
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
        return new ProfileResourceModel(
            _resourceModel.Value,
            _profileMetadataProvider.ProfileDefinitionsByName.GetValueOrThrow(profileName, "Unable to find profile '{0}'."),
            _profileValidationReporter);
    }
}
