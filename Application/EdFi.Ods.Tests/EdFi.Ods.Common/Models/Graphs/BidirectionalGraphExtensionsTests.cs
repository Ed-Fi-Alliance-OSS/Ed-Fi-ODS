// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using EdFi.Ods.Common.Models.Graphs;
using EdFi.TestFixture;
using NUnit.Framework;
using QuickGraph;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Graphs
{
    [TestFixture]
    public class BidirectionalGraphExtensionsTests
    {
        public class When_evaluating_a_graph_with_no_cyclical_dependencies : TestFixtureBase
        {
            protected override void Act()
            {
                var graph = new BidirectionalGraph<string, IEdge<string>>();

                /*
                 *   (A) --> (B) --> (C1) --> (D1)
                 *               \
                 *                --> (C2) --> (D2)
                */

                graph.AddVertex("A");
                graph.AddVertex("B");
                graph.AddVertex("C1");
                graph.AddVertex("D1");
                graph.AddVertex("C2");
                graph.AddVertex("D2");

                graph.AddEdge(new Edge<string>("A", "B"));
                graph.AddEdge(new Edge<string>("B", "C1"));
                graph.AddEdge(new Edge<string>("C1", "D1"));
                graph.AddEdge(new Edge<string>("B", "C2"));
                graph.AddEdge(new Edge<string>("C2", "D2"));

                graph.ValidateGraph();
            }

            [Assert]
            public void Should_not_throw_an_exception()
            {
                Assert.That(ActualException, Is.Null);
            }
        }
        
        public class When_evaluating_a_graph_with_a_cyclical_dependency : TestFixtureBase
        {
            protected override void Act()
            {
                var graph = new BidirectionalGraph<string, IEdge<string>>();

                /*
                 *            .----------------------.
                 *            V                       \
                 *   (A) --> (B) --> (C1) --> (D1)     |
                 *               \                     |
                 *                --> (C2) --> (D2)    |
                 *                         \           |
                 *                          --> (E2) --'
                */
                
                graph.AddVertex("A");
                graph.AddVertex("B");
                graph.AddVertex("C1");
                graph.AddVertex("D1");
                graph.AddVertex("C2");
                graph.AddVertex("D2");

                graph.AddEdge(new Edge<string>("A", "B"));
                graph.AddEdge(new Edge<string>("B", "C1"));
                graph.AddEdge(new Edge<string>("C1", "D1"));
                graph.AddEdge(new Edge<string>("B", "C2"));
                graph.AddEdge(new Edge<string>("C2", "D2"));

                // Add a vertex and edges that creates a cyclical dependency
                graph.AddVertex("E2");
                graph.AddEdge(new Edge<string>("C2", "E2"));
                graph.AddEdge(new Edge<string>("E2", "B"));
                
                graph.ValidateGraph();
            }

            [Assert]
            public void Should_throw_an_exception()
            {
                Assert.That(ActualException, Is.TypeOf<NonAcyclicGraphException>());
            }
        }
        
        public class When_evaluating_a_graph_with_self_referencing_vertices : TestFixtureBase
        {
            protected override void Act()
            {
                var graph = new BidirectionalGraph<string, IEdge<string>>();
                
                /*
                 *                   .--.
                 *                   V  /
                 *   (A) --> (B) --> (C) --> (D)
                */
                
                graph.AddVertex("A");
                graph.AddVertex("B");
                graph.AddVertex("C");
                graph.AddVertex("D");

                graph.AddEdge(new Edge<string>("A", "B"));
                graph.AddEdge(new Edge<string>("B", "C"));
                graph.AddEdge(new Edge<string>("C", "D"));

                // Add a self-referencing edge that creates a cyclical dependency
                // But is not something that we are concerned with for resources/aggregates
                graph.AddEdge(new Edge<string>("C", "C"));

                graph.ValidateGraph();
            }

            [Assert]
            public void Should_throw_an_exception()
            {
                Assert.That(ActualException, Is.TypeOf<NonAcyclicGraphException>());
            }
        }
    }
}
