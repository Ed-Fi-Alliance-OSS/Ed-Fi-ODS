// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.TestFixture;
using NUnit.Framework;
using QuickGraph;
using Shouldly;

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

            [Test]
            public void Should_not_throw_an_exception()
            {
                Assert.That(ActualException, Is.Null);
            }
        }
        
        public class When_a_graph_has_a_cyclical_dependency : TestFixtureBase
        {
            private BidirectionalGraph<string, IEdge<string>> _graph;

            protected override void Act()
            {
                _graph = new BidirectionalGraph<string, IEdge<string>>();

                /*
                 *            .----------------------.
                 *            V                       \
                 *   (A) --> (B) --> (C1) --> (D1)     |
                 *               \                     |
                 *                --> (C2) --> (D2)    |
                 *                         \           |
                 *                          --> (E2) --'
                */
                
                _graph.AddVertex("A");
                _graph.AddVertex("B");
                _graph.AddVertex("C1");
                _graph.AddVertex("D1");
                _graph.AddVertex("C2");
                _graph.AddVertex("D2");

                _graph.AddEdge(new Edge<string>("A", "B"));
                _graph.AddEdge(new Edge<string>("B", "C1"));
                _graph.AddEdge(new Edge<string>("C1", "D1"));
                _graph.AddEdge(new Edge<string>("B", "C2"));
                _graph.AddEdge(new Edge<string>("C2", "D2"));

                // Add a vertex and edges that creates a cyclical dependency
                _graph.AddVertex("E2");
                _graph.AddEdge(new Edge<string>("C2", "E2"));
                _graph.AddEdge(new Edge<string>("E2", "B"));
            }

            [Test]
            public void Validation_should_throw_a_NonAcyclicGraphException()
            {
                Should.Throw<NonAcyclicGraphException>(() => _graph.ValidateGraph());
            }

            [Test]
            public void Should_be_able_to_break_cycles_by_removing_any_removable_cycle_edge()
            {
                var clonedGraph = _graph.Clone();
                clonedGraph.Edges.Any(Is_B_to_C2).ShouldBeTrue();
                var removedEdges = clonedGraph.BreakCycles(Is_B_to_C2);
                clonedGraph.Edges.Any(Is_B_to_C2).ShouldBeFalse("Removable edge B-to-C2 was not removed.");
                clonedGraph.Edges.Count().ShouldBe(_graph.Edges.Count() - 1);
                removedEdges.Single(Is_B_to_C2).ShouldNotBeNull();
                
                clonedGraph = _graph.Clone();
                clonedGraph.Edges.Any(Is_C2_to_E2).ShouldBeTrue();
                removedEdges = clonedGraph.BreakCycles(Is_C2_to_E2);
                clonedGraph.Edges.Any(Is_C2_to_E2).ShouldBeFalse("Removable edge C2-to-E2 was not removed.");
                clonedGraph.Edges.Count().ShouldBe(_graph.Edges.Count() - 1);
                removedEdges.Single(Is_C2_to_E2).ShouldNotBeNull();
                
                clonedGraph = _graph.Clone();
                clonedGraph.Edges.Any(Is_E2_to_B).ShouldBeTrue();
                removedEdges = clonedGraph.BreakCycles(Is_E2_to_B);
                clonedGraph.Edges.Any(Is_E2_to_B).ShouldBeFalse("Removable edge E2-to-B was not removed.");
                clonedGraph.Edges.Count().ShouldBe(_graph.Edges.Count() - 1);
                removedEdges.Single(Is_E2_to_B).ShouldNotBeNull();
            }

            [Test]
            public void Should_break_a_cycle_by_removing_the_deepest_removable_edge()
            {
                var clonedGraph = _graph.Clone();
                clonedGraph.Edges.Count(Is_any_cycle_edge).ShouldBe(3);
                
                var removedEdges = clonedGraph.BreakCycles(Is_any_cycle_edge);
                clonedGraph.Edges.Any(Is_E2_to_B).ShouldBeFalse("Deepest removable edge B-to-C2 was not the edge removed.");
                clonedGraph.Edges.Count().ShouldBe(_graph.Edges.Count() - 1);
                removedEdges.Single(Is_E2_to_B).ShouldNotBeNull();
            }

            [Test]
            public void Should_throw_an_exception_if_none_of_the_cycle_edges_are_removable()
            {
                var clonedGraph = _graph.Clone();
                
                Should.Throw<NonAcyclicGraphException>(() => clonedGraph.BreakCycles(e => !Is_any_cycle_edge(e)));
            }
            
            bool Is_B_to_C2(IEdge<string> e) => e.Source == "B" && e.Target == "C2";
            bool Is_C2_to_E2(IEdge<string> e) => e.Source == "C2" && e.Target == "E2";
            bool Is_E2_to_B(IEdge<string> e) => e.Source == "E2" && e.Target == "B";

            bool Is_any_cycle_edge(IEdge<string> e) => Is_B_to_C2(e) || Is_C2_to_E2(e) || Is_E2_to_B(e);
        }

        public class When_a_graph_has_two_cycles_and_a_self_referencing_association : TestFixtureBase
        {
            private BidirectionalGraph<string, IEdge<string>> _graph;

            protected override void Act()
            {
                _graph = new BidirectionalGraph<string, IEdge<string>>();

                /*    .--------------------------------.
                 *    |       .----------------------.  \
                 *    |     .-|-.    .--.             \  \             
                 *    v     V V /    V  /              |  |
                 *   (A) --> (B) --> (C1) --> (D1)     |  |
                 *               \                     |  |
                 *                --> (C2) --> (D2) ---+--'
                 *                         \           |
                 *                          --> (E2) --'
                */

                _graph.AddVertex("A");
                _graph.AddVertex("B");
                _graph.AddVertex("C1");
                _graph.AddVertex("D1");
                _graph.AddVertex("C2");
                _graph.AddVertex("D2");

                _graph.AddEdge(new Edge<string>("A", "B"));
                _graph.AddEdge(new Edge<string>("B", "C1"));
                _graph.AddEdge(new Edge<string>("C1", "D1"));
                _graph.AddEdge(new Edge<string>("B", "C2"));
                _graph.AddEdge(new Edge<string>("C2", "D2"));

                // Add a vertex and edges that creates a cyclical dependency
                _graph.AddVertex("E2");
                _graph.AddEdge(new Edge<string>("C2", "E2"));
                _graph.AddEdge(new Edge<string>("E2", "B"));
                
                // Add a second cyclical dependency
                _graph.AddEdge(new Edge<string>("D2", "A"));
                
                // Add a self-referencing dependencies
                _graph.AddEdge(new Edge<string>("B", "B"));
                _graph.AddEdge(new Edge<string>("C1", "C1"));
            }
            
            [Test]
            public void Validation_should_fail_initially()
            {
                Should.Throw<NonAcyclicGraphException>(() => _graph.ValidateGraph());
            }
            
            [Test]
            public void Should_be_able_to_break_the_cycles()
            {
                var clonedGraph = _graph.Clone();
                
                IReadOnlyList<IEdge<string>> removedEdges = null;

                Should.NotThrow(() =>
                {
                    removedEdges = clonedGraph.BreakCycles(e => true);

                    Console.WriteLine("Removed edges:");
                    foreach (IEdge<string> removedEdge in removedEdges)
                    {
                        Console.WriteLine(removedEdge);
                    }
                });
                Should.NotThrow(() => clonedGraph.ValidateGraph());
                
                clonedGraph.Edges.Count().ShouldBe(_graph.Edges.Count() - 4);
                
                removedEdges.Count().ShouldBe(4);
                removedEdges.SingleOrDefault(a => a.Source == "E2" && a.Target == "B").ShouldNotBeNull();
                removedEdges.SingleOrDefault(a => a.Source == "D2" && a.Target == "A").ShouldNotBeNull();
                removedEdges.SingleOrDefault(a => a.Source == "C1" && a.Target == "C1").ShouldNotBeNull();
                removedEdges.SingleOrDefault(a => a.Source == "B" && a.Target == "B").ShouldNotBeNull();
            }
        }

        public class When_evaluating_a_graph_with_self_referencing_vertices : TestFixtureBase
        {
            private BidirectionalGraph<string, IEdge<string>> _graph;

            protected override void Act()
            {
                var graph = new BidirectionalGraph<string, IEdge<string>>();
                
                /*
                 *                   .--.
                 *                   V  /
                 *   (A) --> (B) --> (C) --> (D)
                */

                _graph = graph;
                _graph.AddVertex("A");
                _graph.AddVertex("B");
                _graph.AddVertex("C");
                _graph.AddVertex("D");

                _graph.AddEdge(new Edge<string>("A", "B"));
                _graph.AddEdge(new Edge<string>("B", "C"));
                _graph.AddEdge(new Edge<string>("C", "D"));

                // Add a self-referencing edge that creates a cyclical dependency
                // But is not something that we are concerned with for resources/aggregates
                _graph.AddEdge(new Edge<string>("C", "C"));
            }

            [Test]
            public void Should_throw_an_exception_on_validation()
            {
                Should.Throw<NonAcyclicGraphException>(() => _graph.ValidateGraph());
            }

            [Test]
            public void Should_be_able_to_break_the_cycle_by_removing_the_self_referencing_edge()
            {
                var clonedGraph = _graph.Clone();
                
                var removedEdges = clonedGraph.BreakCycles(e => true);
                
                clonedGraph.Edges.Count().ShouldBe(_graph.Edges.Count() - 1);
                
                removedEdges.Count().ShouldBe(1);
                removedEdges.SingleOrDefault(a => a.Source == "C" && a.Target == "C").ShouldNotBeNull();
            }
        }
    }
}
