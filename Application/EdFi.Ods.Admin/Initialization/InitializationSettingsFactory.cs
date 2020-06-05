// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Configuration;
using System.Linq;

namespace EdFi.Ods.Admin.Initialization
{
    public interface IInitializationSettingsFactory
    {
        InitializationModel GetInitializationModel();
    }

    /// <summary>
    /// Provides initialization settings from web.config or app.config
    /// </summary>
    public class InitializationSettingsFactory : IInitializationSettingsFactory
    {
        public InitializationModel GetInitializationModel()
        {
            var section = ConfigurationManager.GetSection("initialization") as InitializationSection ?? new InitializationSection();

            return new InitializationModel
                   {
                       Enabled = section.Enabled, Users = section.Users.OfType<UserElement>()
                                                                 .Select(
                                                                      u => new UserInitializationModel
                                                                           {
                                                                               Name = u.Name, Email = u.Email, Password = u.Password, Admin = u.Admin,
                                                                               Sandboxes = u.Sandboxes.OfType<SandboxElement>()
                                                                                            .Select(
                                                                                                 s => new SandboxInitializationModel
                                                                                                      {
                                                                                                          Name = s.Name, Key = s.Key,
                                                                                                          Secret = s.Secret, SandboxType = s.Type,
                                                                                                          Refresh = s.Refresh
                                                                                                      })
                                                                                            .ToArray()
                                                                           })
                                                                 .ToArray()
                   };
        }
    }
}
