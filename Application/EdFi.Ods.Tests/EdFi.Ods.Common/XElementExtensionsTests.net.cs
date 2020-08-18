// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Xml;
using System.Xml.Linq;
using EdFi.Ods.Common.Extensions;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common
{
    [TestFixture]
    public class When_Get_The_Short_Value_Of_An_Element
    {
        [Test]
        public void And_Element_Is_Named_SchoolYear_Should_And_Is_in_MuliYear_Format_Should_Only_Return_Value_Of_Later_Year()
        {
            var schoolyear = @"<root><SchoolYear>2014-2015</SchoolYear></root>";
            var expected = short.Parse("2015");

            XElement.Parse(schoolyear)
                    .Last4CharactersAsNullableShort()
                    .ShouldBe(expected);
        }
    }

    [TestFixture]
    public class When_Getting_The_Decimal_Value_of_An_Element
    {
        [Test]
        public void And_Element_Is_Null_or_Empty_Should_Return_Default_Value()
        {
            var emptyval = @"<root><myval></myval></root>";
            var expected = default(decimal);

            XElement.Parse(emptyval)
                    .DecimalValueOf("myval")
                    .ShouldBe(expected);
        }

        [Test]
        public void And_Element_Is_Parsable_As_Decimal_Should_Return_Value()
        {
            var reals = @"<root><reals>10.3</reals></root>";
            var expected = (decimal) 10.3;

            XElement.Parse(reals)
                    .DecimalValueOf("reals")
                    .ShouldBe(expected);
        }
    }

    [TestFixture]
    public class When_Getting_The_Nullable_Decimal_Value_Of_An_Element
    {
        [Test]
        public void And_Element_has_Value_Should_Return_Value()
        {
            var valuable = @"<root><valuable>100.4</valuable></root>";
            var expected = (decimal?) 100.4;

            XElement.Parse(valuable)
                    .NullableDecimalValueOf("valuable")
                    .ShouldBe(expected);
        }

        [Test]
        public void And_Element_is_Null_Should_Return_null()
        {
            var nullish = @"<root><nullish></nullish></root>";

            XElement.Parse(nullish)
                    .NullableDecimalValueOf("nullish")
                    .ShouldBeNull();
        }
    }

    [TestFixture]
    public class When_testing_element_or_default
    {
        [Test]
        public void Should_return_null_when_elements_do_not_exist_in_chained_methods()
        {
            const string xml = @"<Root></Root>";

            XElement.Parse(xml)
                    .ElementOrEmpty("A")
                    .ElementOrEmpty("B")
                    .ShouldBeNull();
        }

        [Test]
        public void Should_return_value_when_element_has_namespace()
        {
            const string xml =
                @"<Root>
                    <Child xmlns='http://mynamespace/666'>
                        <GrandChild>1</GrandChild>
                    </Child>
                  </Root>";

            XElement.Parse(xml)
                    .ElementOrEmpty("Child")
                    .IntValueOf("GrandChild")
                    .ShouldBe(1);
        }

        [Test]
        public void Should_return_value_when_elements_exist_in_chained_methods()
        {
            const string xml = @"<Root><Child><GrandChild>TheValue</GrandChild></Child></Root>";

            XElement.Parse(xml)
                    .ElementOrEmpty("Child")
                    .ElementOrEmpty("GrandChild")
                    .Value.ShouldBe("TheValue");
        }
    }

    [TestFixture]
    public class When_testing_elements_or_default
    {
        [Test]
        public void Should_find_elements_regardless_of_their_namespace()
        {
            const string xml =
                @"<Root>
                    <Child xmlns='http://mynamespace/1'>1</Child>
                    <Child xmlns='http://mynamespace/2'>2</Child>
                    <Child xmlns='http://mynamespace/3'>3</Child>
                    <Child/>
                  </Root>";

            XElement.Parse(xml)
                    .ElementsOrEmpty("Child")
                    .Count()
                    .ShouldBe(4);
        }

        [Test]
        public void Should_return_a_list_when_elements_exist_in_chained_methods()
        {
            const string xml =
                @"<Root>
                    <Child>1</Child>
                    <Child>2</Child>
                    <Child/>
                  </Root>";

            XElement.Parse(xml)
                    .ElementsOrEmpty("Child")
                    .Count()
                    .ShouldBe(3);
        }

        [Test]
        public void Should_return_an_empty_list_when_elements_do_not_exist_in_chained_methods()
        {
            const string xml = @"<Root></Root>";

            XElement.Parse(xml)
                    .ElementsOrEmpty("A")
                    .Count()
                    .ShouldBe(0);
        }
    }

    [TestFixture]
    public class When_testing_attribute_Value
    {
        [Test]
        public void Should_return_attribute_value_when_attribute_exists()
        {
            const string xml =
                @"<Root>
                    <Child id='123'/>
                </Root>";

            XElement.Parse(xml)
                    .ElementOrEmpty("Child")
                    .AttributeValue("id")
                    .ShouldBe("123");
        }

        [Test]
        public void Should_return_null_when_attribute_do_not_exist()
        {
            const string xml =
                @"<Root>
                    <Child/>
                </Root>";

            XElement.Parse(xml)
                    .ElementOrEmpty("Child")
                    .AttributeValue("SomeAttribute")
                    .ShouldBeNull();
        }

        [Test]
        public void Should_return_null_when_reading_attribute_of_an_element_that_do_not_exist()
        {
            const string xml =
                @"<Root>
                </Root>";

            XElement.Parse(xml)
                    .ElementOrEmpty("Child")
                    .AttributeValue("SomeAttribute")
                    .ShouldBeNull();
        }
    }

    [TestFixture]
    public class When_testing_value_of
    {
        [Test]
        public void Should_return_null_when_element_do_not_exist()
        {
            const string xml =
                @"<Root>
                  </Root>";

            XElement.Parse(xml)
                    .ValueOf("Child")
                    .ShouldBeNull();
        }

        [Test]
        public void Should_return_value_when_element_exists()
        {
            const string xml =
                @"<Root>
                    <Child>foo</Child>
                  </Root>";

            XElement.Parse(xml)
                    .ValueOf("Child")
                    .ShouldBe("foo");
        }
    }

    [TestFixture]
    public class When_testing_int_value_of
    {
        [Test]
        public void Should_return_value_when_element_exists()
        {
            const string xml =
                @"<Root>
                    <Child>
                        <GrandChild>1</GrandChild>
                    </Child>
                  </Root>";

            XElement.Parse(xml)
                    .ElementOrEmpty("Child")
                    .IntValueOf("GrandChild")
                    .ShouldBe(1);
        }

        [Test]
        public void Should_return_zero_when_last_element_not_exist()
        {
            const string xml =
                @"<Root>
                        <Child/>
                  </Root>";

            XElement.Parse(xml)
                    .ElementOrEmpty("Child")
                    .IntValueOf("GrandChild")
                    .ShouldBe(0);
        }

        [Test]
        public void Should_return_zero_when_no_elements_exists_in_chain()
        {
            const string xml =
                @"<Root>
                  </Root>";

            XElement.Parse(xml)
                    .ElementOrEmpty("Child")
                    .IntValueOf("GrandChild")
                    .ShouldBe(0);
        }
    }

    [TestFixture]
    public class When_Getting_Value_Or_Default
    {
        [Test]
        public void Of_A_Null_Object_Should_Return_Null()
        {
            XElement nullElement = null;

            nullElement.ValueOrDefault()
                       .ShouldBeNull();
        }

        [Test]
        public void Of_An_Empty_Object_Should_Return_Empty_String()
        {
            XElement.Parse("<node></node>")
                    .ValueOrDefault()
                    .ShouldBeEmpty();
        }
    }

    [TestFixture]
    public class When_Getting_A_TimeSpan_Value
    {
        [Test]
        public void Of_A_Populated_Object_Should_Return_Value()
        {
            var xml = "<root><timespan>07:57:00.0000000-05:00</timespan></root>";

            XElement.Parse(xml)
                    .TimeSpanValueOf("timespan")
                    .ShouldBe(
                         XmlConvert.ToDateTime("07:57:00.0000000-05:00", XmlDateTimeSerializationMode.Utc)
                                   .TimeOfDay);
        }
    }

    [TestFixture]
    public class When_Getting_A_Nullable_TimeSpan_Value
    {
        [Test]
        public void Of_A_Populated_Object_Should_Return_Value()
        {
            var xml = "<root><timespan>07:57:00.0000000-05:00</timespan></root>";

            XElement.Parse(xml)
                    .TimeSpanValueOf("timespan")
                    .ShouldBe(
                         XmlConvert.ToDateTime("07:57:00.0000000-05:00", XmlDateTimeSerializationMode.Utc)
                                   .TimeOfDay);
        }
    }

    [TestFixture]
    public class When_Finding_Nested_Elements
    {
        [Test]
        public void Given_Element_With_Grandchildren_Containing_String_Value_Should_Return_Value()
        {
            var expected = "Larry";
            var xml = "<student><name><firstname>" + expected + "</firstname></name></student>";

            XElement.Parse(xml)
                    .NestedValueOf(
                         new[]
                         {
                             "name", "firstname"
                         })
                    .ShouldBe(expected);
        }

        [Test]
        public void Given_Element_With_Inline_Entity_Grandchildren_Should_Return_All_Elements()
        {
            var expected1 = "Curly";
            var expected2 = "Moe";
            var openxml = @"<root><name>";
            var openNick = @"<nick>";
            var closeNick = @"</nick>";
            var closexml = @"</name></root>";
            var xml = openxml + openNick + expected1 + closeNick + openNick + expected2 + closeNick + closexml;

            var found = XElement.Parse(xml)
                                .NestedElementsOrEmpty(
                                     new[]
                                     {
                                         "name", "nick"
                                     });

            found.Count()
                 .ShouldBe(2);
        }

        [Test]
        public void Given_The_Containing_Element_Does_Not_Exist_When_String_Value_Requested_Should_return_Empty_String()
        {
            var xml = "<root><something></something></root>";

            var given = new[]
                        {
                            "Bob", "Lisa"
                        };

            var result = XElement.Parse(xml)
                                 .NestedValueOf(given);

            string.IsNullOrWhiteSpace(result)
                  .ShouldBeTrue();
        }
    }

    [TestFixture]
    public class When_Finding_Multiple_Elements_Containing_the_Same_Structure
    {
        private const string expected1 = @"<Comedian><id>1</id><name>Curly</name></Comedian>";
        private const string expected2 = @"<Programmer><id>2</id><name>Bob</name></Programmer>";
        private const string expected3 = @"<Baker><id>3</id><name>Henry</name></Baker>";
        private static readonly string[] allElements =
        {
            "Comedian", "Programmer", "Baker"
        };

        [Test]
        public void Given_Element_With_Three_Matching_Elements_Should_Return_All_Three()
        {
            var xml = @"<root><funny>" + expected1 + "</funny><notfunny>" + expected2 + expected3 + "</notfunny></root>";
            var given = allElements;

            var found = XElement.Parse(xml)
                                .AllElementsOrEmpty(given);

            found.Count()
                 .ShouldBe(3);
        }

        [Test]
        public void Given_Elements_At_Various_Nesting_Depths_Should_Find_Them_All()
        {
            var xml = @"<root>" + expected1 + "<level1>" + expected2 + "<level2>" + expected3 + "</level2></level1></root>";
            var given = allElements;

            var found = XElement.Parse(xml)
                                .AllElementsOrEmpty(given);

            found.Count()
                 .ShouldBe(3);
        }

        [Test]
        public void Given_No_Elements_In_Xml_Should_Return_Empty_Collection()
        {
            var xml = "<root><nothere></nothere><nothereeither></nothereeither></root>";
            var given = allElements;

            XElement.Parse(xml)
                    .AllElementsOrEmpty(given)
                    .ShouldBeEmpty();
        }

        [Test]
        public void Given_The_Same_Element_At_Various_Nesting_Depths_Should_Find_All_Elements()
        {
            var expected1A = expected1.Replace("1", "2");
            var expected1B = expected1.Replace("1", "3");
            var expected1C = expected1.Replace("1", "4");

            var xml = @"<root>" + expected1 + expected1A + "<level1>" + expected1B + "<level2>" + expected1C +
                      "</level2></level1></root>";

            var given = allElements;

            var found = XElement.Parse(xml)
                                .AllElementsOrEmpty(given);

            found.Count()
                 .ShouldBe(4);
        }
    }
}
