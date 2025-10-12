// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EdFi.Ods.SandboxAdmin.Services.Extensions;


namespace EdFi.Ods.SandboxAdmin.Services.Models.Results
{
    public abstract class AdminActionResult<TResult, TModel> : IAdminActionResult
        where TResult : AdminActionResult<TResult, TModel>
    {
        private readonly HashSet<string> _failingFields = new HashSet<string>();

        public string RedirectRoute { get; set; }

        public bool HasMessage
        {
            get { return !string.IsNullOrEmpty(Message); }
        }

        public string[] FailingFields
        {
            get { return _failingFields.ToArray(); }
        }

        public bool Success { get; set; }

        public string Message { get; set; }

        public TResult WithMessage(string message)
        {
            Message = message;
            return (TResult)this;
        }

        public TResult AddFailingField<T>(Expression<Func<TModel, T>> field)
        {
            _failingFields.Add(
                field.MemberName()
                     .ToLower());

            return (TResult)this;
        }
    }
}