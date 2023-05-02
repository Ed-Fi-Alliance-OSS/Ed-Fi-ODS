using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Authentication;
using EdFi.Ods.Api.Jobs;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Context;
using FakeItEasy;
using NUnit.Framework;
using Quartz;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.ScheduledJobs
{
    [TestFixture]
    public class DeleteExpiredTokensJobTests
    {
        private IExpiredAccessTokenDeleter _expiredAccessTokenDeleter;
        private IApiJobScheduler _apiJobScheduler;
        private ITenantConfigurationProvider _tenantConfigurationProvider;
        private IContextProvider<TenantConfiguration> _tenantConfigurationContextProvider;

        [SetUp]
        public void SetUp()
        {
            _expiredAccessTokenDeleter = A.Fake<IExpiredAccessTokenDeleter>();
            _apiJobScheduler = A.Fake<IApiJobScheduler>();
            _tenantConfigurationProvider = A.Fake<ITenantConfigurationProvider>();
            _tenantConfigurationContextProvider = A.Fake<IContextProvider<TenantConfiguration>>();
        }

        [Test]
        public async Task When_invoked_with_TenantConfiguration_in_job_execution_context_sets_to_current_context_and_deletes_expired_access_tokens_()
        {
            // Arrange
            IJob job = new DeleteExpiredTokensJob(
                _expiredAccessTokenDeleter,
                _apiJobScheduler,
                _tenantConfigurationContextProvider)
            {
                TenantConfigurationProvider = _tenantConfigurationProvider
            };

            var suppliedTenantConfiguration = new TenantConfiguration() { TenantIdentifier = "TestTenant"};

            IDictionary<string, object> suppliedJobData = new Dictionary<string, object>
            {
                { nameof(TenantConfiguration), suppliedTenantConfiguration }
            };

            var jobDetail = A.Fake<IJobDetail>();
            A.CallTo(() => jobDetail.JobDataMap)
                .Returns(new JobDataMap(suppliedJobData));
            
            var jobExecutionContext = A.Fake<IJobExecutionContext>();
            A.CallTo(() => jobExecutionContext.JobDetail).Returns(jobDetail);

            // Act
            await job.Execute(jobExecutionContext);

            // Assert
            A.CallTo(() => _tenantConfigurationContextProvider.Set(suppliedTenantConfiguration))
                .MustHaveHappenedOnceExactly();
            
            A.CallTo(() => _expiredAccessTokenDeleter.DeleteExpiredTokensAsync())
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task When_invoked_without_TenantConfiguration_in_job_execution_context_schedules_single_execution_jobs_for_each_tenant_with_TenantConfiguration_in_job_data_map()
        {
            // Arrange
            IJob job = new DeleteExpiredTokensJob(
                _expiredAccessTokenDeleter,
                _apiJobScheduler,
                _tenantConfigurationContextProvider)
            {
                TenantConfigurationProvider = _tenantConfigurationProvider
            };
            
            var jobDetail = A.Fake<IJobDetail>();
            A.CallTo(() => jobDetail.JobDataMap).Returns(new JobDataMap());
            A.CallTo(() => jobDetail.Key).Returns(new JobKey("TestJob"));

            var trigger = A.Fake<ITrigger>();
            A.CallTo(() => trigger.Key).Returns(new TriggerKey("TestTrigger"));

            var jobExecutionContext = A.Fake<IJobExecutionContext>();
            A.CallTo(() => jobExecutionContext.JobDetail).Returns(jobDetail);
            A.CallTo(() => jobExecutionContext.Trigger).Returns(trigger);

            var suppliedTenantConfigurations = new List<TenantConfiguration>()
            {
                new() { TenantIdentifier = "TenantOne" },
                new() { TenantIdentifier = "TenantTwo" },
            };

            A.CallTo(() => _tenantConfigurationProvider.GetAllConfigurations())
                .Returns(suppliedTenantConfigurations);
            
            // Act
            await job.Execute(jobExecutionContext);

            // Assert
            A.CallTo(() => _tenantConfigurationContextProvider.Set(A<TenantConfiguration>.Ignored))
                .MustNotHaveHappened();
            
            A.CallTo(() => _expiredAccessTokenDeleter.DeleteExpiredTokensAsync())
                .MustNotHaveHappened();

            A.CallTo(
                    () => _apiJobScheduler.AddSingleExecutionJob(
                        typeof(DeleteExpiredTokensJob),
                        "TestJob-TenantOne",
                        "TestTrigger-TenantOne",
                        A<JobDataMap>.That.Matches(
                            jdm => jdm.ContainsKey(nameof(TenantConfiguration))
                                && jdm[nameof(TenantConfiguration)] == suppliedTenantConfigurations[0])))
                .MustHaveHappenedOnceExactly();

            A.CallTo(
                    () => _apiJobScheduler.AddSingleExecutionJob(
                        typeof(DeleteExpiredTokensJob),
                        "TestJob-TenantTwo",
                        "TestTrigger-TenantTwo",
                        A<JobDataMap>.That.Matches(
                            jdm => jdm.ContainsKey(nameof(TenantConfiguration))
                                && jdm[nameof(TenantConfiguration)] == suppliedTenantConfigurations[1])))
                .MustHaveHappenedOnceExactly();
        }
    }
}
