// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.ScheduledJobs.Configurators;
using EdFi.Ods.Api.ScheduledJobs.Jobs;
using EdFi.Ods.Common.Configuration;
using FakeItEasy;
using NUnit.Framework;
using Quartz;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.ScheduledJobs
{
    [TestFixture]
    public class SchedulerConfiguratorTests
    {
        [Test]
        public void MissingCronExpressionShouldApplyDefaultCronExpression()
        {
            ScheduledJobSetting scheduledJobSetting = new ScheduledJobSetting();
            var configurator = new DeleteExpiredTokensSchedulerConfigurator();

            var expectedResult = SchedulerConfiguratorBase<DeleteExpiredTokensScheduledJob>.DefaultCronExpression;
            var actualResult = configurator.GetCronExpression(scheduledJobSetting);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void EmptyCronExpressionShouldApplyDefaultCronExpression()
        {
            ScheduledJobSetting scheduledJobSetting = new ScheduledJobSetting() {CronExpression = ""};

            var configurator = new DeleteExpiredTokensSchedulerConfigurator();

            var expectedResult = SchedulerConfiguratorBase<DeleteExpiredTokensScheduledJob>.DefaultCronExpression;
            var actualResult = configurator.GetCronExpression(scheduledJobSetting);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void InvalidCronExpressionShouldApplyDefaultCronExpression()
        {
            ScheduledJobSetting scheduledJobSetting = new ScheduledJobSetting() {CronExpression = "INVALID_CRON_SCHEDULE"};

            var configurator = new DeleteExpiredTokensSchedulerConfigurator();

            var expectedResult = SchedulerConfiguratorBase<DeleteExpiredTokensScheduledJob>.DefaultCronExpression;
            var actualResult = configurator.GetCronExpression(scheduledJobSetting);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ValidCronExpressionShouldApplyProvidedCronExpression()
        {
            string validCronSchedule = "0 0/20 * 1/1 * ? *";
            ScheduledJobSetting scheduledJobSetting = new ScheduledJobSetting() {CronExpression = validCronSchedule};

            var configurator = new DeleteExpiredTokensSchedulerConfigurator();

            var expectedResult = validCronSchedule;
            var actualResult = configurator.GetCronExpression(scheduledJobSetting);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task AddSchedulerJobShouldCallScheduleJobOnScheduler()
        {
            IScheduler scheduler = A.Fake<IScheduler>();
            CancellationToken cancellationToken = default(CancellationToken);

            string validCronSchedule = "0 0/20 * 1/1 * ? *";
            ScheduledJobSetting scheduledJobSetting = new ScheduledJobSetting() {CronExpression = validCronSchedule};

            var configurator = new DeleteExpiredTokensSchedulerConfigurator();
            IJobDetail jobDetail = configurator.BuildJobDetail(scheduledJobSetting);
            ITrigger trigger = configurator.BuildTrigger(scheduledJobSetting);

            await configurator.AddScheduledJob(scheduler, scheduledJobSetting, cancellationToken);

            A.CallTo(
                () => scheduler.ScheduleJob(jobDetail, trigger, cancellationToken)).MustHaveHappened();
        }
    }
}
