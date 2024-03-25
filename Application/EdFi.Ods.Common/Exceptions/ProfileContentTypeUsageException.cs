// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Utils.Profiles;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Common.Exceptions;

public class ProfileContentTypeUsageException : EdFiProblemDetailsExceptionBase
{
    // Fields containing override values for Problem Details
    public const string TypePart = "profile:invalid-content-type";
    public const string TitleText = "Invalid Profile Usage";
    private const int StatusValue = StatusCodes.Status400BadRequest;

    public const string DefaultDetail = "Usage of the API Profiles feature was incorrect.";

    private int? _statusOverride;

    public ProfileContentTypeUsageException(string detail, string error, string profileName, ContentTypeUsage contentTypeUsage)
        : base(detail, error)
    {
        ProfileName = profileName;
        ContentTypeUsage = contentTypeUsage;

        if (error != null)
        {
            this.SetErrors(error);
        }
    }

    public ProfileContentTypeUsageException(int status, string detail, string error, string profileName, ContentTypeUsage contentTypeUsage)
        : this(detail,  error, profileName,  contentTypeUsage)
    {
        _statusOverride = status;
    }

    public string ProfileName { get; }

    public ContentTypeUsage ContentTypeUsage { get; }
    
    // ---------------------------
    //  Boilerplate for overrides
    // ---------------------------
    public override string Title { get => TitleText; }

    public override int Status { get => _statusOverride ?? StatusValue; }
    
    protected override IEnumerable<string> GetTypeParts()
    {
        foreach (var part in base.GetTypeParts())
        {
            yield return part;
        }

        yield return TypePart;
    }
    // ---------------------------
}
