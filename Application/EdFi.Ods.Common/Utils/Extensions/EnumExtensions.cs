// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.Contracts;

namespace EdFi.Ods.Common.Utils.Extensions
{
    /// <summary>
    /// Extension methods for enumerations.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Tests whether a <b>non-flag</b> enumeration value is one of the given set of 2 or more enumeration
        /// values.
        /// </summary>
        /// <remarks>The reason the parameters are two values, and then a param array of values rather than
        /// simply a param array of values is to avoid a signature collision with the Flag enum verions of
        /// In if a person were to call this method with only a single test value. This method signature
        /// avoids that potential collision by excluding calling with only a single test value, which would
        /// be better done by a simple equality test instead of using this method.</remarks>
        /// <example>var myColor = Colors.Orange;
        /// bool isPrimaryColor = myColor.In(Colors.Red, Colors.Green, Colors.Blue);</example>
        /// <param name="anEnumValue">The enum value being tested.</param>
        /// <param name="value1">A value in the set of values anEnumValue will be tested against.</param>
        /// <param name="value2">A value in the set of values anEnumValue will be tested against.</param>
        /// <param name="additionalValues">More values in the set of values anEnumValue will be tested against.</param>
        /// <returns><b>true</b> if the specified value is one of the specified set of values, otherwise <b>false</b>.</returns>
        public static bool In(this Enum anEnumValue, Enum value1, Enum value2, params Enum[] additionalValues)
        {
            if (anEnumValue.Equals(value1) || anEnumValue.Equals(value2))
            {
                return true;
            }

            foreach (var value in additionalValues)
            {
                if (anEnumValue.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Tests whether the set of enum <b>Flag</b> values (value) contains all the specified set of enum flag values (flags).
        /// </summary>
        /// <example>var myFeatures = Features.NativeBorn | Features.BlondeHair;
        /// bool answer = qualifyingFeatures.In(myFeatures);
        /// bool canBePresident = (Features.NativeBorn | Features.OlderThan35 | Features.Resident14Years).In(myFeatures);</example>
        /// <param name="flags">The enum flag set value against which inclusion will be tested.</param>
        /// <param name="values">The enum flag set values being tested for inclusion.</param>
        /// <returns><b>true</b> if the specified flags are contained within value, otherwise <b>false</b>.</returns>
        public static bool In(this Enum flags, Enum values)
        {
            long value64 = Convert.ToInt64(values);
            long flags64 = Convert.ToInt64(flags);
            return (value64 & flags64) == flags64;
        }

        /// <summary>
        /// Tests whether the set of enum flag values contains at least one of the flags in the specified set of enum flag values.
        /// </summary>
        /// <example>bool canRideRollerCoaster = (Features.TooShort | Features.TooHeavy | Features.ToAfraid).In(myFeatures);</example>
        /// <param name="flags">The enum flag set value against which intersection will be tested.</param>
        /// <param name="value">The enum flag set value being tested for intersection.</param>
        /// <returns><b>true</b> if the specified flags intersect value, otherwise <b>false</b>.</returns>
        public static bool Intersects(this Enum value, Enum flags)
        {
            long value64 = Convert.ToInt64(value);
            long flags64 = Convert.ToInt64(flags);
            return (value64 & flags64) != 0;
        }

        /// <summary>
        /// Returns the enum value having a name that matches the given string value,
        /// or the string value with all space characters removed.
        /// </summary>
        /// <example>MyEnum enumValue = stringValue.ToEnum&lt;MyEnum&gt;();</example>
        /// <remarks>
        /// Throws ArgumentException if the given type is not an Enum, or
        /// if none of the TEnum's values have a name matching the given string.
        /// </remarks>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The string enum name value.</param>
        /// <returns>The enum value whose name matches the given string.</returns>
        public static TEnum ToEnum<TEnum>(this string value)
            where TEnum : struct
        {
            Contract.Requires(!string.IsNullOrEmpty(value));

            return ToEnum<TEnum>(value, false);
        }

        public static TEnum ToEnum<TEnum>(this string value, bool ignoreCase)
            where TEnum : struct
        {
            var type = typeof(TEnum);

            if (!type.IsEnum)
            {
                throw new ArgumentException("Type provided must be an Enum.", "TEnum");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return (TEnum) Enum.Parse(
                type,
                value.Replace(" ", "")
                     .Trim());
        }

        /// <summary>
        /// Returns the flag enum value composed of the enum values associated with the
        /// specified array of name strings.
        /// </summary>
        /// <remarks>
        /// Throws ArgumentException if the given type is not an Enum, or
        /// if none of the TEnum's values have a name matching the given string.
        /// </remarks>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The string enum name values.</param>
        /// <returns>The enum value whose name matches the given string.</returns>
        public static TEnum ToEnum<TEnum>(this string[] values)
            where TEnum : struct
        {
            var type = typeof(TEnum);

            if (type.IsEnum)
            {
                string value = string.Join(",", values);
                TEnum tmp = (TEnum) Enum.Parse(type, value); // TODO should this be changed to value.Replace(" ","") ?
                return tmp;
            }

            throw new ArgumentException();
        }

        /// <summary>
        /// Retrieves a string array of the Bitmapped values in an enum
        /// </summary>
        /// <param name="value">an arbitrary enumerated value</param>
        /// <returns>one,two,three</returns>
        public static string[] ToStrings(this Enum value)
        {
            return value.ToString()
                        .Split(
                             new[]
                             {
                                 ',', ' '
                             },
                             StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Determines whether the specified value is defined.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     <c>true</c> if the specified value is defined; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDefined<TAttribute>(this object value)
            where TAttribute : Attribute
        {
            try
            {
                return Enum.IsDefined(typeof(TAttribute), value);
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        /// <summary>
        /// Tries the parse.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="ret">The ret.</param>
        /// <returns></returns>
        public static bool TryParse<TEnum>(this string value, out TEnum ret)
        {
            ret = default(TEnum);

            try
            {
                ret = (TEnum) Enum.Parse(typeof(TEnum), value);
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }

            return true;
        }

        public static string GetName<TEnum>(this TEnum value)
        {
            return Enum.GetName(typeof(TEnum), value);
        }
    }
}
