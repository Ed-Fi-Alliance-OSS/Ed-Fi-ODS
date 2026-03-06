// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;
using EdFi.LoadTools.ApiClient;

namespace EdFi.SmokeTest.Console.Application
{
    /// <summary>
    /// Creates a TokenProvider implementation that gets tokens from IOAuthTokenHandler
    /// </summary>
    public static class TokenProviderFactory
    {
        public static object CreateTokenProvider(Assembly sdkAssembly, IOAuthTokenHandler tokenHandler)
        {
            // Get TokenProvider<T> and OAuthToken types from SDK
            var tokenProviderType = sdkAssembly.GetExportedTypes()
                .FirstOrDefault(t => t.Name == "TokenProvider`1");
            var oauthTokenType = sdkAssembly.GetExportedTypes()
                .FirstOrDefault(t => t.Name == "OAuthToken");
                
            if (tokenProviderType == null || oauthTokenType == null)
            {
                return null;
            }

            var concreteTokenProviderType = tokenProviderType.MakeGenericType(oauthTokenType);
            
            // Create dynamic subclass of TokenProvider<OAuthToken>
            var assemblyName = new AssemblyName("DynamicTokenProvider");
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(
                assemblyName, 
                AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
            
            var typeBuilder = moduleBuilder.DefineType(
                "SmokeTestTokenProvider",
                TypeAttributes.Public | TypeAttributes.Class,
                concreteTokenProviderType);

            // Add a field to store the token handler
            var handlerField = typeBuilder.DefineField("_tokenHandler", typeof(IOAuthTokenHandler), FieldAttributes.Private);

            // Define constructor that takes IOAuthTokenHandler and calls base with empty token array
            var baseConstructor = concreteTokenProviderType.GetConstructor(
                new[] { typeof(IEnumerable<>).MakeGenericType(oauthTokenType) });
                
            var constructorBuilder = typeBuilder.DefineConstructor(
                MethodAttributes.Public,
                CallingConventions.Standard,
                new[] { typeof(IOAuthTokenHandler) });

            var ctorIL = constructorBuilder.GetILGenerator();
            
            // Get Array.Empty<OAuthToken>()
            var arrayEmptyMethod = typeof(Array).GetMethod("Empty").MakeGenericMethod(oauthTokenType);
            
            // Call base constructor with empty array
            ctorIL.Emit(OpCodes.Ldarg_0);
            ctorIL.Emit(OpCodes.Call, arrayEmptyMethod);
            ctorIL.Emit(OpCodes.Call, baseConstructor);
            
            // Store the token handler
            ctorIL.Emit(OpCodes.Ldarg_0);
            ctorIL.Emit(OpCodes.Ldarg_1);
            ctorIL.Emit(OpCodes.Stfld, handlerField);
            
            ctorIL.Emit(OpCodes.Ret);

            // Override GetAsync method to return a token from IOAuthTokenHandler
            var getAsyncMethod = concreteTokenProviderType.GetMethod("GetAsync", 
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                
            var methodBuilder = typeBuilder.DefineMethod(
                "GetAsync",
                MethodAttributes.Family | MethodAttributes.Virtual,
                typeof(ValueTask<>).MakeGenericType(oauthTokenType),
                new[] { typeof(string), typeof(CancellationToken) });

            var methodIL = methodBuilder.GetILGenerator();

            // Get bearer token from handler: string token = _tokenHandler.GetBearerToken();
            methodIL.Emit(OpCodes.Ldarg_0);
            methodIL.Emit(OpCodes.Ldfld, handlerField);
            methodIL.Emit(OpCodes.Callvirt, typeof(IOAuthTokenHandler).GetMethod("GetBearerToken"));

            // Create OAuthToken instance with just the token string
            // The constructor signature is: OAuthToken(string value, TimeSpan? timeout = null)
            // We'll pass the token and use reflection to get all constructors
            var oauthTokenConstructors = oauthTokenType.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            // Try to find a constructor that takes (string, TimeSpan?)
            ConstructorInfo oauthTokenConstructor = null;
            foreach (var ctor in oauthTokenConstructors)
            {
                var ctorParams = ctor.GetParameters();
                if (ctorParams.Length == 2 && 
                    ctorParams[0].ParameterType == typeof(string) &&
                    ctorParams[1].ParameterType == typeof(TimeSpan?))
                {
                    oauthTokenConstructor = ctor;
                    break;
                }
                else if (ctorParams.Length == 1 && ctorParams[0].ParameterType == typeof(string))
                {
                    oauthTokenConstructor = ctor;
                }
            }

            if (oauthTokenConstructor == null)
            {
                throw new InvalidOperationException($"Could not find constructor for OAuthToken");
            }

            // If constructor has 2 parameters, emit default(TimeSpan?) which is null
            var ctorParamsCount = oauthTokenConstructor.GetParameters().Length;
            if (ctorParamsCount == 2)
            {
                // Stack: [tokenString]
                // Create a default TimeSpan? (which is null)
                var timeSpanNullableLocal = methodIL.DeclareLocal(typeof(TimeSpan?));
                methodIL.Emit(OpCodes.Ldloca_S, timeSpanNullableLocal);
                methodIL.Emit(OpCodes.Initobj, typeof(TimeSpan?));
                methodIL.Emit(OpCodes.Ldloc, timeSpanNullableLocal);
                // Stack: [tokenString, default(TimeSpan?)]
            }

            methodIL.Emit(OpCodes.Newobj, oauthTokenConstructor);

            // Return as ValueTask<OAuthToken>: return new ValueTask<OAuthToken>(oauthToken);
            var valueTaskConstructor = typeof(ValueTask<>).MakeGenericType(oauthTokenType).GetConstructor(new[] { oauthTokenType });
            methodIL.Emit(OpCodes.Newobj, valueTaskConstructor);
            methodIL.Emit(OpCodes.Ret);

            typeBuilder.DefineMethodOverride(methodBuilder, getAsyncMethod);

            var dynamicType = typeBuilder.CreateType();
            return Activator.CreateInstance(dynamicType, tokenHandler);
        }
    }
}
