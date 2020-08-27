// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common
{
    public class InterchangeFileFormat : LegacyEnumeration<InterchangeFileFormat, string>
    {
        public static readonly InterchangeFileFormat TextXml = new InterchangeFileFormat("text/xml");
        public static readonly InterchangeFileFormat ApplicationXml = new InterchangeFileFormat("application/xml");

        private InterchangeFileFormat(string name)
        {
            Name = name;
        }

        public override string Id
        {
            get { return Name; }
        }

        public string Name { get; }

        public static InterchangeFileFormat GetByName(string name)
        {
            return GetValues()
               .SingleOrDefault(x => x.Name.EqualsIgnoreCase(name));
        }
    }
}
