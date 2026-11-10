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
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Features.Composites.Infrastructure;
using EdFi.TestFixture;
using FakeItEasy;
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

        public class When_a_flattened_reference_is_not_authorized_for_some_rows : ScenarioFor<CompositeResourceResponseProvider>
        {
            private IList<IDictionary> _actualWithNullsIgnored;
            private IList<IDictionary> _actualWithNullsIncluded;

            protected override void Act()
            {
                _actualWithNullsIgnored = Process(NullValueHandling.Ignore);
                _actualWithNullsIncluded = Process(NullValueHandling.Include);
            }

            private IList<IDictionary> Process(NullValueHandling nullValueHandling)
            {
                var orderedFieldNamesWithTypes = new Dictionary<string, PropertyType>
                {
                    { "sectionIdentifier", new PropertyType(System.Data.DbType.String) },
                    { "localCourseCode", new PropertyType(System.Data.DbType.String) },
                    { "localCourseTitle", new PropertyType(System.Data.DbType.String) },
                    { "courseTitle", new PropertyType(System.Data.DbType.String) },
                };

                IEnumerable<object> futureQuery = new List<Hashtable>
                {
                    Row("authorized", courseOfferingFlag: 1, courseFlag: 1),
                    Row("courseOfferingDenied", courseOfferingFlag: 0, courseFlag: 1),
                    Row("onlyNestedCourseDenied", courseOfferingFlag: 1, courseFlag: 0),
                };

                var query = new CompositeQuery(DisplayName, orderedFieldNamesWithTypes, futureQuery, isSingleItemResult: false)
                {
                    AuthorizationFlagAliasesByFieldAlias = new Dictionary<string, string[]>
                    {
                        // LocalCourseCode is an identifying property of the CourseOffering, so it has no entry
                        { "localCourseTitle", ["__Auth_comp_ab"] },
                        { "courseTitle", ["__Auth_comp_ab", "__Auth_comp_ac"] },
                    }
                };

                return (IList<IDictionary>) SystemUnderTest.ProcessResults(query, null, nullValueHandling, new UniqueIdLookupsByUsiContext());
            }

            private static Hashtable Row(string sectionIdentifier, int courseOfferingFlag, int courseFlag)
                => new()
                {
                    { "sectionIdentifier", sectionIdentifier },
                    { "localCourseCode", "ALG-1" },
                    { "localCourseTitle", "Algebra I" },
                    { "courseTitle", "Algebra" },
                    { "__Auth_comp_ab", courseOfferingFlag },
                    { "__Auth_comp_ac", courseFlag },
                };

            [Test]
            public void Should_return_every_row()
            {
                _actualWithNullsIgnored.Count.ShouldBe(3);
                _actualWithNullsIncluded.Count.ShouldBe(3);
            }

            [Test]
            public void Should_return_all_values_for_authorized_rows()
            {
                var item = _actualWithNullsIgnored[0];

                AssertHelper.All(
                    () => item["sectionIdentifier"].ShouldBe("authorized"),
                    () => item["localCourseCode"].ShouldBe("ALG-1"),
                    () => item["localCourseTitle"].ShouldBe("Algebra I"),
                    () => item["courseTitle"].ShouldBe("Algebra"),
                    () => item.Count.ShouldBe(4));
            }

            [Test]
            public void Should_remove_non_identifying_values_of_the_unauthorized_reference_and_of_references_nested_in_it()
            {
                var item = _actualWithNullsIgnored[1];

                AssertHelper.All(
                    () => item["sectionIdentifier"].ShouldBe("courseOfferingDenied"),
                    () => item["localCourseCode"].ShouldBe("ALG-1"),
                    () => item.Contains("localCourseTitle").ShouldBeFalse(),
                    () => item.Contains("courseTitle").ShouldBeFalse(),
                    () => item.Count.ShouldBe(2));
            }

            [Test]
            public void Should_remove_only_the_values_of_an_unauthorized_nested_reference()
            {
                var item = _actualWithNullsIgnored[2];

                AssertHelper.All(
                    () => item["localCourseTitle"].ShouldBe("Algebra I"),
                    () => item.Contains("courseTitle").ShouldBeFalse(),
                    () => item.Count.ShouldBe(3));
            }

            [Test]
            public void Should_return_nulls_for_unauthorized_values_when_nulls_are_included()
            {
                var item = _actualWithNullsIncluded[1];

                AssertHelper.All(
                    () => item["localCourseCode"].ShouldBe("ALG-1"),
                    () => item.Contains("localCourseTitle").ShouldBeTrue(),
                    () => item["localCourseTitle"].ShouldBeNull(),
                    () => item.Contains("courseTitle").ShouldBeTrue(),
                    () => item["courseTitle"].ShouldBeNull());
            }

            [Test]
            public void Should_never_return_the_authorization_flags()
            {
                foreach (var item in _actualWithNullsIncluded.Concat(_actualWithNullsIgnored))
                {
                    item.Keys.Cast<string>().ShouldAllBe(k => !k.StartsWith("__"));
                }
            }
        }

        public class When_an_unauthorized_flattened_reference_value_is_a_USI_and_nulls_are_included
            : ScenarioFor<CompositeResourceResponseProvider>
        {
            private IList<IDictionary> _actual;

            protected override void Arrange()
            {
                var personEntitySpecification = Given<IPersonEntitySpecification>();

                string personType;
                string roleName;

                A.CallTo(() => personEntitySpecification.TryGetUSIPersonTypeAndRoleName("studentUSI", out personType, out roleName))
                    .Returns(true)
                    .AssignsOutAndRefParameters("Student", string.Empty);
            }

            protected override void Act()
            {
                var orderedFieldNamesWithTypes = new Dictionary<string, PropertyType>
                {
                    { "sectionIdentifier", new PropertyType(System.Data.DbType.String) },
                    { "studentUniqueId", new PropertyType(System.Data.DbType.String) },
                };

                IEnumerable<object> futureQuery = new List<Hashtable>
                {
                    new()
                    {
                        { "sectionIdentifier", "denied" },
                        { "studentUSI", 123 },
                        { "__Auth_comp_ab", 0 },
                    }
                };

                var query = new CompositeQuery(DisplayName, orderedFieldNamesWithTypes, futureQuery, isSingleItemResult: false)
                {
                    AuthorizationFlagAliasesByFieldAlias = new Dictionary<string, string[]>
                    {
                        { "studentUSI", ["__Auth_comp_ab"] },
                    }
                };

                _actual = (IList<IDictionary>) SystemUnderTest.ProcessResults(
                    query, null, NullValueHandling.Include, new UniqueIdLookupsByUsiContext());
            }

            [Test]
            public void Should_return_a_null_UniqueId_instead_of_the_USI()
            {
                var item = _actual.Single();

                AssertHelper.All(
                    () => item["sectionIdentifier"].ShouldBe("denied"),
                    () => item.Contains("studentUniqueId").ShouldBeTrue(),
                    () => item["studentUniqueId"].ShouldBeNull(),
                    () => item.Contains("studentUSI").ShouldBeFalse());
            }
        }

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