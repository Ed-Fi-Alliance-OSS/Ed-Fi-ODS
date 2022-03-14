// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Engine.Query;

namespace EdFi.Ods.Common.Infrastructure.Filtering;

public interface IInstanceAuthorizationResult
{
    /// <summary>
    /// Indicates whether instance-based authorization could be performed.
    /// </summary>
    bool AuthorizationPerformed { get; }

    /// <summary>
    /// Gets the Exception to be thrown, if necessary, to indicate authorization failure.
    /// </summary>
    Exception Exception { get; }
}

public class InstanceAuthorizationResult : IInstanceAuthorizationResult
{
    /// <summary>
    /// An instance authorization result indicating instance-based authorization could not be performed.
    /// </summary>
    public static InstanceAuthorizationResult NotPerformed = new InstanceAuthorizationResult(authorizationPerformed: false);
        
    /// <summary>
    /// An instance authorization result indicating success.
    /// </summary>
    public static InstanceAuthorizationResult Success = new InstanceAuthorizationResult(authorizationPerformed: true);

    /// <summary>
    /// Initializes a new instance of the <see cref="InstanceAuthorizationResult"/> class to indicate failure with the
    /// supplied exception.
    /// </summary>
    /// <param name="ex">The exception that occurred.</param>
    public InstanceAuthorizationResult(Exception ex)
    {
        Exception = ex;
        AuthorizationPerformed = true;
    }

    private InstanceAuthorizationResult(bool authorizationPerformed)
    {
        AuthorizationPerformed = authorizationPerformed;
    }

    /// <summary>
    /// Indicates whether instance-based authorization could be performed.
    /// </summary>
    public bool AuthorizationPerformed { get; }
        
    /// <summary>
    /// Gets the Exception to be thrown, if necessary, to indicate authorization failure.
    /// </summary>
    public Exception Exception { get; }

    // /// <summary>
    // /// Indicates whether the authorization was successful.
    // /// </summary>
    // /// <returns><b>true</b> if authorization was successful, <b>false</b> if unsuccessful, or <b>null</b> if instance authorization could not be performed.</returns>
    // public bool? IsAuthorized()
    // {
    //     if (!AuthorizationPerformed)
    //     {
    //         return null;
    //     }
    //
    //     return Exception != null;
    // }
}

public interface IResolvableInstanceAuthorizationResult : IInstanceAuthorizationResult
{
    void ResolveSuccessful();

    void ResolveWithFailure(Exception ex);
}

public class ResolvableInstanceAuthorizationResult : IResolvableInstanceAuthorizationResult
{
    private InstanceAuthorizationResult _result;

    public ResolvableInstanceAuthorizationResult(InstanceAuthorizationResult initialResult)
    {
        _result = initialResult;
    }

    public bool AuthorizationPerformed
    {
        get => _result.AuthorizationPerformed;
    }

    public Exception Exception
    {
        get => _result.Exception;
    }

    public void ResolveSuccessful()
    {
        _result = InstanceAuthorizationResult.Success;
    }

    public void ResolveWithFailure(Exception ex)
    {
        _result = new InstanceAuthorizationResult(ex);
    }
}

public class CompositeResolvableInstanceAuthorizationResult : IResolvableInstanceAuthorizationResult
{
    public bool AuthorizationPerformed
    {
        get => _authorizationResults.All(x => x.AuthorizationPerformed);
    }

    public Exception Exception
    {
        get => _authorizationResults.FirstOrDefault(x => x.Exception != null)?.Exception;
    }

    private List<IResolvableInstanceAuthorizationResult> _authorizationResults = new();
    
    public void AddAuthorizationResult(IResolvableInstanceAuthorizationResult authorizationResult)
    {
        _authorizationResults.Add(authorizationResult);
    }

    public void ResolveSuccessful()
    {
        _authorizationResults.ForEach(x => x.ResolveSuccessful());
    }

    public void ResolveWithFailure(Exception ex)
    {
        _authorizationResults.ForEach(x => x.ResolveWithFailure(ex));
    }
}
