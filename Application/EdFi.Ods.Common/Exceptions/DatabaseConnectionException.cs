// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EdFi.Ods.Common.Exceptions
{
    public class DatabaseConnectionException : InternalServerErrorException
    {
        // Fields containing override values for Problem Details
        private const string TypePart = "database-connection";
        private const string TitleText = "Database Connection Problem";
        private const string DefaultDatabaseConnectionDetail = "There was a problem communicating with the database.";

        public DatabaseConnectionException(string message)
            : base(DefaultDatabaseConnectionDetail, message) { }

        public DatabaseConnectionException(string message, Exception inner)
            : base(DefaultDatabaseConnectionDetail, message, inner) { }

        // ---------------------------
        //  Boilerplate for overrides
        // ---------------------------
        public override string Title { get => TitleText; }
    
        protected override IEnumerable<string> GetTypeParts()
        {
            foreach (var part in base.GetTypeParts())
            {
                yield return part;
            }

            yield return TypePart;
        }
        // ---------------------------
    }
}
