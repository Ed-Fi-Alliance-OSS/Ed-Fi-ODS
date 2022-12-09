using System.Collections.Generic;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models.Validation;

public class ProfileValidationReporter : IProfileValidationReporter
{
    private readonly List<ProfileValidationFailure> _validationFailures = new();

    /// <inheritdoc cref="IProfileValidationReporter.ReportValidationFailure" />
    public void ReportValidationFailure(
        ProfileValidationSeverity severity,
        string profileName,
        FullName resourceName,
        FullName resourceClassName,
        string[] memberNames,
        string message)
    {
        var profileValidationFailure = new ProfileValidationFailure(severity, profileName, resourceName, resourceClassName, memberNames, message);

        if (!_validationFailures.Contains(profileValidationFailure))
        {
            _validationFailures.Add(profileValidationFailure);
        }
    }

    public IReadOnlyList<ProfileValidationFailure> ValidationFailures
    {
        get => _validationFailures;
    }
}
