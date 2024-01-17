// <copyright file="Add.cshtml.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using MediatorBuddy.Samples.Razor.Features.AddWidget;
using MediatorBuddy.Samples.Razor.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.Samples.Razor.Pages.Widgets
{
    /// <summary>
    /// Sample add page for widgets.
    /// </summary>
    public class AddModel : MediatorBuddyBasePage<AddWidgetViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddModel"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        public AddModel(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Adds a new widget and redirects to the index page.
        /// </summary>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            return await ExecuteCommand(
                new AddWidgetRequest(ViewModel.Name),
                response => ("Details", null, new RouteValueDictionary(new { Id = response.Widget.Id })));
        }
    }
}