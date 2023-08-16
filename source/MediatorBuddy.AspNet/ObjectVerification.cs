using System.ComponentModel.DataAnnotations;

namespace MediatorBuddy.AspNet
{
    /// <summary>
    /// A class used to validate a request or query object before it is executed.
    /// </summary>
    public static class ObjectVerification
    {
        /// <summary>
        /// Validates an object against its attributes.
        /// </summary>
        /// <param name="entity">The object to be validated.</param>
        /// <returns>A result object indicating if the request object pass validation.</returns>
        public static ObjectVerificationResult Validate(object entity)
        {
            var context = new ValidationContext(entity, null, null);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(entity, context, results, true))
            {
                return ObjectVerificationResult.Failure(results.Select(validationResult => validationResult.ErrorMessage ?? string.Empty));
            }

            return ObjectVerificationResult.Successful();
        }
    }
}
