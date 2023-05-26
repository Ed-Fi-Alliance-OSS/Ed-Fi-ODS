using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Configuration.Sections;
using EdFi.Ods.Common.Context;
using Microsoft.Extensions.Options;

namespace EdFi.Ods.Features.MultiTenancy;

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