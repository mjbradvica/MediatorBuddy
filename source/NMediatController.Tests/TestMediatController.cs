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
        public async Task<IActionResult> Accepted(TestObjectRequest request) => await HandleAccepted(request);

        public async Task<IActionResult> AcceptedObject(TestObjectRequest request) => await HandleAcceptedObject(request);

        public async Task<IActionResult> Accepted(TestObjectRequest request, string uri) => await HandleAccepted(request, uri);

        public async Task<IActionResult> Accepted(TestObjectRequest request, Uri uri) => await HandleAccepted(request, uri);

        public async Task<IActionResult> AcceptedObject(TestObjectRequest request, string uri) => await HandleAcceptedObject(request, uri);

        public async Task<IActionResult> AcceptedObject(TestObjectRequest request, Uri uri) => await HandleAcceptedObject(request, uri);

        // Accepted At Action
        public async Task<IActionResult> AcceptedAtAction(TestObjectRequest request, string actionName) => await HandleAcceptedAtAction(request, actionName);

        public async Task<IActionResult> AcceptedAtActionObject(TestObjectRequest request, string actionName) => await HandleAcceptedAtActionObject(request, actionName);

        public async Task<IActionResult> AcceptedAtAction(TestObjectRequest request, string actionName, string controllerName) => await HandleAcceptedAtAction(request, actionName, controllerName);

        public async Task<IActionResult> AcceptedAtActionObject(TestObjectRequest request, string actionName, object routeValues) => await HandleAcceptedAtActionObject(request, actionName, routeValues);

        public async Task<IActionResult> AcceptedAtAction(TestObjectRequest request, string actionName, string controllerName, object routeValues) => await HandleAcceptedAtAction(request, actionName, controllerName, routeValues);

        public async Task<IActionResult> AcceptedAtActionObject(TestObjectRequest request, string actionName, string controllerName, object routeValues) => await HandleAcceptedAtActionObject(request, actionName, controllerName, routeValues);



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
