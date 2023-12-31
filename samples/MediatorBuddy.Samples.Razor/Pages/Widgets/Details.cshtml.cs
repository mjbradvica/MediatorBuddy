// <copyright file="Details.cshtml.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using AutoMapper;
using MediatorBuddy.Samples.Razor.Common;
using MediatorBuddy.Samples.Razor.Features.GetById;
using MediatorBuddy.Samples.Razor.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.Samples.Razor.Pages.Widgets
{
    /// <summary>
    /// Sample Widget details page.
    /// </summary>
    public class DetailsModel : BaseGetPage<WidgetViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DetailsModel"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        /// <param name="mapper">An instance of the <see cref="IMapper"/> interface.</param>
        public DetailsModel(IMediator mediator, IMapper mapper)
            : base(mediator, mapper)
        {
        }

        /// <summary>
        /// Gets a widget details.
        /// </summary>
        /// <param name="id">The widget identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            return await ExecuteGet(new GetWidgetByIdRequest(id));
        }
    }
}
