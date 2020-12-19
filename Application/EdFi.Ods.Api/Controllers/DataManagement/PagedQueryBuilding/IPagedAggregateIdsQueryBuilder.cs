using Dapper;
using EdFi.Ods.Common.Models.Domain;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Controllers.DataManagement.PagedQueryBuilding
{
    public interface IPagedAggregateIdsQueryBuilder
    {
        SqlBuilder BuildQuery(Entity entity, IQueryCollection queryCollection);
        
        void ApplyParameters(DynamicParameters parameters, IQueryCollection queryCollection);
    }
}