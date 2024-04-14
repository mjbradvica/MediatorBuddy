// <copyright file="EnvelopeHandlerTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatorBuddy.AspNet.Registration;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Instantiation
{
    /// <summary>
    /// Tests for the base envelope handler.
    /// </summary>
    [TestClass]
    public class EnvelopeHandlerTests
    {
        /// <summary>
        /// Handlers can be resolved from the container.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task EmptyHandlers_CanBeInvokedThroughTheContainer()
        {
            var collection = new ServiceCollection();

            collection.AddMediatorBuddy(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            var provider = collection.BuildServiceProvider();

            var handler = provider.GetRequiredService<IRequestHandler<TestRequest, IEnvelope<Unit>>>();

            var result = await handler.Handle(new TestRequest(), CancellationToken.None);

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Response handlers can be invoked from the container.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ResponseHandler_CanBeInvokedThroughTheContainer()
        {
            var collection = new ServiceCollection();

            collection.AddMediatorBuddy(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            var provider = collection.BuildServiceProvider();

            var handler = provider.GetRequiredService<IRequestHandler<TestResponseRequest, IEnvelope<TestResponse>>>();

            var result = await handler.Handle(new TestResponseRequest(), CancellationToken.None);

            Assert.IsNotNull(result);
        }
    }
}
