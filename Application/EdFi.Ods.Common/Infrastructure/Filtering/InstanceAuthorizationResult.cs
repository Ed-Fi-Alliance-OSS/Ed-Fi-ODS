// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Engine.Query;

namespace EdFi.Ods.Common.Infrastructure.Filtering;

public enum AuthorizationState
{
    NotPerformed,
    Success,
    Failed,
}

public class InstanceAuthorizationResult
{
    /// <summary>
    /// An instance authorization result indicating instance-based authorization could not be performed.
    /// </summary>
    public static InstanceAuthorizationResult NotPerformed() => new(AuthorizationState.NotPerformed);
    
    /// <summary>
    /// An instance authorization result indicating success.
    /// </summary>
    public static InstanceAuthorizationResult Success() => new(AuthorizationState.Success);

    /// <summary>
    /// An instance authorization result indicating success.
    /// </summary>
    public static InstanceAuthorizationResult Failed(Exception ex) => new(ex);

    /// <summary>
    /// Initializes a new instance of the <see cref="InstanceAuthorizationResult"/> class to indicate failure with the
    /// supplied exception.
    /// </summary>
    /// <param name="ex">The exception that occurred.</param>
    private InstanceAuthorizationResult(Exception ex)
    {
        State = AuthorizationState.Failed;
        Exception = ex;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InstanceAuthorizationResult"/> class using the supplied authorization state.
    /// </summary>
    /// <param name="state"></param>
    private InstanceAuthorizationResult(AuthorizationState state)
    {
        if (state == AuthorizationState.Failed)
        {
            throw new InvalidOperationException(
                "Authorization state of error must have an associated exception. Use another constructor.");
        }
        
        State = state;
    }

    /// <summary>
    /// Indicates the current state of authorization of the instance.
    /// </summary>
    public AuthorizationState State { get; private set; }

    /// <summary>
    /// Gets the Exception indicating the authorization failure.
    /// </summary>
    public Exception Exception { get; private set; }

    /// <summary>
    /// Resolve the authorization to a success state.
    /// </summary>
    public void ResolveSuccessful()
    {
        if (State != AuthorizationState.NotPerformed)
        {
            throw new InvalidOperationException("Cannot change the state of an authorization that has already been performed.");
        }

        State = AuthorizationState.Success;
    }

    /// <summary>
    /// Resolve the authorization to a failed state with the supplied exception.
    /// </summary>
    /// <param name="ex"></param>
    /// <exception cref="InvalidOperationException">Occurs when the current <see cref="State" /> is not <see cref="AuthorizationState.NotPerformed" />.</exception>
    public void ResolveFailed(Exception ex)
    {
        if (State != AuthorizationState.NotPerformed)
        {
            throw new InvalidOperationException("Cannot change the state of an authorization that has already been performed.");
        }
        
        State = AuthorizationState.Failed;
        Exception = ex;
    }
}
