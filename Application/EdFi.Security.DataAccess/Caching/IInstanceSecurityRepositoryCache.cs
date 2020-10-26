namespace EdFi.Security.DataAccess.Caching
{
    public interface IInstanceSecurityRepositoryCache
    {
        InstanceSecurityRepositoryCacheObject GetSecurityRepository(string instanceId);
    }
}