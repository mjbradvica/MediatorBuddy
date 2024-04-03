// <copyright file="StandardAutoMapperPage.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using AutoMapper;
using MediatorBuddy.AspNet;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.Samples.Razor.Common
{
    /// <summary>
    /// Sample base get page.
    /// </summary>
    /// <typeparam name="TViewModel">The view model type.</typeparam>
    public abstract class StandardAutoMapperPage<TViewModel> : MediatorBuddyStandardPage<TViewModel>
        where TViewModel : new()
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardAutoMapperPage{TViewModel}"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        /// <param name="mapper">An instance of the <see cref="IMapper"/> interface.</param>
        protected StandardAutoMapperPage(IMediator mediator, IMapper mapper)
            : base(mediator)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Executes a get for a request.
        /// </summary>
        /// <param name="request">The get request.</param>
        /// <typeparam name="TResponse">The response type.</typeparam>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        protected async Task<IActionResult> ExecuteGet<TResponse>(IEnvelopeRequest<TResponse> request)
        {
            return await ExecuteQuery(request, _mapper.Map<TResponse, TViewModel>);
        }
    }
}
