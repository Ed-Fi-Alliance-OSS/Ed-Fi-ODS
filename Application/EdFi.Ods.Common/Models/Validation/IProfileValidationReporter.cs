using System.Collections.Generic;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models.Validation;

public interface IProfileValidationReporter
{
    void ReportValidationFailure(
        ProfileValidationSeverity severity,
        string profileName,
        FullName resourceName,
        FullName resourceClassName,
        string[] memberNames,
        string message);
        
    IReadOnlyList<ProfileValidationFailure> ValidationFailures { get; }
}