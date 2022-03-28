using System;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.Common;
using log4net;
using Quartz;

namespace EdFi.Ods.Api.ScheduledJobs.Jobs
{
    public class DeleteExpiredTokensScheduledJob : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(DeleteExpiredTokensScheduledJob));
        private readonly IAccessTokenClientRepo _accessTokenClientRepo;

        public DeleteExpiredTokensScheduledJob(IAccessTokenClientRepo accessTokenClientRepo)
        {
            _accessTokenClientRepo = Preconditions.ThrowIfNull(accessTokenClientRepo, nameof(accessTokenClientRepo));
        }

        public async Task Execute(IJobExecutionContext context) 
        {
            try
            {
                await _accessTokenClientRepo.DeleteExpiredTokensAsync();
                _logger.Debug("Expired client access tokens have been deleted");

            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
        }    
    }
}