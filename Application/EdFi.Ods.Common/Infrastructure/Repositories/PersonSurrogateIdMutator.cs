// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Infrastructure.Repositories;

public class PersonSurrogateIdMutator : ISurrogateIdMutator
{
    public bool TrySetSurrogateId(object instance, IItemRawData itemRawData)
    {
        if (instance is IPersonUsiMutator personMutator)
        {
            int usi = personMutator.GetUsi();
        
            // If already resolved, quit resolution process now
            if (usi != 0)
            {
                return true;
            }

            personMutator.SetUsi(itemRawData.SurrogateId);
            return true;
        }

        return false;
    }
}
