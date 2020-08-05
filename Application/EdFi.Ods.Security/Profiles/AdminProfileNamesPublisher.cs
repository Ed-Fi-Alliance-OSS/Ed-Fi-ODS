// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Metadata;
using log4net;

namespace EdFi.Ods.Security.Profiles
{
    public class AdminProfileNamesPublisher : IAdminProfileNamesPublisher
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(AdminProfileNamesPublisher));
        private readonly IProfileResourceNamesProvider _profileResourceNamesProvider;
        private readonly IUsersContextFactory _usersContextFactory;

        public AdminProfileNamesPublisher(IUsersContextFactory usersContextFactory, IProfileResourceNamesProvider profileResourceNamesProvider)
        {
            _usersContextFactory = Preconditions.ThrowIfNull(usersContextFactory, nameof(usersContextFactory));
            _profileResourceNamesProvider = Preconditions.ThrowIfNull(profileResourceNamesProvider, nameof(profileResourceNamesProvider));
        }

        public async Task<bool> PublishProfilesAsync()
        {
            return await Task.Factory.StartNew(PublishProfiles);
        }

        private bool PublishProfiles()
        {
            try
            {
                //get the set of profiles from any Profiles.xml files found in assemblies
                var definedProfiles =
                    _profileResourceNamesProvider.GetProfileResourceNames()
                                                 .Select(x => x.ProfileName)
                                                 .Distinct();

                using (var usersContext = _usersContextFactory.CreateContext())
                {
                    //determine which Profiles from the Profiles.xml files do not exist in the admin database
                    var publishedProfiles = usersContext.Profiles
                                                        .Select(x => x.ProfileName)
                                                        .ToList();

                    var profilesToInsert = definedProfiles
                                          .Except(publishedProfiles)
                                          .ToList();

                    //if there are none to insert return
                    if (!profilesToInsert.Any())
                    {
                        return true;
                    }

                    //for each profile not in the database, add it
                    foreach (var profileName in profilesToInsert)
                    {
                        usersContext.Profiles.Add(
                            new Profile
                            {
                                ProfileName = profileName
                            });
                    }

                    usersContext.SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                //If an exception occurs log it and return false since it is an async call.
                _logger.Error("An error occured when attempting to publish Profiles to the admin database.", exception);
                return false;
            }
        }
    }
}
