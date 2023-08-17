namespace MediatorBuddy
{
    /// <summary>
    /// Defines that class that contains status codes used to designate the status of the application.
    /// </summary>
    public class ApplicationStatus
    {
        /// <summary>
        /// Indicates an operation was successful.
        /// </summary>
        public const int Success = 0;

        /// <summary>
        /// The User could not be found.
        /// </summary>
        public const int UserDoesNotExist = 10;

        /// <summary>
        /// The User was unable to be created.
        /// </summary>
        public const int UserCouldNotBeCreated = 11;

        /// <summary>
        /// The User name already exists.
        /// </summary>
        public const int UserNameAlreadyExists = 12;

        /// <summary>
        /// The email is already in use.
        /// </summary>
        public const int EmailIsAlreadyUsed = 13;

        /// <summary>
        /// The password given was incorrect.
        /// </summary>
        public const int PasswordIsNotCorrect = 11;

        /// <summary>
        /// The password does not meet all the requirements.
        /// </summary>
        public const int PasswordDoesNotMeetRequirements = 12;

        /// <summary>
        /// The User has attempted too may attempts recently.
        /// </summary>
        public const int TooManyRecentAttempts = 13;

        /// <summary>
        /// The User is currently locked out of their account.
        /// </summary>
        public const int AccountIsLockedOut = 14;

        /// <summary>
        /// The account has yet to be verified.
        /// </summary>
        public const int AccountHasNotBeenVerified = 15;

        /// <summary>
        /// The Email has yet to be verified.
        /// </summary>
        public const int EmailHasNotBeenVerified = 16;

        /// <summary>
        /// The given two-factor code was incorrect.
        /// </summary>
        public const int TwoFactorCodeIncorrect = 17;

        /// <summary>
        /// A validation constraint was not met.
        /// </summary>
        public const int ValidationConstraintNotMet = 30;

        /// <summary>
        /// The Entity in question was not found.
        /// </summary>
        public const int EntityWasNotFound = 31;

        /// <summary>
        /// The operation could not complete at this time.
        /// </summary>
        public const int OperationCouldNotBeCompleted = 32;
    }
}
