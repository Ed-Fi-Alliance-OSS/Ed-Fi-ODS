// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.ScheduledJobs.Configurators;
using EdFi.Ods.Common.Configuration;
using NUnit.Framework;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.ScheduledJobs;

[TestFixture]
public class BaseScheduledJobConfiguratorTests
{
    [Test]
    public void MissingCronExpressionShouldApplyDefaultCronExpression()
    {
        ScheduledJobSetting scheduledJobSetting = new ScheduledJobSetting();
        DeleteExpiredTokensScheduledJobConfigurator configurator = new DeleteExpiredTokensScheduledJobConfigurator();

        var expectedResult = BaseScheduledJobConfigurator.DefaultCronExpression;
        var actualResult = configurator.GetCronExpression(scheduledJobSetting);

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void EmptyCronExpressionShouldApplyDefaultCronExpression()
    {
        ScheduledJobSetting scheduledJobSetting = new ScheduledJobSetting()
        {
            CronExpression = ""
        }; 

        DeleteExpiredTokensScheduledJobConfigurator configurator = new DeleteExpiredTokensScheduledJobConfigurator();

        var expectedResult = BaseScheduledJobConfigurator.DefaultCronExpression;
        var actualResult = configurator.GetCronExpression(scheduledJobSetting);

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void InvalidCronExpressionShouldApplyDefaultCronExpression()
    {
        ScheduledJobSetting scheduledJobSetting = new ScheduledJobSetting()
        {
            CronExpression = "INVALID_CRON_SCHEDULE"
        };

        DeleteExpiredTokensScheduledJobConfigurator configurator = new DeleteExpiredTokensScheduledJobConfigurator();

        var expectedResult = BaseScheduledJobConfigurator.DefaultCronExpression;
        var actualResult = configurator.GetCronExpression(scheduledJobSetting);

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void ValidCronExpressionShouldApplyDefaultCronExpression()
    {
        string validCronSchedule = "0 0/20 * 1/1 * ? *";
        ScheduledJobSetting scheduledJobSetting = new ScheduledJobSetting()
        {
            CronExpression = validCronSchedule
        };

        DeleteExpiredTokensScheduledJobConfigurator configurator = new DeleteExpiredTokensScheduledJobConfigurator();

        var expectedResult = validCronSchedule;
        var actualResult = configurator.GetCronExpression(scheduledJobSetting);

        Assert.AreEqual(expectedResult, actualResult);
    }


    [Test]
    public void MissingStartAtShouldApplyDefaultStartAt()
    {
        ScheduledJobSetting scheduledJobSetting = new ScheduledJobSetting();
        DeleteExpiredTokensScheduledJobConfigurator configurator = new DeleteExpiredTokensScheduledJobConfigurator();

        var expectedResult = BaseScheduledJobConfigurator.DefaultStartAt;
        var actualResult = configurator.GetStartAt(scheduledJobSetting);

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void StartAtLessThanZeroShouldApplyDefaultStartAt()
    {
        ScheduledJobSetting scheduledJobSetting = new ScheduledJobSetting()
        {
            StartAtMinutes = -1
        };

        DeleteExpiredTokensScheduledJobConfigurator configurator = new DeleteExpiredTokensScheduledJobConfigurator();

        var expectedResult = BaseScheduledJobConfigurator.DefaultStartAt;
        var actualResult = configurator.GetStartAt(scheduledJobSetting);

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void StartAtGreaterThanMaxStartAtShouldApplyDefaultStartAt()
    {
        ScheduledJobSetting scheduledJobSetting = new ScheduledJobSetting()
        {
            StartAtMinutes = BaseScheduledJobConfigurator.MaxStartAt + 1
        };

        DeleteExpiredTokensScheduledJobConfigurator configurator = new DeleteExpiredTokensScheduledJobConfigurator();

        var expectedResult = BaseScheduledJobConfigurator.DefaultStartAt;
        var actualResult = configurator.GetStartAt(scheduledJobSetting);

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void ValidStartAtShouldBeApplied()
    {
        double startAtMinutes = BaseScheduledJobConfigurator.DefaultStartAt - 1; ;
        ScheduledJobSetting scheduledJobSetting = new ScheduledJobSetting()
        {
            StartAtMinutes = startAtMinutes
        };

        DeleteExpiredTokensScheduledJobConfigurator configurator = new DeleteExpiredTokensScheduledJobConfigurator();

        var expectedResult = startAtMinutes;
        var actualResult = configurator.GetStartAt(scheduledJobSetting);

        Assert.AreEqual(expectedResult, actualResult);
    }
}
