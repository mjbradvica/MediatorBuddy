namespace NMediatController.Tests
{
    using System.ComponentModel.DataAnnotations;
    using MediatR;

    public class TestObjectRequest : IRequest<object>
    {
        [Required]
        public string TestField { get; set; }

        public static TestObjectRequest Valid()
        {
            return new TestObjectRequest { TestField = "valid" };
        }
    }
}
