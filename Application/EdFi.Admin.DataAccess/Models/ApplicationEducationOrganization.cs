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
    public class ApplicationEducationOrganization
    {
        private Application _application;

        public ApplicationEducationOrganization()
        {
            ApiClients = new Collection<ApiClient>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationEducationOrganizationId { get; set; }

        public virtual Application Application
        {
            // Setting <Nullable>enable</Nullable> in the csproj file would achieve the desired aim: do 
            // not allow this value to be null. However, that could have other ramifications that need
            // to be studied before going there.
            get { return _application; }
            set
            {
                _application = value ?? throw new System.InvalidOperationException("Application cannot be null");
            }
        }

        public long EducationOrganizationId { get; set; }

        public virtual ICollection<ApiClient> ApiClients { get; set; }
    }
}