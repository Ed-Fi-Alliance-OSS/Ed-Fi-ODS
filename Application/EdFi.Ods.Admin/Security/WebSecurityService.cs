// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using WebMatrix.WebData;

namespace EdFi.Ods.Admin.Security
{
    /// <summary>
    /// Starting this class so that we can get a wrapper around WebSecurity and start to unit test the things that use it.
    /// </summary>
    public class WebSecurityService
    {
        public static void UpdatePasswordAndActivate(string username, string password)
        {
            var token = WebSecurity.GeneratePasswordResetToken(username);
            WebSecurity.ResetPassword(token, password);
        }
    }
}
