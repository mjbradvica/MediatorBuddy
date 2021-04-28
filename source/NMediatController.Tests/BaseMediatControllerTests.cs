namespace NMediatController.Tests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class BaseControllerTests
    {
        private const string ActionName = "MyActionName";
        private const string ControllerName = "MyControllerName";
        private const string UriString = "http://www.test.com/";
        private readonly RouteValueDictionary _routeValues = new RouteValueDictionary { { "route", "value" } };
        private readonly Mock<IMediator> _mediator;
        private readonly TestMediatController _controller;
        private readonly Uri _uri = new Uri(UriString);

        public BaseControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _controller = new TestMediatController(_mediator.Object);
            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None)).ReturnsAsync(new TestResponse());
        }

        [TestMethod]
        public async Task HandleAccepted_ReturnsAcceptedResult()
        {
            var result = await _controller.Accepted(TestObjectRequest.Valid()) as AcceptedResult;

            Assert.IsInstanceOfType(result, typeof(AcceptedResult));
            Assert.IsNull(result.Value);
        }

        [TestMethod]
        public async Task HandleAcceptedObject_ReturnsAcceptedResult()
        {
            var result = await _controller.AcceptedObject(TestObjectRequest.Valid()) as AcceptedResult;

            Assert.IsInstanceOfType(result, typeof(AcceptedResult));
            Assert.IsInstanceOfType(result.Value, typeof(TestResponse));
        }

        [TestMethod]
        public async Task HandleAccepted_StringUri_ReturnsAcceptedResult()
        {
            var result = await _controller.Accepted(TestObjectRequest.Valid(), UriString) as AcceptedResult;

            Assert.IsInstanceOfType(result, typeof(AcceptedResult));
            Assert.IsNull(result.Value);
            Assert.AreEqual(UriString, result.Location);
        }

        [TestMethod]
        public async Task HandleAccepted_Uri_ReturnsAcceptedResult()
        {
            var result = await _controller.Accepted(TestObjectRequest.Valid(), _uri) as AcceptedResult;

            Assert.IsInstanceOfType(result, typeof(AcceptedResult));
            Assert.IsNull(result.Value);
            Assert.AreEqual(UriString, result.Location);
        }

        [TestMethod]
        public async Task HandleAcceptedObject_StringUri_ReturnsAcceptedResult()
        {
            var result = await _controller.AcceptedObject(TestObjectRequest.Valid(), UriString) as AcceptedResult;

            Assert.IsInstanceOfType(result, typeof(AcceptedResult));
            Assert.AreEqual(UriString, result.Location);
            Assert.IsInstanceOfType(result.Value, typeof(TestResponse));
        }

        [TestMethod]
        public async Task HandleAcceptedObject_Uri_ReturnsAcceptedResult()
        {
            var result = await _controller.AcceptedObject(TestObjectRequest.Valid(), _uri) as AcceptedResult;

            Assert.IsInstanceOfType(result, typeof(AcceptedResult));
            Assert.AreEqual(UriString, result.Location);
            Assert.IsInstanceOfType(result.Value, typeof(TestResponse));
        }

        // Accepted At Action
        [TestMethod]
        public async Task HandleAcceptedAtAction_ActionName_ReturnsAcceptedAtActionResult()
        {
            var result = await _controller.AcceptedAtAction(TestObjectRequest.Valid(), ActionName) as AcceptedAtActionResult;

            Assert.IsInstanceOfType(result, typeof(AcceptedAtActionResult));
            Assert.IsNull(result.Value);
            Assert.AreEqual(ActionName, result.ActionName);
        }

        [TestMethod]
        public async Task HandleAcceptedAtActionObject_ActionName_ReturnsAcceptedAtActionResult()
        {
            var result = await _controller.AcceptedAtActionObject(TestObjectRequest.Valid(), ActionName) as AcceptedAtActionResult;

            Assert.IsInstanceOfType(result, typeof(AcceptedAtActionResult));
            Assert.IsInstanceOfType(result.Value, typeof(TestResponse));
            Assert.AreEqual(ActionName, result.ActionName);
        }

        [TestMethod]
        public async Task HandleAcceptedAtAction_ActionName_ControllerName_ReturnsAcceptedAtActionResult()
        {
            var result = await _controller.AcceptedAtAction(TestObjectRequest.Valid(), ActionName, ControllerName) as AcceptedAtActionResult;

            Assert.IsInstanceOfType(result, typeof(AcceptedAtActionResult));
            Assert.IsNull(result.Value);
            Assert.AreEqual(ActionName, result.ActionName);
            Assert.AreEqual(ControllerName, result.ControllerName);
        }

        [TestMethod]
        public async Task HandleAcceptedAtActionObject_ActionName_RouteValues_ReturnsCorrectValues()
        {
            var result = await _controller.AcceptedAtActionObject(TestObjectRequest.Valid(), ActionName, _routeValues) as AcceptedAtActionResult;

            Assert.IsInstanceOfType(result, typeof(AcceptedAtActionResult));
            Assert.IsInstanceOfType(result.Value, typeof(TestResponse));
            Assert.AreEqual(ActionName, result.ActionName);
            Assert.IsInstanceOfType(result.RouteValues, typeof(RouteValueDictionary));
        }

        [TestMethod]
        public async Task HandleAcceptedAtAction_ActionName_ControllerName_RouteValues_ReturnsCorrectValues()
        {
            var result = await _controller.AcceptedAtAction(TestObjectRequest.Valid(), ActionName, ControllerName, _routeValues) as AcceptedAtActionResult;

            Assert.IsInstanceOfType(result, typeof(AcceptedAtActionResult));
            Assert.IsNull(result.Value);
            Assert.AreEqual(ControllerName, result.ControllerName);
            Assert.AreEqual(ActionName, result.ActionName);
            Assert.IsInstanceOfType(result.RouteValues, typeof(RouteValueDictionary));
        }

        [TestMethod]
        public async Task HandleAcceptedAtActionObject_ActionName_ControllerName_RouteValues_ReturnsCorrectValues()
        {
            var result = await _controller.AcceptedAtActionObject(TestObjectRequest.Valid(), ActionName, ControllerName, _routeValues) as AcceptedAtActionResult;

            Assert.IsInstanceOfType(result, typeof(AcceptedAtActionResult));
            Assert.IsInstanceOfType(result.Value, typeof(TestResponse));
            Assert.AreEqual(ControllerName, result.ControllerName);
            Assert.AreEqual(ActionName, result.ActionName);
            Assert.IsInstanceOfType(result.RouteValues, typeof(RouteValueDictionary));
        }








        [TestMethod]
        public async Task HandleOk_Success_ReturnsOkResult()
        {
            var result = await _controller.Ok(TestStringRequest.Valid());

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task HandleCreated_Success_Uri_ReturnsCreatedResult()
        {
            var result = await _controller.Created(TestStringRequest.Valid());

            Assert.IsInstanceOfType(result, typeof(CreatedResult));
        }

        [TestMethod]
        public async Task HandleCreated_Success_ReturnsCreatedResult()
        {
            var result = await _controller.Created(TestStringRequest.Valid(), _uri);

            Assert.IsInstanceOfType(result, typeof(CreatedResult));
        }

        [TestMethod]
        public async Task HandleNoContent_Success_ReturnsNoContentResult()
        {
            var result = await _controller.NoContent(TestStringRequest.Valid());

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task Handle_ValidationFailure_ReturnsBadRequest()
        {
            var result = await _controller.Ok(TestStringRequest.Invalid());

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task Handle_OnException_ReturnsBadRequest()
        {
            _mediator.Setup(mediator => mediator.Send(It.IsAny<IRequest<string>>(), CancellationToken.None))
                .Throws<Exception>();

            var result = await _controller.Ok(TestStringRequest.Valid()) as StatusCodeResult;

            Assert.AreEqual(result.StatusCode, StatusCodes.Status500InternalServerError);
        }
    }
}
