using System.IO;

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

        [HttpGet]
        public async Task<IActionResult> HandleEnvelope()
        {
            return await ExecuteOkObject(TestEnvelopeRequest.Valid());
        }

        [HttpGet]
        public async Task<IActionResult> SomeWeirdAction()
        {
            return await ExecuteOkObject(TestEnvelopeRequest.Valid());

            return await ExecuteRequest(TestEnvelopeRequest.Valid(), envelope =>
            {
                return new FileStreamResult(Stream.Null, envelope.Response.Value);
            });
        }
    }
}
