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
    public class Vendor
    {
        public Vendor()
        {
            Applications = new Collection<Application>();
            Users = new Collection<User>();
            VendorNamespacePrefixes = new Collection<VendorNamespacePrefix>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VendorId { get; set; }

        public string VendorName { get; set; }

        public virtual ICollection<Application> Applications { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<VendorNamespacePrefix> VendorNamespacePrefixes { get; set; }

        public Application CreateApplication(string applicationName, string claimSetName)
        {
            var application = new Application
                              {
                                  ApplicationName = applicationName, Vendor = this, ClaimSetName = claimSetName
                              };

            Applications.Add(application);
            return application;
        }
    }
}
