using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Configuration.Sections;
using EdFi.Ods.Common.Context;
using Microsoft.Extensions.Options;

namespace EdFi.Ods.Features.MultiTenancy;

/// <summary>
/// Implements a multi-tenant connection string override applicator that applies the latest connection strings defined in the
/// "Tenants" configuration section for the tenant currently in context.
/// </summary>
public class MultiTenantConnectionStringOverridesApplicator : IConnectionStringOverridesApplicator
{
    private readonly IOptionsMonitor<TenantsSection> _tenantsConfigurationOptions;
    private readonly IContextProvider<TenantConfiguration> _tenantConfigurationContextProvider;

    public MultiTenantConnectionStringOverridesApplicator(
        IOptionsMonitor<TenantsSection> tenantsConfigurationOptions,
        IContextProvider<TenantConfiguration> tenantConfigurationContextProvider)
    {
        _tenantsConfigurationOptions = tenantsConfigurationOptions;
        _tenantConfigurationContextProvider = tenantConfigurationContextProvider;
    }

    /// <inheritdoc cref="IConnectionStringOverridesApplicator.ApplyOverrides" />
    public void ApplyOverrides(OdsInstanceConfiguration odsInstanceConfiguration)
    {
        // Apply configuration data-based overrides
        var currentTenantConfiguration = _tenantConfigurationContextProvider.Get();

        if (currentTenantConfiguration == null)
        {
            return;
        }

        if (_tenantsConfigurationOptions.CurrentValue.Tenants.TryGetValue(
                currentTenantConfiguration.TenantIdentifier,
                out var tenant))
        {
            var odsInstances = tenant.OdsInstances;
            odsInstanceConfiguration.ApplyOdsConnectionStringOverrides(odsInstances);
        }
    }
}