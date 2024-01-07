// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Validation;
using Validator = EdFi.Ods.Common.Validation.Validator;

namespace EdFi.Ods.Api.Validation
{
    public class DataAnnotationsResourceValidator : ObjectValidatorBase, IResourceValidator
    {
        private readonly IContextProvider<DataManagementResourceContext> _resourceContextProvider;
        private readonly IMappingContractProvider _mappingContractProvider;

        public DataAnnotationsResourceValidator(
            IContextProvider<DataManagementResourceContext> resourceContextProvider,
            IMappingContractProvider mappingContractProvider)
        {
            _resourceContextProvider = resourceContextProvider;
            _mappingContractProvider = mappingContractProvider;
        }
        
        public ICollection<ValidationResult> ValidateObject(object entity)
        {
            var validationResults = new List<ValidationResult>();

            // Creates the items for the validation context containing the mapping contract for the resource
            var validationContext = CreateValidationContext(entity);

            if (!Validator.TryValidateObject(entity, validationContext, validationResults, validateAllProperties: true, validateEverything: true))
            {
                SetInvalid();
            }
            else
            {
                SetValid();
            }

            return validationResults;
        }

        private ValidationContext CreateValidationContext(object entity)
        {
            var validationContext = new ValidationContext(
                entity,
                new ValidationServiceProvider(_mappingContractProvider),
                CreateItemsWithMappingContract());

            return validationContext;

            Dictionary<object, object> CreateItemsWithMappingContract()
            {
                var resource = _resourceContextProvider.Get().Resource;

                if (resource == null)
                {
                    return null;
                }

                var items = new Dictionary<object, object>()
                {
                    {ValidationContextKeys.ResourceClass, resource} 
                };

                return items;
            }
        }
    }

    public class ValidationServiceProvider : IServiceProvider
    {
        private readonly IMappingContractProvider _mappingContractProvider;

        public ValidationServiceProvider(IMappingContractProvider mappingContractProvider)
        {
            _mappingContractProvider = mappingContractProvider;
        }

        public object GetService(Type serviceType)
            => serviceType == typeof(IMappingContractProvider)
                ? _mappingContractProvider
                : null;
    }
}
