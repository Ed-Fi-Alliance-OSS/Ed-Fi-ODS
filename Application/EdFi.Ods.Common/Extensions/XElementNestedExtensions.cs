// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace EdFi.Ods.Common.Extensions
{
    public static class XElementNestedExtensions
    {
        private static bool ElementsOnlyNestedOneLayer(string[] elements)
        {
            if (elements.Count() != 2)
            {
                throw new Exception(
                    string.Format(
                        "EdFi.Ods.Common.XElementExtensions.NestedValueOf extension method does not handle nesting beyond a single element depth.  You supplied {0} levels.",
                        elements.Count() - 1));
            }

            return true;
        }

        public static XElement NestedElementOrEmpty(this XElement thiXElement, string[] elements)
        {
            ElementsOnlyNestedOneLayer(elements);
            var element = thiXElement.ElementOrEmpty(elements[0]);

            return element == null || string.IsNullOrWhiteSpace(element.Value)
                ? null
                : element.ElementOrEmpty(elements[1]);
        }

        public static IEnumerable<XElement> NestedElementsOrEmpty(this XElement thisXElement, string[] elements)
        {
            ElementsOnlyNestedOneLayer(elements);
            var element = thisXElement.ElementOrEmpty(elements[0]);

            return element == null
                ? new List<XElement>()
                : element.ElementsOrEmpty(elements[1]);
        }

        public static string NestedValueOf(this XElement thisXElement, string[] elements)
        {
            ElementsOnlyNestedOneLayer(elements);
            var element = thisXElement.ElementOrEmpty(elements[0]);

            return element == null
                ? string.Empty
                : element.ElementOrEmpty(elements[1])
                         .ValueOrDefault();
        }

        public static DateTime NestedDateTimeValueOf(this XElement thisXElement, string[] elements)
        {
            ElementsOnlyNestedOneLayer(elements);
            var element = thisXElement.ElementOrEmpty(elements[0]);

            return element == null
                ? default(DateTime)
                : element.DateValueOf(elements[1]);
        }

        public static DateTime? NestedNullableDateTimeValueOf(this XElement thisXElement, string[] elements)
        {
            ElementsOnlyNestedOneLayer(elements);
            var parent = thisXElement.ElementOrEmpty(elements[0]);

            return parent == null
                ? null
                : parent.NullableDateValueOf(elements[1]);
        }

        public static short? NestedNullableShortValueOf(this XElement thisXElement, string[] elements)
        {
            ElementsOnlyNestedOneLayer(elements);
            var parent = thisXElement.ElementOrEmpty(elements[0]);

            return parent == null
                ? null
                : parent.NullableShortValueOf(elements[1]);
        }

        public static short NestedShortValueOf(this XElement thisXElement, string[] elements)
        {
            ElementsOnlyNestedOneLayer(elements);
            var parent = thisXElement.ElementOrEmpty(elements[0]);

            return parent == null
                ? default(short)
                : parent.ShortValueOf(elements[1]);
        }

        public static int NestedIntValueOf(this XElement thisXElement, string[] elements)
        {
            ElementsOnlyNestedOneLayer(elements);
            var parent = thisXElement.ElementOrEmpty(elements[0]);

            return parent == null
                ? default(int)
                : parent.IntValueOf(elements[1]);
        }

        public static int? NestedNullableIntValueOf(this XElement thisXElement, string[] elements)
        {
            ElementsOnlyNestedOneLayer(elements);
            var parent = thisXElement.ElementOrEmpty(elements[0]);

            return parent == null
                ? null
                : parent.NullableIntValueOf(elements[1]);
        }

        public static bool? NestedNullableBoolValueOf(this XElement thisXElement, string[] elements)
        {
            ElementsOnlyNestedOneLayer(elements);
            var parent = thisXElement.ElementOrEmpty(elements[0]);

            return parent == null
                ? null
                : parent.NullableBoolValueOf(elements[1]);
        }

        public static bool NestedBoolValueOf(this XElement thisXElement, string[] elements)
        {
            ElementsOnlyNestedOneLayer(elements);
            var parent = thisXElement.ElementOrEmpty(elements[0]);

            return parent == null
                ? default(bool)
                : parent.BoolValueOf(elements[1]);
        }

        public static decimal NestedDecimalValueOf(this XElement thisXElement, string[] elements)
        {
            ElementsOnlyNestedOneLayer(elements);
            var parent = thisXElement.ElementOrEmpty(elements[0]);

            return parent == null
                ? default(decimal)
                : parent.DecimalValueOf(elements[1]);
        }

        public static decimal? NestedNullableDecimalValueOf(this XElement thisXElement, string[] elements)
        {
            ElementsOnlyNestedOneLayer(elements);
            var parent = thisXElement.ElementOrEmpty(elements[0]);

            return parent == null
                ? null
                : parent.NullableDecimalValueOf(elements[1]);
        }

        public static TimeSpan NestedTimeSpanValueOf(this XElement thisXElement, string[] elements)
        {
            ElementsOnlyNestedOneLayer(elements);
            var parent = thisXElement.ElementOrEmpty(elements[0]);

            return parent == null
                ? default(TimeSpan)
                : parent.TimeSpanValueOf(elements[1]);
        }

        public static TimeSpan? NestedNullableTimeSpanValueOf(this XElement thisXElement, string[] elements)
        {
            ElementsOnlyNestedOneLayer(elements);
            var parent = thisXElement.ElementOrEmpty(elements[0]);

            return parent == null
                ? null
                : parent.NullableTimeSpanValueOf(elements[1]);
        }
    }
}
