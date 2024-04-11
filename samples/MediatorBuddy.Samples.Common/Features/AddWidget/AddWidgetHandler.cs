// <copyright file="AddWidgetHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Common.Features.Common;

namespace MediatorBuddy.Samples.Common.Features.AddWidget
{
    /// <summary>
    /// Sample handler for adding widgets.
    /// </summary>
    public class AddWidgetHandler : IEnvelopeHandler<AddWidgetRequest, AddWidgetResponse>
    {
        private readonly IWidgetRepository _widgetRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddWidgetHandler"/> class.
        /// </summary>
        /// <param name="widgetRepository">An instance of the <see cref="IWidgetRepository"/> interface.</param>
        public AddWidgetHandler(IWidgetRepository widgetRepository)
        {
            _widgetRepository = widgetRepository;
        }

        /// <inheritdoc/>
        public async Task<IEnvelope<AddWidgetResponse>> Handle(AddWidgetRequest request, CancellationToken cancellationToken)
        {
            var widget = WidgetFactory.FromRequest(request);

            if (widget == null)
            {
                return Envelope<AddWidgetResponse>.ValidationConstraintNotMet();
            }

            var result = await _widgetRepository.AddWidget(widget);

            if (result == 0)
            {
                return Envelope<AddWidgetResponse>.OperationCouldNotBeCompleted();
            }

            var response = WidgetFactory.AddResponse(widget);

            return Envelope<AddWidgetResponse>.Success(response);
        }
    }
}
