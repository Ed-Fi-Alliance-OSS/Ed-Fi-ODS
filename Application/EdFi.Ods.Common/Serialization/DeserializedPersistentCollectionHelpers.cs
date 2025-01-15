// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using NHibernate.Engine;

namespace EdFi.Ods.Common.Serialization;

public static class DeserializedPersistentCollectionHelpers
{
    public static object CreatePersistentBag(
        ISessionFactoryImplementor sessionFactoryImplementor,
        object extensionObject = null)
    {
        var list = new List<object>();

        if (extensionObject != null)
        {
            list.Add(extensionObject);
        }

        var bag = new DeserializedPersistentGenericBag<object>(sessionFactoryImplementor, list);

        return bag;
    }
}
