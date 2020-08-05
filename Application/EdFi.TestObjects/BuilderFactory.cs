// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.TestObjects.Builders;

namespace EdFi.TestObjects
{
    public class BuilderFactory
    {
        private static readonly List<Func<IValueBuilder>> _default = new List<Func<IValueBuilder>>();
        private static readonly object _lock = new object();

        /// <summary>
        /// Provides a static delegate for obtaining the <see cref="IActivator"/> to be used 
        /// by the builder when adding builders using the generic overloads only supplying the type.
        /// </summary>
        public static Func<IActivator> Activator = () => _systemActivator;
        private static readonly SystemActivator _systemActivator = new SystemActivator();
        private readonly List<Func<IValueBuilder>> _append = new List<Func<IValueBuilder>>();
        private readonly List<Func<IValueBuilder>> _prepend = new List<Func<IValueBuilder>>();

        public IValueBuilder[] GetBuilders()
        {
            lock (_lock)
            {
                if (_default.Count == 0)
                {
                    SetDefaults();
                }
            }

            var reversePrepend = Enumerable.Reverse(_prepend)
                                           .ToArray();

            var builders = reversePrepend
                          .Union(_default)
                          .Union(_append)
                          .Select(x => x())
                          .ToArray();

            return builders;
        }

        private static void SetDefaults()
        {
            //_default.Add(() => new IgnoreAttributeSkipper());
            //_default.Add(() => new UpdatePropertySkipper());
            //_default.Add(() => new FixedLengthStringValueBuilder());
            //_default.Add(() => new RangeConstrainedFloatingPointValueBuilder());
            //_default.Add(() => new GuidBuilder());
            //_default.Add(() => new BooleanBuilder());
            //_default.Add(() => new EnumBuilder());
            //_default.Add(() => new DateTimeBuilder());
            //_default.Add(() => new TimeSpanBuilder());
            //_default.Add(() => new IncrementingNumericValueBuilder());
            //_default.Add(() => new OpenGenericTypeBuilder());
            //_default.Add(() => new StringValueBuilder());
            //_default.Add(() => new ObjectValueBuilder());

            ////Collections
            //_default.Add(() => new HashtableBuilder());
            //_default.Add(() => new IDictionaryBuilder());
            //_default.Add(() => new IEnumerableBuilder());
            //_default.Add(() => new KeyValuePairBuilder());

            _default.Add(
                () => Activator()
                   .CreateInstance<IgnoreAttributeSkipper>());

            _default.Add(
                () => Activator()
                   .CreateInstance<UpdatePropertySkipper>());

            _default.Add(
                () => Activator()
                   .CreateInstance<FixedLengthStringValueBuilder>());

            _default.Add(
                () => Activator()
                   .CreateInstance<RangeConstrainedFloatingPointValueBuilder>());

            _default.Add(
                () => Activator()
                   .CreateInstance<GuidBuilder>());

            _default.Add(
                () => Activator()
                   .CreateInstance<BooleanBuilder>());

            _default.Add(
                () => Activator()
                   .CreateInstance<EnumBuilder>());

            _default.Add(
                () => Activator()
                   .CreateInstance<DateTimeBuilder>());

            _default.Add(
                () => Activator()
                   .CreateInstance<TimeSpanBuilder>());

            _default.Add(
                () => Activator()
                   .CreateInstance<IncrementingNumericValueBuilder>());

            _default.Add(
                () => Activator()
                   .CreateInstance<OpenGenericTypeBuilder>());

            _default.Add(
                () => Activator()
                   .CreateInstance<StringValueBuilder>());

            _default.Add(
                () => Activator()
                   .CreateInstance<ObjectValueBuilder>());

            _default.Add(
                () => Activator()
                   .CreateInstance<ClassicDictionaryEmptyValueBuilder>());

            //Collections
            _default.Add(
                () => Activator()
                   .CreateInstance<HashtableBuilder>());

            _default.Add(
                () => Activator()
                   .CreateInstance<IDictionaryBuilder>());

            _default.Add(
                () => Activator()
                   .CreateInstance<IEnumerableBuilder>());

            _default.Add(
                () => Activator()
                   .CreateInstance<KeyValuePairBuilder>());
        }

        public void AddToEnd(Func<IValueBuilder> buildBuilder)
        {
            _append.Add(buildBuilder);
        }

        public void AddToEnd<TBuilder>()
            where TBuilder : IValueBuilder
        {
            _append.Add(
                () => Activator()
                   .CreateInstance<TBuilder>());
        }

        public void AddToFront(Func<IValueBuilder> buildBuilder)
        {
            _prepend.Add(buildBuilder);
        }

        public void AddToFront<TBuilder>()
            where TBuilder : IValueBuilder
        {
            _prepend.Add(
                () => Activator()
                   .CreateInstance<TBuilder>());
        }

        public void ClearAddOnBuilders()
        {
            _append.Clear();
            _prepend.Clear();
        }
    }
}
