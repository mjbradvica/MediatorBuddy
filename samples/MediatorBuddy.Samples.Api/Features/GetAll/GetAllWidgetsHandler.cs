// <copyright file="GetAllWidgetsHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Api.Features.Common;

namespace MediatorBuddy.Samples.Api.Features.GetAll
{
    /// <summary>
    /// Sample get all widgets handler.
    /// </summary>
    public class GetAllWidgetsHandler : IEnvelopeHandler<GetAllWidgetsRequest, GetAllWidgetsResponse>
    {
        private readonly IWidgetRepository _widgetRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllWidgetsHandler"/> class.
        /// </summary>
        /// <param name="widgetRepository">An instance of the <see cref="IWidgetRepository"/> interface.</param>
        public GetAllWidgetsHandler(IWidgetRepository widgetRepository)
        {
            _widgetRepository = widgetRepository;
        }

        /// <summary>
        /// Sample get all widgets method.
        /// </summary>
        /// <param name="request">A <see cref="GetAllWidgetsRequest"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        public async Task<IEnvelope<GetAllWidgetsResponse>> Handle(GetAllWidgetsRequest request, CancellationToken cancellationToken)
        {
            var widgets = await _widgetRepository.GetAllWidgets();

            var response = WidgetFactory.GetAllResponse(widgets);

            return Envelope<GetAllWidgetsResponse>.Success(response);
        }
    }
}
