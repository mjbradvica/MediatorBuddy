// <copyright file="TestBaseHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatorBuddy.Tests.Instantiation
{
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
