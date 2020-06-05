// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using EdFi.Ods.Common;
using EdFi.Ods.Tests.EdFi.Ods.Common.Serialization;
using Newtonsoft.Json;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi
{
    /// <summary>
    /// A class which represents the edfi.StaffLanguage table of the Staff aggregate in the ODS Database.
    /// </summary>
    [Serializable]
    [DataContract]
    public class StaffLanguage
    {
        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        private IList<StaffLanguageUse> _staffLanguageUses;

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------
        public StaffLanguage()
        {
            StaffLanguageUses = new List<StaffLanguageUse>();
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>

        // NOT in a reference, IS a lookup column 
        [DataMember(Name = "languageDescriptor")]
        [NaturalKeyMember]
        public string LanguageDescriptor { get; set; }

        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        [JsonProperty("_ext")]
        [JsonConverter(
            typeof(ExtensionsConverterWithAssemblyOverride),
            "Staff",
            "StaffLanguage")]
        public IDictionary Extensions { get; set; }

        [DataMember(Name = "uses")]
        public IList<StaffLanguageUse> StaffLanguageUses
        {
            get { return _staffLanguageUses; }
            set
            {
                if (value == null)
                {
                    return;
                }

                _staffLanguageUses = value;
            }
        }

        // -------------------------------------------------------------
    }
}
