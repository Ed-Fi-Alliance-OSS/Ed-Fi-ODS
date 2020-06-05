// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdFi.Admin.DataAccess.Models
{
    public class Application
    {
        public Application()
        {
            ApplicationEducationOrganizations = new Collection<ApplicationEducationOrganization>();
            ApiClients = new Collection<ApiClient>();
            Profiles = new Collection<Profile>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationId { get; set; }

        public string ApplicationName { get; set; }

        [StringLength(255)]
        public string ClaimSetName { get; set; }

        public virtual Vendor Vendor { get; set; }

        public virtual OdsInstance OdsInstance { get; set; }

        [StringLength(255)]
        [Required]
        public string OperationalContextUri { get; set; }

        public virtual ICollection<ApplicationEducationOrganization> ApplicationEducationOrganizations { get; set; }

        public virtual ICollection<ApiClient> ApiClients { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }

        public ApplicationEducationOrganization CreateEducationOrganizationAssociation(int educationOrganizationId)
        {
            var educationOrganization = new ApplicationEducationOrganization
                                        {
                                            EducationOrganizationId = educationOrganizationId, Application = this
                                        };

            ApplicationEducationOrganizations.Add(educationOrganization);
            return educationOrganization;
        }
    }
}
