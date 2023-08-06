using System.ComponentModel.DataAnnotations;

namespace NMediatController.Tests.ObjectValidation
{
    public class ObjectVerificationTest
    {
        [Required]
        public string Value { get; set; }
    }
}
