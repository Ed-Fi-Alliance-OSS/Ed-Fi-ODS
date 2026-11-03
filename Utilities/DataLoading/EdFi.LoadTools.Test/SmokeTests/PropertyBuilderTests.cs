// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest;
using EdFi.LoadTools.SmokeTest.PropertyBuilders;
using FakeItEasy;
using Microsoft.OpenApi;
using NUnit.Framework;
using Assert = NUnit.Framework.Legacy.ClassicAssert;

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
            var builder = new ExistingResourceBuilder(dict, A.Fake<IPropertyInfoMetadataLookup>());
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

            var propInfoMetadataLookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => propInfoMetadataLookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = true
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
            var builder = new ReferencePropertyBuilder(dict, A.Fake<IPropertyInfoMetadataLookup>());
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

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = true,
                    Schema = new OpenApiSchema()
                });

            var builder = new StringPropertyBuilder(lookup);
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.IsFalse(string.IsNullOrEmpty(obj.stringProperty1));
            Assert.AreEqual(7, obj.stringProperty1.Length);
        }

#endregion

#region TimeStringPropertyBuilder tests

        [Test]
        public void TimeStringPropertyBuilder_should_set_string_properties()
        {
            DateTime result;
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("startTime");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = true,
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
            var builder = new UniqueIdPropertyBuilder(A.Fake<IPropertyInfoMetadataLookup>());
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

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = true
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
            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = false
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

            public int? schoolId { get; set; }

            public long? localEducationAgencyId { get; set; }

            public double? educationOrganizationId { get; set; }

            public DateTime dateTimeProperty1 { get; set; }

            public string startTime { get; set; }

            public string type { get; set; }

            public string class1Type { get; set; }

            public object link { get; set; }

            public string _etag { get; set; }

            public string _lastModifiedDate { get; set; }
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
            var builder = new IgnorePropertyBuilder(A.Fake<IPropertyInfoMetadataLookup>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.IsTrue(string.IsNullOrEmpty(obj.id));
        }

        [Test]
        public void IgnorePropertyBuilder_should_ignore_etag_property()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("_etag");
            var builder = new IgnorePropertyBuilder(A.Fake<IPropertyInfoMetadataLookup>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.IsTrue(string.IsNullOrEmpty(obj._etag));
        }

        [Test]
        public void IgnorePropertyBuilder_should_ignore_link_property()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("link");
            var builder = new IgnorePropertyBuilder(A.Fake<IPropertyInfoMetadataLookup>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.IsNull(obj.link);
        }

        [Test]
        public void IgnorePropertyBuilder_should_ignore_lastModifiedDate_property()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("_lastModifiedDate");
            var builder = new IgnorePropertyBuilder(A.Fake<IPropertyInfoMetadataLookup>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.IsNull(obj._lastModifiedDate);
        }

#endregion

#region SimplePropertyBuilder

        [Test]
        public void SimplePropertyBuilder_should_ignore_nullable_properties()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("nullableProperty1");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = false
                });

            var builder = new SimplePropertyBuilder(lookup, A.Fake<IDestructiveTestConfiguration>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.IsFalse(obj.nullableProperty1.HasValue);
        }

        [Test]
        public void SimplePropertyBuilder_should_generate_a_value_if_required()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("nullableProperty1");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = true,
                    Schema = new OpenApiSchema()
                });

            var builder = new SimplePropertyBuilder(lookup, A.Fake<IDestructiveTestConfiguration>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.AreNotEqual(default(int), obj.nullableProperty1);
        }

        [Test]
        public void SimplePropertyBuilder_should_not_generate_a_value_if_optional()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("nullableProperty1");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = false
                });

            var builder = new SimplePropertyBuilder(lookup, A.Fake<IDestructiveTestConfiguration>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.AreEqual(default(int?), obj.nullableProperty1);
        }

        [Test]
        public void SimplePropertyBuilder_should_handle_min_max_implicit_values()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("nullableProperty1");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = true,
                    Schema = new OpenApiSchema
                    {
                        Maximum = "9999999999.99999",
                        Minimum = "-9999999999.99999"
                    }
                });

            var builder = new SimplePropertyBuilder(lookup, A.Fake<IDestructiveTestConfiguration>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.AreNotEqual(default(int), obj.nullableProperty1);
        }

        [Test]
        public void SimplePropertyBuilder_should_handle_min_implicit_values()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("nullableProperty1");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = true,
                    Schema = new OpenApiSchema { Minimum = "-9999999999.99999" }
                });

            var builder = new SimplePropertyBuilder(lookup, A.Fake<IDestructiveTestConfiguration>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.AreNotEqual(default(int), obj.nullableProperty1);
        }

        [Test]
        public void SimplePropertyBuilder_should_handle_max_implicit_values()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("nullableProperty1");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = true,
                    Schema = new OpenApiSchema { Maximum = "9999999999.99999" }
                });

            var builder = new SimplePropertyBuilder(lookup, A.Fake<IDestructiveTestConfiguration>());
            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.AreNotEqual(default(int), obj.nullableProperty1);
        }

        [Test]
        public void SimplePropertyBuilder_should_keep_no_bounds_numeric_fallback_within_configured_max()
        {
            var propInfo = typeof(Class1).GetProperty("nullableProperty1");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = true,
                    Schema = new OpenApiSchema()
                });

            var configuration = A.Fake<IDestructiveTestConfiguration>();
            A.CallTo(() => configuration.DefaultNumericFallbackMax).Returns(5);
            A.CallTo(() => configuration.UnifiedProperties).Returns(Array.Empty<string>());

            var builder = new SimplePropertyBuilder(lookup, configuration);

            var values = Enumerable.Range(0, 7)
                .Select(
                    _ =>
                    {
                        var obj = new Class1();

                        Assert.IsTrue(builder.BuildProperty(obj, propInfo));

                        return obj.nullableProperty1.Value;
                    })
                .ToArray();

            Assert.AreEqual(new[] { 1, 2, 3, 4, 5, 1, 2 }, values);
            Assert.IsTrue(values.All(v => v <= 5));
        }
        #endregion

#region EducationOrganizationIdBuilder tests

        [Test]
        public void EducationOrganizationIdBuilder_should_use_overridden_value_when_configured()
        {
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("schoolId");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();

            var configuration = A.Fake<IDestructiveTestConfiguration>();
            A.CallTo(() => configuration.EducationOrganizationIdOverrides)
                .Returns(new Dictionary<string, int> { ["schoolId"] = 100000 });

            var builder = new EducationOrganizationIdBuilder(lookup, configuration);

            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.AreEqual(100000, obj.schoolId);
        }

        [Test]
        public void EducationOrganizationIdBuilder_should_use_edorg_safe_range_for_non_overridden_edorg_id()
        {
            var propInfo = typeof(Class1).GetProperty("schoolId");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = true,
                    Schema = new OpenApiSchema()
                });

            var configuration = A.Fake<IDestructiveTestConfiguration>();
            A.CallTo(() => configuration.EducationOrganizationIdOverrides).Returns(new Dictionary<string, int>());

            // A small generic max would put the generic 1..max fallback well below the EdOrg-safe range,
            // so an EdOrg-safe value proves the EdOrg path, not the generic fallback, produced it.
            A.CallTo(() => configuration.DefaultNumericFallbackMax).Returns(5);

            var builder = new EducationOrganizationIdBuilder(lookup, configuration);

            var values = Enumerable.Range(0, 3)
                .Select(
                    _ =>
                    {
                        var obj = new Class1();

                        Assert.IsTrue(builder.BuildProperty(obj, propInfo));

                        return obj.schoolId.Value;
                    })
                .ToArray();

            Assert.AreEqual(
                new[]
                {
                    DestructiveTestConfigurationDefaults.EducationOrganizationFallbackStart,
                    DestructiveTestConfigurationDefaults.EducationOrganizationFallbackStart + 1,
                    DestructiveTestConfigurationDefaults.EducationOrganizationFallbackStart + 2
                },
                values);
            Assert.IsTrue(values.All(v => v >= DestructiveTestConfigurationDefaults.EducationOrganizationFallbackStart));
        }

        [Test]
        public void EducationOrganizationIdBuilder_should_defer_when_non_overridden_edorg_id_publishes_bounds()
        {
            // If OpenAPI publishes numeric bounds for an EdOrg id, the EdOrg builder defers so SimplePropertyBuilder
            // can honor those bounds instead of overriding them with the EdOrg-safe range.
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("schoolId");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = true,
                    Schema = new OpenApiSchema { Minimum = "1", Maximum = "10" }
                });

            var configuration = A.Fake<IDestructiveTestConfiguration>();
            A.CallTo(() => configuration.EducationOrganizationIdOverrides).Returns(new Dictionary<string, int>());

            var builder = new EducationOrganizationIdBuilder(lookup, configuration);

            Assert.IsFalse(builder.BuildProperty(obj, propInfo));
            Assert.IsFalse(obj.schoolId.HasValue);
        }

        [Test]
        public void Builder_chain_should_resolve_non_overridden_edorg_id_through_education_organization_id_builder()
        {
            // SmokeTestsDestructiveSdkModule registers EducationOrganizationIdBuilder before SimplePropertyBuilder,
            // and PostTest uses the first builder that handles the property (Any(...) short-circuits). The EdOrg
            // builder must therefore claim a non-overridden EdOrg id so SimplePropertyBuilder never generates it
            // from the generic 1..max range, which would reintroduce the populated-template collision risk.
            var propInfo = typeof(Class1).GetProperty("schoolId");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = true,
                    Schema = new OpenApiSchema()
                });

            var configuration = A.Fake<IDestructiveTestConfiguration>();
            A.CallTo(() => configuration.EducationOrganizationIdOverrides).Returns(new Dictionary<string, int>());
            A.CallTo(() => configuration.DefaultNumericFallbackMax).Returns(5);
            A.CallTo(() => configuration.UnifiedProperties).Returns(Array.Empty<string>());

            var builders = new IPropertyBuilder[]
            {
                new EducationOrganizationIdBuilder(lookup, configuration),
                new SimplePropertyBuilder(lookup, configuration)
            };

            var obj = new Class1();

            Assert.IsTrue(builders.Any(b => b.BuildProperty(obj, propInfo)));
            Assert.GreaterOrEqual(
                obj.schoolId.Value, DestructiveTestConfigurationDefaults.EducationOrganizationFallbackStart);
        }

        [Test]
        public void EducationOrganizationIdBuilder_should_use_edorg_safe_range_when_only_minimum_is_published()
        {
            // A min-only bound gives SimplePropertyBuilder no maximum to honor, so it would fall back to the
            // generic 1..max range. The EdOrg builder must keep the value in the EdOrg-safe range instead.
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("schoolId");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = true,
                    Schema = new OpenApiSchema { Minimum = "1" }
                });

            var configuration = A.Fake<IDestructiveTestConfiguration>();
            A.CallTo(() => configuration.EducationOrganizationIdOverrides).Returns(new Dictionary<string, int>());

            var builder = new EducationOrganizationIdBuilder(lookup, configuration);

            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.AreEqual(DestructiveTestConfigurationDefaults.EducationOrganizationFallbackStart, obj.schoolId.Value);
            Assert.Greater(obj.schoolId.Value, DestructiveTestConfigurationDefaults.DefaultNumericFallbackMax);
        }

        [Test]
        public void EducationOrganizationIdBuilder_should_honor_published_minimum_above_the_edorg_safe_start()
        {
            // When a parseable minimum exceeds the EdOrg-safe start, generated values must honor it while staying
            // monotonic across calls. A single call masks the bug; multiple EdOrg ids must not collide on the
            // minimum, so consecutive values have to advance past it rather than repeat it.
            var propInfo = typeof(Class1).GetProperty("schoolId");

            const int publishedMinimum = DestructiveTestConfigurationDefaults.EducationOrganizationFallbackStart + 50000;

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = true,
                    Schema = new OpenApiSchema { Minimum = publishedMinimum.ToString() }
                });

            var configuration = A.Fake<IDestructiveTestConfiguration>();
            A.CallTo(() => configuration.EducationOrganizationIdOverrides).Returns(new Dictionary<string, int>());

            var builder = new EducationOrganizationIdBuilder(lookup, configuration);

            var values = Enumerable.Range(0, 3)
                .Select(
                    _ =>
                    {
                        var obj = new Class1();

                        Assert.IsTrue(builder.BuildProperty(obj, propInfo));

                        return obj.schoolId.Value;
                    })
                .ToArray();

            Assert.AreEqual(new[] { publishedMinimum, publishedMinimum + 1, publishedMinimum + 2 }, values);
            Assert.IsTrue(values.All(v => v >= publishedMinimum));
        }

        [Test]
        public void EducationOrganizationIdBuilder_should_use_edorg_safe_range_when_bounds_are_unparseable()
        {
            // Unparseable bound strings are not usable by SimplePropertyBuilder, so they must not trigger deferral;
            // the EdOrg-safe range still applies.
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("schoolId");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = true,
                    Schema = new OpenApiSchema { Minimum = "not-a-number", Maximum = "also-not-a-number" }
                });

            var configuration = A.Fake<IDestructiveTestConfiguration>();
            A.CallTo(() => configuration.EducationOrganizationIdOverrides).Returns(new Dictionary<string, int>());

            var builder = new EducationOrganizationIdBuilder(lookup, configuration);

            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.AreEqual(DestructiveTestConfigurationDefaults.EducationOrganizationFallbackStart, obj.schoolId.Value);
        }

        [Test]
        public void EducationOrganizationIdBuilder_should_defer_when_only_maximum_is_published()
        {
            // A parseable maximum is a real ceiling SimplePropertyBuilder honors, so the EdOrg builder defers.
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("schoolId");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = true,
                    Schema = new OpenApiSchema { Maximum = "10" }
                });

            var configuration = A.Fake<IDestructiveTestConfiguration>();
            A.CallTo(() => configuration.EducationOrganizationIdOverrides).Returns(new Dictionary<string, int>());

            var builder = new EducationOrganizationIdBuilder(lookup, configuration);

            Assert.IsFalse(builder.BuildProperty(obj, propInfo));
            Assert.IsFalse(obj.schoolId.HasValue);
        }

        [Test]
        public void EducationOrganizationIdBuilder_should_apply_override_to_nullable_long_property()
        {
            // The configured override is an int; a nullable long EdOrg id must accept it via type conversion
            // rather than throwing on the boxed int.
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("localEducationAgencyId");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();

            var configuration = A.Fake<IDestructiveTestConfiguration>();
            A.CallTo(() => configuration.EducationOrganizationIdOverrides)
                .Returns(new Dictionary<string, int> { ["localEducationAgencyId"] = 255901 });

            var builder = new EducationOrganizationIdBuilder(lookup, configuration);

            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.AreEqual(255901L, obj.localEducationAgencyId.Value);
        }

        [Test]
        public void EducationOrganizationIdBuilder_should_apply_override_to_nullable_double_property()
        {
            // The configured override is an int; a nullable double EdOrg id must accept it via type conversion
            // rather than throwing on the boxed int.
            var obj = new Class1();
            var propInfo = typeof(Class1).GetProperty("educationOrganizationId");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();

            var configuration = A.Fake<IDestructiveTestConfiguration>();
            A.CallTo(() => configuration.EducationOrganizationIdOverrides)
                .Returns(new Dictionary<string, int> { ["educationOrganizationId"] = 255901 });

            var builder = new EducationOrganizationIdBuilder(lookup, configuration);

            Assert.IsTrue(builder.BuildProperty(obj, propInfo));
            Assert.AreEqual(255901d, obj.educationOrganizationId.Value);
        }

        [Test]
        public void Builder_chain_should_set_nullable_long_edorg_id_when_deferred_with_published_maximum()
        {
            // A long? EdOrg id that publishes a parseable maximum defers to SimplePropertyBuilder, which must set
            // the value as the property's underlying type rather than throwing on a boxed int.
            var propInfo = typeof(Class1).GetProperty("localEducationAgencyId");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = true,
                    Schema = new OpenApiSchema { Maximum = "100" }
                });

            var configuration = A.Fake<IDestructiveTestConfiguration>();
            A.CallTo(() => configuration.EducationOrganizationIdOverrides).Returns(new Dictionary<string, int>());
            A.CallTo(() => configuration.DefaultNumericFallbackMax).Returns(5);
            A.CallTo(() => configuration.UnifiedProperties).Returns(Array.Empty<string>());

            var builders = new IPropertyBuilder[]
            {
                new EducationOrganizationIdBuilder(lookup, configuration),
                new SimplePropertyBuilder(lookup, configuration)
            };

            var obj = new Class1();

            Assert.IsTrue(builders.Any(b => b.BuildProperty(obj, propInfo)));
            Assert.IsTrue(obj.localEducationAgencyId.HasValue);
            Assert.AreEqual(100L, obj.localEducationAgencyId.Value);
        }

        [Test]
        public void Builder_chain_should_set_nullable_double_edorg_id_when_deferred_with_published_maximum()
        {
            // A double? EdOrg id that publishes a parseable maximum defers to SimplePropertyBuilder, which must set
            // the value as the property's underlying type rather than throwing on a boxed int.
            var propInfo = typeof(Class1).GetProperty("educationOrganizationId");

            var lookup = A.Fake<IPropertyInfoMetadataLookup>();
            A.CallTo(() => lookup.GetMetadata(propInfo))
                .Returns(new OpenApiParameter
                {
                    Required = true,
                    Schema = new OpenApiSchema { Maximum = "100" }
                });

            var configuration = A.Fake<IDestructiveTestConfiguration>();
            A.CallTo(() => configuration.EducationOrganizationIdOverrides).Returns(new Dictionary<string, int>());
            A.CallTo(() => configuration.DefaultNumericFallbackMax).Returns(5);
            A.CallTo(() => configuration.UnifiedProperties).Returns(Array.Empty<string>());

            var builders = new IPropertyBuilder[]
            {
                new EducationOrganizationIdBuilder(lookup, configuration),
                new SimplePropertyBuilder(lookup, configuration)
            };

            var obj = new Class1();

            Assert.IsTrue(builders.Any(b => b.BuildProperty(obj, propInfo)));
            Assert.IsTrue(obj.educationOrganizationId.HasValue);
            Assert.AreEqual(100d, obj.educationOrganizationId.Value);
        }

#endregion
    }
}
