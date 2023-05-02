// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Common.Metadata.Profiles;
using log4net;

namespace EdFi.Ods.Api.Security.Profiles
{
    public class AdminProfileNamesPublisher : IAdminProfileNamesPublisher
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(AdminProfileNamesPublisher));
        private readonly IProfileResourceNamesProvider _profileResourceNamesProvider;
        private readonly IUsersContextFactory _usersContextFactory;

        public AdminProfileNamesPublisher(
            IUsersContextFactory usersContextFactory,
            IProfileResourceNamesProvider profileResourceNamesProvider)
        {
            _profileResourceNamesProvider = profileResourceNamesProvider ?? throw new ArgumentNullException(nameof(profileResourceNamesProvider));
            _usersContextFactory = usersContextFactory ?? throw new ArgumentNullException(nameof(usersContextFactory));
        }

        public async Task<bool> PublishProfilesAsync()
        {
                //get the set of profiles from any Profiles.xml files found in assemblies
                var definedProfiles = _profileResourceNamesProvider.GetProfileResourceNames()
                    .Select(x => x.ProfileName)
                    .Distinct();

                using (var usersContext = _usersContextFactory.CreateContext())
                {
                    //determine which Profiles from the Profiles.xml files do not exist in the admin database
                    var publishedProfiles = await usersContext.Profiles.Select(x => x.ProfileName).ToListAsync();

                    var profilesToInsert = definedProfiles.Except(publishedProfiles).ToList();

                    //if there are none to insert return
                    if (!profilesToInsert.Any())
                    {
                        if (_logger.IsDebugEnabled)
                        {
                            string adminDatabaseName = (usersContext as DbContext)?.Database.Connection.Database;
                            _logger.Debug($"No profile names need to be published to the Admin database '{adminDatabaseName}'...");
                        }

                        return true;
                    }

                    if (_logger.IsDebugEnabled)
                    {
                        string adminDatabaseName = (usersContext as DbContext)?.Database.Connection.Database;
                        _logger.Debug($"Publishing the following Profile names to the Admin database '{adminDatabaseName}': {string.Join("', '", profilesToInsert)}");
                    }

                    // for each profile not in the database, add it
                    foreach (var profileName in profilesToInsert)
                    {
                        usersContext.Profiles.Add(new Profile { ProfileName = profileName });
                    }

                    await usersContext.SaveChangesAsync();
                }

                return true;
        }
    }
}
