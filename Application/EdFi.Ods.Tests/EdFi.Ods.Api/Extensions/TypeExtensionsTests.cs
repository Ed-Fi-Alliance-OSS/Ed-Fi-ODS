// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Text;
using System.Threading.Tasks;
using EdFi.Ods.Api.Extensions;
using NUnit.Framework;
using Quartz;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Extensions;

[TestFixture]
public class TypeExtensionsTests
{
    [Test]
    public void IsDecoratorOf_WhenPassedAClassWithMultipleConstructors_ShouldReturnFalse()
    {
        typeof(NotADecoratorBecauseMultipleConstructors).IsDecoratorOf<IJob>().ShouldBeFalse();
    }

    [Test]
    public void IsDecoratorOf_WhenPassedAnAbstractClass_ShouldReturnFalse()
    {
        typeof(NotADecoratorBecauseAbstract).IsDecoratorOf<IJob>().ShouldBeFalse();
    }

    [Test]
    public void IsDecoratorOf_WhenPassedAClassWithNoServiceInjected_ShouldReturnFalse()
    {
        typeof(NotADecoratorBecauseNoServiceInjected).IsDecoratorOf<IJob>().ShouldBeFalse();
    }

    [Test]
    public void IsDecoratorOf_WhenPassedAClassWithASingleConstructorWithInjectedService_ShouldReturnTrue()
    {
        typeof(IsAConcreteClassDecorator).IsDecoratorOf<IJob>().ShouldBeTrue();
    }

    [Test]
    public void IsDecoratorOf_WhenPassedADerivedClassWithASingleConstructorWithInjectedService_ShouldReturnTrue()
    {
        typeof(IsADerivedClassDecorator).IsDecoratorOf<IJob>().ShouldBeTrue();
    }
    
    public abstract class NotADecoratorBecauseAbstract : IJob
    {
        protected NotADecoratorBecauseAbstract(IJob decorated) { }
        public abstract Task Execute(IJobExecutionContext context);
    }
    
    public class NotADecoratorBecauseMultipleConstructors : IJob
    {
        public NotADecoratorBecauseMultipleConstructors() { }
        public NotADecoratorBecauseMultipleConstructors(IJob decorated) { }

        public Task Execute(IJobExecutionContext context) => throw new System.NotImplementedException();
    }

    public class NotADecoratorBecauseNoServiceInjected : IJob
    {
        public NotADecoratorBecauseNoServiceInjected(NotADecoratorBecauseAbstract decorated) { }

        public Task Execute(IJobExecutionContext context) => throw new System.NotImplementedException();
    }

    public class IsAConcreteClassDecorator : IJob
    {
        public IsAConcreteClassDecorator(StringBuilder sb, IJob decorated) { }

        public Task Execute(IJobExecutionContext context) => throw new System.NotImplementedException();
    }

    public class IsADerivedClassDecorator : NotADecoratorBecauseAbstract
    {
        public IsADerivedClassDecorator(StringBuilder sb, IJob decorated) : base(decorated) { }

        public override Task Execute(IJobExecutionContext context) => throw new System.NotImplementedException();
    }
}
