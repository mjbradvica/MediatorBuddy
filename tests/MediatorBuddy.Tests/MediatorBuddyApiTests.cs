// <copyright file="MediatorBuddyApiTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// Tests the <see cref="MediatorBuddyApi"/> class capabilities.
    /// </summary>
    [TestClass]
    public class MediatorBuddyApiTests
    {
        private readonly Mock<IMediator> _mediator;
        private TestMediatorApiController _apiController;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddyApiTests"/> class.
        /// </summary>
        public MediatorBuddyApiTests()
        {
            _mediator = new Mock<IMediator>();
            _apiController = new TestMediatorApiController(_mediator.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext(),
                },
            };
        }

        /// <summary>
        /// Ensures the correct response when validation fails.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteRequest_OnValidationFailures_ReturnsBadRequest()
        {
            var result = await _apiController.Handle(TestObjectRequest.InValid());

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        /// <summary>
        /// Ensures the correct response when a success occurs.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteRequest_OnSuccess_ReturnsCorrectResult()
        {
            var response = new TestResponse { Value = "success" };
            var envelope = Envelope<TestResponse>.Success(response);

            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ReturnsAsync(envelope);

            var result = await _apiController.Handle(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<OkObjectResult>(result);
            Assert.AreEqual(response, (result as OkObjectResult)?.Value);
        }

        /// <summary>
        /// Ensures the correct response on an exception.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteRequest_OnException_ReturnsBadRequest()
        {
            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ThrowsAsync(new Exception());

            var result = await _apiController.Handle(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<ObjectResult>(result);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, (result as ObjectResult)?.StatusCode);
        }

        /// <summary>
        /// Ensures additional options is called successfully if supplied.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task AdditionalOptions_RunsSuccessfully()
        {
            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ReturnsAsync(Envelope<TestResponse>.Success(new TestResponse()));

            static IActionResult? ExtraOptions(ApiErrorWrapper wrapper) => new StatusCodeResult(999);

            _apiController = new TestMediatorApiController(_mediator.Object, ExtraOptions)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext(),
                },
            };

            var result = await _apiController.Handle(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<StatusCodeResult>(result);
            Assert.AreEqual(999, (result as StatusCodeResult)?.StatusCode);
        }

        /// <summary>
        /// Ensures that general errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GeneralError_IsCorrect()
        {
            await AssertStatusCorrect<ObjectResult>(Envelope<TestResponse>.GeneralError());
        }

        /// <summary>
        /// Ensures that operation could not be completed errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task OperationCouldNotBeCompleted_IsCorrect()
        {
            await AssertStatusCorrect<ObjectResult>(Envelope<TestResponse>.OperationCouldNotBeCompleted());
        }

        /// <summary>
        /// Ensures that conflict with other resource errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ConflictWithOtherResource_IsCorrect()
        {
            await AssertStatusCorrect<ConflictObjectResult>(Envelope<TestResponse>.ConflictWithOtherResource());
        }

        /// <summary>
        /// Ensures that entity was not found errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task EntityWasNotFound_IsCorrect()
        {
            await AssertStatusCorrect<ObjectResult>(Envelope<TestResponse>.EntityWasNotFound());
        }

        /// <summary>
        /// Ensures that validation constraint not met errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ValidationConstraintNotMet_IsCorrect()
        {
            await AssertStatusCorrect<ObjectResult>(Envelope<TestResponse>.ValidationConstraintNotMet());
        }

        /// <summary>
        /// Ensures that pre-condition not met errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task PreConditionNotMet_IsCorrect()
        {
            await AssertStatusCorrect<BadRequestObjectResult>(Envelope<TestResponse>.PreConditionNotMet());
        }

        /// <summary>
        /// Ensures that post condition not met errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task PostConditionNotMet_IsCorrect()
        {
            await AssertStatusCorrect<ObjectResult>(Envelope<TestResponse>.PostConditionNotMet());
        }

        /// <summary>
        /// Ensures that could not process request errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task CouldNotProcessRequest_IsCorrect()
        {
            await AssertStatusCorrect<ObjectResult>(Envelope<TestResponse>.CouldNotProcessRequest());
        }

        /// <summary>
        /// Ensures that user does not exist errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task UserDoesNotExist_IsCorrect()
        {
            await AssertStatusCorrect<NotFoundObjectResult>(Envelope<TestResponse>.UserDoesNotExist());
        }

        /// <summary>
        /// Ensures that user could not be created errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task UserCouldNotBeCreated_IsCorrect()
        {
            await AssertStatusCorrect<ObjectResult>(Envelope<TestResponse>.UserCouldNotBeCreated());
        }

        /// <summary>
        /// Ensures that username already exists errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task UsernameAlreadyExists_IsCorrect()
        {
            await AssertStatusCorrect<ConflictObjectResult>(Envelope<TestResponse>.UsernameAlreadyExists());
        }

        /// <summary>
        /// Ensures that email is already used errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task EmailIsAlreadyUsed_IsCorrect()
        {
            await AssertStatusCorrect<ConflictObjectResult>(Envelope<TestResponse>.EmailIsAlreadyUsed());
        }

        /// <summary>
        /// Ensures that password is incorrect errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task PasswordIsIncorrect_IsCorrect()
        {
            await AssertStatusCorrect<BadRequestObjectResult>(Envelope<TestResponse>.PasswordIsIncorrect());
        }

        /// <summary>
        /// Ensures that password does not meet requirements errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task PasswordDoesNotMeetRequirements_IsCorrect()
        {
            await AssertStatusCorrect<BadRequestObjectResult>(Envelope<TestResponse>.PasswordDoesNotMeetRequirements());
        }

        /// <summary>
        /// Ensures that too many recent attempts errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task TooManyRecentAttempts_IsCorrect()
        {
            await AssertStatusCorrect<ObjectResult>(Envelope<TestResponse>.TooManyRecentAttempts());
        }

        /// <summary>
        /// Ensures that account is locked out errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task AccountIsLockedOut_IsCorrect()
        {
            await AssertStatusCorrect<ObjectResult>(Envelope<TestResponse>.AccountIsLockedOut());
        }

        /// <summary>
        /// Ensures that account has not been verified errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task AccountHasNotBeenVerified_IsCorrect()
        {
            await AssertStatusCorrect<ObjectResult>(Envelope<TestResponse>.AccountHasNotBeenVerified());
        }

        /// <summary>
        /// Ensures that email has not been verified errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task EmailHasNotBeenVerified_IsCorrect()
        {
            await AssertStatusCorrect<ObjectResult>(Envelope<TestResponse>.EmailHasNotBeenVerified());
        }

        /// <summary>
        /// Ensures that two-factor code incorrect errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task TwoFactorCodeIncorrect_IsCorrect()
        {
            await AssertStatusCorrect<BadRequestObjectResult>(Envelope<TestResponse>.TwoFactorCodeIsIncorrect());
        }

        /// <summary>
        /// Ensures that unauthorized user errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task UnauthorizedUser_IsCorrect()
        {
            await AssertStatusCorrect<UnauthorizedObjectResult>(Envelope<TestResponse>.UnauthorizedUser());
        }

        /// <summary>
        /// Ensures that content is forbidden errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ContentIsForbidden_IsCorrect()
        {
            await AssertStatusCorrect<ObjectResult>(Envelope<TestResponse>.ContentIsForbidden());
        }

        /// <summary>
        /// Ensures that general auth errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GeneralAuthError_IsCorrect()
        {
            await AssertStatusCorrect<UnauthorizedObjectResult>(Envelope<TestResponse>.GeneralAuthError());
        }

        /// <summary>
        /// Ensures that authentication challenged errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task AuthenticationChallenged_IsCorrect()
        {
            await AssertStatusCorrect<UnauthorizedObjectResult>(Envelope<TestResponse>.AuthenticationChallenged());
        }

        /// <summary>
        /// Ensures that anonymous errors are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task AnonymousErrors_IsCorrect()
        {
            await AssertStatusCorrect<ObjectResult>(new Envelope<TestResponse>(999, string.Empty, string.Empty));
        }

        /// <summary>
        /// Ensures the request path is in the error response.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task RequestPath_IsPresent()
        {
            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ThrowsAsync(new Exception());

            const string requestPath = "/TestPath";

            _apiController.HttpContext.Request.Path = requestPath;

            var result = await _apiController.Handle(TestObjectRequest.Valid());

            var responseObject = (result as ObjectResult)?.Value as ErrorResponse;

            Assert.AreEqual(new Uri(requestPath, UriKind.Relative), responseObject?.Instance);
        }

        private async Task AssertStatusCorrect<TResponseType>(IEnvelope<TestResponse> response)
            where TResponseType : ObjectResult
        {
            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ReturnsAsync(response);

            var result = await _apiController.Handle(TestObjectRequest.Valid());

            var errorResponse = result as ObjectResult;

            Assert.IsInstanceOfType<TResponseType>(result);
            Assert.IsInstanceOfType<ErrorResponse>(errorResponse?.Value);
            Assert.AreEqual(errorResponse.StatusCode, (errorResponse.Value as ErrorResponse)?.Status);
        }
    }
}
