// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common;

namespace EdFi.LoadTools.SmokeTest
{
    public class TestSet : Enumeration<TestSet, string>
    {
        public static readonly TestSet NonDestructiveApi = new TestSet("NonDestructiveApi", "NonDestructiveApi");
        public static readonly TestSet NonDestructiveSdk = new TestSet("NonDestructiveSdk", "NonDestructiveSdk");
        public static readonly TestSet DestructiveSdk = new TestSet("DestructiveSdk", "DestructiveSdk");

        public TestSet(string value, string displayName)
            : base(value, displayName) { }
    }
}
