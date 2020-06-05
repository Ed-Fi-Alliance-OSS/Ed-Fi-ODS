// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NHibernate.Cache;
using NHibernate.Engine;
using NHibernate.Mapping;
using NHibernate.Persister.Entity;
using NHibernate.Type;
using NHibernate.Util;

namespace EdFi.Ods.Api.Common.Infrastructure.Architecture.Persisters
{
    // Addresses ODS-2964 - https://tracker.ed-fi.org/browse/ODS-2964
    //
	// Overrides the default NHibernate implementation for "Table-per-subclass, using a discriminator" mapping.
	// See https://nhibernate.info/doc/nhibernate-reference/inheritance.html#inheritance-tablepersubclass-discriminator)
	//
	// Based on NHibernate 5.1.2, this overridden implementation fixes the issue for Ed-Fi extensions of 
	// (primarily) EdOrg-derived types (e.g. School, LocalEducationAgency, etc.)
    // See NHibernate #2094 - https://github.com/nhibernate/nhibernate-core/issues/2094
    public class DiscriminatedSubclassWithDynamicComponentEntityPersister : SingleTableEntityPersister
    {
        public DiscriminatedSubclassWithDynamicComponentEntityPersister(
            PersistentClass persistentClass,
            ICacheConcurrencyStrategy cache,
            ISessionFactoryImplementor factory,
            IMapping mapping)
            : base(persistentClass, cache, factory, mapping)
        {
        }

        public override int GetSubclassPropertyTableNumber(string propertyPath)
        {
            string propertyName = StringHelper.Root(propertyPath);
            IType type = this.propertyMapping.ToType(propertyName);

            // ----------------------------------------------------------------------------------------------
            // NEW CODE for NHibernate #2094 (https://github.com/nhibernate/nhibernate-core/issues/2094)
            // ----------------------------------------------------------------------------------------------
            // If root path is a component, revert to using the full property path
            if (type.IsComponentType)
            {
                propertyName = propertyPath;
                type = this.propertyMapping.ToType(propertyPath);
            }

            // ----------------------------------------------------------------------------------------------

            if (type.IsAssociationType)
            {
                IAssociationType associationType = (IAssociationType) type;

                if (associationType.UseLHSPrimaryKey)
                    return 0;

                if (type.IsCollectionType)
                    propertyName = associationType.LHSPropertyName;
            }

            int i = System.Array.IndexOf<string>(this.SubclassPropertyNameClosure, propertyName);

            if (i != -1)
                return this.GetSubclassPropertyTableNumber(i);

            return 0;
        }
    }
}
