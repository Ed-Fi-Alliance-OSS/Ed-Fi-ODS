// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Common.Infrastructure.Pipelines.Put
{
    public class PutContext<TResourceModel, TEntityModel> : IHasPersistentModel<TEntityModel>, IHasResource<TResourceModel>, IHasIdentifier
        where TResourceModel : IHasETag
        where TEntityModel : class, IHasIdentifier
    {
        private readonly ValidationState validationState;

        public PutContext(TResourceModel resource, ValidationState validationState)
            : this(resource, validationState, null) { }

        public PutContext(TResourceModel resource, ValidationState validationState, string etagValue)
        {
            this.validationState = validationState;
            Resource = resource;
            ETagValue = etagValue;
        }

        public string ETagValue { get; set; }

        public bool? IsValid
        {
            get { return validationState.IsValid; }
            set { validationState.IsValid = value; }
        }

        public bool EnforceOptimisticLock
        {
            get { return Resource.ETag != null; }
        }

        public Guid Id
        {
            get { return PersistentModel.Id; }
            set { throw new NotImplementedException("Cannot set the identifier of the persistent model through the context."); }
        }

        public TEntityModel PersistentModel { get; set; }

        public TResourceModel Resource { get; set; }
    }
}
