// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common
{
    public static class Namespaces
    {
        public static readonly string OdsBaseNamespace = "EdFi.Ods";

        public static class Standard
        {
            public static readonly string RelativeNamespace = "Standard";

            public static readonly string BaseNamespace = $"{OdsBaseNamespace}.{RelativeNamespace}";

            public static readonly string Security = $"{BaseNamespace}.Security";

            public static readonly string NHibernateMappings = $"{BaseNamespace}.NHibernate.Mappings";
        }

        public static class Api
        {
            public static string AssemblyName = "EdFi.Ods.Api";

            public static readonly string RelativeNamespace = "Api";

            public static readonly string BaseNamespace = $"{OdsBaseNamespace}.{RelativeNamespace}";

            public static readonly string Pipelines = $"{BaseNamespace}.Pipelines";

            public static readonly string Architecture = $"{BaseNamespace}.Architecture";

            public static readonly string Controllers = $"{BaseNamespace}.Services.Controllers";

            public static class NHibernate
            {
                public static readonly string RelativeNamespace = "Api.NHibernate";

                public static readonly string BaseNamespace = $"{OdsBaseNamespace}.{RelativeNamespace}";

                public static readonly string Architecture = $"{BaseNamespace}.Architecture";
            }

            public static class Security
            {
                public static readonly string RelativeNamespace = "Api.Security";

                public static readonly string BaseNamespace = $"{OdsBaseNamespace}.{RelativeNamespace}";

                public static readonly string AuthorizationStrategies = $"{BaseNamespace}.{"AuthorizationStrategies"}";

                public static readonly string Authorization = $"{BaseNamespace}.{"Authorization"}";

                public static readonly string Relationships = $"{AuthorizationStrategies}.{"Relationships"}";

                public static readonly string ContextDataProviders = $"{Authorization}.{"ContextDataProviders"}";
            }
        }

        public static class Resources
        {
            public static readonly string RelativeNamespace = "Api.Common.Models.Resources";

            public static readonly string BaseNamespace = $"{OdsBaseNamespace}.{RelativeNamespace}";
        }

        public static class Requests
        {
            public static readonly string RelativeNamespace = "Api.Common.Models.Requests";

            public static readonly string BaseNamespace = $"{OdsBaseNamespace}.{RelativeNamespace}";
        }

        public static class Entities
        {
            public static readonly string RelativeNamespace = "Entities";

            public static readonly string BaseNamespace = $"{OdsBaseNamespace}.{RelativeNamespace}";

            public static class NHibernate
            {
                public static readonly string RelativeNamespace = "Entities.NHibernate";

                public static readonly string BaseNamespace = $"{OdsBaseNamespace}.{RelativeNamespace}";

                public static string GetAggregateNamespace(string aggregateName, string properCaseName, bool isExtensionEntity = false)
                {
                    return AggregateNamespace(
                        BaseNamespace,
                        aggregateName,
                        properCaseName,
                        isExtensionEntity);
                }

                private static string AggregateNamespace(
                    string baseNamespace,
                    string aggregateName,
                    string properCaseName,
                    bool isExtensionEntity)
                {
                    if (isExtensionEntity)
                    {
                        return AggregateNamespaceForExtensionEntity(
                            baseNamespace,
                            aggregateName,
                            properCaseName);
                    }

                    return
                        AggregateNamespaceForEntity(
                            baseNamespace,
                            aggregateName,
                            properCaseName);
                }

                private static string AggregateNamespaceForExtensionEntity(string baseNamespace, string aggregateName, string schemaProperCaseName)
                {
                    return $"{baseNamespace}.{aggregateName}Aggregate.{schemaProperCaseName}";
                }

                public static string AggregateNamespaceForEntity(string baseNamespace, string aggregateName, string schemaProperCaseName)
                {
                    return $"{baseNamespace}.{aggregateName}Aggregate.{schemaProperCaseName}";
                }

                public static class QueryModels
                {
                    public static readonly string RelativeNamespace = $"{NHibernate.RelativeNamespace}.QueryModels";

                    public static readonly string BaseNamespace = $"{NHibernate.BaseNamespace}.QueryModels";

                    public static readonly string Views = $"{BaseNamespace}.Views";

                    public static string GetViewNamespace(string viewName)
                    {
                        return $"{Views}.{viewName}";
                    }

                    public static string GetAggregateNamespace(
                        string aggregateName,
                        string properCaseName,
                        bool isExtensionContext = false,
                        bool isExtensionEntity = false)
                    {
                        return AggregateNamespace(
                            BaseNamespace,
                            aggregateName,
                            properCaseName,
                            isExtensionEntity);
                    }
                }
            }

            public static class Common
            {
                public static readonly string RelativeNamespace = "Entities.Common";

                public static readonly string BaseNamespace = $"{OdsBaseNamespace}.{RelativeNamespace}";
            }
        }

        public static class Extensions
        {
            public static readonly string RelativeNamespace = "Extensions";

            public static readonly string BaseNamespace = $"{OdsBaseNamespace}.{RelativeNamespace}";

            public static string FullExtensionTypeName(string extensionEntityName) => $"{BaseNamespace}.{extensionEntityName}";
        }

        public static class CodeGen
        {
            public static readonly string BaseNamespace = "EdFi.Ods.CodeGen";

            public static readonly string XmlShredding = $"{BaseNamespace}.XmlShredding";

            public static readonly string XsdToWebApiProcess = $"{BaseNamespace}.XsdToWebApi.Process";

            public static readonly string Metadata = "EdFi.Ods.Metadata";

            public static readonly string ExceptionHandling = "EdFi.Ods.Api.ExceptionHandling";
        }

        public static class Common
        {
            public static readonly string BaseNamespace = "EdFi.Ods.Common";

            public static readonly string Security = $"{BaseNamespace}.{"Security"}";

            public static readonly string Claims = $"{Security}.{"Claims"}";
        }

        public static class XmlShredding
        {
            public static readonly string BaseNamespace = $"{OdsBaseNamespace}.XmlShredding";

            public static readonly string ResourceFactories = $"{BaseNamespace}.ResourceFactories";
        }
    }
}
