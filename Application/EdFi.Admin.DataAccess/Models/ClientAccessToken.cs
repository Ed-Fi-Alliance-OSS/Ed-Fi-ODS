// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdFi.Admin.DataAccess.Models
{
    public class ClientAccessToken
    {
        private Guid _id;

        //Does not instantiate GUID for case of loading from database
        public ClientAccessToken() { }

        //For creation of a new Token
        public ClientAccessToken(TimeSpan lifespan)
        {
            Expiration = DateTime.UtcNow.Add(lifespan);
            Duration = lifespan;
        }

        public Guid Id
        {
            get
            {
                if (_id == default(Guid))
                {
                    _id = Guid.NewGuid();
                }

                return _id;
            }
            set { _id = value; }
        }

        public ApiClient ApiClient { get; set; }

        public DateTime Expiration { get; set; }

        [NotMapped]
        public TimeSpan Duration { get; }

        public string Scope { get; set; }

        public override string ToString()
        {
            return Id.ToString("N");
        }

        public bool IsExpired()
        {
            return DateTime.UtcNow.Subtract(Expiration) > TimeSpan.Zero;
        }
    }
}
