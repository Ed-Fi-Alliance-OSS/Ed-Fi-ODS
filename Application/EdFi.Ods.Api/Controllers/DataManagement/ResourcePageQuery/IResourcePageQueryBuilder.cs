using Dapper;
using EdFi.Ods.Common.Models.Domain;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Controllers.DataManagement.ResourcePageQuery
{
    public interface IResourcePageQueryBuilder
    {
        SqlBuilder BuildQuery(Entity entity, IQueryCollection query);
        
        // TODO: Simple API - Consider the possibility of just merging this method into the BuildQuery (they are called in immediate succession)
        // TODO: Simple API - Consider passing the pertinent part of the request's context (API Resource and action) information through from the controller instead of using the AuthorizationContextProvider.
        void ApplyParameters(DynamicParameters parameters, IQueryCollection query);
    }
}