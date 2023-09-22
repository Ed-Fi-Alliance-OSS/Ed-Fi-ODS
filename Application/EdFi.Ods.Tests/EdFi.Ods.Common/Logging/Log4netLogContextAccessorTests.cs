// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Logging;
using log4net;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Logging
{
    [TestFixture]
    public class Log4netLogContextAccessorTests
    {
        [Test]
        public void GetValueAndSetValue_ShouldSetAndGetValueInLogicalThreadContext()
        {
            // Arrange
            var logContextAccessor = new Log4NetLogContextAccessor();
            
            // Act
            logContextAccessor.SetValue("TestProperty", "TestValue");
            var result = logContextAccessor.GetValue("TestProperty");
            
            // Assert
            LogicalThreadContext.Properties["TestProperty"].ShouldBe("TestValue");
            result.ShouldBe("TestValue");
        }

        [Test]
        public void GetValue_ShouldGetValueAsNull_WhenNotSetInLogicalThreadContext()
        {
            // Arrange
            var logContextAccessor = new Log4NetLogContextAccessor();
            
            // Act
            var result = logContextAccessor.GetValue("TestProperty");
            
            // Assert
            result.ShouldBeNull();
        }
    }
}
