// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using NHibernate;

namespace EdFi.Ods.Api.Common.Infrastructure.Architecture.Activities
{
    /// <summary>
    /// Defines a method for setting a list of parameters on an <see cref="IQuery" /> instance.
    /// </summary>
    public interface IParameterListSetter
    {
        /// <summary>
        /// Sets the value of a parameter (by name) to the supplied list of Ids.
        /// </summary>
        /// <param name="query">The NHibernate query.</param>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="ids">The list of Ids to be assigned to the parameter's value.</param>
        void SetParameterList(IQuery query, string name, IEnumerable ids);
    }
}
