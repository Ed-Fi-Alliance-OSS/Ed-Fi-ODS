// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
// using EdFi.Ods.Api.Jobs.Configurators;
using EdFi.Ods.Common.Configuration;
using FakeItEasy;
using NUnit.Framework;
using Quartz;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.ScheduledJobs
{
    // [TestFixture]
    // public class SchedulerConfiguratorTests
    // {
    //     [Test]
    //     public void MissingCronExpressionShouldApplyDefaultCronExpression()
    //     {
    //         ScheduledJobSettings scheduledJobSettings = new ScheduledJobSettings();
    //         var configurator = new DeleteExpiredTokensSchedulerConfigurator();
    //
    //         var expectedResult = ScheduledJobSettings.DefaultCronExpression;
    //         var actualResult = configurator.GetCronExpression(scheduledJobSettings);
    //
    //         Assert.AreEqual(expectedResult, actualResult);
    //     }
    //
    //     [Test]
    //     public void EmptyCronExpressionShouldApplyDefaultCronExpression()
    //     {
    //         ScheduledJobSettings scheduledJobSettings = new ScheduledJobSettings() {CronExpression = ""};
    //
    //         var configurator = new DeleteExpiredTokensSchedulerConfigurator();
    //
    //         var expectedResult = ScheduledJobSettings.DefaultCronExpression;
    //         var actualResult = configurator.GetCronExpression(scheduledJobSettings);
    //
    //         Assert.AreEqual(expectedResult, actualResult);
    //     }
    //
    //     [Test]
    //     public void InvalidCronExpressionShouldApplyDefaultCronExpression()
    //     {
    //         ScheduledJobSettings scheduledJobSettings = new ScheduledJobSettings() {CronExpression = "INVALID_CRON_SCHEDULE"};
    //
    //         var configurator = new DeleteExpiredTokensSchedulerConfigurator();
    //
    //         var expectedResult = ScheduledJobSettings.DefaultCronExpression;
    //         var actualResult = configurator.GetCronExpression(scheduledJobSettings);
    //
    //         Assert.AreEqual(expectedResult, actualResult);
    //     }
    //
    //     [Test]
    //     public void ValidCronExpressionShouldApplyProvidedCronExpression()
    //     {
    //         string validCronSchedule = "0 0/20 * 1/1 * ? *";
    //         ScheduledJobSettings scheduledJobSettings = new ScheduledJobSettings() {CronExpression = validCronSchedule};
    //
    //         var configurator = new DeleteExpiredTokensSchedulerConfigurator();
    //
    //         var expectedResult = validCronSchedule;
    //         var actualResult = configurator.GetCronExpression(scheduledJobSettings);
    //
    //         Assert.AreEqual(expectedResult, actualResult);
    //     }
    //
    //     [Test]
    //     public async Task AddSchedulerJobShouldCallScheduleJobOnScheduler()
    //     {
    //         IScheduler scheduler = A.Fake<IScheduler>();
    //         CancellationToken cancellationToken = default(CancellationToken);
    //
    //         string validCronSchedule = "0 0/20 * 1/1 * ? *";
    //         ScheduledJobSettings scheduledJobSettings = new ScheduledJobSettings() {CronExpression = validCronSchedule};
    //
    //         var configurator = new DeleteExpiredTokensSchedulerConfigurator();
    //         IJobDetail jobDetail = configurator.BuildJobDetail(scheduledJobSettings);
    //         ITrigger trigger = configurator.BuildTrigger(scheduledJobSettings);
    //
    //         await configurator.AddScheduledJob(scheduler, scheduledJobSettings, cancellationToken);
    //
    //         A.CallTo(
    //             () => scheduler.ScheduleJob(jobDetail, trigger, cancellationToken)).MustHaveHappened();
    //     }
    // }
}
