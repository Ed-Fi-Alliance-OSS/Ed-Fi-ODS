// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EdFi.Ods.Api.Common.Infrastructure.Architecture.SqlServer;
using NHibernate;
using NHibernate.Type;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.NHibernate.Architecture
{
    [TestFixture]
    public class SqlServerTableValuedParameterHelperTests
    {
        public class When_setting_value_for_a_table_valued_parameter_on_a_query_to_a_list_of_Guid_ids
            : LegacyTestFixtureBase
        {
            // Supplied values
            private List<Guid> _suppliedIds;
            private string _suppliedParameterName;

            // External dependencies
            private IQuery _query;
            
            protected override void Arrange()
            {
                _query = Stub<IQuery>();

                _suppliedIds = new List<Guid>
                               {
                                   Guid.NewGuid(), Guid.NewGuid()
                               };

                _suppliedParameterName = "parameterName";
            }

            protected override void Act()
            {
                var parameterSetter = new SqlServerTableValuedParameterListSetter();

                parameterSetter.SetParameterList(_query, _suppliedParameterName, _suppliedIds);
            }

            [Assert]
            public void Should_call_the_SetParameter_method_exactly_once()
            {
                _query.AssertWasCalled(
                    x => x.SetParameter(null, null, null),
                    options => options.IgnoreArguments()
                                      .Repeat.Once());
            }

            [Assert]
            public void Should_set_the_parameter_value_on_the_query_using_the_supplied_name()
            {
                _query.AssertWasCalled(
                    x => x.SetParameter(
                        Arg<string>.Is.Equal(_suppliedParameterName),
                        Arg<IEnumerable>.Is.Anything,
                        Arg<IType>.Is.Anything));
            }

            [Assert]
            public void Should_set_the_parameter_value_on_the_query_using_a_DataTable_containing_the_supplied_ids()
            {
                _query.AssertWasCalled(
                    x =>
                        x.SetParameter(
                            Arg<string>.Is.Anything,
                            Arg<object>.Matches(arg => IdsMatch(arg)),
                            Arg<IType>.Is.Anything));
            }

            private bool IdsMatch(object arg)
            {
                var actualIds = ((DataTable) arg).Rows
                                                 .Cast<DataRow>()
                                                 .Select(row => (Guid) row["Id"]);

                Assert.That(actualIds, Is.EquivalentTo(_suppliedIds));

                return true;
            }

            [Assert]
            public void Should_set_the_parameter_value_on_the_query_using_an_IType_that_is_an_instance_of_the_custom_SqlStructured()
            {
                _query.AssertWasCalled(
                    x => x.SetParameter(
                        Arg<string>.Is.Anything,
                        Arg<IEnumerable>.Is.Anything,
                        Arg<IType>.Matches(arg => arg.GetType() == typeof(SqlServerStructured<Guid>))));
            }
        }

        public class When_setting_value_for_a_table_valued_parameter_on_a_query_to_a_list_of_int_ids
            : LegacyTestFixtureBase
        {
            // Supplied values
            private List<int> _suppliedIds;
            private string _suppliedParameterName;

            // External dependencies
            private IQuery _query;
            
            protected override void Arrange()
            {
                _query = Stub<IQuery>();

                _suppliedIds = new List<int>
                               {
                                   1, 2
                               };

                _suppliedParameterName = "parameterName";
            }

            protected override void Act()
            {
                var parameterSetter = new SqlServerTableValuedParameterListSetter();

                parameterSetter.SetParameterList(_query, _suppliedParameterName, _suppliedIds);
            }

            [Assert]
            public void Should_call_the_SetParameter_method_exactly_once()
            {
                _query.AssertWasCalled(
                    x => x.SetParameter(null, null, null),
                    options => options.IgnoreArguments()
                                      .Repeat.Once());
            }

            [Assert]
            public void Should_set_the_parameter_value_on_the_query_using_the_supplied_name()
            {
                _query.AssertWasCalled(
                    x => x.SetParameter(
                        Arg<string>.Is.Equal(_suppliedParameterName),
                        Arg<IEnumerable>.Is.Anything,
                        Arg<IType>.Is.Anything));
            }

            [Assert]
            public void Should_set_the_parameter_value_on_the_query_using_a_DataTable_containing_the_supplied_ids()
            {
                _query.AssertWasCalled(
                    x =>
                        x.SetParameter(
                            Arg<string>.Is.Anything,
                            Arg<object>.Matches(arg => IdsMatch(arg)),
                            Arg<IType>.Is.Anything));
            }

            private bool IdsMatch(object arg)
            {
                var actualIds = ((DataTable) arg).Rows
                                                 .Cast<DataRow>()
                                                 .Select(row => (int) row["Id"]);

                Assert.That(actualIds, Is.EquivalentTo(_suppliedIds));

                return true;
            }

            [Assert]
            public void Should_set_the_parameter_value_on_the_query_using_an_IType_that_is_an_instance_of_the_custom_SqlStructured()
            {
                _query.AssertWasCalled(
                    x => x.SetParameter(
                        Arg<string>.Is.Anything,
                        Arg<IEnumerable>.Is.Anything,
                        Arg<IType>.Matches(arg => arg.GetType() == typeof(SqlServerStructured<int>))));
            }
        }

        public class When_setting_value_for_a_table_valued_parameter_on_a_query_to_a_list_of_ids_of_an_unsupported_type
            : LegacyTestFixtureBase
        {
            // Supplied values
            private List<DateTime> _suppliedIds;
            private string _suppliedParameterName;

            // External dependencies
            private IQuery _query;

            protected override void Arrange()
            {
                _query = Stub<IQuery>();

                _suppliedIds = new List<DateTime>
                               {
                                   DateTime.Today, DateTime.Today.AddDays(1)
                               };

                _suppliedParameterName = "parameterName";
            }

            protected override void Act()
            {
                var parameterSetter = new SqlServerTableValuedParameterListSetter();

                parameterSetter.SetParameterList(_query, _suppliedParameterName, _suppliedIds);
            }

            [Assert]
            public void Should_not_call_the_SetParameter_method()
            {
                _query.AssertWasNotCalled(
                    x => x.SetParameter(null, null, null),
                    options => options.IgnoreArguments());
            }

            [Assert]
            public void Should_pass_the_call_through_to_the_SetParameterList_method()
            {
                _query.AssertWasCalled(x => x.SetParameterList(_suppliedParameterName, _suppliedIds));
            }
        }
    }
}
