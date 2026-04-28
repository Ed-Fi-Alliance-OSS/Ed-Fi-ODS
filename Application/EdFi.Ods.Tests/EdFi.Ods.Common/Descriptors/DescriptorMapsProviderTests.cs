// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Descriptors;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Descriptors;

[TestFixture]
public class DescriptorMapsProviderTests
{
    [Test]
    public void GetMaps_ReturnsExpectedDescriptorMaps()
    {
        // Arrange
        var descriptorDetailsProvider = A.Fake<IDescriptorDetailsProvider>();
        
        A.CallTo(() => descriptorDetailsProvider.GetAllDescriptorDetails()).Returns(GetSampleDescriptorDetails());

        var contextProvider = FakeContextProvider();

        var provider = new DescriptorMapsProvider(descriptorDetailsProvider, contextProvider);

        // Act
        var maps = provider.GetMaps();

        // Assert
        maps.ShouldNotBeNull();
        maps.DescriptorIdByUri.ShouldNotBeNull();
        maps.UriByDescriptorId.ShouldNotBeNull();

        maps.DescriptorIdByUri.Count.ShouldBe(2);
        maps.UriByDescriptorId.Count.ShouldBe(2);

        maps.DescriptorIdByUri["http://ed-fi.org/TestDescriptor#1"].ShouldBe(("AbcDescriptor", 1));
        maps.DescriptorIdByUri["http://ed-fi.org/TestDescriptor#2"].ShouldBe(("AbcDescriptor", 2));

        // Ensure case-insensitive matching on descriptor values
        maps.DescriptorIdByUri.ContainsKey("HTTP://ED-FI.ORG/TESTDESCRIPTOR#1").ShouldBe(true);
        maps.DescriptorIdByUri.ContainsKey("HTTP://ED-FI.ORG/TESTDESCRIPTOR#2").ShouldBe(true);
        
        maps.UriByDescriptorId[1].ShouldBe(("AbcDescriptor", "http://ed-fi.org/TestDescriptor#1"));
        maps.UriByDescriptorId[2].ShouldBe(("AbcDescriptor", "http://ed-fi.org/TestDescriptor#2"));
    }

    [Test]
    public void GetMaps_ConcurrentCallers_InvokeLoaderOnce_AndReturnSameInstance()
    {
        // Arrange
        const int concurrentCallers = 3;

        var loaderInvocations = 0;
        var gate = new System.Threading.ManualResetEventSlim(initialState: false);

        var descriptorDetailsProvider = A.Fake<IDescriptorDetailsProvider>();

        A.CallTo(() => descriptorDetailsProvider.GetAllDescriptorDetails())
            .ReturnsLazily(() =>
            {
                System.Threading.Interlocked.Increment(ref loaderInvocations);
                gate.Wait();
                return GetSampleDescriptorDetails();
            });

        var provider = new DescriptorMapsProvider(
            descriptorDetailsProvider,
            FakeContextProvider());

        var tasks = new System.Threading.Tasks.Task<DescriptorMaps>[concurrentCallers];
        var started = new System.Threading.CountdownEvent(concurrentCallers);

        // Act
        for (int i = 0; i < concurrentCallers; i++)
        {
            tasks[i] = System.Threading.Tasks.Task.Run(() =>
            {
                started.Signal();
                return provider.GetMaps();
            });
        }

        // Wait for all callers to be in flight before releasing the loader
        started.Wait(TimeSpan.FromSeconds(15)).ShouldBeTrue("callers did not all start");
        gate.Set();

        System.Threading.Tasks.Task.WaitAll(tasks, TimeSpan.FromSeconds(10)).ShouldBeTrue("tasks did not complete");

        // Assert
        loaderInvocations.ShouldBe(1);

        var first = tasks[0].Result;
        first.ShouldNotBeNull();

        for (int i = 1; i < concurrentCallers; i++)
        {
            tasks[i].Result.ShouldBeSameAs(first);
        }
    }

    [Test]
    public void GetMaps_LoaderException_PropagatesToWaiters_AndDoesNotPoisonFutureCalls()
    {
        // Arrange
        const int concurrentCallers = 3;

        var loaderInvocations = 0;
        var gate = new System.Threading.ManualResetEventSlim(initialState: false);
        var shouldThrow = true;

        var descriptorDetailsProvider = A.Fake<IDescriptorDetailsProvider>();

        A.CallTo(() => descriptorDetailsProvider.GetAllDescriptorDetails())
            .ReturnsLazily(() =>
            {
                System.Threading.Interlocked.Increment(ref loaderInvocations);
                gate.Wait();

                if (shouldThrow)
                {
                    throw new InvalidOperationException("boom");
                }

                return GetSampleDescriptorDetails();
            });

        var provider = new DescriptorMapsProvider(
            descriptorDetailsProvider,
            FakeContextProvider());

        var tasks = new System.Threading.Tasks.Task<DescriptorMaps>[concurrentCallers];
        var started = new System.Threading.CountdownEvent(concurrentCallers);

        // Act — first wave: loader throws
        for (int i = 0; i < concurrentCallers; i++)
        {
            tasks[i] = System.Threading.Tasks.Task.Run(() =>
            {
                started.Signal();
                return provider.GetMaps();
            });
        }

        started.Wait(TimeSpan.FromSeconds(15)).ShouldBeTrue("callers did not all start");
        gate.Set();

        // Assert — all waiters observe the same exception, loader ran once
        foreach (var task in tasks)
        {
            var ex = Should.Throw<AggregateException>(() => task.Wait());
            ex.InnerException.ShouldBeOfType<InvalidOperationException>();
            ex.InnerException!.Message.ShouldBe("boom");
        }

        loaderInvocations.ShouldBe(1);

        // Act — second wave: loader should be re-invoked (no poisoning)
        shouldThrow = false;
        gate.Set(); // loader proceeds immediately this time

        var result = provider.GetMaps();

        // Assert — the loader ran a second time and a fresh result was produced
        loaderInvocations.ShouldBe(2);
        result.ShouldNotBeNull();
        result.DescriptorIdByUri.Count.ShouldBe(2);
    }

    [Test]
    public void GetMaps_DifferentContexts_DoNotSerializeAgainstEachOther()
    {
        // Arrange
        var gateA = new System.Threading.ManualResetEventSlim(initialState: false);
        var gateB = new System.Threading.ManualResetEventSlim(initialState: false);
        var loaderAEntered = new System.Threading.ManualResetEventSlim(initialState: false);
        var loaderBEntered = new System.Threading.ManualResetEventSlim(initialState: false);

        OdsInstanceConfiguration currentContext = null;
        var contextProvider = A.Fake<IContextProvider<OdsInstanceConfiguration>>();
        A.CallTo(() => contextProvider.Get()).ReturnsLazily(() => currentContext);

        var contextA = BuildContext(odsInstanceId: 1);
        var contextB = BuildContext(odsInstanceId: 2);

        var descriptorDetailsProvider = A.Fake<IDescriptorDetailsProvider>();

        // Each loader signals entry and waits for its dedicated gate before returning.
        // If the single-flight were NOT keyed by context, the second caller would block
        // on the first's Lazy and we would never observe BOTH loaders entered concurrently.
        A.CallTo(() => descriptorDetailsProvider.GetAllDescriptorDetails())
            .ReturnsLazily(() =>
            {
                if (ReferenceEquals(currentContext, contextA))
                {
                    loaderAEntered.Set();
                    gateA.Wait();
                }
                else
                {
                    loaderBEntered.Set();
                    gateB.Wait();
                }

                return GetSampleDescriptorDetails();
            });

        var provider = new DescriptorMapsProvider(descriptorDetailsProvider, contextProvider);

        // Act
        var taskA = System.Threading.Tasks.Task.Run(() =>
        {
            currentContext = contextA;
            return provider.GetMaps();
        });

        // Wait for loader A to be in flight before starting B so we can observe concurrency
        loaderAEntered.Wait(TimeSpan.FromSeconds(15)).ShouldBeTrue("loader A did not enter");

        var taskB = System.Threading.Tasks.Task.Run(() =>
        {
            currentContext = contextB;
            return provider.GetMaps();
        });

        loaderBEntered.Wait(TimeSpan.FromSeconds(15))
            .ShouldBeTrue("loader B was blocked on loader A — single-flight is not context-keyed");

        // Release both loaders
        gateA.Set();
        gateB.Set();

        System.Threading.Tasks.Task.WaitAll(new[] { taskA, taskB }, TimeSpan.FromSeconds(10))
            .ShouldBeTrue("tasks did not complete");

        // Assert — both succeeded
        taskA.Result.ShouldNotBeNull();
        taskB.Result.ShouldNotBeNull();
    }

    private static OdsInstanceConfiguration BuildContext(int odsInstanceId)
    {
        return new OdsInstanceConfiguration(
            odsInstanceId: odsInstanceId,
            odsInstanceHashId: (ulong)odsInstanceId,
            connectionString: string.Empty,
            contextValueByKey: new Dictionary<string, string>(),
            connectionStringByDerivativeType: new Dictionary<DerivativeType, string>());
    }
    
    private static IContextProvider<OdsInstanceConfiguration> FakeContextProvider(int odsInstanceId = 1)
    {
        var config = BuildContext(odsInstanceId);

        var contextProvider = A.Fake<IContextProvider<OdsInstanceConfiguration>>();
        A.CallTo(() => contextProvider.Get()).Returns(config);

        return contextProvider;
    }

    private static List<DescriptorDetails> GetSampleDescriptorDetails()
    {
        return new List<DescriptorDetails>
        {
            new() { DescriptorId = 1, DescriptorName = "AbcDescriptor", Namespace = "http://ed-fi.org/TestDescriptor", CodeValue = "1" },
            new() { DescriptorId = 2, DescriptorName = "AbcDescriptor", Namespace = "http://ed-fi.org/TestDescriptor", CodeValue = "2" },
        };
    }
}
