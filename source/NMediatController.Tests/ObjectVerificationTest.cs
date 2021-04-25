namespace NMediatController.Tests
{
    using System.ComponentModel.DataAnnotations;

    public class ObjectVerificationTest
    {
        [Required]
        public string Value { get; set; }
    }
}
