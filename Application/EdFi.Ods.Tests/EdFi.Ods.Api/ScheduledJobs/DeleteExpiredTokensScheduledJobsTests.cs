﻿using System;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Authentication;
using EdFi.Ods.Api.ScheduledJobs.Jobs;
using FakeItEasy;
using NUnit.Framework;
using Quartz;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.ScheduledJobs
{
    [TestFixture]
    public class DeleteExpiredTokensScheduledJobsTests
    {
        [Test]
        public void Should_throw_exception_when_dependency_is_missing()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var result = new DeleteExpiredTokensScheduledJob(null);
            });
        }

        [Test]
        public async Task Should_call_delete_expired_tokens_async_once()
        {
            var expiredAccessTokenDeleter = A.Fake<IExpiredAccessTokenDeleter>();
            var jobExecutionContext = A.Fake<IJobExecutionContext>();

            DeleteExpiredTokensScheduledJob job = new DeleteExpiredTokensScheduledJob(expiredAccessTokenDeleter);
            await job.Execute(jobExecutionContext);

            A.CallTo(() => expiredAccessTokenDeleter.DeleteExpiredTokensAsync())
                .MustHaveHappenedOnceExactly();
        }
    }
}
