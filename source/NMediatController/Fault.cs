namespace NMediatController
{
    public enum Fault
    {
        /// <summary>
        /// A successful request was handled.
        /// </summary>
        NoFault = 0,

        /// <summary>
        /// A failure that can't be logically tied to a specific error.
        /// </summary>
        GeneralFailure = 1,

        /// <summary>
        /// A badly or imperfectly formed request.
        /// </summary>
        MalformedRequest = 2,

        /// <summary>
        /// The request did not satisfy requirements.
        /// </summary>
        InvalidRequest = 3,

        /// <summary>
        /// The request was deemed suspicious.
        /// </summary>
        DeceptiveRequest = 4,

        /// <summary>
        /// Payment is required to continue the process.
        /// </summary>
        PaymentIsRequired = 5,

        /// <summary>
        /// The client does not have the correct content rights.
        /// </summary>
        Unauthorized = 6,

        /// <summary>
        /// The client can not be verified.
        /// </summary>
        Unauthenticated = 7,

        N
    }
}
