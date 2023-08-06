using System.Collections.Generic;
using System.Linq;

namespace NMediatController.ASPNET
{
    /// <summary>
    /// A object that contains the status of a requests' validation and any errors present.
    /// </summary>
    public class ObjectVerificationResult
    {
        private ObjectVerificationResult(bool failed, IEnumerable<string> errors)
        {
            Failed = failed;
            Errors = errors;
        }

        /// <summary>
        /// Gets a value indicating whether the request object failed its validation.
        /// </summary>
        public bool Failed { get; }

        /// <summary>
        /// Gets a list of errors if the object failed validation.
        /// </summary>
        public IEnumerable<string> Errors { get; }

        /// <summary>
        /// Function that indicates an object pass validation.
        /// </summary>
        /// <returns>A validation result with success properties.</returns>
        public static ObjectVerificationResult Successful()
        {
            return new ObjectVerificationResult(false, Enumerable.Empty<string>());
        }

        /// <summary>
        /// Function that indicates an object failed validation.
        /// </summary>
        /// <param name="errors">A list of validation errors.</param>
        /// <returns>A validation result with failed properties.</returns>
        public static ObjectVerificationResult Failure(IEnumerable<string> errors)
        {
            return new ObjectVerificationResult(true, errors);
        }
    }
}
