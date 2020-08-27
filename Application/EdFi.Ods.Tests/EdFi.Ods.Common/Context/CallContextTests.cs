// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

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

            // TODO ODS-4043 need to sort how to do call context in the future.
            // [Test]
            // public void Should_pass_data_between_treads_for_d2()
            // {
            //     AssertHelper.All(
            //         () => Assert.AreSame(_d2, _t2),
            //         () => Assert.AreSame(_d2, _t20),
            //         () => Assert.AreSame(_d2, _t21),
            //         () => Assert.AreSame(_d2, _t22),
            //         () => Assert.AreSame(_d2, _t23)
            //     );
            // }

            // TODO ODS-4043 need to sort how to do call context in the future.
            // [Test]
            // public void Should_return_null_when_getting_data_for_d1() => Assert.IsNull(CallContext.GetData("d1"));

            // TODO ODS-4043 need to sort how to do call context in the future.
            // [Test]
            // public void Should_return_null_when_getting_data_for_d2() => Assert.IsNull(CallContext.GetData("d2"));
        }
    }
}

