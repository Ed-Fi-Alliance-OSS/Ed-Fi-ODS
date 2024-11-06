// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.CodeGen.Helpers;

public class MessagePackIndexer
{
    private MessagePackIndexer _context;
    private int _index = 0;

    public MessagePackIndexer() { }

    public MessagePackIndexer(int initialIndex)
    {
        _index = initialIndex;
    }

    public MessagePackIndexer(MessagePackIndexer context)
    {
        _context = context;
    }

    public int NextKey
    {
        get
        {
            if (_context != null)
            {
                // Initialize the current message pack indexer to one higher than the context provided
                _index = _context._index;
                _context = null;
            }

            return _index++;
        }
    }
}
