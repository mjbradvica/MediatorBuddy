// <copyright file="TestBaseResponseHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

namespace MediatorBuddy.Tests.Instantiation
{
    /// <inheritdoc />
    internal class TestBaseResponseHandler : EnvelopeHandler<TestResponseRequest, TestResponse>
    {
        /// <inheritdoc/>
        public override Task<IEnvelope<TestResponse>> Handle(TestResponseRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Success(new TestResponse()));
        }
    }
}
