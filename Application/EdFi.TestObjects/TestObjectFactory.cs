// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using EdFi.TestObjects._Extensions;
using log4net;

namespace EdFi.TestObjects
{
    public interface ICustomAttributeProvider
    {
        object[] GetCustomAttributes(MemberInfo memberInfo, Type attributeType, bool inherit);

        object[] GetCustomAttributes(MemberInfo memberInfo, bool inherit);
    }

    public class CustomAttributeProvider : ICustomAttributeProvider
    {
        public object[] GetCustomAttributes(MemberInfo memberInfo, Type attributeType, bool inherit)
        {
            return memberInfo.GetCustomAttributes(attributeType, inherit);
        }

        public object[] GetCustomAttributes(MemberInfo memberInfo, bool inherit)
        {
            return memberInfo.GetCustomAttributes(inherit);
        }
    }

    public interface ITestObjectFactory
    {
        ICustomAttributeProvider CustomAttributeProvider { get; }

        /// <summary>
        ///     Gets or sets the maximum depth in a hierarchical structure for which data should be generated.
        /// </summary>
        int MaximumHierarchyDepth { get; set; }

        /// <summary>
        ///     Gets or sets the number of items that should be generated in each collection.
        /// </summary>
        int CollectionCount { get; set; }

        /// <summary>
        /// Provides a customizable delegate that is called before creating each object/value to allow
        /// for certain types to be excluded from creation.
        /// </summary>
        Func<Type, bool> CanCreate { get; set; }

        T Create<T>();

        object Create(
            string logicalPropertyPath,
            Type targetType,
            IDictionary<string, object> propertyValueConstraints,
            LinkedList<object> objectGraphLineage);

        object Create(Type objectType, string[] notSoRandomUniqueIds = null);

        ValueBuildResult[] RandomizeValue(object value, Type explicitValueType, string[] notSoRandomUniqueIds = null);

        string[] GetIgnorePaths(Type t, BuildMode mode);

        /// <summary>
        /// Resets all the value builders to their initial state, if applicable.
        /// </summary>
        void ResetValueBuilders();
    }

    public class TestObjectFactory : ITestObjectFactory
    {
        private readonly IActivator activator;

        private readonly IValueBuilder[] builders;

        private readonly ILog _logger = LogManager.GetLogger(typeof(TestObjectFactory));

        public CancellationToken CancellationToken;

        public TestObjectFactory()
            : this(new BuilderFactory().GetBuilders(), new SystemActivator(), new CustomAttributeProvider()) { }

        public TestObjectFactory(IValueBuilder[] builders, IActivator activator, ICustomAttributeProvider customAttributeProvider)
        {
            CollectionCount = 2;
            MaximumHierarchyDepth = 2;

            this.builders = builders;
            this.activator = activator;
            CustomAttributeProvider = customAttributeProvider;

            foreach (var builder in builders)
            {
                builder.Factory = this;
            }
        }

        private string[] NotSoRandomUniqueId { get; set; }

        public ICustomAttributeProvider CustomAttributeProvider { get; }

        public T Create<T>()
        {
            return (T) Create(string.Empty, typeof(T), null, null);
        }

        [Obsolete("This method is marked for deprecation.  Consider refactoring with a custom value builder to handle supplying specific uniqueIds")]
        public object Create(Type objectType, string[] notSoRandomUniqueIds = null)
        {
            NotSoRandomUniqueId = notSoRandomUniqueIds;
            return Create(string.Empty, objectType, null, null);
        }

        public object Create(
            string logicalPropertyPath,
            Type targetType,
            IDictionary<string, object> propertyValueConstraints,
            LinkedList<object> objectGraphLineage)
        {
            // TODO: Needs unit test to ensure proper cancellation
            if (CancellationToken.IsCancellationRequested)
            {
                _logger.WarnFormat("Cancellation requested prior to creating value for '{0}' (of type '{1}').", logicalPropertyPath, targetType.Name);

                throw new OperationCanceledException(
                    string.Format("Cancellation requested prior to creating value for '{0}' (of type '{1}').", logicalPropertyPath, targetType.Name));
            }

            // Make sure type should be created
            if (!CanCreate(targetType))
            {
                _logger.DebugFormat("CanCreate delegate on TestObjectFactory indicated that '{0}' should not be created.", targetType.Name);
                return null;
            }

            if (objectGraphLineage == null)
            {
                objectGraphLineage = new LinkedList<object>();
            }

            var customObjectBuildContext = new CustomObjectBuildContext();

            var buildContext = new BuildContext(
                logicalPropertyPath,
                targetType,
                propertyValueConstraints,
                null,
                objectGraphLineage,
                BuildMode.Create);

            return BuildValue(new List<ValueBuildResult>(), buildContext, customObjectBuildContext)
               .Value;
        }

        // TODO: GKM - Should this method be marked Obsolete, and should its behavior be refactored to use value builders?
        public ValueBuildResult[] RandomizeValue(object value, Type explicitValueType, string[] notSoRandomUniqueIds = null)
        {
            var buildResults = new List<ValueBuildResult>();
            NotSoRandomUniqueId = notSoRandomUniqueIds;
            var customObjectBuildContext = new CustomObjectBuildContext();

            BuildAndAssignPropertyValues(
                string.Empty,
                new LinkedList<object>(
                    new[]
                    {
                        value
                    }),
                explicitValueType,
                new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase),
                buildResults,
                BuildMode.Modify,
                customObjectBuildContext);

            return buildResults.OrderBy(x => x.LogicalPath)
                               .ToArray();
        }

        public string[] GetIgnorePaths(Type t, BuildMode mode)
        {
            var valueBuildResults = new List<ValueBuildResult>();

            var customObjectBuildContext = new CustomObjectBuildContext();

            //this.customObjectCollectionSequence = new Dictionary<Type, int>();

            var buildContext = new BuildContext(
                string.Empty,
                t,
                new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase),
                null,
                null,
                mode);

            BuildValue(valueBuildResults, buildContext, customObjectBuildContext);

            var typeNamePrefix = string.Format("{0}.", t.Name);

            return valueBuildResults
                  .Where(x => x.ShouldSkip)
                  .Select(x => x.LogicalPath)
                  .Select(
                       x => x.StartsWith(typeNamePrefix)
                           ? x.Substring(typeNamePrefix.Length)
                           : x)
                  .ToArray();
        }

        public void ResetValueBuilders()
        {
            foreach (var valueBuilder in builders)
            {
                valueBuilder.Reset();
            }
        }

        /// <summary>
        ///     Gets or sets the maximum depth in a hierarchical structure for which data should be generated.
        /// </summary>
        public int MaximumHierarchyDepth { get; set; }

        /// <summary>
        ///     Gets or sets the number of items that should be generated in each collection.
        /// </summary>
        public int CollectionCount { get; set; }

        /// <summary>
        /// Provides a customizable delegate that is called before creating each object/value to allow
        /// for certain types to be excluded from creation.
        /// </summary>
        public Func<Type, bool> CanCreate { get; set; } = type => true;

        private ValueBuildResult BuildValue(
            List<ValueBuildResult> buildResults,
            BuildContext buildContext,
            CustomObjectBuildContext customObjectBuildContext)
        {
            string logicalPropertyPath = buildContext.LogicalPropertyPath;
            Type targetType = buildContext.TargetType;

            _logger.DebugFormat(
                "Initiating build of value for property path '{0}' of type '{1}' (with build context {2})...",
                string.IsNullOrEmpty(logicalPropertyPath)
                    ? "[empty]"
                    : logicalPropertyPath,
                targetType.Name,
                buildContext);

            foreach (var builder in builders)
            {
                var buildResult = builder.TryBuild(
                    buildContext);

                if (buildResult.Handled)
                {
                    if (buildResult.ShouldSetValue)
                    {
                        _logger.DebugFormat(
                            "Value built for property path '{0}' was '{1}'...",
                            string.IsNullOrEmpty(logicalPropertyPath)
                                ? "[empty]"
                                : logicalPropertyPath,
                            buildResult.Value);
                    }

                    else if (buildResult.ShouldSkip)
                    {
                        _logger.DebugFormat(
                            "Value was skipped for property path '{0}' by value builder '{1}'...",
                            string.IsNullOrEmpty(logicalPropertyPath)
                                ? "[empty]"
                                : logicalPropertyPath,
                            builder.GetType()
                                   .Name);
                    }

                    return buildResult;
                }
            }

            // No builder handled it, so try to build it using the built in
            var customBuildResult = TryBuildCustomObject(buildResults, buildContext, customObjectBuildContext);

            if (customBuildResult.Handled)
            {
                return customBuildResult;
            }

            throw new Exception(
                string.Format(
                    "Unable to create object of type '{0}'{1}.  Consider adding an IValueBuilder implementation to handle creating this type for serialization testing.",
                    targetType.FullName,
                    string.IsNullOrEmpty(logicalPropertyPath)
                        ? string.Empty
                        : "at logical path " + logicalPropertyPath));
        }

        private ValueBuildResult TryBuildCustomObject(
            List<ValueBuildResult> buildResults,
            BuildContext buildContext,
            CustomObjectBuildContext customObjectBuildContext)
        {
            if (customObjectBuildContext == null)
            {
                customObjectBuildContext = new CustomObjectBuildContext();
            }

            Type targetType = buildContext.TargetType;

            if (targetType.IsValueType
                || targetType == typeof(string)
                || targetType.FullName.StartsWith("System.") 
                || targetType.IsAbstract)
            {
                return ValueBuildResult.NotHandled;
            }

            string logicalPropertyPath = buildContext.LogicalPropertyPath;
            var objectGraphLineage = buildContext.ObjectGraphLineage;
            var propertyValueConstraints = buildContext.PropertyValueConstraints;
            var buildMode = buildContext.BuildMode;

            // Start or augment logical property path
            if (string.IsNullOrEmpty(logicalPropertyPath))
            {
                logicalPropertyPath = targetType.Name;
            }
            else
            {
                logicalPropertyPath += "." + targetType.Name;
            }

            // Initialize depth for type if it doesn't yet exist
            if (!customObjectBuildContext.CustomObjectDepthByType.ContainsKey(targetType))
            {
                customObjectBuildContext.CustomObjectDepthByType[targetType] = 0;
            }

            // Initialize sequence for type if it doesn't yet exist
            if (!customObjectBuildContext.CustomObjectCollectionSequence.ContainsKey(targetType))
            {
                customObjectBuildContext.CustomObjectCollectionSequence[targetType] = 0;
            }

            // Are we already building an instance of this type of object?
            int depth = customObjectBuildContext.CustomObjectDepthByType[targetType];

            // Are we already building an instance in a collection of this type of object?
            int sequence = customObjectBuildContext.CustomObjectCollectionSequence[targetType];

            // Don't go any deeper than 2
            if (depth == MaximumHierarchyDepth)
            {
                return ValueBuildResult.Skip(logicalPropertyPath);
            }

            customObjectBuildContext.CustomObjectDepthByType[targetType] = depth + 1;

            try
            {
                // Attempt to create the object using a default constructor
                try
                {
                    object instance = activator.CreateInstance(targetType);

                    objectGraphLineage.AddFirst(instance);

                    try
                    {
                        BuildAndAssignPropertyValues(
                            logicalPropertyPath,
                            objectGraphLineage,
                            targetType,
                            propertyValueConstraints,
                            buildResults,
                            buildMode,
                            customObjectBuildContext);
                    }
                    finally
                    {
                        objectGraphLineage.RemoveFirst();
                    }

                    return ValueBuildResult.WithValue(instance, logicalPropertyPath);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Unable to create type '{0}' at {1}.", targetType.FullName, logicalPropertyPath), ex);
                }
            }
            finally
            {
                customObjectBuildContext.CustomObjectDepthByType[targetType] = customObjectBuildContext.CustomObjectDepthByType[targetType] - 1;
                customObjectBuildContext.CustomObjectCollectionSequence[targetType] = sequence + 1;
            }
        }

        private void BuildAndAssignPropertyValues(
            string logicalPropertyPath,
            LinkedList<object> objectGraphLineage,
            Type explicitType,
            IDictionary<string, object> propertyValueConstraints,
            List<ValueBuildResult> results,
            BuildMode mode,
            CustomObjectBuildContext customObjectBuildContext)
        {
            // Get its public properties
            int i = 0;

            var writableProperties = // TODO: Need unit test for this behavior
                (from p in explicitType.GetPublicProperties()
                 where p.CanWrite && !p.GetCustomAttributes<IgnoreDataMemberAttribute>().Any()
                 select p)
               .OrderBy(
                    p =>
                    {
                        // Set scalar values first, then object references, then lists
                        if (p.PropertyType.IsCustomClass())
                        {
                            return 10000 + i++;
                        }

                        // Not a scalar, and not a custom object reference, then it's probably a list (sort last)
                        if (!p.PropertyType.IsScalarProperty())
                        {
                            return 20000 + i++;
                        }

                        return i++;
                    })
               .ToList();

            _logger.DebugFormat(
                "Processing custom object properties in the following order: {0}",
                string.Join(", ", writableProperties.Select(p => p.Name)));

            var containingInstance = objectGraphLineage.First.Value;

            while (writableProperties.Count > 0)
            {
                // Make note of the number of remaining writable properties we need to generate
                int lastWritableCount = writableProperties.Count;

                // Get a list of public, writable properties
                foreach (var property in writableProperties.ToArray())
                {
                    ValueBuildResult buildResult = null;

                    object constraintValue;

                    // Look for property name match using name and (if necessary) the "role name prefix" convention.
                    if (propertyValueConstraints.TryGetValue(property.Name, out constraintValue)
                        || propertyValueConstraints.TryGetValue(explicitType.Name + property.Name, out constraintValue))
                    {
                        _logger.DebugFormat(
                            "Setting property '{0}' to '{1}' from context.",
                            logicalPropertyPath + "." + property.Name,
                            constraintValue);

                        buildResult = ValueBuildResult.WithValue(constraintValue, logicalPropertyPath + "." + property.Name);

                        try
                        {
                            property.SetValue(containingInstance, buildResult.Value, null);
                        }
                        catch (Exception ex)
                        {
                            // TODO: Need unit test for this behavior of falling through to normal build on exception

                            string valueTypeName = buildResult.Value == null
                                ? "N/A"
                                : buildResult.Value.GetType()
                                             .Name;

                            // This can happen when context is incorrectly used to set a similarly named property and the types are different
                            _logger.DebugFormat(
                                "Normal value building will proceed for path '{0}' because the property '{1}' (of type '{2}') could not be set to value '{3}' (of type '{4}') on instance type '{5}' due to the following exception:\r\n{6}.",
                                logicalPropertyPath,
                                property.Name,
                                property.PropertyType.Name,
                                buildResult.Value ?? "[null]",
                                valueTypeName,
                                containingInstance.GetType()
                                                  .Name,
                                ex);

                            // Clear the result, allow normal processing to proceed
                            buildResult = null;
                        }
                    }

                    if (buildResult == null)
                    {
                        // -----------------------------------------------------------------
                        // TODO: Need unit test for logic to not pass ALL context to children
                        // -----------------------------------------------------------------
                        // TODO: This functionality/decision needs to be externalized from the Test Object Factory... as a "ContextFilter" (or something similar)
                        // For example, IChildContextFilter with a NoContextFilter, and an EdOrgContextAllowedFilter (removes non EdOrg context from children)
                        IDictionary<string, object> constraintsToPass;

                        // Is this some sort of child list?
                        if (property.PropertyType != typeof(string) &&
                            typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                        {
                            // Filter the context passed to children.
                            // Only pass EdOrg-related property value constraints to children
                            var edOrgKeyValuePairs =
                                from kvp in propertyValueConstraints.AsEnumerable()
                                where kvp.Key.IsEducationOrganizationIdentifier()
                                select kvp;

                            constraintsToPass = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);

                            foreach (var kvp in edOrgKeyValuePairs)
                            {
                                constraintsToPass.Add(kvp);
                            }
                        }
                        else
                        {
                            constraintsToPass = propertyValueConstraints;
                        }

                        // -----------------------------------------------------------------

                        var buildContext = new BuildContext(
                            logicalPropertyPath + "." + property.Name,
                            property.PropertyType,
                            constraintsToPass, //propertyValueConstraints, 
                            explicitType,
                            objectGraphLineage,
                            mode);

                        buildResult = BuildValue(results, buildContext, customObjectBuildContext);

                        if (buildResult.ShouldDefer)
                        {
                            continue;
                        }
                    }

                    if (buildResult.ShouldSetValue)
                    {
                        try
                        {
                            property.SetValue(containingInstance, buildResult.Value, null);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(
                                string.Format(
                                    "Unable to set property '{0}' to value '{1}' on instance type '{2}'.",
                                    property.Name,
                                    buildResult.Value,
                                    containingInstance.GetType()
                                                      .Name),
                                ex);
                        }
                    }

                    writableProperties.Remove(property);
                    results.Add(buildResult);
                }

                // If we made no progress on the writeable properties, throw an exception now
                if (writableProperties.Count == lastWritableCount)
                {
                    throw new Exception(
                        string.Format(
                            "The attempts to build the following properties have failed to make progress due to 'Defer' responses from the value builders:\r\n{0}.",
                            string.Join(", ", writableProperties.Select(p => p.Name))));
                }
            }
        }

        private static void SetValue(PropertyInfo property, object containingInstance, object proposedValue)
        {
            // TODO: GKM - This logic needs to be removed.  This is a general builder, and should not have knowledge of UniqueIds
            // GKM - Now this line is breaking Load Generation
            //       ----->  var value = property.Name.EndsWith("UniqueId") ? this.NotSoRandomUniqueId[sequence] : buildResult.Value;
            var value = proposedValue;

            try
            {
                property.SetValue(containingInstance, value, null);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    string.Format(
                        "Unable to set property '{0}' to value '{1}' on instance type '{2}'.",
                        property.Name,
                        value,
                        containingInstance.GetType()
                                          .Name),
                    ex);
            }
        }

        private class CustomObjectBuildContext
        {
            public CustomObjectBuildContext()
            {
                CustomObjectDepthByType = new Dictionary<Type, int>();
                CustomObjectCollectionSequence = new Dictionary<Type, int>();
            }

            public Dictionary<Type, int> CustomObjectDepthByType { get; }

            public Dictionary<Type, int> CustomObjectCollectionSequence { get; }
        }
    }
}
