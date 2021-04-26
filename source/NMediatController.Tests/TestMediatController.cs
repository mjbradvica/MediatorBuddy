namespace NMediatController.Tests
{
    using System;
    using System.Threading.Tasks;
    using ASPNET;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class TestMediatController : BaseMediatController
    {
        public TestMediatController(IMediator mediator)
            : base(mediator)
        {
        }

        // Accepted
        public async Task<IActionResult> Accepted(IRequest<object> request)
        {
            return await HandleAccepted(request);
        }

        public async Task<IActionResult> AcceptedObject(IRequest<object> request)
        {
            return await HandleAcceptedObject(request);
        }

        public async Task<IActionResult> Accepted(IRequest<object> request, string uri)
        {
            return await HandleAccepted(request, uri);
        }

        public async Task<IActionResult> Accepted(IRequest<object> request, Uri uri)
        {
            return await HandleAccepted(request, uri);
        }

        public async Task<IActionResult> AcceptedObject(IRequest<object> request, string uri)
        {
            return await HandleAcceptedObject(request, uri);
        }

        public async Task<IActionResult> AcceptedObject(IRequest<object> request, Uri uri)
        {
            return await HandleAcceptedObject(request, uri);
        }

        // Accepted At Action
        public async Task<IActionResult> AcceptedAtAction(IRequest<object> request, string actionName)
        {
            return await HandleAcceptedAtAction(request, actionName);
        }

        public async Task<IActionResult> AcceptedAtActionObject(IRequest<object> request, string actionName)
        {
            return await HandleAcceptedAtActionObject(request, actionName);
        }

        // Ok
        public async Task<IActionResult> Ok(IRequest<string> request)
        {
            return await HandleOk(request);
        }

        // Created
        public async Task<IActionResult> Created(IRequest<string> request, Uri uri)
        {
            return await HandleCreated(request, uri);
        }

        public async Task<IActionResult> Created(IRequest<string> request)
        {
            return await HandleCreated(request);
        }

        // NoContent
        public async Task<IActionResult> NoContent(IRequest<string> request)
        {
            return await HandleNoContent(request);
        }
    }
}
