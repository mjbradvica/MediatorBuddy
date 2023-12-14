// <copyright file="BaseErrorControllerTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// Tests the base error controller.
    /// </summary>
    [TestClass]
    public class BaseErrorControllerTests
    {
        private readonly TestErrorController _errorController;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseErrorControllerTests"/> class.
        /// </summary>
        public BaseErrorControllerTests()
        {
            _errorController = new TestErrorController();
        }

        /// <summary>
        /// Ensures GeneralError is correct.
        /// </summary>
        [TestMethod]
        public void GeneralError_IsCorrectType()
        {
            AssertCorrect(_errorController.GeneralError());
        }

        /// <summary>
        /// Ensures OperationCouldNotBeCompleted is correct.
        /// </summary>
        [TestMethod]
        public void OperationCouldNotBeCompleted_IsCorrectType()
        {
            AssertCorrect(_errorController.OperationCouldNotBeCompleted());
        }

        /// <summary>
        /// Ensures EntityWasNotFound is correct.
        /// </summary>
        [TestMethod]
        public void EntityWasNotFound_IsCorrectType()
        {
            AssertCorrect(_errorController.EntityWasNotFound());
        }

        /// <summary>
        /// Ensures ConflictWithOtherResource is correct.
        /// </summary>
        [TestMethod]
        public void ConflictWithOtherResource_IsCorrectType()
        {
            AssertCorrect(_errorController.ConflictWithOtherResource());
        }

        /// <summary>
        /// Ensures ValidationConstraintNotMet is correct.
        /// </summary>
        [TestMethod]
        public void ValidationConstraintNotMet_IsCorrectType()
        {
            AssertCorrect(_errorController.ValidationConstraintNotMet());
        }

        /// <summary>
        /// Ensures PreConditionNotMet is correct.
        /// </summary>
        [TestMethod]
        public void PreConditionNotMet_IsCorrectType()
        {
            AssertCorrect(_errorController.PreConditionNotMet());
        }

        /// <summary>
        /// Ensures PostConditionNotMet is correct.
        /// </summary>
        [TestMethod]
        public void PostConditionNotMet_IsCorrectType()
        {
            AssertCorrect(_errorController.PostConditionNotMet());
        }

        /// <summary>
        /// Ensures UserDoesNotExist is correct.
        /// </summary>
        [TestMethod]
        public void UserDoesNotExist_IsCorrectType()
        {
            AssertCorrect(_errorController.UserDoesNotExist());
        }

        /// <summary>
        /// Ensures UserCouldNotBeCreated is correct.
        /// </summary>
        [TestMethod]
        public void UserCouldNotBeCreated_IsCorrectType()
        {
            AssertCorrect(_errorController.UserCouldNotBeCreated());
        }

        /// <summary>
        /// Ensures UsernameAlreadyExists is correct.
        /// </summary>
        [TestMethod]
        public void UsernameAlreadyExists_IsCorrectType()
        {
            AssertCorrect(_errorController.UsernameAlreadyExists());
        }

        /// <summary>
        /// Ensures EmailIsAlreadyUsed is correct.
        /// </summary>
        [TestMethod]
        public void EmailIsAlreadyUsed_IsCorrectType()
        {
            AssertCorrect(_errorController.EmailIsAlreadyUsed());
        }

        /// <summary>
        /// Ensures PasswordIsIncorrect is correct.
        /// </summary>
        [TestMethod]
        public void PasswordIsIncorrect_IsCorrectType()
        {
            AssertCorrect(_errorController.PasswordIsIncorrect());
        }

        /// <summary>
        /// Ensures PasswordDoesNotMeetRequirements is correct.
        /// </summary>
        [TestMethod]
        public void PasswordDoesNotMeetRequirements_IsCorrectType()
        {
            AssertCorrect(_errorController.PasswordDoesNotMeetRequirements());
        }

        /// <summary>
        /// Ensures TooManyRecentAttempts is correct.
        /// </summary>
        [TestMethod]
        public void TooManyRecentAttempts_IsCorrectType()
        {
            AssertCorrect(_errorController.TooManyRecentAttempts());
        }

        /// <summary>
        /// Ensures AccountIsLockedOut is correct.
        /// </summary>
        [TestMethod]
        public void AccountIsLockedOut_IsCorrectType()
        {
            AssertCorrect(_errorController.AccountIsLockedOut());
        }

        /// <summary>
        /// Ensures AccountHasNotBeenVerified is correct.
        /// </summary>
        [TestMethod]
        public void AccountHasNotBeenVerified_IsCorrectType()
        {
            AssertCorrect(_errorController.AccountHasNotBeenVerified());
        }

        /// <summary>
        /// Ensures EmailHasNotBeenVerified is correct.
        /// </summary>
        [TestMethod]
        public void EmailHasNotBeenVerified_IsCorrectType()
        {
            AssertCorrect(_errorController.EmailHasNotBeenVerified());
        }

        /// <summary>
        /// Ensures TwoFactoryCodeIncorrect is correct.
        /// </summary>
        [TestMethod]
        public void TwoFactorCodeIncorrect_IsCorrectType()
        {
            AssertCorrect(_errorController.TwoFactorCodeIncorrect());
        }

        /// <summary>
        /// Ensures UnauthorizedUser is correct.
        /// </summary>
        [TestMethod]
        public void UnauthorizedUser_IsCorrectType()
        {
            AssertCorrect(_errorController.UnauthorizedUser());
        }

        /// <summary>
        /// Ensures ContentIsForbidden is correct.
        /// </summary>
        [TestMethod]
        public void ContentIsForbidden_IsCorrectType()
        {
            AssertCorrect(_errorController.ContentIsForbidden());
        }

        /// <summary>
        /// Ensures GeneralAuthError is correct.
        /// </summary>
        [TestMethod]
        public void GeneralAuthError_IsCorrectType()
        {
            AssertCorrect(_errorController.GeneralAuthError());
        }

        private static void AssertCorrect(IActionResult result)
        {
            Assert.IsInstanceOfType<OkObjectResult>(result);
            Assert.IsInstanceOfType<string>((result as OkObjectResult)?.Value);
        }
    }
}
