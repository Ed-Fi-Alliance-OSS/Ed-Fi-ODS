namespace EdFi.Ods.Common.Security.Claims;

/// <summary>
/// Provides the security metadata for a single resource claim and its actions.
/// </summary>
/// <param name="ClaimName"></param>
/// <param name="Actions">The actions that can be performed by the claim on the resource.</param>
public record ClaimSetResourceClaimMetadata(string ClaimName, ResourceAction[] Actions);
