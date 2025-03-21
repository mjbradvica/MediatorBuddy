﻿// <copyright file="UpdateWidgetHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Common.Features.Common;

namespace MediatorBuddy.Samples.Common.Features.UpdateWidget
{
    /// <summary>
    /// Sample update widget handler.
    /// </summary>
    public class UpdateWidgetHandler : EnvelopeHandler<UpdateWidgetRequest, UpdateWidgetResponse>
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
        public override async Task<IEnvelope<UpdateWidgetResponse>> Handle(UpdateWidgetRequest request, CancellationToken cancellationToken)
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

            var updateResult = widget.UpdateName(request.Name);

            if (updateResult == 0)
            {
                return PreConditionNotMet();
            }

            var result = await _widgetRepository.UpdateWidget(widget);

            if (result == 0)
            {
                return OperationCouldNotBeCompleted();
            }

            var response = WidgetFactory.UpdateResponse(widget);

            return Success(response);
        }
    }
}
