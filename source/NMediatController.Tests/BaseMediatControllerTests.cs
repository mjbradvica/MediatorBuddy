using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace NMediatController.Tests
{
    [TestClass]
    public class BaseControllerTests
    {
        private readonly Mock<IMediator> _mediator;
        private readonly TestMediatController _controller;

        public BaseControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _controller = new TestMediatController(_mediator.Object);
        }

        [TestMethod]
        public async Task ExecuteRequest_OnValidationFailures_ReturnsBadRequest()
        {
            var result = await _controller.Handle(TestObjectRequest.InValid());

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task ExecuteRequest_OnSuccess_ReturnsCorrectResult()
        {
            var response = new TestResponse { Value = "success" };

            _mediator.Setup(x => x.Send(It.IsAny<IRequest<TestResponse>>(), CancellationToken.None))
                .ReturnsAsync(response);

            var result = await _controller.Handle(TestObjectRequest.Valid()) as OkObjectResult;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(response, result.Value);
        }

        [TestMethod]
        public async Task ExecuteRequest_OnException_ReturnsBadRequest()
        {
            _mediator.Setup(x => x.Send(It.IsAny<IRequest<TestResponse>>(), CancellationToken.None))
                .ThrowsAsync(new Exception());

            var result = await _controller.Handle(TestObjectRequest.InValid());

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
    }
}
