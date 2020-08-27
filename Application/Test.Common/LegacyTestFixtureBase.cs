// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace Test.Common
{
    [TestFixture]
    [Obsolete("RhinoMocks has been deprecated use TestFixtureBase")]
    public abstract class LegacyTestFixtureBase
    {
        protected MockRepository mocks;

        private Exception _actualException;
        private bool _actualExceptionInspected;

        protected Exception ActualException
        {
            get
            {
                _actualExceptionInspected = true;
                return _actualException;
            }
            set
            {
                _actualExceptionInspected = false;
                _actualException = value;
            }
        }

        [OneTimeSetUp]
        public virtual void RunOnceBeforeAny()
        {
            // Initialize NBuilder settings
            //BuilderSetup.SetDefaultPropertyNamer(new NonDefaultNonRepeatingPropertyNamer(new ReflectionUtil()));

            // Create a mock repository for new mocks
            mocks = new MockRepository();

            try
            {
                //Arrange
                EstablishContext();
                Arrange();
            }
            catch (Exception ex)
            {
                var handled = HandleArrangeException(ex);

                if (!handled)
                {
                    throw;
                }
            }

            // Stop recording
            mocks.ReplayAll();

            //Act
            try
            {
                // Allow execution of code just prior to behavior execution
                BeforeBehaviorExecution();

                // Execute the behavior
                try
                {
                    ExecuteBehavior();
                    Act();
                }
                catch (Exception ex)
                {
                    ActualException = ex;
                }
            }
            finally
            {
                // Allow cleanup surrounding behavior execution, prior to final cleanup
                AfterBehaviorExecution();
            }
        }

        [OneTimeTearDown]
        public virtual void RunOnceAfterAll()
        {
            // Make sure all objects are now in replay mode
            mocks.ReplayAll();

            // Make sure all defined mocks are satisfied
            mocks.VerifyAll();

            // Make sure exception was inspected.
            if (_actualException != null && !_actualExceptionInspected)
            {
                throw new AssertionException(
                    string.Format(
                        "The exception of type '{0}' was not inspected by the test:\r\n {1}.",
                        _actualException.GetType()
                            .Name,
                        _actualException));
            }
        }

        protected virtual void Arrange() { }

        protected virtual void EstablishContext() { }

        protected virtual void BeforeBehaviorExecution() { }

        protected virtual void AfterBehaviorExecution() { }

        /// <summary>
        /// Executes the code to be tested.
        /// </summary>
        protected virtual void Act() { }

        protected virtual void ExecuteBehavior() { }

        protected T Stub<T>()
            where T : class
        {
            return MockRepository.GenerateStub<T>();
        }

        protected virtual bool HandleArrangeException(Exception ex)
        {
            return false;
        }
    }
}
