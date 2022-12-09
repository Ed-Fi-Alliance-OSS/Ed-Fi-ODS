using System.Collections.Generic;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models.Validation;

/// <summary>
/// Defines methods for report validation errors on Profile definitions.
/// </summary>
public interface IProfileValidationReporter
{
    /// <summary>
    /// Reports a validation failure for a Profile definition.
    /// </summary>
    /// <param name="severity">One of the values of the <see cref="ProfileValidationSeverity" /> enumeration, indicating the severity of failure.</param>
    /// <param name="profileName">The name of the Profile that is the subject of the validation failure.</param>
    /// <param name="resourceName">The name of the Resource within the Profile definition that is the subject of the validation failure.</param>
    /// <param name="resourceClassName">The name of the Resource class (which may be resource or one of its children), that is the subject of the validation failure.</param>
    /// <param name="memberNames">The names of the members that are part of the validation failure.</param>
    /// <param name="message">The description of the validation failure.</param>
    void ReportValidationFailure(
        ProfileValidationSeverity severity,
        string profileName,
        FullName resourceName,
        FullName resourceClassName,
        string[] memberNames,
        string message);
        
    /// <summary>
    /// Gets a collection of the validation failures that have been reported.
    /// </summary>
    IReadOnlyList<ProfileValidationFailure> ValidationFailures { get; }
}
