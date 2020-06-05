// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using EdFi.Ods.Api.Common.Infrastructure.Composites;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Repositories.NHibernate.Composites
{
    public class When_parsing_an_expression_that_includes_one_member_with_children
        : LegacyScenarioFor<FieldsExpressionParser>
    {
        [Assert]
        public void Should_parse_expressions_that_select_top_level_properties()
        {
            var result = TestSubject.ParseFields("someProperty1,someProperty2");

            Assert.That(result, Has.Count.EqualTo(2));

            Assert.That(
                result[0]
                   .MemberName,
                Is.EqualTo("someProperty1"));

            Assert.That(
                result[0]
                   .Children,
                Has.Count.EqualTo(0));

            Assert.That(
                result[1]
                   .MemberName,
                Is.EqualTo("someProperty2"));

            Assert.That(
                result[0]
                   .Children,
                Has.Count.EqualTo(0));
        }

        [Assert]
        public void Should_parse_expressions_that_select_top_level_properties_even_with_trailing_spaces_in_the_expression()
        {
            var result = TestSubject.ParseFields("someProperty1,someProperty2  ");

            Assert.That(result, Has.Count.EqualTo(2));

            Assert.That(
                result[0]
                   .MemberName,
                Is.EqualTo("someProperty1"));

            Assert.That(
                result[0]
                   .Children,
                Has.Count.EqualTo(0));

            Assert.That(
                result[1]
                   .MemberName,
                Is.EqualTo("someProperty2"));

            Assert.That(
                result[0]
                   .Children,
                Has.Count.EqualTo(0));
        }

        [Assert]
        public void Should_parse_expressions_that_select_members_with_all_children_included()
        {
            var result = TestSubject.ParseFields("someProperty1,someReference(*)");

            Assert.That(result, Has.Count.EqualTo(2));

            Assert.That(
                result[0]
                   .MemberName,
                Is.EqualTo("someProperty1"));

            Assert.That(
                result[0]
                   .Children,
                Has.Count.EqualTo(0));

            Assert.That(
                result[1]
                   .MemberName,
                Is.EqualTo("someReference"));

            Assert.That(
                result[1]
                   .Children,
                Is.EqualTo(
                    new[]
                    {
                        "*"
                    }));
        }

        [Assert]
        public void Should_parse_expressions_that_select_members_with_specific_children_included()
        {
            var result = TestSubject.ParseFields("someProperty1,someReference(someRefProp1,someRefProp2)");

            Assert.That(result, Has.Count.EqualTo(2));

            Assert.That(
                result[0]
                   .MemberName,
                Is.EqualTo("someProperty1"));

            Assert.That(
                result[0]
                   .Children,
                Has.Count.EqualTo(0));

            Assert.That(
                result[1]
                   .MemberName,
                Is.EqualTo("someReference"));

            Assert.That(
                result[1]
                   .Children.Select(x => x.MemberName),
                Is.EqualTo(
                    new[]
                    {
                        "someRefProp1", "someRefProp2"
                    }));
        }

        [Assert]
        public void Should_parse_expressions_that_select_members_with_specific_children_included_without_being_sensitive_to_leading_spaces()
        {
            var result = TestSubject.ParseFields("someProperty1,   someReference(  someRefProp1, someRefProp2)");

            Assert.That(result, Has.Count.EqualTo(2));

            Assert.That(
                result[0]
                   .MemberName,
                Is.EqualTo("someProperty1"));

            Assert.That(
                result[0]
                   .Children,
                Has.Count.EqualTo(0));

            Assert.That(
                result[1]
                   .MemberName,
                Is.EqualTo("someReference"));

            Assert.That(
                result[1]
                   .Children.Select(x => x.MemberName),
                Is.EqualTo(
                    new[]
                    {
                        "someRefProp1", "someRefProp2"
                    }));
        }

        [Assert]
        public void Should_parse_expressions_that_select_members_with_specific_descendants_included()
        {
            var result = TestSubject.ParseFields(
                "someProperty1,someCollection(someCollProp1,someCollProp2,someCollRef1(someCollRef1Prop1,someCollRef1Prop2),someCollProp3),someProperty2");

            Assert.That(result, Has.Count.EqualTo(3));

            // First item
            Assert.That(
                result[0]
                   .MemberName,
                Is.EqualTo("someProperty1"));

            Assert.That(
                result[0]
                   .Children,
                Has.Count.EqualTo(0));

            // Second item, with children
            Assert.That(
                result[1]
                   .MemberName,
                Is.EqualTo("someCollection"));

            Assert.That(
                result[1]
                   .Children.Select(x => x.MemberName),
                Is.EqualTo(
                    new[]
                    {
                        "someCollProp1", "someCollProp2", "someCollRef1", "someCollProp3"
                    }));

            // Second item's grandchildren
            Assert.That(
                result[1]
                   .Children.Single(x => x.MemberName == "someCollRef1")
                   .Children.Select(y => y.MemberName),
                Is.EqualTo(
                    new[]
                    {
                        "someCollRef1Prop1", "someCollRef1Prop2"
                    }));

            // Third item
            Assert.That(
                result[2]
                   .MemberName,
                Is.EqualTo("someProperty2"));

            Assert.That(
                result[2]
                   .Children,
                Has.Count.EqualTo(0));
        }

        [Assert]
        public void Should_throw_exception_for_unclosed_parenthesis()
        {
            Should.Throw<ArgumentException>(() => TestSubject.ParseFields("a,b(c"));
        }

        [Assert]
        public void Should_throw_exception_for_too_many_close_parenthesis()
        {
            Should.Throw<ArgumentException>(() => TestSubject.ParseFields("a,b(c(d))e)"));
        }

        [Assert]
        public void Should_throw_exception_for_use_of_non_alpha_numeric_characters_in_a_property_names()
        {
            Should.Throw<ArgumentException>(() => TestSubject.ParseFields("abc12%3"));
        }

        [Assert]
        public void Should_throw_exception_if_the_fields_expression_is_empty()
        {
            Should.Throw<ArgumentException>(() => TestSubject.ParseFields(string.Empty));
        }

        [Assert]
        public void Should_throw_exception_if_the_fields_expression_is_null()
        {
            Should.Throw<ArgumentException>(() => TestSubject.ParseFields(null));
        }

        [Assert]
        public void Should_allow_use_of_alpha_numeric_characters_and_underscores_in_property_names()
        {
            var result = TestSubject.ParseFields("abc12_3_");

            Assert.That(
                result[0]
                   .MemberName,
                Is.EqualTo("abc12_3_"));
        }

        [Assert]
        public void Should_skip_empty_property_names()
        {
            var result = TestSubject.ParseFields("a(,b)");

            Assert.That(result[0], Is.EqualTo("a"));

            Assert.That(
                result[0]
                   .Children,
                Has.Count.EqualTo(1));

            Assert.That(
                result[0]
                   .Children[0]
                   .MemberName,
                Is.EqualTo("b"));
        }

        [Assert]
        public void Should_throw_exception_if_child_fields_expression_is_empty()
        {
            Should.Throw<ArgumentException>(()=> TestSubject.ParseFields("a()"));
        }

        [Assert]
        public void Should_throw_exception_if_grandchild_fields_expression_is_empty()
        {
            Should.Throw<ArgumentException>(()=> TestSubject.ParseFields("a(b())"));
        }

        [Assert]
        public void Should_skip_trailing_empty_property_names()
        {
            var result = TestSubject.ParseFields("a,b,");

            Assert.That(
                result,
                Is.EqualTo(
                    new[]
                    {
                        "a", "b"
                    }));
        }

        [Assert]
        public void Should_be_tolerant_of_spaces_around_field_names()
        {
            var result = TestSubject.ParseFields("   a   ,  b     ");

            Assert.That(
                result,
                Is.EqualTo(
                    new[]
                    {
                        "a", "b"
                    }));
        }
    }
}
