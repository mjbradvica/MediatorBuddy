namespace NMediatController.Tests
{
    using System.ComponentModel.DataAnnotations;

    internal class TestEnvelopeRequest : IEnvelopeRequest<TestResponse>
    {
        [Required]
        public string TestField { get; set; }

        public static TestEnvelopeRequest Valid()
        {
            return new TestEnvelopeRequest { TestField = "valid" };
        }

        public static TestEnvelopeRequest InValid()
        {
            return new TestEnvelopeRequest { TestField = null };
        }
    }
}
