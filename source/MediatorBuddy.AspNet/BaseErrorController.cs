// <copyright file="BaseErrorController.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet
{
    /// <summary>
    /// Standard error controller.
    /// </summary>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public abstract class BaseErrorController : ControllerBase
    {
        /// <summary>
        /// An explanation for the general error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("GeneralError")]
        public virtual IActionResult GeneralError()
        {
            return Ok("A general error is most likely an un-classified error. The system was unable to determine what error to choose from. This is different than a 500 where the server experienced a fault and needs to physically recover.");
        }

        /// <summary>
        /// An explanation for the operation could not be completed error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("OperationCouldNotBeCompleted")]
        public virtual IActionResult OperationCouldNotBeCompleted()
        {
            return Ok("The operation could not be completed at this time. The operation may have on partially completed and faulted part way through. You may experience inconsistent results until the system is able to recover.");
        }

        /// <summary>
        /// An explanation for the entity was not found error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("EntityWasNotFound")]
        public virtual IActionResult EntityWasNotFound()
        {
            return Ok("The entity was not found. This could mean it was deleted or moved since the last time it was accessed. You may have also provided an invalid identifier to find an entity.");
        }

        /// <summary>
        /// An explanation for the conflict with other resource error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("ConflictWithOtherResource")]
        public virtual IActionResult ConflictWithOtherResource()
        {
            return Ok("A conflict occurred with an already existing resource in the system. This may be that both resource were attempting to access a different entity at the same time. A retry may be necessary.");
        }

        /// <summary>
        /// An explanation for the validation constraint not met error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("ValidationConstraintNotMet")]
        public virtual IActionResult ValidationConstraintNotMet()
        {
            return Ok("A validation constraint was not satisfied. This could have happened at the onset of the operation, or during the process. Please check the values you are sending the server.");
        }

        /// <summary>
        /// An explanation for the pre-condition not met error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("PreConditionNotMet")]
        public virtual IActionResult PreConditionNotMet()
        {
            return Ok("A pre-condition could not be satisfied and therefor the operation could not be completed at this time. Your request probably passed validation but another condition was not correct.");
        }

        /// <summary>
        /// An explanation for the post-condition not met error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("PostConditionNotMet")]
        public virtual IActionResult PostConditionNotMet()
        {
            return Ok("A post-condition could not be satisfied and therefor the operation could not be completed at this time. Your request probably passed validation but another condition was not correct.");
        }

        /// <summary>
        /// An explanation for the user does not exist error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("UserDoesNotExist")]
        public virtual IActionResult UserDoesNotExist()
        {
            return Ok("A user does not exist in the system. They may have been deleted, modified, or moved. It is also possible the wrong identifier for them was supplied.");
        }

        /// <summary>
        /// An explanation for the user could not be created.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("UserCouldNotBeCreated")]
        public virtual IActionResult UserCouldNotBeCreated()
        {
            return Ok("The user could not be created given the information supplied. This may be either a client or server error. If you feel this was server related, please try again or the check the information you are sending.");
        }

        /// <summary>
        /// An explanation for the username already exists error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("UsernameAlreadyExists")]
        public virtual IActionResult UsernameAlreadyExists()
        {
            return Ok("The username supplied already exists in the system. Please provide a different username and attempt the operation again. A previous user account with that name may have been deleted, but could take a while for the system to recognize it.");
        }

        /// <summary>
        /// An explanation for the email is already used error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("EmailIsAlreadyUsed")]
        public virtual IActionResult EmailIsAlreadyUsed()
        {
            return Ok("The email supplied already exists in the system. Provide a different email and attempt the operation again. A previous user account that that email may have been deleted, but could take a while for the system to recognize it.");
        }

        /// <summary>
        /// An explanation for the password is incorrect error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("PasswordIsIncorrect")]
        public virtual IActionResult PasswordIsIncorrect()
        {
            return Ok("The password supplied does not match what was originally supplied. You may need to reset your password.");
        }

        /// <summary>
        /// An explanation for the password does not meet requirements error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("PasswordDoesNotMeetRequirements")]
        public virtual IActionResult PasswordDoesNotMeetRequirements()
        {
            return Ok("The password supplied does not meet the minimum strength requirements. A strong password typically has at least one capital letter, number, and special character.");
        }

        /// <summary>
        /// An explanation for the too many recent attempts error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("TooManyRecentAttempts")]
        public virtual IActionResult TooManyRecentAttempts()
        {
            return Ok("You have attempted to access the server too many times in a small time window. Please pause your requests or wait until the server is ready.");
        }

        /// <summary>
        /// An explanation for the account is locked out error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("AccountIsLockedOut")]
        public virtual IActionResult AccountIsLockedOut()
        {
            return Ok("Your attempt is currently locked out. This could be due to too many recent attempts or suspicious activity was detected. You may have to wait a while until your account is freed up.");
        }

        /// <summary>
        /// An explanation for the account has not been verified error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("AccountHasNotBeenVerified")]
        public virtual IActionResult AccountHasNotBeenVerified()
        {
            return Ok("Your account has not been completely verified. You may need to validate your account, email, or phone number. Until you do this your account access or features may be limited.");
        }

        /// <summary>
        /// An explanation for the email has not been verified error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("EmailHasNotBeenVerified")]
        public virtual IActionResult EmailHasNotBeenVerified()
        {
            return Ok("Your email has not been verified. Until you do this your account access or features may be limited.");
        }

        /// <summary>
        /// An explanation for the two-factor code incorrect error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("TwoFactorCodeIncorrect")]
        public virtual IActionResult TwoFactorCodeIncorrect()
        {
            return Ok("The two-factor code supplied was incorrect. Your code may have timed out.");
        }

        /// <summary>
        /// An explanation for an unauthorized user error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("UnauthorizedUser")]
        public virtual IActionResult UnauthorizedUser()
        {
            return Ok("The user is unauthorized and therefor the request could not be honored. Please log in to the server or checked that your have not been automatically logged out.");
        }

        /// <summary>
        /// An explanation for the content is forbidden error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("ContentIsForbidden")]
        public virtual IActionResult ContentIsForbidden()
        {
            return Ok("The content in question is forbidden and the user does not have access. You may need an administrator to give you permissions.");
        }

        /// <summary>
        /// An explanation of the general auth error.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("GeneralAuthError")]
        public virtual IActionResult GeneralAuthError()
        {
            return Ok("A non-descriptive error related to auth occurred. This error does not have a detailed explanation or may be returned when no other response appears appropriate.");
        }
    }
}
