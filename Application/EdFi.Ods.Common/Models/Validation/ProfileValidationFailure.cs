// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models.Validation;

/// <summary>
/// Contains information about a Profiles validation failure.
/// </summary>
/// <param name="Severity">One of the values of the <see cref="ProfileValidationSeverity" /> enumeration, indicating the severity of failure.</param>
/// <param name="ProfileName">The name of the Profile that is the subject of the validation failure.</param>
/// <param name="ResourceName">The name of the Resource within the Profile definition that is the subject of the validation failure.</param>
/// <param name="ResourceClassName">The name of the Resource class (which may be resource or one of its children), that is the subject of the validation failure.</param>
/// <param name="MemberNames">The names of the members that are part of the validation failure.</param>
/// <param name="Message">The description of the validation failure.</param>
public record struct ProfileValidationFailure(
    ProfileValidationSeverity Severity,
    string ProfileName,
    FullName ResourceName,
    FullName ResourceClassName,
    string[] MemberNames,
    string Message)
{
    public readonly bool Equals(ProfileValidationFailure other)
        => Severity == other.Severity
            && ProfileName == other.ProfileName
            && ResourceName.Equals(other.ResourceName)
            && ResourceClassName.Equals(other.ResourceClassName)
            && (MemberNames.Length == other.MemberNames.Length && !MemberNames.Where((m, i) => other.MemberNames[i] != m).Any())
            && Message == other.Message;

    public override readonly int GetHashCode()
        => HashCode.Combine(
            (int)Severity,
            ProfileName,
            ResourceName,
            ResourceClassName,
            string.Join('|', MemberNames),
            Message);
}
