namespace NMediatController.ASPNET
{
    using Microsoft.AspNetCore.Mvc;

    public static class CommonResponseFunctions
    {
        public static IActionResult Ok<TResponse>(TResponse response) => new OkResult();

        public static IActionResult OkEnvelope<TResponse>(Envelope<TResponse> response)
        {
            if (response.Fault != Fault.NoFault)
            {
                return DetermineFault(response);
            }

            return new OkResult();
        }

        public static IActionResult OkObject<TResponse>(TResponse response) => new OkObjectResult(response);

        public static IActionResult OkEnvelopeObject<TResponse>(Envelope<TResponse> response)
        {
            if (response.Fault != Fault.NoFault)
            {
                return DetermineFault(response);
            }

            return new OkObjectResult(response.Response);
        }

        public static IActionResult DetermineFault<TResponse>(Envelope<TResponse> response)
        {
            return response.Fault switch
            {
                Fault.GeneralFailure => new BadRequestResult(),
                _ => new BadRequestResult(),
            };
        }
    }
}
