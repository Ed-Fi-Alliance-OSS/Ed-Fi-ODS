using Dapper;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Strategies.RelationshipBased
{
    // TODO: API Simplification - Need better name to distinguish from IRelationshipBasedAuthorizationViewJoinApplicator
    public interface IRelationshipBasedAuthorizationFilterHandler
    {
        bool CanHandle(string authorizationStrategyName);
        
        void ApplyAuthorizationFilter(SqlBuilder sqlBuilder, Entity entity);
    }
}