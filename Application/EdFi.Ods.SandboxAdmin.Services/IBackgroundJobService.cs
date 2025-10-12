namespace EdFi.Ods.Sandbox.Admin.Services
{
    public interface IBackgroundJobService
    {
        void Configure(bool exitAfterSandboxCreation = false);
    }
}
