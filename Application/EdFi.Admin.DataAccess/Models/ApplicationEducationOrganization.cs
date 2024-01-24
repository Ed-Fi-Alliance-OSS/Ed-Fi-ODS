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
    public sealed class ApplicationEducationOrganization
    {
        public ApplicationEducationOrganization()
        {
            Clients = new Collection<ApiClient>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationEducationOrganizationId { get; set; }

        public Application Application { get; set; }

        public int EducationOrganizationId { get; set; }

        public ICollection<ApiClient> Clients { get; set; }
    }
}
