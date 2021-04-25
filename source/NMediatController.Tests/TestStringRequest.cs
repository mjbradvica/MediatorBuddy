namespace NMediatController.Tests
{
    using System.ComponentModel.DataAnnotations;
    using MediatR;

    internal class TestStringRequest : IRequest<string>
    {
        [Required]
        public string TestField { get; set; }

        public static TestStringRequest Valid()
        {
            return new TestStringRequest { TestField = "valid" };
        }

        public static TestStringRequest Invalid()
        {
            return new TestStringRequest();
        }
    }
}
