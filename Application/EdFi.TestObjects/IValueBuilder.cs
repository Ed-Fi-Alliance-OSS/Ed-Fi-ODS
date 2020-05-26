// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using log4net;

namespace EdFi.TestObjects
{
    public class BuildContext
    {
        private Type _targetType;

        public BuildContext(
            string logicalPropertyPath,
            Type targetType,
            IDictionary<string, object> propertyValueConstraints,
            Type containingType,
            LinkedList<object> objectGraphLineage,
            BuildMode buildMode)
        {
            if (targetType == null)
            {
                throw new ArgumentNullException("targetType");
            }

            LogicalPropertyPath = logicalPropertyPath;

            TargetType = targetType;

            //_propertyValueConstraints = propertyValueConstraints ?? new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
            if (propertyValueConstraints == null)
            {
                PropertyValueConstraints =
                    new BuildContextConstraints(); // new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
            }
            else
            {
                PropertyValueConstraints =
                    new BuildContextConstraints(
                        propertyValueConstraints); // Dictionary<string, object>(propertyValueConstraints, StringComparer.InvariantCultureIgnoreCase);
            }

            ContainingType = containingType;
            ObjectGraphLineage = objectGraphLineage ?? new LinkedList<object>();
            BuildMode = buildMode;
        }

        public string LogicalPropertyPath { get; }

        /// <summary>
        /// Gets or sets the type for which a value is to be built (returning the underlying type in the case of a nullable value type).
        /// </summary>
        public Type TargetType
        {
            get { return _targetType; }
            set
            {
                RawTargetType = value;

                Type underlyingType = null;

                if (value.IsGenericType)
                {
                    underlyingType = Nullable.GetUnderlyingType(value);
                }

                _targetType = underlyingType ?? value;
            }
        }

        /// <summary>
        /// Gets the original target type with no processing performed to identify the underlying type of a nullable value type.
        /// </summary>
        public Type RawTargetType { get; private set; }

        public IDictionary<string, object> PropertyValueConstraints { get; }

        public Type ContainingType { get; }

        public LinkedList<object> ObjectGraphLineage { get; }

        public BuildMode BuildMode { get; }

        /// <summary>
        /// Gets the object to which the current value will be applied.
        /// </summary>
        /// <returns>The current instance if the value being generated is a property; otherwise <b>null</b>.</returns>
        public dynamic GetContainingInstance(bool caseInsensitiveProperties)
        {
            if (ObjectGraphLineage.First == null)
            {
                return null;
            }

            return new CaseInsensitivePropertiesDynamicWrapper(ObjectGraphLineage.First.Value);
        }

        public dynamic GetContainingInstance()
        {
            if (ObjectGraphLineage.First == null)
            {
                return null;
            }

            return ObjectGraphLineage.First.Value;
        }

        /// <summary>
        /// Gets the parent of the object to which the current value is to be applied (useful for navigating object graphs).
        /// </summary>
        /// <returns>The parent of the current instance if the value being generated is a property; otherwise <b>null</b>.</returns>
        public dynamic GetParentInstance()
        {
            var firstNode = ObjectGraphLineage.First;

            if (firstNode == null || firstNode.Next == null)
            {
                return null;
            }

            return firstNode.Next.Value;
        }

        /// <summary>
        /// Gets the parent of the object to which the current value is to be applied (useful for navigating object graphs).
        /// </summary>
        /// <returns>The parent of the current instance if the value being generated is a property; otherwise <b>null</b>.</returns>
        public dynamic GetParentType()
        {
            var parent = GetParentInstance();

            if (parent == null)
            {
                return null;
            }

            return parent.GetType();
        }

        /// <summary>
        /// Gets the last segment of the logical property path, generally indicating the property name.
        /// </summary>
        /// <returns></returns>
        public string GetPropertyName()
        {
            string[] parts = LogicalPropertyPath.Split('.');
            string propertyName = parts[parts.Length - 1];

            return propertyName;
        }

        /// <summary>
        /// Gets the containing type's name, if present, otherwise an empty string.
        /// </summary>
        /// <returns>The containing type's name if available; otherwise an empty string.</returns>
        public string GetContainingTypeName()
        {
            if (ContainingType == null)
            {
                return string.Empty;
            }

            return ContainingType.Name;
        }

        public override string ToString()
        {
            if (PropertyValueConstraints.Count == 0)
            {
                return string.Format(
                    "[Context #{0}: Building path '{1}' using no values.]",
                    GetHashCode(),
                    string.IsNullOrEmpty(LogicalPropertyPath)
                        ? "[empty]"
                        : LogicalPropertyPath);
            }

            return string.Format(
                "[Context #{0}: Building path '{1}' using {2}.]",
                GetHashCode(),
                string.IsNullOrEmpty(LogicalPropertyPath)
                    ? "[empty]"
                    : LogicalPropertyPath,
                GetContextDisplayText());
        }

        private string GetContextDisplayText()
        {
            return string.Join(", ", PropertyValueConstraints.Select(x => string.Format("[{0}={1}]", x.Key, x.Value)));
        }
    }

    public class BuildContextConstraints : IDictionary<string, object>
    {
        private readonly IDictionary<string, object> _constraints;
        private readonly ILog _log = LogManager.GetLogger(typeof(BuildContextConstraints));

        public BuildContextConstraints()
        {
            _constraints = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
        }

        public BuildContextConstraints(IDictionary<string, object> constraints)
        {
            if (constraints == null)
            {
                _constraints = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
                return;
            }

            if (constraints is BuildContextConstraints)
            {
                _constraints = (constraints as BuildContextConstraints)._constraints;
                return;
            }

            var constraintsAsDictionary = constraints as Dictionary<string, object>;

            if (constraintsAsDictionary == null)
            {
                throw new ArgumentException(
                    string.Format(
                        "Constraints supplied to the build context must be backed by a Dictionary<string, object> instance (an instance of '{0}' was passed instead).",
                        constraints.GetType()));
            }

            if (constraintsAsDictionary.Comparer.GetType() != StringComparer.InvariantCultureIgnoreCase.GetType())
            {
                throw new ArgumentException(
                    "Constraints supplied to the build context must be backed by a Dictionary<string, object> instance, and must use the StringComparer.InvariantCultureIgnoreCase comparer in order to ensure correct behavior.");
            }

            _constraints = new Dictionary<string, object>(constraints, StringComparer.InvariantCultureIgnoreCase);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _constraints.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _constraints).GetEnumerator();
        }

        public void Add(KeyValuePair<string, object> item)
        {
            _constraints.Add(item);
            _log.DebugFormat("Added [{0}='{1}'] to property constraints.", item.Key, item.Value);
        }

        public void Clear()
        {
            _constraints.Clear();
            _log.DebugFormat("Cleared context of {0} value(s).", _constraints.Count);
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return _constraints.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            _constraints.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            var result = _constraints.Remove(item);
            _log.DebugFormat("Removed [{0}='{1}'] from property constraints.", item.Key, item.Value);
            return result;
        }

        public int Count
        {
            get { return _constraints.Count; }
        }

        public bool IsReadOnly
        {
            get { return _constraints.IsReadOnly; }
        }

        public bool ContainsKey(string key)
        {
            return _constraints.ContainsKey(key);
        }

        public void Add(string key, object value)
        {
            _constraints.Add(key, value);
            _log.DebugFormat("Added [{0}='{1}'] to property constraints.", key, value);
        }

        public bool Remove(string key)
        {
            var result = _constraints.Remove(key);
            _log.DebugFormat("Removed [{0}] from property constraints.", key);
            return result;
        }

        public bool TryGetValue(string key, out object value)
        {
            return _constraints.TryGetValue(key, out value);
        }

        public object this[string key]
        {
            get { return _constraints[key]; }
            set
            {
                object existingValue;

                // Detect overwriting of constraint values, and warn
                if (_constraints.TryGetValue(key, out existingValue))
                {
                    if (!value.Equals(existingValue))
                    {
                        _log.DebugFormat(
                            "Overwriting value for '{0}' from '{1}' to '{2}'.",
                            key,
                            existingValue,
                            value);
                    }
                    else
                    {
                        _log.DebugFormat(
                            "Overwriting value for '{0}' with same value ('{1}').",
                            key,
                            value);
                    }
                }

                _constraints[key] = value;
                _log.DebugFormat("Set [{0}='{1}'] to property constraints.", key, value);
            }
        }

        public ICollection<string> Keys
        {
            get { return _constraints.Keys; }
        }

        public ICollection<object> Values
        {
            get { return _constraints.Values; }
        }

#pragma warning disable 659
        public override bool Equals(object obj)
#pragma warning restore 659
        {
            var other = obj as IDictionary<string, object>;

            if (other == null)
            {
                return false;
            }

            if (other.Count != Count)
            {
                return false;
            }

            return this.AsEnumerable()
                       .All(
                            x =>
                            {
                                object value;

                                if (!other.TryGetValue(x.Key, out value))
                                {
                                    return false;
                                }

                                if (x.Value == null && value == null)
                                {
                                    return true;
                                }

                                if (x.Value == null || value == null)
                                {
                                    return false;
                                }

                                return value.Equals(x.Value);
                            });
        }

        public override int GetHashCode()
        {
            // ReSharper disable BaseObjectGetHashCodeCallInGetHashCode
            return base.GetHashCode();

            // ReSharper restore BaseObjectGetHashCodeCallInGetHashCode
        }
    }

    public interface IValueBuilder
    {
        ITestObjectFactory Factory { get; set; }

        ValueBuildResult TryBuild(BuildContext buildContext);

        void Reset();
    }
}
