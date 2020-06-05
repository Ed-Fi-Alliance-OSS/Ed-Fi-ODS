// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common
{
    public static class Namespaces
    {
        public static string OdsBaseNamespace => "EdFi.Ods";

        public static class Standard
        {
            public static string RelativeNamespace => "Standard";

            public static string BaseNamespace => $"{OdsBaseNamespace}.{RelativeNamespace}";

            public static string Security => $"{BaseNamespace}.Security";

            public static string NHibernateMappings => $"{BaseNamespace}.NHibernate.Mappings";
        }

        public static class Api
        {
            public static string AssemblyName = "EdFi.Ods.Api";

            public static string RelativeNamespace => "Api";

            public static string BaseNamespace => $"{OdsBaseNamespace}.{RelativeNamespace}";

            public static string Pipelines => $"{BaseNamespace}.Pipelines";

            public static string Architecture => $"{BaseNamespace}.Architecture";

            public static string Controllers => $"{BaseNamespace}.Services.Controllers";

            public static class NHibernate
            {
                public static string RelativeNamespace => "Api.NHibernate";

                public static string BaseNamespace => $"{OdsBaseNamespace}.{RelativeNamespace}";

                public static string Architecture => $"{BaseNamespace}.Architecture";
            }
        }

        public static class Resources
        {
            public static string RelativeNamespace => "Api.Common.Models.Resources";

            public static string BaseNamespace => $"{OdsBaseNamespace}.{RelativeNamespace}";
        }

        public static class Requests
        {
            public static string RelativeNamespace => "Api.Common.Models.Requests";

            public static string BaseNamespace => $"{OdsBaseNamespace}.{RelativeNamespace}";
        }

        public static class Entities
        {
            public static string RelativeNamespace => "Entities";

            public static string BaseNamespace => $"{OdsBaseNamespace}.{RelativeNamespace}";

            public static class NHibernate
            {
                public static string RelativeNamespace => "Entities.NHibernate";

                public static string BaseNamespace => $"{OdsBaseNamespace}.{RelativeNamespace}";

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
                    public static string RelativeNamespace => $"{NHibernate.RelativeNamespace}.QueryModels";

                    public static string BaseNamespace => $"{NHibernate.BaseNamespace}.QueryModels";

                    public static string Views => $"{BaseNamespace}.Views";

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
                public static string RelativeNamespace => "Entities.Common";

                public static string BaseNamespace => $"{OdsBaseNamespace}.{RelativeNamespace}";
            }

            public static class Records
            {
                public static string RelativeNamespace => $"{Common.RelativeNamespace}.Records";

                public static string BaseNamespace => $"{OdsBaseNamespace}.{RelativeNamespace}";
            }
        }

        public static class Extensions
        {
            public static string RelativeNamespace => "Extensions";

            public static string BaseNamespace => $"{OdsBaseNamespace}.{RelativeNamespace}";

            public static string FullExtensionTypeName(string extensionEntityName) => $"{BaseNamespace}.{extensionEntityName}";
        }

        public static class CodeGen
        {
            public static string BaseNamespace => "EdFi.Ods.CodeGen";

            public static string XmlShredding => $"{BaseNamespace}.XmlShredding";

            public static string XsdToWebApiProcess => $"{BaseNamespace}.XsdToWebApi.Process";

            public static string Metadata => "EdFi.Ods.Metadata";

            public static string ExceptionHandling => "EdFi.Ods.Api.ExceptionHandling";
        }

        public static class Common
        {
            public static string BaseNamespace => "EdFi.Ods.Common";

            public static string Security => $"{BaseNamespace}.{"Security"}";

            public static string Claims => $"{Security}.{"Claims"}";
        }

        public static class Security
        {
            public static string BaseNamespace => $"{OdsBaseNamespace}.{"Security"}";

            public static string AuthorizationStrategies => $"{BaseNamespace}.{"AuthorizationStrategies"}";

            public static string Authorization => $"{BaseNamespace}.{"Authorization"}";

            public static string Relationships => $"{AuthorizationStrategies}.{"Relationships"}";

            public static string ContextDataProviders => $"{Authorization}.{"ContextDataProviders"}";
        }

        public static class XmlShredding
        {
            public static string BaseNamespace => $"{OdsBaseNamespace}.XmlShredding";

            public static string ResourceFactories => $"{BaseNamespace}.ResourceFactories";
        }
    }
}
