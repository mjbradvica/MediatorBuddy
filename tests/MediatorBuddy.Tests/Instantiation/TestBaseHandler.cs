// <copyright file="TestBaseHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

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
