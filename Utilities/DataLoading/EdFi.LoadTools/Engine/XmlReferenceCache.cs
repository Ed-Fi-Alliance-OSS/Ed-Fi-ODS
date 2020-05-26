// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdFi.LoadTools.ApiClient;
using log4net;

namespace EdFi.LoadTools.Engine
{
    public class XmlReferenceCache : IXmlReferenceCache
    {
        private readonly ILog _log = LogManager.GetLogger(nameof(XmlReferenceCache));
        private readonly XmlModelMetadata[] _metadata;

        private readonly ConcurrentDictionary<string, XmlReferenceTracker> _xmlReferences;

        public XmlReferenceCache(IEnumerable<XmlModelMetadata> metadata)
        {
            _xmlReferences = new ConcurrentDictionary<string, XmlReferenceTracker>();
            _metadata = metadata.ToArray();
        }

        public void PreloadReferenceSource(string id, XElement sourceElement)
        {
            var referenceWasAdded = false;

            var referenceTracker = _xmlReferences.GetOrAdd(
                id, delegate
                    {
                        referenceWasAdded = true;
                        return new XmlReferenceTracker();
                    });

            if (!referenceWasAdded)
            {
                referenceTracker.SetReferenceObject(() => CreateReferenceElement(sourceElement));
            }
        }

        public void LoadReferenceSource(string id, XElement sourceElement)
        {
            var referenceTracker = _xmlReferences.GetOrAdd(id, new XmlReferenceTracker());
            referenceTracker.SetReferenceObject(() => CreateReferenceElement(sourceElement));
        }

        public void LoadReference(string id)
        {
            var referenceTracker = _xmlReferences.GetOrAdd(id, new XmlReferenceTracker());
            referenceTracker.IncrementRefCount();
        }

        public XElement VisitReference(string id)
        {
            XmlReferenceTracker referenceTracker;

            return !_xmlReferences.TryGetValue(id, out referenceTracker)
                ? null
                : referenceTracker.VisitReferenceObject();
        }

        public bool Exists(string id)
        {
            return _xmlReferences.ContainsKey(id);
        }

        public int RemainingReferenceCount(string id)
        {
            XmlReferenceTracker referenceTracker;

            if (!_xmlReferences.TryGetValue(id, out referenceTracker))
            {
                return 0;
            }

            return referenceTracker.GetRefCount();
        }

        public int NumberOfLoadedReferences
        {
            get { return _xmlReferences.Values.Count(v => v.ReferenceObjectLoaded); }
        }

        public int NumberOfReferences => _xmlReferences.Values.Count;

        private XElement CreateReferenceElement(XElement sourceElement)
        {
            var elementName = sourceElement.Name.LocalName;

            if (elementName.EndsWith("Reference"))
            {
                return sourceElement;
            }

            var ns = sourceElement.Name.Namespace;

            var identityName = ns + $"{elementName}Identity";

            var referenceProperties = _metadata.Where(x => x.Model == $"{elementName}IdentityType")
                                               .Select(x => x.Property)
                                               .Distinct();

            var element = new XElement(identityName);
            var identityElements = sourceElement.Elements().Where(x => referenceProperties.Contains(x.Name.LocalName));
            element.Add(identityElements);

            var additionalReferences = element.Descendants()
                                              .Where(x => x.Attribute("ref") != null)
                                              .Select(
                                                   x => new
                                                        {
                                                            RefId = x.Attribute("ref").Value, Element = x
                                                        })
                                              .Where(x => !string.IsNullOrWhiteSpace(x.RefId)).ToList();

            foreach (var additionalReference in additionalReferences)
            {
                var subReference = VisitReference(additionalReference.RefId);

                if (subReference == null)
                {
                    _log.Error(
                        $"Unable to resolve required sub-reference '{additionalReference.RefId}' while creating reference element of type '{sourceElement.Name}'.  This might be caused by an incorrect load order.");

                    continue;
                }

                additionalReference.Element.ReplaceWith(subReference);
            }

            var referenceName = ns + $"{elementName}Reference";
            return new XElement(referenceName, element);
        }

        private class XmlReferenceTracker
        {
            private readonly object _lock = new object();

            private int RefCount { get; set; }

            public bool ReferenceObjectLoaded { get; private set; }

            private XElement ReferenceObject { get; set; }

            public int GetRefCount()
            {
                return RefCount;
            }

            public void IncrementRefCount()
            {
                lock (_lock)
                {
                    RefCount++;
                }
            }

            public void SetReferenceObject(Func<XElement> referenceObjectCreationFunction)
            {
                lock (_lock)
                {
                    if (ReferenceObject == null && RefCount > 0)
                    {
                        ReferenceObjectLoaded = true;
                        ReferenceObject = referenceObjectCreationFunction();
                    }
                }
            }

            public XElement VisitReferenceObject()
            {
                lock (_lock)
                {
                    RefCount--;
                    var result = ReferenceObject;

                    if (RefCount <= 0)
                    {
                        ReferenceObjectLoaded = false;
                        ReferenceObject = null;
                    }

                    return result;
                }
            }
        }
    }
}
