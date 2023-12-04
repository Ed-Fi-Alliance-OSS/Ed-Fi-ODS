// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac.Core;

namespace EdFi.Ods.Common;

/// <summary>
/// Marks a module as a "plugin" module so that it is invoked after all other types of modules so that
/// services registered this way override services registered by other modules.
/// </summary>
public interface IPluginModule : IModule { }
