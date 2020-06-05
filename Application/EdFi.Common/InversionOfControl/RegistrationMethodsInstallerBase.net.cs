#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace EdFi.Ods.Common.InversionOfControl
{
    /// <summary>
    /// Provides an implementation of a Castle Windsor <see cref="IWindsorInstaller"/> that,
    /// using reflection, invokes all member methods whose name is prefixed with "Register", 
    /// and whose signature accepts and single parameter of type <see cref="IWindsorContainer"/>.
    /// </summary>
    /// <remarks>The installer invokes registration methods marked with the <see cref="PreregisterAttribute"/> 
    /// attribute before the other methods, and then within those groups the methods are invoked in 
    /// alphabetical order.  This is done to allow for preregistration of "core" components which 
    /// may then be used as dependencies for other registration methods.  For example, this is done
    /// for components that provide access to configuration values which other registration methods 
    /// may depend on (by calling <see cref="IWindsorContainer.Resolve"/>) to properly configure 
    /// their components.</remarks>
    public abstract class RegistrationMethodsInstallerBase : IWindsorInstaller
    {
        //private ILog logger = LogManager.GetLogger(typeof (RegistrationMethodsInstallerBase));

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Kernel.ComponentRegistered += (k, h) => logger.DebugFormat("Registered {0} - {1}/{2}", k, h.ComponentModel.Service.FullName, h.ComponentModel.Implementation.FullName);
            //container.Kernel.DependencyResolving += (k, h, j) => logger.DebugFormat("Resolving {0} - {1} - {2}", k, h, j);
            var registrationMethods =
                (from m in GetType()
                    .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                 let parameters = m.GetParameters()
                 where m.Name.StartsWith("Register")
                       && parameters.Length == 1
                       && parameters[0]
                          .ParameterType == typeof(IWindsorContainer)
                 let preregister = m.GetCustomAttributes(typeof(PreregisterAttribute), true)
                                    .Any()
                 select new
                        {
                            MethodInfo = m, Preregister = preregister
                        })
               .ToList();

            // Dynamically invoke all the preregistration methods
            foreach (var registrationMethod in registrationMethods.Where(x => x.Preregister)
                                                                  .OrderBy(x => x.MethodInfo.Name))
            {
                registrationMethod.MethodInfo.Invoke(
                    this,
                    new object[]
                    {
                        container
                    });
            }

            // Dynamically invoke all the non-preregistration methods
            foreach (var registrationMethod in registrationMethods.Where(x => !x.Preregister)
                                                                  .OrderBy(x => x.MethodInfo.Name))
            {
                registrationMethod.MethodInfo.Invoke(
                    this,
                    new object[]
                    {
                        container
                    });
            }
        }
    }
}
#endif