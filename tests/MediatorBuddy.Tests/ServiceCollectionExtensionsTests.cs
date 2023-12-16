// <copyright file="ServiceCollectionExtensionsTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Reflection;
using MediatorBuddy.AspNet.Registration;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// Tests the <see cref="ServiceCollectionExtensionsTests"/> class.
    /// </summary>
    [TestClass]
    public class ServiceCollectionExtensionsTests
    {
        /// <summary>
        /// Ensures the setup method has correct registrations.
        /// </summary>
        [TestMethod]
        public void AddMediatorBuddy_StandardConfig_HasCorrectRegistrations()
        {
            var assembly = new Mock<Assembly>();

            var services = new ServiceCollection();

            var configuration = new MediatRServiceConfiguration();
            configuration.RegisterServicesFromAssembly(assembly.Object);

            services.AddMediatorBuddy(configuration);

            var provider = services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IMediator>());
        }

        /// <summary>
        /// Ensures the setup method has correct registrations.
        /// </summary>
        [TestMethod]
        public void AddMediatorBuddy_Action_HasCorrectRegistrations()
        {
            var assembly = new Mock<Assembly>();

            var services = new ServiceCollection();

            services.AddMediatorBuddy(configuration => configuration.RegisterServicesFromAssembly(assembly.Object));

            var provider = services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IMediator>());
        }
    }
}
