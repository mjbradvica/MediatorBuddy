// <copyright file="TestBaseHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// Tests for the base envelope handler.
    /// </summary>
    [TestClass]
    public class EnvelopeHandlerTests
    {
    }

    /// <summary>
    /// Sample request for handler.
    /// </summary>
    internal class TestRequest : IEnvelopeRequest
    {
    }

    /// <inheritdoc />
    internal class TestBaseHandler : EnvelopeHandler<TestRequest>
    {
        /// <inheritdoc/>
        public override Task<IEnvelope<Unit>> Handle(TestRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Success());
        }
    }
}
