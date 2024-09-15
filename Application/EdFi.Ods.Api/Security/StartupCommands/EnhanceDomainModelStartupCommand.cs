using EdFi.Ods.Api.Startup;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain.DomainModelEnhancers;

namespace EdFi.Ods.Api.Security.StartupCommands;

public class EnhanceDomainModelStartupCommand : IStartupCommand
{
    private readonly IDomainModelEnhancer[] _domainModelEnhancers;
    private readonly IDomainModelProvider _domainModelProvider;

    public EnhanceDomainModelStartupCommand(IDomainModelEnhancer[] domainModelEnhancers, IDomainModelProvider domainModelProvider)
    {
        _domainModelEnhancers = domainModelEnhancers;
        _domainModelProvider = domainModelProvider;
    }
    
    public void Execute()
    {
        var domainModel = _domainModelProvider.GetDomainModel();
        
        foreach (var domainModelEnhancer in _domainModelEnhancers)
        {
            domainModelEnhancer.Enhance(domainModel);
        }
    }
}