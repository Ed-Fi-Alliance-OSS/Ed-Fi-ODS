// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Entities.Common.EdFi;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Standard.Security.Authorization.Overrides;

namespace EdFi.Ods.Standard.Container.Modules
{
    public class RelationshipsAuthorizationContextDataProviderOverridesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Establish authorization context for OrganizationDepartments using the ParentEducationOrganization
            // rather than default behavior (EducationOrganizationId)
            builder.RegisterType<OrganizationDepartmentRelationshipsAuthorizationContextDataProvider<RelationshipsAuthorizationContextData>>()
                .As<IRelationshipsAuthorizationContextDataProvider<IOrganizationDepartment, RelationshipsAuthorizationContextData>>()
                .SingleInstance();

            // Establish authorization context for DisciplineActions using the ResponsibilitySchoolId and StudentUSI 
            // rather than default behavior (StudentUSI)
            builder.RegisterType<DisciplineActionRelationshipsAuthorizationContextDataProvider<RelationshipsAuthorizationContextData>>()
                .As<IRelationshipsAuthorizationContextDataProvider<IDisciplineAction, RelationshipsAuthorizationContextData>>()
                .SingleInstance();
            
            // Establish authorization context for StudentAssessment using the ReportedSchoolId and StudentUSI rather than
            // using the default convention (only StudentUSI)
            builder.RegisterType<StudentAssessmentRelationshipsAuthorizationContextDataProvider<RelationshipsAuthorizationContextData>>()
                .As<IRelationshipsAuthorizationContextDataProvider<IStudentAssessment, RelationshipsAuthorizationContextData>>()
                .SingleInstance();

            // Establish authorization context for EvaluationRubricDimension using the ProgramEducationOrganizationId rather than
            // using the default behavior (EducationOrganizationId)
            builder.RegisterType<EvaluationRubricDimensionRelationshipsAuthorizationContextDataProvider<RelationshipsAuthorizationContextData>>()
                .As<IRelationshipsAuthorizationContextDataProvider<IEvaluationRubricDimension, RelationshipsAuthorizationContextData>>()
                .SingleInstance();

            // Establish authorization context for StudentAssessment using the ProgramEducationOrganizationId rather than
            // using the default behavior (EducationOrganizationId)
            builder.RegisterType<ProgramEvaluationRelationshipsAuthorizationContextDataProvider<RelationshipsAuthorizationContextData>>()
                .As<IRelationshipsAuthorizationContextDataProvider<IProgramEvaluation, RelationshipsAuthorizationContextData>>()
                .SingleInstance();

            // Establish authorization context for StudentAssessment using the ProgramEducationOrganizationId rather than
            // using the default behavior (EducationOrganizationId)
            builder.RegisterType<ProgramEvaluationElementRelationshipsAuthorizationContextDataProvider<RelationshipsAuthorizationContextData>>()
                .As<IRelationshipsAuthorizationContextDataProvider<IProgramEvaluationElement, RelationshipsAuthorizationContextData>>()
                .SingleInstance();

            // Establish authorization context for StudentAssessment using the ProgramEducationOrganizationId rather than
            // using the default behavior (EducationOrganizationId)
            builder.RegisterType<ProgramEvaluationObjectiveRelationshipsAuthorizationContextDataProvider<RelationshipsAuthorizationContextData>>()
                .As<IRelationshipsAuthorizationContextDataProvider<IProgramEvaluationObjective, RelationshipsAuthorizationContextData>>()
                .SingleInstance();
        }
    }
}
