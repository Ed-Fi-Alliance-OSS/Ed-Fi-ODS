// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using QuickGraph;

namespace EdFi.Ods.Security.Authorization
{
    public class PersonResourceLoadGraphTransformer : IResourceLoadGraphTransformer
    {
        public void Transform(BidirectionalGraph<Resource, AssociationViewEdge> resourceGraph)
        {
            ApplyStudentTransformation(resourceGraph);
            ApplyStaffTransformation(resourceGraph);
            // ApplyParentTransformation(resourceGraph);
        }

        private static void ApplyStaffTransformation(BidirectionalGraph<Resource, AssociationViewEdge> resourceGraph)
        {
            var resources = resourceGraph.Vertices.ToList();
            
            var staffResource = resources.FirstOrDefault(x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "Staff"));

            var staffEdOrgEmployAssoc =
                resources.FirstOrDefault(
                    x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "StaffEducationOrganizationEmploymentAssociation"));

            var staffEdOrgAssignAssoc =
                resources.FirstOrDefault(
                    x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "StaffEducationOrganizationAssignmentAssociation"));

            // No staff entity in the graph, nothing to do.
            if (staffResource == null)
            {
                return;
            }

            if (staffEdOrgEmployAssoc == null && staffEdOrgAssignAssoc == null)
            {
                throw new EdFiSecurityException(
                    "Unable to transform resource load graph since StaffEducationOrganizationAssignmentAssociation and" +
                    " StaffEducationOrganizationEmploymentAssociation were not found in the graph.");
            }

            // Get direct staff dependencies
            var directStaffDependencies = resourceGraph.OutEdges(staffResource)
                .Where(e => e.Target != staffEdOrgEmployAssoc && e.Target != staffEdOrgAssignAssoc)
                .ToList();
            
            // Add dependency on primaryRelationship path
            foreach (var directStaffDependency in directStaffDependencies)
            {
                // Re-point the edge to the primary relationships
                resourceGraph.RemoveEdge(directStaffDependency);
                
                resourceGraph.AddEdge(new AssociationViewEdge(staffEdOrgAssignAssoc, directStaffDependency.Target, directStaffDependency.AssociationView));
                resourceGraph.AddEdge(new AssociationViewEdge(staffEdOrgEmployAssoc, directStaffDependency.Target, directStaffDependency.AssociationView));
            }

            // StaffEducationOrganizationEmploymentAssociation or StaffEducationOrganizationAssignmentAssociation
            //must be created before Staff can be updated.
            // resourceGraph.AddEdge(
            //     new DataOperationEdge
            //     {
            //         Source = new EntityWithDataOperation(staffEdOrgEmployAssoc, DataOperation.Create),
            //         Target = new EntityWithDataOperation(staffResource, DataOperation.Update)
            //     });
            //
            // resourceGraph.AddEdge(
            //     new DataOperationEdge
            //     {
            //         Source = new EntityWithDataOperation(staffEdOrgAssignAssoc, DataOperation.Create),
            //         Target = new EntityWithDataOperation(staffResource, DataOperation.Update)
            //     });

            //Creates before updates since they have different security.
            // resourceGraph.AddEdge(
            //     new DataOperationEdge
            //     {
            //         Source = new EntityWithDataOperation(staffEdOrgEmployAssoc, DataOperation.Create),
            //         Target = new EntityWithDataOperation(staffEdOrgEmployAssoc, DataOperation.Update)
            //     });
            //
            // resourceGraph.AddEdge(
            //     new DataOperationEdge
            //     {
            //         Source = new EntityWithDataOperation(staffEdOrgAssignAssoc, DataOperation.Create),
            //         Target = new EntityWithDataOperation(staffEdOrgAssignAssoc, DataOperation.Update)
            //     });
        }

        private static void ApplyStudentTransformation(BidirectionalGraph<Resource, AssociationViewEdge> resourceGraph)
        {
            var resources = resourceGraph.Vertices.ToList();

            var studentResource = resources.FirstOrDefault(x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "Student"));
            var studentSchoolAssociationResource = resources.FirstOrDefault(x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "StudentSchoolAssociation"));

            // No student entity in the graph, nothing to do.
            if (studentResource == null)
            {
                return;
            }

            if (studentSchoolAssociationResource == null)
            {
                throw new EdFiSecurityException(
                    "Unable to transform resource load graph as StudentSchoolAssociation was not found in the graph.");
            }

            // Get direct student dependencies
            var studentDependencies = resourceGraph.OutEdges(studentResource)
                .Where(e => e.Target != studentSchoolAssociationResource)
                .ToList();

            // Add dependency on primaryRelationship path
            foreach (var directStudentDependency in studentDependencies)
            {
                // Re-point the edge to the primary relationships
                resourceGraph.RemoveEdge(directStudentDependency);
                resourceGraph.AddEdge(new AssociationViewEdge(studentSchoolAssociationResource, directStudentDependency.Target, directStudentDependency.AssociationView));
            }

            // Run these separately since Create and update have different strategies.
            // resourceGraph.AddEdge(
            //     new DataOperationEdge
            //     {
            //         Source = new EntityWithDataOperation(studentSchoolAssociationResource, DataOperation.Create),
            //         Target = new EntityWithDataOperation(studentSchoolAssociationResource, DataOperation.Update)
            //     });
            //
            // // StudentSchoolAssociation must be created before Students can be updated.
            // resourceGraph.AddEdge(
            //     new DataOperationEdge
            //     {
            //         Source = new EntityWithDataOperation(studentSchoolAssociationResource, DataOperation.Create),
            //         Target = new EntityWithDataOperation(studentResource, DataOperation.Update)
            //     });
        }

        // private static void ApplyParentTransformation(BidirectionalGraph<Resource, AssociationViewEdge> resourceGraph)
        // {
        //     var resources = resourceGraph.Vertices.ToList();
        //
        //     var parentResource = resources.FirstOrDefault(x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "Parent"));
        //     var studentParentAssociation = resources.FirstOrDefault(x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "StudentParentAssociation"));
        //     var studentSchoolAssociation = resources.FirstOrDefault(x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "StudentSchoolAssociation"));
        //
        //     // No parent entity in the graph, nothing to do.
        //     if (parentResource == null)
        //     {
        //         return;
        //     }
        //
        //     if (studentParentAssociation == null)
        //     {
        //         throw new EdFiSecurityException(
        //             "Unable to transform resource load graph since StudentParentAssociation was not found in the graph.");
        //     }
        //
        //     // StudentParentAssociation must be created before Parents can be updated.
        //     resourceGraph.AddEdge(
        //         new DataOperationEdge
        //         {
        //             Source = new EntityWithDataOperation(studentParentAssociationEntity, DataOperation.Create),
        //             Target = new EntityWithDataOperation(parentEntity, DataOperation.Update)
        //         });
        //
        //     // StudentSchoolAssociation must be created before Parents can be updated.
        //     resourceGraph.AddEdge(
        //         new DataOperationEdge
        //         {
        //             Source = new EntityWithDataOperation(studentSchoolAssociationEntity, DataOperation.Create),
        //             Target = new EntityWithDataOperation(parentEntity, DataOperation.Update)
        //         });
        //
        //     // StudentSchoolAssociation must be created before ParentAssociations can be updated.
        //     resourceGraph.AddEdge(
        //         new DataOperationEdge
        //         {
        //             Source = new EntityWithDataOperation(studentSchoolAssociationEntity, DataOperation.Create),
        //             Target = new EntityWithDataOperation(studentParentAssociationEntity, DataOperation.Update)
        //         });
        // }
    }
}
