using System.ComponentModel.DataAnnotations;

namespace MediatorBuddy.Tests.ObjectValidation
{
    /// <summary>
    /// Test class for object verification.
    /// </summary>
    public class ObjectVerificationTest
    {
        /// <summary>
        /// Gets or sets value to be verified by the validation methods.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Value { get; set; } = string.Empty;
    }
}
