using System;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Authentication;
using EdFi.Common;
using log4net;
using Quartz;

namespace EdFi.Ods.Api.ScheduledJobs.Jobs
{
    public class DeleteExpiredTokensScheduledJob : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(DeleteExpiredTokensScheduledJob));
        private readonly IExpiredAccessTokenDeleter _expiredAccessTokenDeleter;

        public DeleteExpiredTokensScheduledJob(IExpiredAccessTokenDeleter expiredAccessTokenDeleter)
        {
            _expiredAccessTokenDeleter = Preconditions.ThrowIfNull(expiredAccessTokenDeleter, nameof(expiredAccessTokenDeleter));
        }

        public async Task Execute(IJobExecutionContext context) 
        {
            try
            {
                _logger.Debug("Removing expired client access tokens...");
                
                await _expiredAccessTokenDeleter.DeleteExpiredTokensAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }    
    }
}