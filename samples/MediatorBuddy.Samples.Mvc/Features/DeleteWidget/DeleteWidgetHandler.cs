// <copyright file="DeleteWidgetHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Mvc.Features.Common;
using MediatR;

namespace MediatorBuddy.Samples.Mvc.Features.DeleteWidget
{
    /// <summary>
    /// Sample delete widget handler.
    /// </summary>
    public class DeleteWidgetHandler : IEnvelopeHandler<DeleteWidgetRequest>
    {
        private readonly IWidgetRepository _widgetRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWidgetHandler"/> class.
        /// </summary>
        /// <param name="widgetRepository">An instance of the <see cref="IWidgetRepository"/> interface.</param>
        public DeleteWidgetHandler(IWidgetRepository widgetRepository)
        {
            _widgetRepository = widgetRepository;
        }

        /// <summary>
        /// Sample delete widget method.
        /// </summary>
        /// <param name="request">A <see cref="DeleteWidgetRequest"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        public async Task<IEnvelope<Unit>> Handle(DeleteWidgetRequest request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                return Envelope<Unit>.ValidationConstraintNotMet();
            }

            var widget = await _widgetRepository.GetById(request.Id);

            if (widget == null)
            {
                return Envelope<Unit>.EntityWasNotFound();
            }

            var result = await _widgetRepository.DeleteWidget(widget);

            if (result == 0)
            {
                return Envelope<Unit>.OperationCouldNotBeCompleted();
            }

            return Envelope<Unit>.Success(Unit.Value);
        }
    }
}
