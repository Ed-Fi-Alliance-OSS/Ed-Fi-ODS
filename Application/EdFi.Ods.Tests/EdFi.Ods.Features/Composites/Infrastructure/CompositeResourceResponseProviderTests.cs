// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Features.Composites.Infrastructure;
using EdFi.TestFixture;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.Composites.Infrastructure
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CompositeResourceResponseProviderTests
    {
        protected const string ValueOne = "one";
        protected const string ValueTwo = "two";
        protected const string ValueOne1 = "one1";
        protected const string ValueTwo2 = "two2";
        protected static Guid ValueGuid = Guid.Parse("7E0D03CD-C48C-4EDF-AFC3-16E6DA8EB0D2");
        protected static DateTime ValueDate = DateTime.Parse("2023-12-06 18:53:04.7329766");
        protected const string ExpectedGuid = "7e0d03cdc48c4edfafc316e6da8eb0d2";
        protected const string ExpectedDate = "2023-12-06";
        protected const string KeyOne = "One";
        protected const string KeyTwo = "Two";
        protected const string KeyGuid = "Guid";
        protected const string KeyDate = "Date";
        protected const string KeyStartsWithUnderscores = "__Something";
        protected const string KeyEndsWithUnderscoresNamespace = "Something__Namespace";
        protected const string KeyStartsWithHUnderscore = "H_Something";
        protected const string DisplayName = "DisplayName";

        public class When_child_is_outside_context_of_parent : ScenarioFor<CompositeResourceResponseProvider>
        {
            private IList<IDictionary> _actual;

            protected override void Act()
            {
                var orderedFieldNamesWithTypes = new Dictionary<string, PropertyType>
                {
                    { KeyOne, new PropertyType(System.Data.DbType.String) },
                    { KeyTwo, new PropertyType(System.Data.DbType.String) }
                };

                IEnumerable<object> futureQuery = new List<Hashtable>
                {
                    new Hashtable(
                        new Dictionary<string, string>
                        {
                            {
                                KeyOne, ValueOne
                            },
                            {
                                KeyTwo, ValueTwo
                            }
                        })
                };

                var query = new CompositeQuery(DisplayName, orderedFieldNamesWithTypes, futureQuery, isSingleItemResult: true);

                var parentRow = new Hashtable(
                    new Dictionary<string, string>
                    {
                        {
                            KeyOne, ValueOne1
                        },
                        {
                            KeyTwo, ValueTwo2
                        }
                    });

                string[] parentKeys =
                {
                    KeyOne, KeyTwo
                };

                _actual = SystemUnderTest.ProcessResults(query, parentRow, parentKeys, new List<SelectedResourceMember>(), NullValueHandling.Ignore, new UniqueIdLookupsByUsiContext());
            }

            [Test]
            public void Should_return_empty_list()
            {
                AssertHelper.All(
                    () => _actual.ShouldNotBeNull(),
                    () => _actual.ShouldBeEmpty());
            }
        }

        public class When_child_is_in_context_of_parent : ScenarioFor<CompositeResourceResponseProvider>
        {
            private IList<IDictionary> _actual;

            protected override void Act()
            {
                var orderedFieldNamesWithTypes = new Dictionary<string, PropertyType>
                {
                    { KeyOne, new PropertyType(System.Data.DbType.String) },
                    { KeyTwo, new PropertyType(System.Data.DbType.String) },
                    { KeyGuid, new PropertyType(System.Data.DbType.Guid) },
                    { KeyDate, new PropertyType(System.Data.DbType.Date) }
                };

                IEnumerable<object> futureQuery = new List<Hashtable>
                {
                    new Hashtable(
                        new Dictionary<string, object>
                        {
                            {
                                KeyOne, ValueOne1
                            },
                            {
                                KeyTwo, ValueTwo2
                            },
                            {
                                KeyGuid, ValueGuid
                            },
                            {
                                KeyDate, ValueDate
                            },
                            {
                                KeyStartsWithUnderscores, KeyStartsWithUnderscores
                            },
                            {
                                KeyEndsWithUnderscoresNamespace, KeyEndsWithUnderscoresNamespace
                            },
                            {
                                KeyStartsWithHUnderscore, KeyStartsWithHUnderscore
                            }
                        })
                };

                var query = new CompositeQuery(DisplayName, orderedFieldNamesWithTypes, futureQuery, isSingleItemResult: true);

                var parentRow = new Hashtable(
                    new Dictionary<string, string>
                    {
                        {
                            KeyOne, ValueOne1
                        },
                        {
                            KeyTwo, ValueTwo2
                        },
                    });

                string[] parentKeys =
                {
                    KeyOne, KeyTwo
                };

                _actual = SystemUnderTest.ProcessResults(query, parentRow, parentKeys, new List<SelectedResourceMember>(), NullValueHandling.Ignore, new UniqueIdLookupsByUsiContext());
            }

            [Test]
            public void Should_return_list_with_both_items()
            {
                AssertHelper.All(
                    () => _actual.ShouldNotBeNull(),
                    () => _actual.ShouldNotBeEmpty(),
                    () => _actual.Count.ShouldBe(1),
                    () => _actual.First()
                        .Contains(KeyOne)
                        .ShouldBeTrue(),

                    () => _actual.First()[KeyOne]
                        .ShouldBe(ValueOne1),

                    () => _actual.First()
                        .Contains(KeyTwo)
                        .ShouldBeTrue(),

                    () => _actual.First()[KeyTwo]
                        .ShouldBe(ValueTwo2),

                    () => _actual.First()
                        .Contains(KeyGuid)
                        .ShouldBeTrue(),

                    () => _actual.First()[KeyGuid]
                        .ShouldBe(ExpectedGuid),

                    () => _actual.First()
                        .Contains(KeyDate)
                        .ShouldBeTrue(),

                    () => _actual.First()[KeyDate]
                        .ShouldBe(ExpectedDate));
            }
        }

        public class When_child_is_in_context_of_parent_and_composite_has_child_queries : ScenarioFor<CompositeResourceResponseProvider>
        {
            private IList<IDictionary> _actual;

            protected override void Act()
            {
                var orderedFieldNamesWithTypes = new Dictionary<string, PropertyType>
                {
                    { KeyOne, new PropertyType(System.Data.DbType.String) },
                    { KeyTwo, new PropertyType(System.Data.DbType.String) }
                };

                IEnumerable<object> futureQuery = new List<Hashtable>
                {
                    new Hashtable(
                        new Dictionary<string, string>
                        {
                            {
                                KeyOne, ValueOne1
                            },
                            {
                                KeyTwo, ValueTwo2
                            },
                            {
                                KeyStartsWithUnderscores, KeyStartsWithUnderscores
                            },
                            {
                                KeyEndsWithUnderscoresNamespace, KeyEndsWithUnderscoresNamespace
                            },
                            {
                                KeyStartsWithHUnderscore, KeyStartsWithHUnderscore
                            }
                        })
                };

                var query = new CompositeQuery(DisplayName, orderedFieldNamesWithTypes, futureQuery, isSingleItemResult: true);
                var childQuery = new CompositeQuery(DisplayName, orderedFieldNamesWithTypes, futureQuery, isSingleItemResult: true);
                query.ChildQueries.Add(childQuery);

                var parentRow = new Hashtable(
                    new Dictionary<string, string>
                    {
                        {
                            KeyOne, ValueOne1
                        },
                        {
                            KeyTwo, ValueTwo2
                        }
                    });

                string[] parentKeys =
                {
                    KeyOne, KeyTwo
                };

                _actual = SystemUnderTest.ProcessResults(query, parentRow, parentKeys, new List<SelectedResourceMember>(), NullValueHandling.Ignore, new UniqueIdLookupsByUsiContext());
            }

            [Test]
            public void Should_return_list_with_both_items_and_DisplayName()
            {
                AssertHelper.All(
                    () => _actual.ShouldNotBeNull(),
                    () => _actual.ShouldNotBeEmpty(),
                    () => _actual.Count.ShouldBe(1),

                    () => _actual.First()
                        .Contains(KeyOne)
                        .ShouldBeTrue(),

                    () => _actual.First()[KeyOne]
                        .ShouldBe(ValueOne1),

                    () => _actual.First()
                        .Contains(KeyTwo)
                        .ShouldBeTrue(),

                    () => _actual.First()[KeyTwo]
                        .ShouldBe(ValueTwo2),

                    () => _actual.First()
                        .Contains("DisplayName")
                        .ShouldBeTrue()
                );
            }
        }
    }
}