// <copyright file="DeleteWidgetHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Common.Features.Common;
using MediatR;

namespace MediatorBuddy.Samples.Common.Features.DeleteWidget
{
    /// <summary>
    /// Sample delete widget handler.
    /// </summary>
    public class DeleteWidgetHandler : EnvelopeHandler<DeleteWidgetRequest>
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
        public override async Task<IEnvelope<Unit>> Handle(DeleteWidgetRequest request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                return ValidationConstraintNotMet();
            }

            var widget = await _widgetRepository.GetById(request.Id);

            if (widget == null)
            {
                return EntityWasNotFound();
            }

            var result = await _widgetRepository.DeleteWidget(widget);

            if (result == 0)
            {
                return OperationCouldNotBeCompleted();
            }

            return Success();
        }
    }
}
