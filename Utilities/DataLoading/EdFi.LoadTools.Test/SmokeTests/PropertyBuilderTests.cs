// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Globalization;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest;
using EdFi.LoadTools.SmokeTest.PropertyBuilders;
using NUnit.Framework;
using Moq;
using Swashbuckle.Swagger;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace EdFi.LoadTools.Test.SmokeTests
{
    [TestFixture]
    public class PropertyBuilderTests
    {
#region ExistingResourceBuilder tests

        [Test]
        public void ExistingResourceBuilder_should_copy_resource()
        {
            var obj = new Class1();

            var dict = new Dictionary<string, List<object>>
                       {
                           {
                               "Class2", new List<object>
                                         {
                                             new Class2
                                             {
                                                 intProperty = 5, stringProperty = "value"
                                             }
                                         }
                           }
                       };

            var propInfo = typeof(Class1).GetProperty("class2Property1");
            var builder = new ExistingResourceBuilder(dict, Mock.Of<IPropertyInfoMetadataLookup>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.IsNotNull(obj.class2Property1);
        }

#endregion

#region ListPropertyBuilder tests

        [Test]
        public void ListPropertyBuilder_should_create_empty_list_when_required_is_true()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("listProperty1");

            var propInfoMetadataLookup =
                Mock.Of<IPropertyInfoMetadataLookup>(
                    x => x.GetMetadata(propInfo) == new Parameter
                                                    {
                                                        required = true
                                                    });

            var builder = new ListPropertyBuilder(propInfoMetadataLookup);
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.IsNotNull(obj.listProperty1);
            Assert.AreEqual(0, obj.listProperty1.Count);
        }

#endregion

#region ReferencePropertyBuilder tests

        [Test]
        public void ReferencePropertyBuilder_should_build_reference()
        {
            var obj = new Class1();

            var dict = new Dictionary<string, List<object>>
                       {
                           {
                               "Class2", new List<object>
                                         {
                                             new Class2
                                             {
                                                 intProperty = 5, stringProperty = "value"
                                             }
                                         }
                           }
                       };

            var propInfo = typeof(Class1).GetProperty("class2ReferenceProperty");
            var builder = new ReferencePropertyBuilder(dict, Mock.Of<IPropertyInfoMetadataLookup>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.IsNotNull(obj.class2ReferenceProperty);
            Assert.AreEqual(5, obj.class2ReferenceProperty.intProperty);
        }

#endregion

#region StringPropertyBuilder tests

        [Test]
        public void StringPropertyBuilder_should_set_string_properties()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("stringProperty1");

            var lookup = Mock.Of<IPropertyInfoMetadataLookup>(
                f =>
                    f.GetMetadata(propInfo) == new Parameter
                                               {
                                                   required = true
                                               });

            var builder = new StringPropertyBuilder(lookup);
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.IsFalse(string.IsNullOrEmpty(obj.stringProperty1));
            Assert.AreEqual(6, obj.stringProperty1.Length);
        }

#endregion

#region TimeStringPropertyBuilder tests

        [Test]
        public void TimeStringPropertyBuilder_should_set_string_properties()
        {
            DateTime result;
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("startTime");

            var lookup = Mock.Of<IPropertyInfoMetadataLookup>(
                f =>
                    f.GetMetadata(propInfo) == new Parameter
                                               {
                                                   required = true
                                               });

            var builder = new TimeStringPropertyBuilder(lookup);
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.IsFalse(string.IsNullOrEmpty(obj.startTime));

            Assert.IsTrue(
                DateTime.TryParseExact(
                    obj.startTime, "HH:mm:ss",
                    CultureInfo.CurrentCulture, DateTimeStyles.None, out result));
        }

#endregion

#region UniqueIdPropertyBuilder tests

        [Test]
        public void UniqueIdPropertyBuilder_should_generate_a_value()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("testUniqueId");
            var builder = new UniqueIdPropertyBuilder(Mock.Of<IPropertyInfoMetadataLookup>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.IsFalse(string.IsNullOrEmpty(obj.testUniqueId));
        }

#endregion

#region DateTimePropertyBuilder tests

        [Test]
        public void DateTimePropertyBuilder_should_generate_a_value_for_a_required_property()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("dateTimeProperty1");

            var lookup = Mock.Of<IPropertyInfoMetadataLookup>(
                f =>
                    f.GetMetadata(propInfo) == new Parameter
                    {
                        required = true
                    });
            var builder = new DateTimePropertyBuilder(lookup);
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.AreNotEqual(obj.dateTimeProperty1, default(DateTime));
        }

        [Test]
        public void DateTimePropertyBuilder_should_not_generate_a_value_for_an_optional_property()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("dateTimeProperty1");
            var lookup = Mock.Of<IPropertyInfoMetadataLookup>(
                f =>
                    f.GetMetadata(propInfo) == new Parameter
                    {
                        required = false
                    });

            var builder = new DateTimePropertyBuilder(lookup);
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.AreEqual(obj.dateTimeProperty1, default(DateTime));
        }

#endregion

        private class Class1
        {
            public string id { get; set; }

            public string testUniqueId { get; set; }

            public string stringProperty1 { get; set; }

            public List<Class2> listProperty1 { get; set; }

            public Class2 class2Property1 { get; set; }

            public Class2Reference class2ReferenceProperty { get; set; }

            public int? nullableProperty1 { get; set; }

            public DateTime dateTimeProperty1 { get; set; }

            public string startTime { get; set; }

            public string type { get; set; }

            public string class1Type { get; set; }

            public object link { get; set; }

            public string _etag { get; set; }
        }

        private class Class2
        {
            public int intProperty { get; set; }

            public string stringProperty { get; set; }
        }

        private class Class2Reference
        {
            public int intProperty { get; set; }
        }

        private class Class1Type
        {
            public string CodeValue { get; set; }

            public string ShortDescription { get; set; }
        }

#region IgnorePropertyBuilder tests

        [Test]
        public void IgnorePropertyBuilder_should_ignore_id_property()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("id");
            var builder = new IgnorePropertyBuilder(Mock.Of<IPropertyInfoMetadataLookup>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.IsTrue(string.IsNullOrEmpty(obj.id));
        }

        [Test]
        public void IgnorePropertyBuilder_should_ignore_etag_property()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("_etag");
            var builder = new IgnorePropertyBuilder(Mock.Of<IPropertyInfoMetadataLookup>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.IsTrue(string.IsNullOrEmpty(obj._etag));
        }

        [Test]
        public void IgnorePropertyBuilder_should_ignore_link_property()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("link");
            var builder = new IgnorePropertyBuilder(Mock.Of<IPropertyInfoMetadataLookup>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.IsNull(obj.link);
        }

#endregion

#region SimplePropertyBuilder

        [Test]
        public void SimplePropertyBuilder_should_ignore_nullable_properties()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("nullableProperty1");

            var lookup = Mock.Of<IPropertyInfoMetadataLookup>(
                f =>
                    f.GetMetadata(propInfo) == new Parameter
                                               {
                                                   required = false
                                               });

            var builder = new SimplePropertyBuilder(lookup, Mock.Of<IDestructiveTestConfiguration>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.IsFalse(obj.nullableProperty1.HasValue);
        }

        [Test]
        public void SimplePropertyBuilder_should_generate_a_value_if_required()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("nullableProperty1");

            var lookup = Mock.Of<IPropertyInfoMetadataLookup>(
                f =>
                    f.GetMetadata(propInfo) == new Parameter
                                               {
                                                   required = true
                                               });

            var builder = new SimplePropertyBuilder(lookup, Mock.Of<IDestructiveTestConfiguration>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.AreNotEqual(default(int), obj.nullableProperty1);
        }

        [Test]
        public void SimplePropertyBuilder_should_not_generate_a_value_if_optional()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("nullableProperty1");

            var lookup = Mock.Of<IPropertyInfoMetadataLookup>(
                f =>
                    f.GetMetadata(propInfo) == new Parameter
                                               {
                                                   required = false
                                               });

            var builder = new SimplePropertyBuilder(lookup, Mock.Of<IDestructiveTestConfiguration>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.AreEqual(default(int?), obj.nullableProperty1);
        }

#endregion
    }
}
