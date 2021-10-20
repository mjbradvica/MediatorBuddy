namespace NMediatController.Tests
{
    using System.Threading.Tasks;
    using ASPNET;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class TestMediatController : BaseMediatController
    {
        public TestMediatController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Handle(TestObjectRequest request)
        {
            return await ExecuteRequest(request, Ok);
        }
    }
}
