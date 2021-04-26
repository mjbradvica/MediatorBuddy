namespace NMediatController.ASPNET
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public static class ObjectVerification
    {
        public static ObjectVerificationResult Validate(object entity)
        {
            var context = new ValidationContext(entity, null, null);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(entity, context, results, true))
            {
                return ObjectVerificationResult.Failure(results.Select(validationResult => validationResult.ErrorMessage));
            }

            return ObjectVerificationResult.Successful();
        }
    }
}
