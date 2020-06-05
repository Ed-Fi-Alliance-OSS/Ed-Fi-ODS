// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Web;
using EdFi.Ods.Api.Context;
using EdFi.Ods.Common.Context;
using Http.TestLibrary;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Common.Context
{
    [TestFixture]
    public class HttpContextStorageTests
    {
        protected class TestObject
        {
            public string Text { get; set; }
        }

        [Test]
        public void Should_Get_Generic_Value_in_HttpContext()
        {
            using (var simulatedContext = new HttpSimulator())
            {
                var key = "testKey";
                var expected = "Some Text";
                simulatedContext.SimulateRequest();
                var contextStorage = new HttpContextStorage(MockRepository.GenerateStub<IContextStorage>());

                var testObject = new TestObject
                                 {
                                     Text = expected
                                 };

                contextStorage.SetValue(key, testObject);
                var actual = contextStorage.GetValue<TestObject>(key);
                actual.Text.ShouldBe(expected);
            }
        }

        [Test]
        public void Should_SetValue_in_HttpContext()
        {
            using (var simulatedContext = new HttpSimulator())
            {
                var key = "testKey";
                var expected = "Some Text";
                simulatedContext.SimulateRequest();
                var contextStorage = new HttpContextStorage(MockRepository.GenerateStub<IContextStorage>());
                contextStorage.SetValue(key, expected);
                var actual = HttpContext.Current.Items[key];
                actual.ShouldBe(expected);
            }
        }
    }
}
