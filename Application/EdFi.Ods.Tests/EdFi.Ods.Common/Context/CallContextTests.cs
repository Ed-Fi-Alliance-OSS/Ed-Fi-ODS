// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Context;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Context
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CallContextTests
    {
        public class When_flowing_data_between_threads_using_call_context : TestFixtureBase
        {
            private readonly object _d1 = new object();
            private readonly object _d2 = new object();

            private object _t1 = default(object);
            private object _t10 = default(object);
            private object _t11 = default(object);
            private object _t12 = default(object);
            private object _t13 = default(object);

            private object _t2 = default(object);
            private object _t20 = default(object);
            private object _t21 = default(object);
            private object _t22 = default(object);
            private object _t23 = default(object);

            protected override void Act()
            {
                Task.WaitAll(
                    Task.Run(
                        () =>
                        {
                            CallContext.SetData("d1", _d1);
                            new Thread(() => _t10 = CallContext.GetData("d1")).Start();

                            Task.WaitAll(
                                Task.Run(() => _t1 = CallContext.GetData("d1"))
                                    .ContinueWith(t => Task.Run(() => _t11 = CallContext.GetData("d1"))),
                                Task.Run(() => _t12 = CallContext.GetData("d1")),
                                Task.Run(() => _t13 = CallContext.GetData("d1"))
                            );
                        }),
                    Task.Run(
                        () =>
                        {
                            CallContext.SetData("d2", _d2);
                            new Thread(() => _t20 = CallContext.GetData("d2")).Start();

                            Task.WaitAll(
                                Task.Run(() => _t2 = CallContext.GetData("d2"))
                                    .ContinueWith(t => Task.Run(() => _t21 = CallContext.GetData("d2"))),
                                Task.Run(() => _t22 = CallContext.GetData("d2")),
                                Task.Run(() => _t23 = CallContext.GetData("d2"))
                            );
                        })
                );
            }

            [Test]
            public void Should_pass_data_between_threads_for_d1()
            {
                AssertHelper.All(
                    () => Assert.AreSame(_d1, _t1),
                    () => Assert.AreSame(_d1, _t10),
                    () => Assert.AreSame(_d1, _t11),
                    () => Assert.AreSame(_d1, _t12),
                    () => Assert.AreSame(_d1, _t13)
                );
            }

            [Test]
            public void Should_pass_data_between_treads_for_d2()
            {
                AssertHelper.All(
                    () => Assert.AreSame(_d2, _t2),
                    () => Assert.AreSame(_d2, _t20),
                    () => Assert.AreSame(_d2, _t21),
                    () => Assert.AreSame(_d2, _t22),
                    () => Assert.AreSame(_d2, _t23)
                );
            }

            [Test]
            public void Should_return_null_when_getting_data_for_d1() => Assert.IsNull(CallContext.GetData("d1"));

            [Test]
            public void Should_return_null_when_getting_data_for_d2() => Assert.IsNull(CallContext.GetData("d2"));
        }

        public class When_setting_the_same_value_from_multiple_contexts_concurrently : TestFixtureBase
        {
            private class Person
            {
                public string Name { get; set; }
            }
            
            [Test]
            public void Should_set_and_preserve_values_for_independent_contexts()
            {
                const string Key = "Test";
                
                var thread1SetWait = new ManualResetEvent(false);
                var thread2SetWait = new ManualResetEvent(false);

                Person actualThread1PersonAfterThread1Set = null;
                Person actualThread1PersonAfterThread2Set = null;
                Person actualThread2PersonAfterThread2Set = null;

                var t1 = Task.Run(() => 
                    {
                        CallContext.SetData(Key, new Person {Name = "Bob"});

                        actualThread1PersonAfterThread1Set = (Person) CallContext.GetData(Key);

                        // Signal thread 2 to proceed with writing its value
                        thread1SetWait.Set();
                        
                        // Wait for thread 2's assignment to complete
                        thread2SetWait.WaitOne();

                        // Re-fetch the person
                        actualThread1PersonAfterThread2Set = (Person) CallContext.GetData(Key);
                    });
                
                var t2 = Task.Run(() =>
                    {
                        // Wait for thread 1 to set its value
                        thread1SetWait.WaitOne();

                        // Now write the value for thread 2
                        CallContext.SetData(Key, new Person {Name = "Joe"});
                        actualThread2PersonAfterThread2Set = (Person) CallContext.GetData(Key);

                        // Signal that value has been written
                        thread2SetWait.Set();
                    });
                
                Task.WaitAll(t1, t2);
                
                Assert.Multiple(
                    () =>
                    {
                        Assert.That(actualThread1PersonAfterThread1Set, Is.Not.Null, "Thread 1 value.");
                        Assert.That(actualThread1PersonAfterThread1Set?.Name, Is.EqualTo("Bob"), "Thread 1 value.");

                        Assert.That(actualThread2PersonAfterThread2Set, Is.Not.Null, "Thread 2 value.");
                        Assert.That(actualThread2PersonAfterThread2Set?.Name, Is.EqualTo("Joe"), "Thread 2 value.");
                
                        Assert.That(actualThread1PersonAfterThread2Set, Is.Not.Null, "Thread 1 value retrieved after Thread 2 value set.");
                        Assert.That(actualThread1PersonAfterThread2Set?.Name, Is.EqualTo("Bob"), "Thread 1 value retrieved after Thread 2 value set.");
                    });
            }
        }
    }
}
#endif