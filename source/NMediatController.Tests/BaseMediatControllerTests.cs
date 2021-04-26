namespace NMediatController.Tests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class BaseControllerTests
    {
        private const string ActionName = "MyActionName";
        private const string UriString = "http://www.test.com/";
        private readonly Mock<IMediator> _mediator;
        private readonly TestMediatController _controller;
        private readonly Uri _uri = new Uri(UriString);

        public BaseControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _controller = new TestMediatController(_mediator.Object);
        }

        // Accepted
        [TestMethod]
        public async Task HandleAccepted_ReturnsAcceptedResult()
        {
            var result = await _controller.Accepted(TestObjectRequest.Valid());

            TestHelper.AssertInstance<AcceptedResult>(result);
        }

        [TestMethod]
        public async Task HandleAcceptedObject_ReturnsAcceptedResult()
        {
            var result = await _controller.AcceptedObject(TestObjectRequest.Valid());

            TestHelper.AssertInstance<AcceptedResult>(result);
        }

        [TestMethod]
        public async Task HandleAccepted_StringUri_ReturnsAcceptedResult()
        {
            var result = await _controller.Accepted(TestObjectRequest.Valid(), UriString);

            TestHelper.AssertUriInstance<AcceptedResult>(UriString, result);
        }

        [TestMethod]
        public async Task HandleAccepted_Uri_ReturnsAcceptedResult()
        {
            var result = await _controller.Accepted(TestObjectRequest.Valid(), _uri);

            TestHelper.AssertUriInstance<AcceptedResult>(_uri, result);
        }

        [TestMethod]
        public async Task HandleAcceptedObject_StringUri_ReturnsAcceptedResult()
        {
            var result = await _controller.AcceptedObject(TestObjectRequest.Valid(), UriString);

            TestHelper.AssertUriInstance<AcceptedResult>(UriString, result);
        }

        [TestMethod]
        public async Task HandleAcceptedObject_Uri_ReturnsAcceptedResult()
        {
            var result = await _controller.AcceptedObject(TestObjectRequest.Valid(), _uri);

            TestHelper.AssertUriInstance<AcceptedResult>(_uri, result);
        }

        // Accepted At Action
        [TestMethod]
        public async Task HandleAcceptedAtAction_String_ReturnsAcceptedAtActionResult()
        {
            var result = await _controller.AcceptedAtAction(TestObjectRequest.Valid(), ActionName);

            TestHelper.AssertActionNameInstance<AcceptedAtActionResult>(ActionName, result);
        }

        [TestMethod]
        public async Task HandleAcceptedAtActionObject_ReturnsAcceptedAtActionResult()
        {
            var result = await _controller.AcceptedAtActionObject(TestObjectRequest.Valid(), ActionName);

            TestHelper.AssertActionNameInstance<AcceptedAtActionResult>(ActionName, result);
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

            var result = await _controller.Ok(TestStringRequest.Valid());

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
    }
}
