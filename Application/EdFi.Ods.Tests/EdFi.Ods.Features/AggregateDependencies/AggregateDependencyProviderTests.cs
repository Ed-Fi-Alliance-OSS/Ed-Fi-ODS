// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using EdFi.Ods.Api.Models.GraphML;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.AggregateDependencies;
using EdFi.Ods.Features.Container.Modules;
using FakeItEasy;
using NUnit.Framework;
using QuickGraph;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.AggregateDependencies
{
    [TestFixture]
    public class AggregateDependencyProviderTests
    {
        private IResourceLoadGraphFactory _resourceLoadGraphFactory;
        private AggregateDependencyProvider _provider;

        [SetUp]
        public void SetUp()
        {
            _resourceLoadGraphFactory = A.Fake<IResourceLoadGraphFactory>();
            A.CallTo(() => _resourceLoadGraphFactory.CreateResourceLoadGraph()).ReturnsLazily(CreateGraph);

            _provider = new AggregateDependencyProvider(_resourceLoadGraphFactory);
        }

        [Test]
        public void Should_build_the_load_order_once_and_return_the_same_instance()
        {
            var first = _provider.GetLoadOrder();
            var second = _provider.GetLoadOrder();

            A.CallTo(() => _resourceLoadGraphFactory.CreateResourceLoadGraph()).MustHaveHappenedOnceExactly();
            second.ShouldBeSameAs(first);
            first.Select(x => x.Order).ShouldBe(new[] { 1 });
        }

        [Test]
        public void Should_build_the_graphml_once_and_return_the_same_instance()
        {
            var first = _provider.GetGraphML();
            var second = _provider.GetGraphML();

            A.CallTo(() => _resourceLoadGraphFactory.CreateResourceLoadGraph()).MustHaveHappenedOnceExactly();
            second.ShouldBeSameAs(first);
        }

        [Test]
        public void Should_build_the_load_order_and_the_graphml_separately()
        {
            _provider.GetLoadOrder();
            _provider.GetGraphML();

            A.CallTo(() => _resourceLoadGraphFactory.CreateResourceLoadGraph()).MustHaveHappenedTwiceExactly();
        }

        [Test]
        public void Should_return_a_load_order_that_cannot_be_changed_through_the_list()
        {
            ((IList<ResourceLoadOrder>) _provider.GetLoadOrder()).IsReadOnly.ShouldBeTrue();
        }

        [Test]
        public void Should_build_once_when_the_first_requests_arrive_together()
        {
            int builds = 0;
            using var start = new ManualResetEventSlim();

            A.CallTo(() => _resourceLoadGraphFactory.CreateResourceLoadGraph())
                .ReturnsLazily(
                    () =>
                    {
                        Interlocked.Increment(ref builds);

                        // Keep the build running while the other requests arrive
                        Thread.Sleep(200);
                        return CreateGraph();
                    });

            var requests = Enumerable.Range(0, 8)
                .Select(
                    _ => Task.Factory.StartNew(
                        () =>
                        {
                            start.Wait();
                            return _provider.GetLoadOrder();
                        },
                        TaskCreationOptions.LongRunning))
                .ToArray();

            start.Set();
            Task.WaitAll(requests, TimeSpan.FromSeconds(30)).ShouldBeTrue();

            builds.ShouldBe(1);
            requests.Select(r => r.Result).Distinct().Count().ShouldBe(1);
        }

        [Test]
        public void Should_keep_a_circular_dependency_and_not_analyze_the_model_again()
        {
            A.CallTo(() => _resourceLoadGraphFactory.CreateResourceLoadGraph())
                .Throws(new NonAcyclicGraphException());

            Should.Throw<NonAcyclicGraphException>(() => _provider.GetLoadOrder());
            Should.Throw<NonAcyclicGraphException>(() => _provider.GetLoadOrder());
            Should.Throw<NonAcyclicGraphException>(() => _provider.GetGraphML());
            Should.Throw<NonAcyclicGraphException>(() => _provider.GetGraphML());

            // Once for the load order and once for the GraphML
            A.CallTo(() => _resourceLoadGraphFactory.CreateResourceLoadGraph()).MustHaveHappenedTwiceExactly();
        }

        [Test]
        public void Should_not_keep_any_other_exception()
        {
            A.CallTo(() => _resourceLoadGraphFactory.CreateResourceLoadGraph())
                .Throws(new InvalidOperationException("Transient failure")).Once()
                .Then.ReturnsLazily(CreateGraph);

            Should.Throw<InvalidOperationException>(() => _provider.GetLoadOrder());

            _provider.GetLoadOrder().Select(x => x.Order).ShouldBe(new[] { 1 });
            A.CallTo(() => _resourceLoadGraphFactory.CreateResourceLoadGraph()).MustHaveHappenedTwiceExactly();
        }

        [Test]
        public void Should_be_registered_as_a_single_instance()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AggregateDependenciesModule(new FakeFeatureManager()));

            // Only satisfies the dependencies of the registered graph factory
            builder.RegisterInstance(A.Fake<IResourceModelProvider>()).As<IResourceModelProvider>();

            using var container = builder.Build();
            using var firstRequest = container.BeginLifetimeScope();
            using var secondRequest = container.BeginLifetimeScope();

            var first = firstRequest.Resolve<IAggregateDependencyProvider>();

            first.ShouldBeOfType<AggregateDependencyProvider>();
            secondRequest.Resolve<IAggregateDependencyProvider>().ShouldBeSameAs(first);
        }

        private static BidirectionalGraph<Resource, AssociationViewEdge> CreateGraph()
        {
            var graph = new BidirectionalGraph<Resource, AssociationViewEdge>();
            graph.AddVertex(new Resource("Test"));
            return graph;
        }
    }
}
