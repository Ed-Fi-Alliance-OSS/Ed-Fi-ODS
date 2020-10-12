// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FakeItEasy;
using FakeItEasy.Sdk;
using NUnit.Framework;

namespace EdFi.TestFixture
{
    /// <summary>
    /// Provides a structure for creating auto mocked tests using Arrange/Act/Assert semantics with NUnit.
    /// </summary>
    [TestFixture]
    public abstract class ScenarioFor<TSystemUnderTest>
        where TSystemUnderTest : class
    {
        private readonly IDictionary<Type, dynamic> _collectionsByType = new Dictionary<Type, dynamic>();
        private readonly ConstructorInfo _constructor;
        private readonly IList<string> _constructorArgDisplayNames = new List<string>();
        private readonly IList<Lazy<object>> _constructorArgs = new List<Lazy<object>>();
        private readonly IList<Type> _constructorArgTypes = new List<Type>();
        private readonly IDictionary<Type, Lazy<object>> _mocksByType = new Dictionary<Type, Lazy<object>>();
        private readonly IList<string> _propertyArgDisplayNames = new List<string>();

        private readonly IDictionary<string, object> _suppliedByName =
            new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);

        private Exception _actualException;
        private bool _actualExceptionInspected;

        protected ScenarioFor()
        {
            var constructorDetails =
                typeof(TSystemUnderTest).GetConstructors()
                    .Select(
                        c => new
                        {
                            c,
                            p = c.GetParameters()
                        })
                    .OrderByDescending(x => x.p.Length)
                    .Select(
                        x => new
                        {
                            Constructor = x.c,
                            Parameters = x.p
                        })
                    .FirstOrDefault();

            _constructor = constructorDetails.Constructor;

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
                    (typeName, name) => _constructorArgDisplayNames.Add($"{typeName} ({name})")
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
                    (typeName, name) => _propertyArgDisplayNames.Add($"{typeName} ({name} - Property Injection)")
                );
            }
        }

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
                if (_actualException != null)
                {
                    throw new InvalidOperationException(
                        "Multiple exceptions occurred during Scenario test fixture 'Act' step (this isn't supposed to happen).",
                        new AggregateException(_actualException, value));
                }

                _actualException = value;
            }
        }

        /// <summary>
        /// Gets the object whose behavior is the subject of the specification.
        /// </summary>
        protected TSystemUnderTest SystemUnderTest { get; private set; }

        /// <summary>
        /// Setter to override a specific mocked dependency for the system under test
        /// </summary>
        /// <param name="explicitDependency"></param>
        /// <typeparam name="TDependency"></typeparam>
        /// <returns></returns>
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

        /// <summary>
        /// Gets a specific dependency from the system under test.
        /// </summary>
        /// <typeparam name="TDependency"></typeparam>
        /// <returns></returns>
        protected TDependency Given<TDependency>()
            where TDependency : class
        {
            if (!_mocksByType.TryGetValue(typeof(TDependency), out Lazy<object> dependency))
            {
                TDependency stub = A.Fake<TDependency>();

                if (_collectionsByType.TryGetValue(typeof(TDependency), out dynamic list))
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

        protected TDependency The_first<TDependency>()
           where TDependency : class
        {
            dynamic list = GetDependencyList<TDependency>();

            return (TDependency) list[0];
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

        /// <summary>
        /// Supplies a named value for subsequent usage during behavior verification, eliminating the need to create a test fixture field to hold the value.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="value"></param>
        /// <typeparam name="TSupplied"></typeparam>
        /// <returns></returns>
        protected TSupplied Supplied<TSupplied>(string tag, TSupplied value)
        {
            _suppliedByName[tag] = value;

            return value;
        }

        /// <summary>
        /// /// Supplies a named value for subsequent usage during behavior verification, eliminating the need to create a test fixture field to hold the value.
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="TSupplied"></typeparam>
        /// <returns></returns>
        protected TSupplied Supplied<TSupplied>(TSupplied value)
        {
            _suppliedByName.Add(typeof(TSupplied).FullName, value);
            return value;
        }

        /// <summary>
        /// Returns the unnamed value of the usage field.
        /// </summary>
        /// <typeparam name="TSupplied"></typeparam>
        /// <returns></returns>
        protected TSupplied Supplied<TSupplied>()
        {
            return Supplied<TSupplied>(typeof(TSupplied).FullName);
        }

        /// <summary>
        /// Returns the named value of the usage field.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected object Supplied(string tag)
        {
            if (!_suppliedByName.TryGetValue(tag, out object value))
            {
                throw new Exception($"No supplied value found by name of '{tag}'.");
            }

            return value;
        }

        /// <summary>
        /// Returns the named value of the usage field.
        /// </summary>
        /// <typeparam name="TSupplied"></typeparam>
        /// <returns></returns>
        protected TSupplied Supplied<TSupplied>(string tag)
        {
            return (TSupplied) Supplied(tag);
        }

        /// <summary>
        /// Provides a list of dependencies for TDependency. This is used when dependency is a collection of TDependency.
        /// </summary>
        /// <typeparam name="TDependency"></typeparam>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected dynamic DependeciesOf<TDependency>()
            where TDependency : class
        {
            if (!_collectionsByType.TryGetValue(typeof(TDependency), out dynamic list))
            {
                throw new Exception($"Unable to find a list of stubs of type '{typeof(TDependency).Name}'.");
            }

            return list;
        }

        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            // Allow fixture to arrange the state for the test
            Arrange();

            var args = _constructorArgs.Select(x => x.Value)
                .ToArray();

            // Prepare the test subject
            SystemUnderTest = (TSystemUnderTest) _constructor.Invoke(args);

            // Inject property dependencies
            var propertyDependencies = GetPropertyDependencies();

            foreach (var propertyDependency in propertyDependencies)
            {
                var setter = propertyDependency.GetSetMethod();

                if (setter == null)
                {
                    throw new Exception(
                        $"Unable to find property setter for '{propertyDependency.Name}' on type '{propertyDependency.DeclaringType.Name}'.");
                }

                object dependencyValue = _mocksByType[propertyDependency.PropertyType].Value;

                setter.Invoke(
                    SystemUnderTest,
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
        }

        /// <summary>
        /// Prepares the state of the scenario (creating stubs, test data, etc.).
        /// </summary>
        protected virtual void Arrange() { }

        /// <summary>
        /// Executes the code to be exercised for the scenario.
        /// </summary>
        protected virtual void Act() { }

        [OneTimeTearDown]
        public virtual void TestFixtureTearDown()
        {
            // Make sure exception was inspected.
            if (_actualException != null && !_actualExceptionInspected)
            {
                Assert.Fail(
                    $"The exception of type '{_actualException.GetType().Name}' was not inspected by the test:{Environment.NewLine} {_actualException}.");
            }
        }

        private static IList<PropertyInfo> GetPropertyDependencies()
        {
            return typeof(TSystemUnderTest).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.PropertyType.IsInterface && p.CanWrite)
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
                                return Create.Fake(parameterType);
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
                                        $"Attempt to mock parameter type '{parameterType.Name}' failed.",
                                        new AggregateException(ex, ex2));
                                }
                            }
                        });
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unable to create stub of type '{parameterType.Name}'.", ex);
                }
            }

            trackDependency(parameterType, lazyArg);

            _mocksByType[parameterType] = lazyArg;

            setDisplayTypeNameAndName(parameterType.Name, parameterName);
        }
    }
}