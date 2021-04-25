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
        private const string UriString = "http://www.test.com/";
        private readonly Mock<IMediator> _mediator;
        private readonly TestMediatController _controller;
        private readonly Uri _uri = new Uri(UriString);

        public BaseControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _controller = new TestMediatController(_mediator.Object);

            _mediator.Setup(mediator => mediator.Send(It.IsAny<IRequest<string>>(), CancellationToken.None))
                .ReturnsAsync(string.Empty);
        }

        [TestMethod]
        public async Task HandleAccepted_Success_ReturnsOkResult()
        {
            await TestHelper.TestControllerMethod<AcceptedResult>(_controller.Accepted, TestStringRequest.Valid());
        }

        [TestMethod]
        public async Task HandleAccepted_StringUri_Success_ReturnsOkResult()
        {
            await TestHelper.TestControllerMethod<AcceptedResult>(_controller.Accepted, UriString, TestStringRequest.Valid());
        }

        [TestMethod]
        public async Task HandleAccepted_Uri_Success_ReturnsOkResult()
        {
            await TestHelper.TestControllerMethod<AcceptedResult>(_controller.Accepted, _uri, TestStringRequest.Valid());
        }

        [TestMethod]
        public async Task HandleAccepted_Success_ReturnsOkObjectResult()
        {
            await TestHelper.TestControllerMethod<ActionResult>(_controller.AcceptedObject, TestObjectRequest.Valid());
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
