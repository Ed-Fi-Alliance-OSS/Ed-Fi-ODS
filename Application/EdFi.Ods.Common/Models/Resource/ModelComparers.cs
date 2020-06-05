// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models.Resource
{
    public class ModelComparers
    {
        public static readonly IEqualityComparer<Entity> Entity = new EntityEqualityComparer();
        public static readonly IEqualityComparer<ResourceClassBase> Resource = new ResourceEqualityComparer();
        public static IEqualityComparer<ResourceProperty> ResourceProperty = new ResourcePropertyEqualityComparer();
        public static IEqualityComparer<ResourceProperty> ResourcePropertyNameOnly =
            new ResourcePropertyNameOnlyEqualityComparer();
        public static IEqualityComparer<EmbeddedObject> EmbeddedObject = new EmbeddedObjectEqualityComparer();
        public static IEqualityComparer<Collection> Collection = new CollectionEqualityComparer();
        public static IEqualityComparer<Reference> Reference = new ReferenceEqualityComparer();
        public static IEqualityComparer<Reference> ReferenceTypeNameOnly = new ReferenceTypeNameOnlyComparer();
        public static IEqualityComparer<AssociationView> AssociationView = new AssociationViewEqualityComparer();
        public static IEqualityComparer<Association> Association = new AssociationEqualityComparer();
        public static IEqualityComparer<AssociationProperty> AssociationProperty = new AssociationPropertyEqualityComparer();
        public static IEqualityComparer<AssociationProperty> AssociationPropertyNameOnly =
            new AssociationPropertyNameOnlyEqualityComparer();
        public static IEqualityComparer<EntityProperty> EntityProperty = new EntityPropertyEqualityComparer();
        public static IEqualityComparer<EntityProperty> EntityPropertyNameOnly = new EntityPropertyNameOnlyEqualityComparer();
        public static IEqualityComparer<DomainPropertyBase> DomainPropertyNameOnly = new DomainPropertyNameOnlyEqualityComparer();

        private class EntityEqualityComparer : IEqualityComparer<Entity>
        {
            /// <summary>
            /// Determines whether the specified objects are equal.
            /// </summary>
            /// <returns>
            /// true if the specified objects are equal; otherwise, false.
            /// </returns>
            /// <param name="x">The first object of type <paramref name="T"/> to compare.</param><param name="y">The second object of type <paramref name="T"/> to compare.</param>
            public bool Equals(Entity x, Entity y)
            {
                if (x == null && y == null)
                {
                    return true;
                }

                if (x == null || y == null)
                {
                    return false;
                }

                return x.FullName.Equals(y.FullName);
            }

            /// <summary>
            /// Returns a hash code for the specified object.
            /// </summary>
            /// <returns>
            /// A hash code for the specified object.
            /// </returns>
            /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param><exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.</exception>
            public int GetHashCode(Entity obj)
            {
                if (obj == null)
                {
                    return 0;
                }

                unchecked
                {
                    int hash = 17;

                    hash = hash * 23 + obj.Schema.GetHashCode();
                    hash = hash * 23 + obj.Name.GetHashCode();

                    return hash;
                }
            }
        }

        private class ResourceEqualityComparer : IEqualityComparer<ResourceClassBase>
        {
            /// <summary>
            /// Determines whether the specified objects are equal.
            /// </summary>
            /// <returns>
            /// true if the specified objects are equal; otherwise, false.
            /// </returns>
            /// <param name="x">The first object of type <paramref name="T"/> to compare.</param><param name="y">The second object of type <paramref name="T"/> to compare.</param>
            public bool Equals(ResourceClassBase x, ResourceClassBase y)
            {
                if (x == null && y == null)
                {
                    return true;
                }

                if (x == null || y == null)
                {
                    return false;
                }

                return x.FullName.Equals(y.FullName);
            }

            /// <summary>
            /// Returns a hash code for the specified object.
            /// </summary>
            /// <returns>
            /// A hash code for the specified object.
            /// </returns>
            /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param><exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.</exception>
            public int GetHashCode(ResourceClassBase obj)
            {
                if (obj == null)
                {
                    return 0;
                }

                unchecked
                {
                    int hash = 17;

                    hash = hash * 23 + obj.FullName.GetHashCode();

                    return hash;
                }
            }
        }

        public class NameContextEqualityComparerBase<T> : IEqualityComparer<T>
            where T : IHasNameContext
        {
            /// <summary>
            /// Determines whether the specified objects are equal.
            /// </summary>
            /// <returns>
            /// true if the specified objects are equal; otherwise, false.
            /// </returns>
            /// <param name="x">The first object of type <paramref name="T"/> to compare.</param><param name="y">The second object of type <paramref name="T"/> to compare.</param>
            public bool Equals(T x, T y)
            {
                if (x == null && y == null)
                {
                    return true;
                }

                if (x == null || y == null)
                {
                    return false;
                }

                return string.Equals(x.PropertyName, y.PropertyName, StringComparison.InvariantCultureIgnoreCase)
                       && string.Equals(
                           x.ParentFullName.Name, y.ParentFullName.Name, StringComparison.InvariantCultureIgnoreCase);
            }

            /// <summary>
            /// Returns a hash code for the specified object.
            /// </summary>
            /// <returns>
            /// A hash code for the specified object.
            /// </returns>
            /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param><exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.</exception>
            public int GetHashCode(T obj)
            {
                return (obj.ParentFullName.Name.ToLower() + "." + obj.PropertyName.ToLower()).GetHashCode();
            }
        }

        public class PropertyNameOnlyNameContextEqualityComparerBase<T> : IEqualityComparer<T>
            where T : IHasNameContext
        {
            /// <summary>
            /// Determines whether the specified objects are equal.
            /// </summary>
            /// <returns>
            /// true if the specified objects are equal; otherwise, false.
            /// </returns>
            /// <param name="x">The first object of type <paramref name="T"/> to compare.</param><param name="y">The second object of type <paramref name="T"/> to compare.</param>
            public bool Equals(T x, T y)
            {
                if (x == null && y == null)
                {
                    return true;
                }

                if (x == null || y == null)
                {
                    return false;
                }

                return string.Equals(x.PropertyName, y.PropertyName, StringComparison.InvariantCultureIgnoreCase);
            }

            /// <summary>
            /// Returns a hash code for the specified object.
            /// </summary>
            /// <returns>
            /// A hash code for the specified object.
            /// </returns>
            /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param><exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.</exception>
            public int GetHashCode(T obj)
            {
                return obj.PropertyName.GetHashCode();
            }
        }

        public class ResourcePropertyNameOnlyComparer : IEqualityComparer<ResourceProperty>
        {
            /// <summary>
            /// Determines whether the specified objects are equal.
            /// </summary>
            /// <returns>
            /// true if the specified objects are equal; otherwise, false.
            /// </returns>
            /// <param name="x">The first object of type <paramref name="T"/> to compare.</param><param name="y">The second object of type <paramref name="T"/> to compare.</param>
            public bool Equals(ResourceProperty x, ResourceProperty y)
            {
                if (x == null && y == null)
                {
                    return true;
                }

                if (x == null || y == null)
                {
                    return false;
                }

                return string.Equals(x.PropertyName, y.PropertyName, StringComparison.InvariantCultureIgnoreCase);
            }

            /// <summary>
            /// Returns a hash code for the specified object.
            /// </summary>
            /// <returns>
            /// A hash code for the specified object.
            /// </returns>
            /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param><exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.</exception>
            public int GetHashCode(ResourceProperty obj)
            {
                return obj.PropertyName.ToLower()
                    .GetHashCode();
            }
        }

        public class ReferenceTypeNameOnlyComparer : IEqualityComparer<Reference>
        {
            /// <summary>
            /// Determines whether the specified objects are equal.
            /// </summary>
            /// <returns>
            /// true if the specified objects are equal; otherwise, false.
            /// </returns>
            /// <param name="x">The first object of type <paramref name="T"/> to compare.</param><param name="y">The second object of type <paramref name="T"/> to compare.</param>
            public bool Equals(Reference x, Reference y)
            {
                if (x == null && y == null)
                {
                    return true;
                }

                if (x == null || y == null)
                {
                    return false;
                }

                return string.Equals(x.ReferenceTypeName, y.ReferenceTypeName, StringComparison.InvariantCultureIgnoreCase);
            }

            /// <summary>
            /// Returns a hash code for the specified object.
            /// </summary>
            /// <returns>
            /// A hash code for the specified object.
            /// </returns>
            /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param><exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.</exception>
            public int GetHashCode(Reference obj)
            {
                return obj.ReferenceTypeName.GetHashCode();
            }
        }

        public class AssociationEqualityComparer : IEqualityComparer<Association>
        {
            private readonly AssociationPropertyEqualityComparer _entityComparer = new AssociationPropertyEqualityComparer();

            /// <summary>
            /// Determines whether the specified objects are equal.
            /// </summary>
            /// <returns>
            /// true if the specified objects are equal; otherwise, false.
            /// </returns>
            /// <param name="x">The first object of type <paramref name="T"/> to compare.</param><param name="y">The second object of type <paramref name="T"/> to compare.</param>
            public bool Equals(Association x, Association y)
            {
                if (x == null && y == null)
                {
                    return true;
                }

                if (x == null || y == null)
                {
                    return false;
                }

                if (x == y)
                {
                    return true;
                }

                if (x.PrimaryEntityFullName != y.PrimaryEntityFullName
                    || x.SecondaryEntityFullName != y.SecondaryEntityFullName
                    || x.PrimaryEntityAssociationProperties.Length != y.PrimaryEntityAssociationProperties.Length
                    || x.SecondaryEntityAssociationProperties.Length != y.SecondaryEntityAssociationProperties.Length
                    || x.PrimaryEntityAssociationProperties.Where(
                            (p, i) => !_entityComparer.Equals(p, y.PrimaryEntityAssociationProperties[i]))
                        .Any()
                    || x.SecondaryEntityAssociationProperties.Where(
                            (p, i) => !_entityComparer.Equals(p, y.SecondaryEntityAssociationProperties[i]))
                        .Any()
                    || x.IsIdentifying != y.IsIdentifying)
                {
                    return false;
                }

                return true;
            }

            /// <summary>
            /// Returns a hash code for the specified object.
            /// </summary>
            /// <returns>
            /// A hash code for the specified object.
            /// </returns>
            /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param><exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.</exception>
            public int GetHashCode(Association obj)
            {
                unchecked
                {
                    int hash = 17;
                    hash = hash * 23 + obj.PrimaryEntityFullName.GetHashCode();
                    hash = hash * 23 + obj.SecondaryEntityFullName.GetHashCode();

                    foreach (var property in obj.PrimaryEntityAssociationProperties)
                    {
                        hash = hash * 23 + property.PropertyName.GetHashCode();
                    }

                    foreach (var property in obj.SecondaryEntityAssociationProperties)
                    {
                        hash = hash * 23 + property.PropertyName.GetHashCode();
                    }

                    return hash;
                }
            }
        }

        public class ResourcePropertyEqualityComparer
            : NameContextEqualityComparerBase<ResourceProperty> { }

        public class ResourcePropertyNameOnlyEqualityComparer
            : PropertyNameOnlyNameContextEqualityComparerBase<ResourceProperty> { }

        public class EmbeddedObjectEqualityComparer
            : NameContextEqualityComparerBase<EmbeddedObject> { }

        public class CollectionEqualityComparer
            : NameContextEqualityComparerBase<Collection> { }

        public class ReferenceEqualityComparer
            : NameContextEqualityComparerBase<Reference> { }

        public class AssociationViewEqualityComparer
            : NameContextEqualityComparerBase<AssociationView> { }

        public class AssociationPropertyEqualityComparer
            : NameContextEqualityComparerBase<AssociationProperty> { }

        public class AssociationPropertyNameOnlyEqualityComparer
            : PropertyNameOnlyNameContextEqualityComparerBase<AssociationProperty> { }

        public class EntityPropertyEqualityComparer
            : NameContextEqualityComparerBase<EntityProperty> { }

        public class EntityPropertyNameOnlyEqualityComparer
            : PropertyNameOnlyNameContextEqualityComparerBase<EntityProperty> { }

        public class DomainPropertyNameOnlyEqualityComparer
            : PropertyNameOnlyNameContextEqualityComparerBase<DomainPropertyBase> { }
    }
}
