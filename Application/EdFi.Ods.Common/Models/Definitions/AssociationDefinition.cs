// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models.Definitions
{
    public class AssociationDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssociationDefinition" /> class.
        /// </summary>
        public AssociationDefinition() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssociationDefinition"/> class.
        /// </summary>
        /// <param name="fullName">The fully qualified name of the association.</param>
        /// <param name="cardinality">The <see cref="Cardinality"/> of the relationship.</param>
        /// <param name="primaryEntityFullName">The fully qualified name of the primary entity.</param>
        /// <param name="primaryEntityProperties">The primary entity's properties in the association.</param>
        /// <param name="secondaryEntityFullName">The fully qualified name of the secondary entity.</param>
        /// <param name="secondaryEntityProperties">The secondary entity's properties in the association.</param>
        /// <param name="isIdentifying">Indicates whether or not the association participates in the identity of the secondary entity.</param>
        /// <param name="isRequired">Indicates whether or not the association is required (identifying associations must be required).</param>
        /// <param name="constraintNameByDatabaseEngine"></param>
        public AssociationDefinition(
            FullName fullName,
            Cardinality cardinality,
            FullName primaryEntityFullName,
            EntityPropertyDefinition[] primaryEntityProperties,
            FullName secondaryEntityFullName,
            EntityPropertyDefinition[] secondaryEntityProperties,
            bool isIdentifying,
            bool isRequired,
            IDictionary<string,string> constraintNameByDatabaseEngine = null)
        {
            FullName = fullName;
            Cardinality = cardinality;
            PrimaryEntityFullName = primaryEntityFullName;
            PrimaryEntityProperties = primaryEntityProperties;
            SecondaryEntityFullName = secondaryEntityFullName;
            SecondaryEntityProperties = secondaryEntityProperties;
            IsIdentifying = isIdentifying;
            IsRequired = isRequired;

            ConstraintNames = constraintNameByDatabaseEngine ??
                              new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
        }

        public FullName FullName { get; set; }

        public Cardinality Cardinality { get; set; }

        public FullName PrimaryEntityFullName { get; set; }

        public EntityPropertyDefinition[] PrimaryEntityProperties { get; set; }

        public FullName SecondaryEntityFullName { get; set; }

        public EntityPropertyDefinition[] SecondaryEntityProperties { get; set; }

        public bool IsIdentifying { get; set; }

        public bool IsRequired { get; set; }

        public IDictionary<string, string> ConstraintNames { get; set; }
    }
}
