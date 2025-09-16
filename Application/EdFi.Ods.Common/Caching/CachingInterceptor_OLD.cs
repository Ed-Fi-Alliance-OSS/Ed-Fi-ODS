// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using EdFi.Ods.Common.Context;
using log4net;

namespace EdFi.Ods.Common.Caching;

public class CachingInterceptor_OLD(IConcurrentCacheProvider<ulong> _cacheProvider) : IInterceptor, IClearable
{
    private readonly ILog _logger = LogManager.GetLogger(typeof(CachingInterceptor));

    private static readonly ConcurrentDictionary<Type, Func<object, object>> _taskResultAccessors = new();
    private static readonly ConcurrentDictionary<Type, Func<object, Task>> _taskFromResultDelegates = new();
    private static readonly ConcurrentDictionary<MethodInfo, bool> _isAsyncMethodCache = new();

    public void Intercept(IInvocation invocation)
    {
        var returnType = invocation.Method.ReturnType;

        // We cannot cache Task return types.
        if (returnType == typeof(Task))
        {
            return;
        }

        ulong cacheKey;

        try
        {
            if (invocation.Method.DeclaringType == null)
            {
                throw new NotSupportedException($"Unable to generate a cache key for method '{invocation.Method.Name}' because it has no DeclaringType.");
            }

            cacheKey = GenerateCacheKey(invocation.Method, invocation.Arguments);
        }
        catch (Exception ex)
        {
            throw new CachingInterceptorCacheKeyGenerationException(
                $"Cache key generation failed for invocation of method '{invocation.Method.Name}' of declaring type '{invocation.Method.DeclaringType?.FullName}'.", ex);
        }

        bool isAsync = IsAsyncMethod(invocation.Method);

        var cachedValue = _cacheProvider.GetOrCreate(
            cacheKey,
            static (key, args) =>
            {
                // Proceed with the invocation
                args.invocation.Proceed();

                object result = !args.isAsync
                    // Force async completion synchronously.
                    ? HandleAsyncInvocation(args.invocation, args.returnType, args.logger)
                    
                    // Return the synchronous result.
                    : args.invocation.ReturnValue;

                return Task.FromResult(result);
            },
            TimeSpan.FromMinutes(1), // TODO: Make configurable?
            (invocation, isAsync, returnType, logger: _logger));

        invocation.ReturnValue = isAsync ? CreateCompletedTask(returnType, cachedValue) : cachedValue;
    }

    // private (Task task, Func<Object, object> accessor) HandleAsyncInvocation(IInvocation invocation, Type returnType, ulong cacheKey)
    private static object HandleAsyncInvocation(IInvocation invocation, Type returnType, ILog logger) // ulong cacheKey)
    {
        if (returnType == typeof(Task))
        {
            throw new NotSupportedException("Cannot cache a method invocation with a simple Task return type.");
        }

        var originalTask = (Task) invocation.ReturnValue;

        object result;

        try
        {
            // Force completion synchronously and get the T result without AggregateException wrapping.
            result = GetTaskResultSynchronously(originalTask);
        }
        catch (OperationCanceledException)
        {
            // Keep cancellation semantics identical to the original method.
            throw;
        }
        catch (Exception ex)
        {
            logger.Error(
                $"An exception occurred while invoking method '{invocation.Method.Name}' of '{invocation.TargetType.Name}'.",
                ex);

            // Rethrow preserving the original stack trace
            ExceptionDispatchInfo.Capture(ex).Throw();
            throw; // unreachable, keeps compiler happy
        }

        // At this point we have the completed result (T). You can cache it here using cacheKey.

        // Return a *completed* Task<T> to the caller so the method signature is preserved.
        // var fromResult = FromResultOpenGeneric.MakeGenericMethod(taskResultType);
        // invocation.ReturnValue = fromResult.Invoke(null, new[] { result });

        // Also return the raw value if your interceptor caller uses the object directly.
        return result;
        
        // // Task<T> handling
        // var resultAccessor = _taskResultAccessors.GetOrAdd(returnType, CreateResultAccessor);
        //
        // var continuation = originalTask.ContinueWith(t =>
        // {
        //     if (t.IsFaulted)
        //     {
        //         _logger.Error($"An exception occurred while invoking method '{invocation.Method.Name}' of '{invocation.TargetType.Name}'.", t.Exception);
        //
        //         return t;
        //     }
        //
        //     return Task.FromResult(resultAccessor(t));
        // }, TaskContinuationOptions.ExecuteSynchronously).Unwrap();
    }

    private static bool IsAsyncMethod(MethodInfo method)
        => _isAsyncMethodCache.GetOrAdd(method, m => typeof(Task).IsAssignableFrom(m.ReturnType));

    private static readonly ConcurrentDictionary<Type, Func<Task, object>> taskResultGettersByType = new();

    private static object GetTaskResultSynchronously(Task task)
    {
        var taskType = task.GetType();

        // Require Task<T>
        if (!taskType.IsGenericType || taskType.GetGenericTypeDefinition() != typeof(Task<>))
            throw new ArgumentException("Expected a Task<T>.", nameof(task));

        var resultType = taskType.GetGenericArguments()[0];

        // Get (or build) the compiled accessor for this T
        var getter = taskResultGettersByType.GetOrAdd(resultType, static t => CreateTaskResultGetter(t));

        // Invoke: will synchronously complete/throw original exception as GetResult() does
        return getter(task);
    }

    private static Func<Task, object> CreateTaskResultGetter(Type resultType)
    {
        // Build: (Task task) => (object)((Task<T>)task).GetAwaiter().GetResult()
        var taskParam = Expression.Parameter(typeof(Task), "task");

        var castedTask = Expression.Convert(
            taskParam,
            typeof(Task<>).MakeGenericType(resultType));

        var getAwaiter = Expression.Call(
            castedTask,
            typeof(Task<>).MakeGenericType(resultType).GetMethod(nameof(Task<int>.GetAwaiter), Type.EmptyTypes)!);

        var awaiterType = typeof(TaskAwaiter<>).MakeGenericType(resultType);

        var getResult = Expression.Call(
            getAwaiter,
            awaiterType.GetMethod(nameof(TaskAwaiter<int>.GetResult), Type.EmptyTypes)!);

        var box = Expression.Convert(getResult, typeof(object));

        return Expression.Lambda<Func<Task, object>>(box, taskParam).Compile();
    }

    private static Task CreateCompletedTask(Type returnType, object result)
    {
        if (returnType == typeof(Task))
        {
            return Task.CompletedTask;
        }

        var taskReturnType = returnType.GetGenericArguments()[0];
        
        var factory = _taskFromResultDelegates.GetOrAdd(taskReturnType, CreateTaskFromResultFactory);
        return factory(result);
    }

    private static Func<object, Task> CreateTaskFromResultFactory(Type returnType)
    {
        var method = typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(returnType);
        var param = Expression.Parameter(typeof(object), "value");
        var cast = Expression.Convert(param, returnType);
        var call = Expression.Call(method, cast);
        var lambda = Expression.Lambda<Func<object, Task>>(call, param);
        return lambda.Compile();
    }

    /*
    private static Func<object, object> CreateResultAccessor(Type taskType)
    {
        var resultProp = taskType.GetProperty("Result", BindingFlags.Instance | BindingFlags.Public);
        if (resultProp == null)
            throw new InvalidOperationException($"Expected Task<{taskType}> to have a Result property.");

        var param = Expression.Parameter(typeof(object), "task");
        var cast = Expression.Convert(param, taskType);
        var access = Expression.Property(cast, resultProp);
        var box = Expression.Convert(access, typeof(object));
        var lambda = Expression.Lambda<Func<object, object>>(box, param);
        return lambda.Compile();
    }
    */
    
    protected virtual ulong GenerateCacheKey(MethodInfo method, object[] arguments)
    {
        switch (arguments.Length)
        {
            case 0:
                return XxHash3Code.Combine(method.DeclaringType!.FullName, method.Name);

            case 1:
                return XxHash3Code.Combine(method.DeclaringType!.FullName, method.Name, arguments[0]);

            case 2:
                return XxHash3Code.Combine(method.DeclaringType!.FullName, method.Name, arguments[0], arguments[1]);

            case 3:
                return XxHash3Code.Combine(method.DeclaringType!.FullName, method.Name, arguments[0], arguments[1], arguments[2]);

            default:
                throw new NotImplementedException(
                    "Support for generating cache keys for more than 3 arguments has not been implemented.");
        }
    }

    public void Clear()
    {
        if (_cacheProvider is IClearable clearable)
        {
            clearable.Clear();
            return;
        }

        throw new NotSupportedException($"Unable to clear the underlying data associated with the {nameof(CachingInterceptor)}.");
    }
}
