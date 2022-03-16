using System;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Repositories;
using Quartz;

namespace EdFi.Ods.Api.ScheduledJobs.Jobs
{
    public class DeleteExpiredTokensScheduledJob : IJob
    {
        private readonly IAccessTokenClientRepo _accessTokenClientRepo;
        public DeleteExpiredTokensScheduledJob(IAccessTokenClientRepo accessTokenClientRepo)
        {
            _accessTokenClientRepo = accessTokenClientRepo ?? throw new ArgumentNullException(nameof(accessTokenClientRepo));
        }

        public Task Execute(IJobExecutionContext context) =>
            _accessTokenClientRepo.DeleteExpiredTokensAsync();
    }
}