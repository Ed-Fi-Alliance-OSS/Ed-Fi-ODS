// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Jobs;

using EdFi.Ods.Common.Configuration;
using NUnit.Framework;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Jobs
{
    [TestFixture]
    public class CronHelperTests
    {
        [Test]
        public void MissingCronExpressionShouldApplyDefaultCronExpression()
        {
            ScheduledJobSettings scheduledJobSettings = new ScheduledJobSettings();
    
            var expectedResult = ScheduledJobSettings.DefaultCronExpression;
            var actualResult = CronHelper.GetValidCronExpressionOrDefault(scheduledJobSettings);
    
            Assert.AreEqual(expectedResult, actualResult);
        }
    
        [Test]
        public void EmptyCronExpressionShouldApplyDefaultCronExpression()
        {
            ScheduledJobSettings scheduledJobSettings = new ScheduledJobSettings() {CronExpression = ""};
    
            var expectedResult = ScheduledJobSettings.DefaultCronExpression;
            var actualResult = CronHelper.GetValidCronExpressionOrDefault(scheduledJobSettings);
    
            Assert.AreEqual(expectedResult, actualResult);
        }
    
        [Test]
        public void InvalidCronExpressionShouldApplyDefaultCronExpression()
        {
            ScheduledJobSettings scheduledJobSettings = new ScheduledJobSettings() {CronExpression = "INVALID_CRON_SCHEDULE"};
    
            var expectedResult = ScheduledJobSettings.DefaultCronExpression;
            var actualResult = CronHelper.GetValidCronExpressionOrDefault(scheduledJobSettings);
    
            Assert.AreEqual(expectedResult, actualResult);
        }
    
        [Test]
        public void ValidCronExpressionShouldApplyProvidedCronExpression()
        {
            string validCronSchedule = "0 0/20 * 1/1 * ? *";
            ScheduledJobSettings scheduledJobSettings = new ScheduledJobSettings() {CronExpression = validCronSchedule};
    
            var expectedResult = validCronSchedule;
            var actualResult = CronHelper.GetValidCronExpressionOrDefault(scheduledJobSettings);
    
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
