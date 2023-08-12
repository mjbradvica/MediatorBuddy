using System.ComponentModel.DataAnnotations;

namespace NMediatController.Tests
{
    /// <summary>
    /// A test request object for unit testing.
    /// </summary>
    public class TestObjectRequest : IEnvelopeRequest<TestResponse>
    {
        /// <summary>
        /// Gets or sets a test field for validation.
        /// </summary>
        [Required]
        public string? TestField { get; set; }

        /// <summary>
        /// Returns a request object with a valid field.
        /// </summary>
        /// <returns>A new instance of a test request object.</returns>
        public static TestObjectRequest Valid()
        {
            return new TestObjectRequest { TestField = "valid" };
        }

        /// <summary>
        /// Returns a request object with an invalid field.
        /// </summary>
        /// <returns>A new instance of a test request object.</returns>
        public static TestObjectRequest InValid()
        {
            return new TestObjectRequest { TestField = null };
        }
    }
}
