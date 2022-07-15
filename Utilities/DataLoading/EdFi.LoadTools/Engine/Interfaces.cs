// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Common;
using EdFi.LoadTools.Engine.Factories;
using EdFi.LoadTools.Engine.Mapping;
using EdFi.LoadTools.Engine.XmlLookupPipeline;

namespace EdFi.LoadTools.Engine
{
    public interface IApiConfiguration : IThrottleConfiguration
    {
        string Url { get; }

        int? SchoolYear { get; }

        string Profile { get; }

        int Retries { get; }
    }

    public interface IApiMetadataConfiguration
    {
        bool Force { get; }

        string Url { get; }

        string Folder { get; }

        string DependenciesUrl { get; }
    }

    public interface IDataConfiguration
    {
        string Folder { get; }
    }

    public interface IDestructiveTestConfiguration
    {
        string NamespacePrefix { get; }
        int? ParentEdOrgId { get; }
    }

    public interface IHashCacheConfiguration
    {
        string Folder { get; }
    }

    public interface IFileImportPipelineStep
    {
        bool Process(FileContext fileContext, Stream stream);
    }

    public interface IMappingStrategy
    {
        void MapElement(XElement source, string path, XElement target);

        void ReverseMapElement(XElement source, string path, XElement target);
    }

    public interface IInterchangeOrderConfiguration
    {
        string Folder { get; }
    }

    public interface IMetadataFactory<out T>
        where T : IModelMetadata
    {
        IEnumerable<T> GetMetadata();
    }

    public interface IMetadataMapper
    {
        void CreateMetadataMappings(
            MetadataMapping mapping,
            List<ModelMetadata> sourceModels,
            List<ModelMetadata> targetModels);
    }

    public interface IModelMetadata
    {
        string Model { get; set; }

        string Property { get; set; }

        string Type { get; set; }

        bool IsArray { get; set; }

        bool IsRequired { get; set; }

        bool IsSimpleType { get; set; }
    }

    public interface IMetadataMappingFactory
    {
        IEnumerable<MetadataMapping> GetMetadataMappings();
    }

    public interface IOAuthTokenConfiguration
    {
        string Url { get; }

        string Key { get; }

        string Secret { get; }
    }

    public interface IOAuthSessionToken
    {
        string SessionToken { get; set; }
    }

    public interface IHashProvider
    {
        int Bytes { get; }

        byte[] Hash(string text);

        string BytesToStr(byte[] hash);
    }

    public interface IResourceHashCache
    {
        IReadOnlyDictionary<byte[], bool> Hashes { get; }

        void Add(byte[] hash);

        bool Exists(byte[] hash);

        void Load();

        void Visited(byte[] hash);
    }

    public interface IResourcePipelineStep
    {
        bool Process(ApiLoaderWorkItem resourceWorkItem);
    }

    public interface IResponse
    {
        bool IsSuccess { get; }

        string Message { get; }

        string Content { get; }

        HttpStatusCode StatusCode { get; }

        int RequestNumber { get; }
    }

    public interface ISdkLibraryConfiguration
    {
        string Path { get; }
    }

    public interface ISdkLibraryFactory
    {
        Assembly SdkLibrary { get; }
    }

    public interface ISdkConfigurationFactory
    {
        object SdkConfiguration { get; }
    }

    public interface IXmlReferenceCacheFactory
    {
        void Cleanup();

        void InitializeCache(string fileName);
    }

    public interface IXmlReferenceCacheProvider
    {
        IXmlReferenceCache GetXmlReferenceCache(string fileName);
    }

    public interface IXmlReferenceCache
    {
        int NumberOfLoadedReferences { get; }

        int NumberOfReferences { get; }

        bool Exists(string id);

        void LoadReference(string id);

        void LoadReferenceSource(string id, XElement sourceElement);

        void PreloadReferenceSource(string id, XElement sourceElement);

        int RemainingReferenceCount(string id);

        XElement VisitReference(string id);
    }

    public interface ILookupPipelineStep
    {
        Task<bool> Process(XmlLookupWorkItem item);
    }

    public interface IXmlPairsFactory
    {
        IEnumerable<XmlReader> GetSources();

        IEnumerable<XmlIoPair> GetIoPairs();
    }

    public interface IXsdConfiguration
    {
        string Folder { get; }

        bool DoNotValidateXml { get; }
    }

    public interface IThrottleConfiguration
    {
        int ConnectionLimit { get; }

        int TaskCapacity { get; }

        int MaxSimultaneousRequests { get; }
    }
}
