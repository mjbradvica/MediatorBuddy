// <copyright file="Index.cshtml.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using MediatorBuddy.Samples.Common.Features.GetAll;
using MediatorBuddy.Samples.Razor.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.Samples.Razor.Pages.Widgets
{
    /// <summary>
    /// Index for widgets.
    /// </summary>
    public class IndexModel : MediatorBuddyPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        public IndexModel(IMediator mediator)
            : base(mediator)
        {
            ViewModel = new WidgetIndexViewModel();
        }

        /// <summary>
        /// Gets or sets the index view model.
        /// </summary>
        [BindProperty]
        public WidgetIndexViewModel ViewModel { get; set; }

        /// <summary>
        /// Gets all widgets.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IActionResult> OnGetAsync()
        {
            return await ExecuteRequest(new GetAllWidgetsRequest(), ViewModel.FromResponse);
        }
    }
}
