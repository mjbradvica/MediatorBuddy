namespace NMediatController.Tests
{
    using System;
    using System.Threading.Tasks;
    using ASPNET;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    internal class TestMediatController : BaseMediatController
    {
        public TestMediatController(IMediator mediator)
            : base(mediator)
        {
        }

        public async Task<IActionResult> Accepted(IRequest<string> request)
        {
            return await HandleAccepted(request);
        }

        public async Task<IActionResult> Accepted(IRequest<string> request, string uri)
        {
            return await HandleAccepted(request, uri);
        }

        public async Task<IActionResult> Accepted(IRequest<string> request, Uri uri)
        {
            return await HandleAccepted(request, uri);
        }

        public async Task<IActionResult> AcceptedObject(IRequest<object> request)
        {
            return await HandleAcceptedObject(request);
        }

        public async Task<IActionResult> AcceptedObject(IRequest<object> request, string uri)
        {
            return await HandleAcceptedObject(request, uri);
        }

        public async Task<IActionResult> AcceptedObject(IRequest<object> request, Uri uri)
        {
            return await HandleAcceptedObject(request, uri);
        }

        public async Task<IActionResult> Ok(IRequest<string> request)
        {
            return await HandleOk(request);
        }

        public async Task<IActionResult> Created(IRequest<string> request, Uri uri)
        {
            return await HandleCreated(request, uri);
        }

        public async Task<IActionResult> Created(IRequest<string> request)
        {
            return await HandleCreated(request);
        }

        public async Task<IActionResult> NoContent(IRequest<string> request)
        {
            return await HandleNoContent(request);
        }
    }
}
