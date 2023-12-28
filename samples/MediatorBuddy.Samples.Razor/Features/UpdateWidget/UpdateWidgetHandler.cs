// <copyright file="UpdateWidgetHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Razor.Features.Common;

namespace MediatorBuddy.Samples.Razor.Features.UpdateWidget
{
    /// <summary>
    /// Sample update widget handler.
    /// </summary>
    public class UpdateWidgetHandler : IEnvelopeHandler<UpdateWidgetRequest, UpdateWidgetResponse>
    {
        private readonly IWidgetRepository _widgetRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWidgetHandler"/> class.
        /// </summary>
        /// <param name="widgetRepository">An instance of the <see cref="IWidgetRepository"/> interface.</param>
        public UpdateWidgetHandler(IWidgetRepository widgetRepository)
        {
            _widgetRepository = widgetRepository;
        }

        /// <summary>
        /// Sample update widget method.
        /// </summary>
        /// <param name="request">A <see cref="UpdateWidgetRequest"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        public async Task<IEnvelope<UpdateWidgetResponse>> Handle(UpdateWidgetRequest request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                return Envelope<UpdateWidgetResponse>.ValidationConstraintNotMet();
            }

            var widget = await _widgetRepository.GetById(request.Id);

            if (widget == null)
            {
                return Envelope<UpdateWidgetResponse>.EntityWasNotFound();
            }

            var updateResult = widget.UpdateName(request.Name);

            if (updateResult == 0)
            {
                return Envelope<UpdateWidgetResponse>.PreConditionNotMet();
            }

            var result = await _widgetRepository.UpdateWidget(widget);

            if (result == 0)
            {
                return Envelope<UpdateWidgetResponse>.OperationCouldNotBeCompleted();
            }

            var response = WidgetFactory.UpdateResponse(widget);

            return Envelope<UpdateWidgetResponse>.Success(response);
        }
    }
}
