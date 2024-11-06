// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Runtime.Serialization;
using MessagePack;

namespace EdFi.Ods.Common.Models.Domain
{
    public abstract class AggregateRootWithCompositeKey
        : EntityWithCompositeKey,
          IHasIdentifier,
          IHasIdentifierSource,
          IDateVersionedEntity
    {
        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        [Key(1)]
        public virtual DateTime LastModifiedDate { get; set; }

        // nHibernate wraps property getter exception in PropertyAccessException if any
        // underlying mapped properties are set to access "none", due to an invoke exception
        // being triggered.  Placing the ChangeVersion here at the root to avoid this issue,
        // and to make it available for future exposure if needed.
        [Key(2)]
        public virtual long ChangeVersion { get; set; }

        // =============================================================
        //                          AggregateId
        // -------------------------------------------------------------
        [Key(3)]
        public virtual int AggregateId { get; set; }

        [DataMember]
        [Key(4)]
        public virtual Guid Id { get; set; }

        [IgnoreMember]
        public virtual byte[] AggregateData { get; set; }

        IdentifierSource IHasIdentifierSource.IdSource { get; set; }

        // Order to identify the owner (from the current API client), assign the ownership token id to the corresponding aggregate root entity
        [DataMember]
        [Key(5)]
        public virtual short? CreatedByOwnershipTokenId { get; set; }
    }
}
