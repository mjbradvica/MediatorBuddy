using MediatorBuddy.AspNet;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.Samples.Razor.Common
{
    /// <summary>
    /// Sample base mapped page.
    /// </summary>
    /// <typeparam name="TViewModel">The view model type.</typeparam>
    public abstract class BaseGetMappedPage<TViewModel> : MediatorBuddyPage
        where TViewModel : new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseGetMappedPage{TViewModel}"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        protected BaseGetMappedPage(IMediator mediator)
            : base(mediator)
        {
            ViewModel = new TViewModel();
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        [BindProperty]
        public TViewModel ViewModel { get; set; }

        /// <summary>
        /// Executes a get request.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="request">The request to execute.</param>
        /// <param name="mappingFunc">A mapping func to execute.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        protected async Task<IActionResult> ExecuteGet<TResponse>(IEnvelopeRequest<TResponse> request, Func<TResponse, TViewModel> mappingFunc)
        {
            return await ExecuteRequest(request, response => ViewModel = mappingFunc.Invoke(response));
        }
    }
}
