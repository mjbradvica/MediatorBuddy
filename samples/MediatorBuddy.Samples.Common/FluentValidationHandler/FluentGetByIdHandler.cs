// <copyright file="FluentGetByIdHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Common.Features.Common;

namespace MediatorBuddy.Samples.Common.FluentValidationHandler
{
    /// <summary>
    /// Sample fluent get by id handler.
    /// </summary>
    public class FluentGetByIdHandler : IEnvelopeHandler<FluentGetByIdRequest, FluentGetByIdResponse>
    {
        private readonly IWidgetRepository _widgetRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentGetByIdHandler"/> class.
        /// </summary>
        /// <param name="widgetRepository">An instance of the <see cref="IWidgetRepository"/> interface.</param>
        public FluentGetByIdHandler(IWidgetRepository widgetRepository)
        {
            _widgetRepository = widgetRepository;
        }

        /// <summary>
        /// Sample method for fluent handler.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        public async Task<IEnvelope<FluentGetByIdResponse>> Handle(FluentGetByIdRequest request, CancellationToken cancellationToken)
        {
            var validationResult = GetByIdValidator.ValidateRequest(request);

            if (!validationResult.IsValid)
            {
                return Envelope<FluentGetByIdResponse>.ValidationConstraintNotMet();
            }

            var widget = await _widgetRepository.GetById(request.Id);

            if (widget == null)
            {
                return Envelope<FluentGetByIdResponse>.EntityWasNotFound();
            }

            var response = WidgetFactory.FluentResponse(widget);

            return Envelope<FluentGetByIdResponse>.Success(response);
        }
    }
}
