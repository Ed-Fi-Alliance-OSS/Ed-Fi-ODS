// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Models.Domain;

public static class CSharpLanguageType
{
    public const string Long = "long";
    public const string Byte = "byte";
    public const string Short = "short";
    public const string Int = "int";
    public const string Guid = nameof(Guid);
    public const string DateTime = nameof(DateTime);
    public const string Double = "double";
    public const string Float = "float";
    public const string String = "string";
    public const string Decimal = "decimal";
    public const string Bool = "bool";
    public const string ByteArray = "byte[]";
    public const string TimeSpan = nameof(TimeSpan);
    public const string DateTimeOffset = nameof(DateTimeOffset);
}
