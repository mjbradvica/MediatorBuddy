namespace NMediatController.ASPNET
{
    using Microsoft.AspNetCore.Mvc;

    public static class CommonResponseFunctions
    {
        public static IActionResult Ok<TResponse>(TResponse response) => new OkResult();

        public static IActionResult OkObject<TResponse>(TResponse response) => new OkObjectResult(response);
    }
}
