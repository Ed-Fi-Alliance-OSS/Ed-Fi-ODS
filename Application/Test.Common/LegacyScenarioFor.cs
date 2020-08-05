// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace Test.Common
{
    /// <summary>
    /// Provides a structure for creating Scenarios using Arrange/Act/Assert semantics with NUnit.
    /// </summary>
    [TestFixture]
    [Obsolete("RhinoMocks has been deprecated. Use ScenarioFor")]
    public abstract class LegacyScenarioFor<T>
    {
        private readonly Dictionary<Type, Lazy<object>> _mocksByType;
        private readonly ConstructorInfo _constructor;
        private readonly List<Lazy<object>> _constructorArgs;
        private readonly List<Type> _constructorArgTypes;
        private readonly Dictionary<Type, dynamic> _collectionsByType;
        private readonly List<string> _constructorArgDisplayNames = new List<string>();
        private readonly List<string> _propertyArgDisplayNames = new List<string>();

        private Exception _actualException;
        private bool _actualExceptionInspected;

        protected Exception ActualException
        {
            get
            {
                _actualExceptionInspected = true;
                return _actualException;
            }
            set
            {
                // Defensive programming around intended use case.
                if (ActualException != null)
                {
                    throw new InvalidOperationException(
                        "Multiple exceptions occurred during Scenario test fixture 'Act' step (this isn't supposed to happen).",
                        new AggregateException(ActualException, value));
                }

                _actualException = value;
            }
        }

        protected LegacyScenarioFor()
        {
            var constructorDetails =
                (from c in typeof(T).GetConstructors()
                    let p = c.GetParameters()
                    orderby p.Count() descending
                    select new
                    {
                        Constructor = c,
                        Parameters = p
                    })
                .FirstOrDefault();

            _constructor = constructorDetails.Constructor;

            _mocksByType = new Dictionary<Type, Lazy<object>>();

            _collectionsByType = new Dictionary<Type, dynamic>();

            _constructorArgs = new List<Lazy<object>>();
            _constructorArgTypes = new List<Type>();

            foreach (var parameter in constructorDetails.Parameters)
            {
                ProcessDependency(
                    parameter.Name,
                    parameter.ParameterType,
                    (type, lazy) =>
                    {
                        _constructorArgs.Add(lazy);
                        _constructorArgTypes.Add(type);
                    },
                    (typeName, name) =>
                        _constructorArgDisplayNames.Add(
                            string.Format(
                                "{0} ({1})",
                                typeName,
                                name))
                );
            }

            // Now look for injected property dependencies
            var propertyDependencies = GetPropertyDependencies();

            foreach (var propertyDependency in propertyDependencies)
            {
                ProcessDependency(
                    propertyDependency.Name,
                    propertyDependency.PropertyType,
                    (t, lo) => { },
                    (typeName, name) =>
                        _propertyArgDisplayNames.Add(
                            string.Format(
                                "{0} ({1} - Property Injection)",
                                typeName,
                                name))
                );
            }
        }

        private static List<PropertyInfo> GetPropertyDependencies()
        {
            return (from p in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    where p.PropertyType.IsInterface
                          && p.CanWrite
                    select p)
                .ToList();
        }

        private void ProcessDependency(
            string parameterName,
            Type parameterType,
            Action<Type, Lazy<object>> trackDependency,
            Action<string, string> setDisplayTypeNameAndName)
        {
            dynamic arg;
            Lazy<object> lazyArg;

            if (parameterType.IsArray)
            {
                Type elementType = parameterType.GetElementType();
                Type listType = typeof(List<>).MakeGenericType(elementType);
                arg = Activator.CreateInstance(listType);
                lazyArg = new Lazy<object>(() => arg.ToArray());

                _collectionsByType[elementType] = arg;
            }
            else
            {
                try
                {
                    lazyArg = new Lazy<object>(
                        () =>
                        {
                            try
                            {
                                return MockRepository.GenerateStub(parameterType);
                            }
                            catch (ArgumentException ex)
                            {
                                try
                                {
                                    return Activator.CreateInstance(parameterType);
                                }
                                catch (Exception ex2)
                                {
                                    throw new Exception(
                                        string.Format(
                                            "Attempt to mock parameter type '{0}' failed.",
                                            parameterType.Name),
                                        new AggregateException(ex, ex2));
                                }
                            }
                        });
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        string.Format("Unable to create stub of type '{0}'.", parameterType.Name),
                        ex);
                }
            }

            trackDependency(parameterType, lazyArg);

            _mocksByType[parameterType] = lazyArg;

            setDisplayTypeNameAndName(parameterType.Name, parameterName);
        }

        protected TDependency Given<TDependency>(TDependency explicitDependency)
            where TDependency : class
        {
            var lazyDependency = new Lazy<object>(() => explicitDependency);

            _mocksByType[typeof(TDependency)] = lazyDependency;

            if (_constructorArgs.Count > 0)
            {
                var argIndex = _constructorArgs.Select(
                        (a, i) => _constructorArgTypes[i] == typeof(TDependency)
                            ? i
                            : -1)
                    .Max();

                // Rewrite the affected constructor argument
                if (argIndex >= 0)
                {
                    _constructorArgs[argIndex] = new Lazy<object>(() => explicitDependency);
                }
            }

            return (TDependency) lazyDependency.Value;
        }

        protected TDependency Given<TDependency>()
            where TDependency : class
        {
            Lazy<object> dependency;

            if (!_mocksByType.TryGetValue(typeof(TDependency), out dependency))
            {
                TDependency stub = MockRepository.GenerateStub<TDependency>();

                dynamic list;

                if (_collectionsByType.TryGetValue(typeof(TDependency), out list))
                {
                    list.Add(stub);
                }
                else
                {
                    _mocksByType.Add(typeof(TDependency), new Lazy<object>(() => stub));
                }

                return stub;
            }

            return (TDependency) dependency.Value;
        }

        protected TDependency The<TDependency>()
            where TDependency : class
        {
            Lazy<object> dependency;

            if (!_mocksByType.TryGetValue(typeof(TDependency), out dependency))
            {
                object firstFromCollection = null;

                try
                {
                    firstFromCollection = The_first<TDependency>();
                }
                catch { }

                if (firstFromCollection == null)
                {
                    throw new Exception(string.Format("Unable to find a stub of type '{0}'.", typeof(TDependency).Name));
                }

                return (TDependency) firstFromCollection;
            }

            return (TDependency) dependency.Value;
        }

        private readonly Dictionary<string, object> _suppliedByName =
            new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);

        protected TSupplied Supplied<TSupplied>(string tag, TSupplied value)
        {
            _suppliedByName[tag] = value;

            return value;
        }

        protected object Supplied(string tag)
        {
            object value;

            if (!_suppliedByName.TryGetValue(tag, out value))
            {
                throw new Exception(
                    string.Format("No supplied value found by name of '{0}'.", tag));
            }

            return value;
        }

        protected TSupplied Supplied<TSupplied>()
        {
            return Supplied<TSupplied>(typeof(TSupplied).FullName);
        }

        protected TSupplied Supplied<TSupplied>(TSupplied value)
        {
            _suppliedByName.Add(typeof(TSupplied).FullName, value);
            return value;
        }

        protected TSupplied Supplied<TSupplied>(string tag)
        {
            return (TSupplied) Supplied(tag);
        }

        protected TDependency The_first<TDependency>()
            where TDependency : class
        {
            dynamic list = GetDependencyList<TDependency>();

            return (TDependency) list[0];
        }

        protected TDependency The_second<TDependency>()
            where TDependency : class
        {
            dynamic list = GetDependencyList<TDependency>();

            return (TDependency) list[1];
        }

        protected TDependency The_third<TDependency>()
            where TDependency : class
        {
            dynamic list = GetDependencyList<TDependency>();

            return (TDependency) list[2];
        }

        protected TDependency The_fourth<TDependency>()
            where TDependency : class
        {
            dynamic list = GetDependencyList<TDependency>();

            return (TDependency) list[3];
        }

        protected TDependency The_fifth<TDependency>()
            where TDependency : class
        {
            dynamic list = GetDependencyList<TDependency>();

            return (TDependency) list[4];
        }

        private dynamic GetDependencyList<TDependency>()
            where TDependency : class
        {
            dynamic list;

            if (!_collectionsByType.TryGetValue(typeof(TDependency), out list))
            {
                throw new Exception(string.Format("Unable to find a list of stubs of type '{0}'.", typeof(TDependency).Name));
            }

            return list;
        }

        [OneTimeSetUp]
        public void RunOnceBeforeAny()
        {
            // Scenario initialization
            BeforeScenario();

            // Allow fixture to arrange the state for the test
            Arrange();

            // Get a list of uninitialized stubs
            var uninitializedArgDisplayNames = _constructorArgs
                .Select(
                    (x, i) => new
                    {
                        Arg = x,
                        Index = i
                    })
                .Where(x => !x.Arg.IsValueCreated)
                .Select(x => _constructorArgDisplayNames[x.Index])
                .ToList();

            var uninitializedPropertyDisplayNames = _propertyArgDisplayNames.ToList();

            var uninitializedDependencyNames = uninitializedArgDisplayNames.Concat(uninitializedPropertyDisplayNames);

            // Prepare the test subject
            TestSubject = (T) _constructor.Invoke(
                (from a in _constructorArgs
                    select a.Value)
                .ToArray());

            // Inject property dependencies
            var propertyDependencies = GetPropertyDependencies();

            foreach (var propertyDependency in propertyDependencies)
            {
                var setter = propertyDependency.GetSetMethod();

                if (setter == null)
                {
                    throw new Exception(
                        string.Format(
                            "Unable to find property setter for '{0}' on type '{1}'.",
                            propertyDependency.Name,
                            propertyDependency.DeclaringType.Name));
                }

                object dependencyValue = _mocksByType[propertyDependency.PropertyType]
                    .Value;

                setter.Invoke(
                    TestSubject,
                    new[] {dependencyValue});
            }

            // Execute the behavior
            try
            {
                // Execute the behavior
                Act();
            }
            catch (Exception ex)
            {
                ActualException = ex;
            }
            finally
            {
                if (uninitializedDependencyNames.Any())
                {
                    Console.WriteLine(
                        "The following dependencies were only stubbed for the test:\r\n    {0}\r\n",
                        string.Join("\r\n    ", uninitializedDependencyNames));
                }
            }
        }

        /// <summary>
        /// Gets the object whose behavior is the subject of the specification.
        /// </summary>
        public T TestSubject { get; private set; }

        /// <summary>
        /// Executes arbitrary logic prior to scenario preparation.
        /// </summary>
        protected virtual void BeforeScenario() { }

        /// <summary>
        /// Prepares the state of the scenario (creating stubs, test data, etc.).
        /// </summary>
        protected virtual void Arrange() { }

        /// <summary>
        /// Executes the code to be exercised for the scenario.
        /// </summary>
        protected virtual void Act() { }

        /// <summary>
        /// Executes arbitrary logic after scenario execution, regardless of success or failure.
        /// </summary>
        [OneTimeTearDown]
        public virtual void AfterScenario()
        {
            // Make sure exception was inspected.
            if (_actualException != null && !_actualExceptionInspected)
            {
                throw new AssertionException(
                    string.Format(
                        "The exception of type '{0}' was not inspected by the test:\r\n {1}.",
                        _actualException.GetType()
                            .Name,
                        _actualException));
            }
        }

        /// <summary>
        /// Creates a stub of the specified type.
        /// </summary>
        /// <typeparam name="TStub">The type for which a stub should be created.</typeparam>
        /// <returns>An instance of the stub of the specified type.</returns>
        protected TStub Stub<TStub>()
            where TStub : class
        {
            return MockRepository.GenerateStub<TStub>();
        }
    }

    public static class ScenarioExtensions
    {
        public static IMethodOptions<T> returns<T>(
            this IMethodOptions<T> options,
            T value)
        {
            return options.Return(value);
        }
    }
}
