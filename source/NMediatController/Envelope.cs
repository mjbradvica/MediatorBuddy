namespace NMediatController
{
    public class Envelope<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope{T}"/> class.
        /// </summary>
        /// <param name="response">The type <typeparamref name="T"/> that is being returned.</param>
        /// <param name="faulted">A type of the fault you are returning.</param>
        private Envelope(T response, Fault faulted)
        {
            Response = response;
            Fault = faulted;
        }

        /// <summary>
        /// Gets the type of <typeparamref name="T"/> that is being returned.
        /// </summary>
        public T Response { get; }

        /// <summary>
        /// Gets the type of fault you are returning.
        /// </summary>
        public Fault Fault { get; }

        /// <summary>
        /// Indicates that eh business process was a success.
        /// </summary>
        /// <param name="response">The response object you wish to return.</param>
        /// <returns>An type of <typeparamref name="T"/>.</returns>
        public static Envelope<T> Success(T response)
        {
            return new Envelope<T>(response, Fault.NoFault);
        }

        /// <summary>
        /// Indicates the the business process has failed.
        /// </summary>
        /// <param name="fault">The type of fault you are returning.</param>
        /// <returns>An type of <typeparamref name="T"/>.</returns>
        public static Envelope<T> Failure(Fault fault = Fault.GeneralFailure)
        {
            return new Envelope<T>(default, fault);
        }
    }
}
