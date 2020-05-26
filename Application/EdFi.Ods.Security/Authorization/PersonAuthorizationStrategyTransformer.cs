// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Common.Security;
using QuickGraph;

namespace EdFi.Ods.Security.Authorization
{
    public class PersonAuthorizationStrategyTransformer : IEntityWithDataOperationTransformer
    {
        public void Transform(BidirectionalGraph<EntityWithDataOperation, DataOperationEdge> graph)
        {
            //Find the entities in the vertices on the graph for the create operation.
            // Note this class is assuming that there is no authorization strategy overrides
            var entities =
                graph.Vertices.Where(s => s.DataOperation == DataOperation.Create)
                     .Select(e => e.Entity)
                     .ToArray();

            ApplyStudentTransformation(graph, entities);
            ApplyStaffTransformation(graph, entities);
            ApplyParentTransformation(graph, entities);
        }

        private static void ApplyStaffTransformation(
            BidirectionalGraph<EntityWithDataOperation, DataOperationEdge> graph,
            Entity[] entities)
        {
            var staffEntity = entities.FirstOrDefault(x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "Staff"));

            var staffEdOrgEmployAssoc =
                entities.FirstOrDefault(
                    x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "StaffEducationOrganizationEmploymentAssociation"));

            var staffEdOrgAssignAssoc =
                entities.FirstOrDefault(
                    x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "StaffEducationOrganizationAssignmentAssociation"));

            //No staff entity in the graph, nothing to do.
            if (staffEntity == null)
            {
                return;
            }

            if (staffEdOrgEmployAssoc == null && staffEdOrgAssignAssoc == null)
            {
                throw new EdFiSecurityException(
                    "Unable to transform bulk execution graph as StaffEducationOrganizationAssignmentAssociation and" +
                    " StaffEducationOrganizationEmploymentAssociation were not found in the graph.");
            }

            //Add dependency on primaryRelationship path
            foreach (
                var dependentEntity in
                graph.Edges.Where(
                          x =>
                              x.Source.Entity == staffEntity && x.Source.DataOperation == DataOperation.Create &&
                              x.Target.Entity != staffEdOrgEmployAssoc && x.Target.Entity != staffEdOrgAssignAssoc)
                     .Select(y => y.Target))
            {
                graph.AddEdge(
                    new DataOperationEdge
                    {
                        Source = new EntityWithDataOperation(staffEdOrgEmployAssoc, DataOperation.Create), Target = dependentEntity
                    });

                graph.AddEdge(
                    new DataOperationEdge
                    {
                        Source = new EntityWithDataOperation(staffEdOrgAssignAssoc, DataOperation.Create), Target = dependentEntity
                    });
            }

            // StaffEducationOrganizationEmploymentAssociation or StaffEducationOrganizationAssignmentAssociation
            //must be created before Staff can be updated.
            graph.AddEdge(
                new DataOperationEdge
                {
                    Source = new EntityWithDataOperation(staffEdOrgEmployAssoc, DataOperation.Create),
                    Target = new EntityWithDataOperation(staffEntity, DataOperation.Update)
                });

            graph.AddEdge(
                new DataOperationEdge
                {
                    Source = new EntityWithDataOperation(staffEdOrgAssignAssoc, DataOperation.Create),
                    Target = new EntityWithDataOperation(staffEntity, DataOperation.Update)
                });

            //Creates before updates since they have different security.
            graph.AddEdge(
                new DataOperationEdge
                {
                    Source = new EntityWithDataOperation(staffEdOrgEmployAssoc, DataOperation.Create),
                    Target = new EntityWithDataOperation(staffEdOrgEmployAssoc, DataOperation.Update)
                });

            graph.AddEdge(
                new DataOperationEdge
                {
                    Source = new EntityWithDataOperation(staffEdOrgAssignAssoc, DataOperation.Create),
                    Target = new EntityWithDataOperation(staffEdOrgAssignAssoc, DataOperation.Update)
                });
        }

        private static void ApplyParentTransformation(BidirectionalGraph<EntityWithDataOperation, DataOperationEdge> graph, Entity[] entities)
        {
            var parentEntity = entities.FirstOrDefault(x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "Parent"));
            var studentParentAssociationEntity = entities.FirstOrDefault(x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "StudentParentAssociation"));
            var studentSchoolAssociationEntity = entities.FirstOrDefault(x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "StudentSchoolAssociation"));

            //No parent entity in the graph, nothing to do.
            if (parentEntity == null)
            {
                return;
            }

            if (studentParentAssociationEntity == null)
            {
                throw new EdFiSecurityException(
                    "Unable to transform bulk execution graph as StudentParentAssociation was not found in the graph.");
            }

            // StudentParentAssociation must be created before Parents can be updated.
            graph.AddEdge(
                new DataOperationEdge
                {
                    Source = new EntityWithDataOperation(studentParentAssociationEntity, DataOperation.Create),
                    Target = new EntityWithDataOperation(parentEntity, DataOperation.Update)
                });

            // StudentSchoolAssociation must be created before Parents can be updated.
            graph.AddEdge(
                new DataOperationEdge
                {
                    Source = new EntityWithDataOperation(studentSchoolAssociationEntity, DataOperation.Create),
                    Target = new EntityWithDataOperation(parentEntity, DataOperation.Update)
                });

            // StudentSchoolAssociation must be created before ParentAssociations can be updated.
            graph.AddEdge(
                new DataOperationEdge
                {
                    Source = new EntityWithDataOperation(studentSchoolAssociationEntity, DataOperation.Create),
                    Target = new EntityWithDataOperation(studentParentAssociationEntity, DataOperation.Update)
                });
        }

        private static void ApplyStudentTransformation(BidirectionalGraph<EntityWithDataOperation, DataOperationEdge> graph, Entity[] entities)
        {
            var studentEntity = entities.FirstOrDefault(x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "Student"));
            var studentSchoolAssociationEntity = entities.FirstOrDefault(x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "StudentSchoolAssociation"));

            //No student entity in the graph, nothing to do.
            if (studentEntity == null)
            {
                return;
            }

            if (studentSchoolAssociationEntity == null)
            {
                throw new EdFiSecurityException(
                    "Unable to transform bulk execution graph as StudentSchoolAssociation was not found in the graph.");
            }

            //Add dependency on primaryRelationship path
            foreach (
                var dependentEntity in
                graph.Edges.Where(
                          x =>
                              x.Source.Entity == studentEntity && x.Source.DataOperation == DataOperation.Create &&
                              x.Target.Entity != studentSchoolAssociationEntity)
                     .Select(y => y.Target))
            {
                graph.AddEdge(
                    new DataOperationEdge
                    {
                        Source = new EntityWithDataOperation(studentSchoolAssociationEntity, DataOperation.Create), Target = dependentEntity
                    });
            }

            //Run these separately since Create and update have different strategies.
            graph.AddEdge(
                new DataOperationEdge
                {
                    Source = new EntityWithDataOperation(studentSchoolAssociationEntity, DataOperation.Create),
                    Target = new EntityWithDataOperation(studentSchoolAssociationEntity, DataOperation.Update)
                });

            // StudentSchoolAssociation must be created before Students can be updated.
            graph.AddEdge(
                new DataOperationEdge
                {
                    Source = new EntityWithDataOperation(studentSchoolAssociationEntity, DataOperation.Create),
                    Target = new EntityWithDataOperation(studentEntity, DataOperation.Update)
                });
        }
    }
}
