// <copyright file="EnvelopeTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// Tests the <see cref="Envelope{T}"/> class capabilities.
    /// </summary>
    [TestClass]
    public class EnvelopeTests
    {
        /// <summary>
        /// Ensures the default constructor has the correct properties.
        /// </summary>
        [TestMethod]
        public void DefaultConstructor_HasCorrectProperties()
        {
            var response = new TestResponse();

            var envelope = Envelope<TestResponse>.Success(response);

            Assert.AreEqual(ApplicationStatus.Success, envelope.Status);
            Assert.AreEqual(string.Empty, envelope.Title);
            Assert.AreEqual(string.Empty, envelope.Detail);
            Assert.AreEqual(response, envelope.Response);
        }

        /// <summary>
        /// Ensures the status code constructor has the correct properties.
        /// </summary>
        [TestMethod]
        public void StatusCodeConstructor_HasCorrectProperties()
        {
            const int statusCode = 1;
            const string title = "error";
            const string detail = "an error occurred";

            var envelope = Envelope<TestResponse>.Failure(statusCode, title, detail);

            Assert.AreEqual(statusCode, envelope.Status);
            Assert.IsNull(envelope.Response);
            Assert.AreEqual(title, envelope.Title);
            Assert.AreEqual(detail, envelope.Detail);
        }

        /// <summary>
        /// Ensures the default failure method has the correct properties.
        /// </summary>
        [TestMethod]
        public void StatusCodeConstructor_HasCorrectDefaultProperties()
        {
            const int statusCode = 1;
            const string title = "A failure occurred.";
            const string detail = "No details are available for the failure.";

            var envelope = Envelope<TestResponse>.Failure(statusCode);

            Assert.AreEqual(statusCode, envelope.Status);
            Assert.IsNull(envelope.Response);
            Assert.AreEqual(title, envelope.Title);
            Assert.AreEqual(detail, envelope.Detail);
        }

        /// <summary>
        /// Ensures a general error has the correct status.
        /// </summary>
        [TestMethod]
        public void GeneralError_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.GeneralError();

            Assert.AreEqual(ApplicationStatus.GeneralError, result.Status);
        }

        /// <summary>
        /// Ensures an operation could not be completed has the correct status.
        /// </summary>
        [TestMethod]
        public void OperationCouldNotBeCompleted_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.OperationCouldNotBeCompleted();

            Assert.AreEqual(ApplicationStatus.OperationCouldNotBeCompleted, result.Status);
        }

        /// <summary>
        /// Ensures an entity was not found has the correct status.
        /// </summary>
        [TestMethod]
        public void EntityWasNotFound_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.EntityWasNotFound();

            Assert.AreEqual(ApplicationStatus.EntityWasNotFound, result.Status);
        }

        /// <summary>
        /// Ensures a conflict with other resource has the correct status.
        /// </summary>
        [TestMethod]
        public void ConflictWithOtherResource_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.ConflictWithOtherResource();

            Assert.AreEqual(ApplicationStatus.ConflictWithOtherResource, result.Status);
        }

        /// <summary>
        /// Ensures a validation constraint not met has the correct status.
        /// </summary>
        [TestMethod]
        public void ValidationConstraintNotMet_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.ValidationConstraintNotMet();

            Assert.AreEqual(ApplicationStatus.ValidationConstraintNotMet, result.Status);
        }

        /// <summary>
        /// Ensures a pre-condition not met has the correct status.
        /// </summary>
        [TestMethod]
        public void PreConditionNotMet_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.PreConditionNotMet();

            Assert.AreEqual(ApplicationStatus.PreConditionNotMet, result.Status);
        }

        /// <summary>
        /// Ensures a post-condition not met has the correct status.
        /// </summary>
        [TestMethod]
        public void PostConditionNotMet_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.PostConditionNotMet();

            Assert.AreEqual(ApplicationStatus.PostConditionNotMet, result.Status);
        }

        /// <summary>
        /// Ensures a could not process request has the correct status.
        /// </summary>
        [TestMethod]
        public void CouldNotProcessRequest_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.CouldNotProcessRequest();

            Assert.AreEqual(ApplicationStatus.CouldNotProcessRequest, result.Status);
        }

        /// <summary>
        /// Ensures a user does not exist has the correct status.
        /// </summary>
        [TestMethod]
        public void UserDoesNotExist_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.UserDoesNotExist();

            Assert.AreEqual(ApplicationStatus.UserDoesNotExist, result.Status);
        }

        /// <summary>
        /// Ensures a user could not be created has the correct status.
        /// </summary>
        [TestMethod]
        public void UserCouldNotBeCreated_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.UserCouldNotBeCreated();

            Assert.AreEqual(ApplicationStatus.UserCouldNotBeCreated, result.Status);
        }

        /// <summary>
        /// Ensures a username already exists has the correct status.
        /// </summary>
        [TestMethod]
        public void UsernameAlreadyExists_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.UsernameAlreadyExists();

            Assert.AreEqual(ApplicationStatus.UsernameAlreadyExists, result.Status);
        }

        /// <summary>
        /// Ensures an email is already used has the correct properties.
        /// </summary>
        [TestMethod]
        public void EmailIsAlreadyUsed_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.EmailIsAlreadyUsed();

            Assert.AreEqual(ApplicationStatus.EmailIsAlreadyUsed, result.Status);
        }

        /// <summary>
        /// Ensures a password is incorrect has the correct properties.
        /// </summary>
        [TestMethod]
        public void PasswordIsIncorrect_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.PasswordIsIncorrect();

            Assert.AreEqual(ApplicationStatus.PasswordIsIncorrect, result.Status);
        }

        /// <summary>
        /// Ensures a password does not meet requirements has the correct properties.
        /// </summary>
        [TestMethod]
        public void PasswordDoesNotMeetRequirements_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.PasswordDoesNotMeetRequirements();

            Assert.AreEqual(ApplicationStatus.PasswordDoesNotMeetRequirements, result.Status);
        }

        /// <summary>
        /// Ensures a too many recent attempts has the correct properties.
        /// </summary>
        [TestMethod]
        public void TooManyRecentAttempts_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.TooManyRecentAttempts();

            Assert.AreEqual(ApplicationStatus.TooManyRecentAttempts, result.Status);
        }

        /// <summary>
        /// Ensures an account is locked out has the correct properties.
        /// </summary>
        [TestMethod]
        public void AccountIsLockedOut_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.AccountIsLockedOut();

            Assert.AreEqual(ApplicationStatus.AccountIsLockedOut, result.Status);
        }

        /// <summary>
        /// Ensures an account has not been verified has the correct properties.
        /// </summary>
        [TestMethod]
        public void AccountHasNotBeenVerified_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.AccountHasNotBeenVerified();

            Assert.AreEqual(ApplicationStatus.AccountHasNotBeenVerified, result.Status);
        }

        /// <summary>
        /// Ensures an email has not been verified has the correct properties.
        /// </summary>
        [TestMethod]
        public void EmailHasNotBeenVerified_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.EmailHasNotBeenVerified();

            Assert.AreEqual(ApplicationStatus.EmailHasNotBeenVerified, result.Status);
        }

        /// <summary>
        /// Ensures a two-factor code is incorrect has the correct properties.
        /// </summary>
        [TestMethod]
        public void TwoFactorCodeIsIncorrect_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.TwoFactorCodeIsIncorrect();

            Assert.AreEqual(ApplicationStatus.TwoFactorCodeIncorrect, result.Status);
        }

        /// <summary>
        /// Ensures an unauthorized user code has the correct properties.
        /// </summary>
        [TestMethod]
        public void UnauthorizedUser_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.UnauthorizedUser();

            Assert.AreEqual(ApplicationStatus.UnauthorizedUser, result.Status);
        }

        /// <summary>
        /// Ensures a content is forbidden code has the correct properties.
        /// </summary>
        [TestMethod]
        public void ContentIsForbidden_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.ContentIsForbidden();

            Assert.AreEqual(ApplicationStatus.ContentIsForbidden, result.Status);
        }

        /// <summary>
        /// Ensures a general auth error code has the correct properties.
        /// </summary>
        [TestMethod]
        public void GeneralAuthError_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.GeneralAuthError();

            Assert.AreEqual(ApplicationStatus.GeneralAuthError, result.Status);
        }

        /// <summary>
        /// Ensures the authentication challenge code has the correct properties.
        /// </summary>
        [TestMethod]
        public void AuthenticationChallenged_HasCorrectProperties()
        {
            var result = Envelope<TestResponse>.AuthenticationChallenged();

            Assert.AreEqual(ApplicationStatus.AuthenticationChallenged, result.Status);
        }
    }
}
