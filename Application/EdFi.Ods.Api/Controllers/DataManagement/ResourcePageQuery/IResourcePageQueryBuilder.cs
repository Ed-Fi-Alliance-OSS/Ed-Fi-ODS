using Dapper;
using EdFi.Ods.Common.Models.Domain;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Controllers.DataManagement.ResourcePageQuery
{
    public interface IResourcePageQueryBuilder
    {
        SqlBuilder BuildQuery(Entity entity, IQueryCollection query);
        
        void ApplyParameters(DynamicParameters parameters, IQueryCollection query);
    }
}