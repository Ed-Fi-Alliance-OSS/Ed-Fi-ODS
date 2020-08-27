// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Common.Context;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Common.Context
{
    [TestFixture]
    public class CallContextStorageTests
    {
        [TestFixture]
        public class When_accessing_context_in_the_same_thread
        {
            protected class TestObject
            {
                public string Text { get; set; }
            }

            [Test]
            public void Should_Get_Generic_Value_in_CallContext()
            {
                var key = "testKey";
                var expected = "Some Text";
                var contextStorage = new CallContextStorage();

                var testObject = new TestObject
                                 {
                                     Text = expected
                                 };

                contextStorage.SetValue(key, testObject);
                var actual = contextStorage.GetValue<TestObject>(key);
                actual.Text.ShouldBe(expected);
            }

            [Test]
            public void Should_SetValue_in_CallContext()
            {
                var key = "testKey";
                var expected = "Some Text";
                var contextStorage = new CallContextStorage();
                contextStorage.SetValue(key, expected);
                var actual = CallContext.GetData(key);
                actual.ShouldBe(expected);
            }
        }

        [TestFixture]
        public class When_accessing_context_across_a_task_boundary
        {
            private void TestGetValue()
            {
                var value = new CallContextStorage().GetValue<string>("MyReallyAwesomeKey");
                value.ShouldBe("My Cool Value");
            }

            [Test]
            public void Should_retrieve_value()
            {
                new CallContextStorage().SetValue("MyReallyAwesomeKey", "My Cool Value");

                //Sanity Check
                var sameThreadValue = new CallContextStorage().GetValue<string>("MyReallyAwesomeKey");
                sameThreadValue.ShouldBe("My Cool Value");
                Console.WriteLine("Same thread value works fine");

                var task = Task.Run(() => TestGetValue());
                task.Wait();
            }
        }
    }
}
