// <copyright file="GetWidgetByIdHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Razor.Features.Common;

namespace MediatorBuddy.Samples.Razor.Features.GetById
{
    /// <summary>
    /// Sample get widget by id handler.
    /// </summary>
    public class GetWidgetByIdHandler : IEnvelopeHandler<GetWidgetByIdRequest, GetWidgetByIdResponse>
    {
        private readonly IWidgetRepository _widgetRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWidgetByIdHandler"/> class.
        /// </summary>
        /// <param name="widgetRepository">An instance of the <see cref="IWidgetRepository"/> interface.</param>
        public GetWidgetByIdHandler(IWidgetRepository widgetRepository)
        {
            _widgetRepository = widgetRepository;
        }

        /// <summary>
        /// Sample get widget by id method.
        /// </summary>
        /// <param name="request">A <see cref="GetWidgetByIdRequest"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        public async Task<IEnvelope<GetWidgetByIdResponse>> Handle(GetWidgetByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                return Envelope<GetWidgetByIdResponse>.ValidationConstraintNotMet();
            }

            var widget = await _widgetRepository.GetById(request.Id);

            if (widget == null)
            {
                return Envelope<GetWidgetByIdResponse>.EntityWasNotFound();
            }

            var response = WidgetFactory.GetByIdResponse(widget);

            return Envelope<GetWidgetByIdResponse>.Success(response);
        }
    }
}
