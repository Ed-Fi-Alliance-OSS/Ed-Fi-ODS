// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;

namespace EdFi.LoadTools.Engine
{
    public static class Constants
    {
        public const string TypeRegex =
            @"^EXTENSION-(?<TypeName>[A-Za-z]+)$";

        public const string IdentityRegex =
            @"^(?<TypeName>[A-Za-z]+)Identity$";

        public const string IdentityTypeRegex =
            @"^(?<TypeName>[A-Za-z]+)IdentityType$";

        public const string LookupRegex =
            @"^(?<TypeName>[A-Za-z]+)Lookup$";

        public const string LookupTypeRegex =
            @"^(?<TypeName>[A-Za-z]+)LookupType$";

        public const string ReferenceRegex =
            @"^(?<TypeName>[A-Za-z]+)Reference";

        public const string SchoolYearRegex =
            @"^[0-9]{4}-(?<Year>[0-9]{4})$";

        public const string XsdRegex =
            @"(?<XsdPath>[A-Za-z_\-\.0-9]*)EXTENSION-Interchange-(?<InterchangeType>[A-Za-z]+)-Extension.xsd";

        public const string InterchangeNameRegex =
            @"^(?<InterchangeType>Interchange[A-Za-z]+)";

        public static readonly AtomicTypePairs[] AtomicTypes =
        {
            new AtomicTypePairs(XmlTypes.Boolean, JsonTypes.Boolean), new AtomicTypePairs(XmlTypes.Date, JsonTypes.Date),
            new AtomicTypePairs(XmlTypes.DateTime, JsonTypes.DateTime), new AtomicTypePairs(XmlTypes.Decimal, JsonTypes.Number),
            new AtomicTypePairs(XmlTypes.Int, JsonTypes.Integer), new AtomicTypePairs(XmlTypes.Integer, JsonTypes.Integer),
            new AtomicTypePairs(XmlTypes.PositiveInteger, JsonTypes.Integer), new AtomicTypePairs(XmlTypes.Id, JsonTypes.String),
            new AtomicTypePairs(XmlTypes.String, JsonTypes.String), new AtomicTypePairs(XmlTypes.Token, JsonTypes.String),
            new AtomicTypePairs(XmlTypes.Token, JsonTypes.Integer), new AtomicTypePairs(XmlTypes.Year, JsonTypes.Integer),
            new AtomicTypePairs(XmlTypes.Duration, JsonTypes.String), new AtomicTypePairs(XmlTypes.Time, JsonTypes.String)
        };

        public static readonly string[] JsonAtomicTypes = AtomicTypes.Select(x => x.Json).ToArray();
        public static readonly string[] XmlAtomicTypes = AtomicTypes.Select(x => x.Xml).ToArray();

        public struct AtomicTypePairs
        {
            public string Xml { get; }

            public string Json { get; }

            public AtomicTypePairs(string xml, string json)
            {
                Xml = xml;
                Json = json;
            }
        }

        public static class JsonTypes
        {
            public const string Boolean = "boolean";
            public const string DateTime = "date-time";
            public const string Date = "date";
            public const string Number = "number";
            public const string Integer = "integer";
            public const string String = "string";
        }

        public static class XmlTypes
        {
            public const string Boolean = "Boolean";
            public const string Date = "Date";
            public const string DateTime = "DateTime";
            public const string Decimal = "Decimal";
            public const string Int = "Int";
            public const string Integer = "Integer";
            public const string PositiveInteger = "PositiveInteger";
            public const string Id = "Id";
            public const string String = "String";
            public const string Token = "Token";
            public const string Duration = "Duration";
            public const string Year = "GYear";
            public const string Time = "Time";
        }
    }
}
