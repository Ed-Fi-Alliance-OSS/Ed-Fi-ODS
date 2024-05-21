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
    public const string TypePart = "profile:invalid-profile-usage";
    public const string TitleText = "Invalid Profile Usage";

    private const int StatusValue = StatusCodes.Status400BadRequest;

    public const string DefaultDetail = "The request construction was invalid with respect to usage of a data policy.";

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

    public string ProfileName { get; }

    public ContentTypeUsage ContentTypeUsage { get; }
    
    // ---------------------------
    //  Boilerplate for overrides
    // ---------------------------
    public override string Title { get => TitleText; }

    public override int Status { get => StatusValue; }

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
