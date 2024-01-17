// <copyright file="BaseMvcController.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using AutoMapper;
using MediatorBuddy.AspNet;
using MediatorBuddy.AspNet.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.Samples.Mvc.Controllers
{
    /// <summary>
    /// Example controller that utilizes AutoMapper.
    /// </summary>
    public abstract class BaseMvcController : MediatorBuddyMvc
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMvcController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        /// <param name="mapper">An instance of the <see cref="IMapper"/> interface.</param>
        protected BaseMvcController(IMediator mediator, IMapper mapper)
            : base(mediator)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Executes a get request that returns a view response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the request object.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="request">The request object.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<IActionResult> ExecuteGet<TResponse, TViewModel>(IRequest<IEnvelope<TResponse>> request)
        {
            return await ExecuteRequest(request, ResponseOptions.ViewResponse<TResponse, TViewModel>(response => _mapper.Map<TResponse, TViewModel>(response)));
        }
    }
}
