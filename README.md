# MediatorBuddy

An opinionated implementation for the [MediatR](https://github.com/jbogard/MediatR) library.

![TempBuddy](https://i.imgur.com/Un435IL.png)

![build-status](https://github.com/mjbradvica/MediatorBuddy/workflows/main/badge.svg) ![downloads](https://img.shields.io/nuget/dt/MediatorBuddy) ![downloads](https://img.shields.io/nuget/v/MediatorBuddy) ![activity](https://img.shields.io/github/last-commit/mjbradvica/MediatorBuddy/master)

## Overview

What does MediatorBuddy give you?

- :telephone: A consistent interface for communication between your presentation and application layer.
- :clipboard: An implementation of the [RFC 9457](https://www.rfc-editor.org/rfc/rfc9457.txt) spec for user-friendly API error responses.
- :construction_worker: A base controller that handles generic boilerplate for you. Far fewer unit tests.
- :hammer: Extendable: You can define custom application status states and return a specific status code.
- :currency_exchange: Modifiable: Override a status return code, title, or detail message.

## Table of Contents

- [MediatorBuddy](#mediatorbuddy)
  - [Overview](#overview)
  - [Table of Contents](#table-of-contents)
  - [Samples](#samples)
  - [Framework Support](#framework-support)
    - [Built-In Http Status Code Support](#built-in-http-status-code-support)
  - [Dependencies](#dependencies)
  - [Installation](#installation)
  - [What is implied by an "opinionated" library?](#what-is-implied-by-an-opinionated-library)
  - [Background Story](#background-story)
  - [Setup](#setup)
  - [Handlers and Requests](#handlers-and-requests)
    - [Quick Start for Handlers and Requests](#quick-start-for-handlers-and-requests)
    - [Detailed Usage for Handlers and Requests](#detailed-usage-for-handlers-and-requests)
      - [Custom Envelopes](#custom-envelopes)
      - [Custom Fault Messages](#custom-fault-messages)
      - [Custom Faults](#custom-faults)
      - [Third-Party Validation](#third-party-validation)
  - [API Controllers](#api-controllers)
    - [Quick Start for API Controllers](#quick-start-for-api-controllers)
    - [Detailed Usage for API Controllers](#detailed-usage-for-api-controllers)
      - [Detailed Response](#detailed-response)
      - [Custom Callbacks](#custom-callbacks)
      - [Handling Exceptions](#handling-exceptions)
      - [Default Response Codes Reference](#default-response-codes-reference)
      - [Overriding Existing Status Codes](#overriding-existing-status-codes)
      - [Changing the Error Controller](#changing-the-error-controller)
      - [Adding Support for Custom Errors](#adding-support-for-custom-errors)
  - [Razor Pages](#razor-pages)
    - [Quick Start for Razor Pages](#quick-start-for-razor-pages)
    - [Detailed Usage For Razor Pages](#detailed-usage-for-razor-pages)
      - [Using the Base Page](#using-the-base-page)
      - [Integration With AutoMapper](#integration-with-automapper)
      - [Using A Different Error Page](#using-a-different-error-page)
  - [MVC Controllers](#mvc-controllers)
    - [Quick Start for MVC Controller](#quick-start-for-mvc-controller)
    - [Detailed Usage for MVC Controllers](#detailed-usage-for-mvc-controllers)
      - [Using the Controller TempData or ViewData](#using-the-controller-tempdata-or-viewdata)
      - [Integration For AutoMapper](#integration-for-automapper)
      - [Using A Different Error Route](#using-a-different-error-route)
  - [FAQ](#faq)
    - [What is MediatorBuddy?](#what-is-mediatorbuddy)
    - [What is implied by an 80/20 library?](#what-is-implied-by-an-8020-library)
    - [How does MediatorBuddy handle errors?](#how-does-mediatorbuddy-handle-errors)
    - [What if I need to throw an exception?](#what-if-i-need-to-throw-an-exception)
    - [Do I need to use the existing Envelope implementation?](#do-i-need-to-use-the-existing-envelope-implementation)
    - [What is the difference between the ApplicationStatus and an HTTP status?](#what-is-the-difference-between-the-applicationstatus-and-an-http-status)
    - [Can I only use MediatorBuddy for an API?](#can-i-only-use-mediatorbuddy-for-an-api)

## Samples

If you prefer code samples in addition to documentation, there are full samples available for each framework type that can be [viewed here](https://github.com/mjbradvica/MediatorBuddy/tree/master/samples).

## Framework Support

| Framework   | Supported |
| ----------- | --------- |
| .NET API    | Yes       |
| .NET MVC    | Yes       |
| Razor Pages | Yes       |
| gRPC        | Planned   |
| graphQL     | Planned   |
| Blazor      | Planned   |

### Built-In Http Status Code Support

This is the current list of HTTP non-error status codes supported by the library. These are based on this [method list](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase?view=aspnetcore-8.0#methods).

| Codes | Supported          |
| ----- | ------------------ |
| 100s  | 100 - 102          |
| 200s  | 200 - 226          |
| 300s  | 301, 302, 307, 308 |

## Dependencies

- MediatorBuddy has a dependency on [MediatR](https://www.nuget.org/packages/MediatR) in the base package.
- MediatorBuddy.AspNet uses the [Microsoft.AspNetCore.App](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/metapackage-app?view=aspnetcore-7.0) meta-package.

## Installation

The easiest way to get started is to: [Install with NuGet](https://www.nuget.org/).

In your application layer:

```bash
Install-Package MediatorBuddy
```

In your presentation layer:

```bash
Install-Package MediatorBuddy.AspNet
```

## What is implied by an "opinionated" library?

If you are familiar with the [Prettier](https://prettier.io/docs/en/option-philosophy) format library for front-end frameworks-then the idea of an "opinionated" library should be familiar.

MediatorBuddy has a very specific way of handling requests and responses. The advantage you gain is up to 100% less unit testing in your presentation layer alongside a consistent way of handling failures.

MediatorBuddy assumes that you prefer to use the built-in [validation attributes](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-7.0#validation-attributes) that Microsoft provides out of the box.

> Attribute validators are highly recommended, especially if you are utilizing Swagger.

You may use a separate library such as [FluentValidation](https://www.nuget.org/packages/FluentValidation)-however you will need to validate request objects in your handlers.

A quick sample using FluentValidation is available [here.](https://github.com/mjbradvica/MediatorBuddy/tree/master/samples/MediatorBuddy.Samples.Api/FluentValidationExample)

## Background Story

MediatorBuddy is the third version of a small pattern, which I found myself implementing on multiple projects. It started with not wanting to write the same unit test for API endpoints repeatedly. It has since morphed into the formal version you see in this library.

MediatorBuddy's greatest strength is that it puts guardrails on your developers. It forces them to code to a specific implementation. This will lead to a more consistent API for both your developers and customers.

## Setup

> This documentation assumes you are already familiar with how [MediatR](https://github.com/jbogard/MediatR) works.

While MediatorBuddy has nothing it needs to register with the dependency injection framework, it does need to turn off the default model state filter.

For convenience, pass your MediatR configuration setup, and MediatorBuddy will set up MediatR in the same call.

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddMediatorBuddy(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // Continue setup below
    }
}
```

## Handlers and Requests

### Quick Start for Handlers and Requests

All requests will now inherit from the [IEnvelopeRequest](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy/IEnvelopeRequest.cs) interface.

```csharp
public class MyRequest : IEnvelopeRequest<MyResponse>
{
}
```

Any request that does not return a response object will now inherit from the non-generic interface.

```csharp
public class MyRequest : IEnvelopeRequest
{
}
```

> IEnvelopeRequest is the short hand version for returning a IEnvelope for each request.

All handlers will now inherit from the [IEnvelopeHandler](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy/IEnvelopeHandler.cs) interface.

```csharp
public class MyHandler : IEnvelopeHandler<MyRequest, MyResponse>
{
    public async Task<IEnvelope<MyResponse>> Handle(MyRequest handler, CancellationToken cancellationToken)
    {
    }
}
```

A handler that does not return an object will look like so:

```csharp
public class MyHandler : IEnvelopeHandler<MyRequest>
{
    public async Task<IEnvelope<Unit>> Handle(MyRequest handler, CancellationToken cancellationToken)
    {
    }
}
```

> Notice that even though your request does not return anything, the handler still MUST return an envelope.

Use the built-in [Envelope](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy/Envelope.cs) class to return either a success or failure.

> Envelopes must have a generic argument of your response type due to their static nature.

```csharp
public class MyHandler : IEnvelopeHandler<MyRequest, MyResponse>
{
    private readonly IRepository _repository;

    public MyHandler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnvelope<MyResponse>> Handle(MyRequest handler, CancellationToken cancellationToken)
    {
        var data = await _repository.GetData();

        if (data == null)
        {
            return Envelope<MyResponse>.EntityNotFound();
        }

        return Envelope<MyResponse>.Success(new MyResponse(data));
    }
}
```

The envelope class has dozens of methods available that should cover most-if not all-possible error situations in your application.

### Detailed Usage for Handlers and Requests

#### Custom Envelopes

If you wish to create your implementation of the [IEnvelope](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy/IEnvelope.cs) interface, these are the properties you would implement:

```csharp
public interface IEnvelope<out TResponse>
{
    public int Status { get; }

    public string Title { get; }

    public string Detail { get; }

    public TResponse Response { get; }
}
```

> An alternative for a custom implementation may be to create static methods for the Envelope class in the same way the library does it.

#### Custom Fault Messages

The title and description for failures are generic on purpose. You can enrich a fault by adding a custom title and description.

```csharp
public class GetWeatherHandler : IEnvelopeHandler<GetWeatherRequest, GetWeatherResponse>
{
    private readonly IDataSource _data;

    public GetWeatherHandler(IDataSource data)
    {
        _data = data;
    }

    public async Task<IEnvelope<GetWeatherResponse>> Handle(GetWeatherRequest request, CancellationToken cancellationToken)
    {
        var data = await _data.GetData();

        if (data == null)
        {
            return Envelope<GetWeatherResponse>.EntityNotFound("Weather report not found". "No report found for that airport. Do you have the correct code?");
        }

        return Envelope<GetWeatherResponse>.Success(new GetWeatherResponse(data));
    }
}
```

#### Custom Faults

For custom faults, it is recommended to create a class that contains your error codes. These are not HTTP status codes. Make sure they don't overlap with any existing codes in the [ApplicationStatus class.](https://github.com/mjbradvica/MediatorBuddy/blob/development/source/MediatorBuddy/ApplicationStatus.cs)

```csharp
public class CustomApplicationStatus
{
    public const int NotEnoughSteam = 999;
}
```

Create a class that can return an "IEnvelope" of type T responses for each fault code.

```csharp
public class CustomEnvelope<TResponse>
{
    public static IEnvelope<TResponse> NotEnoughSteam()
    {
        return new Envelope<TResponse>(
            CustomApplicationStatus.NotEnoughSteam,
            "Not enough steam.",
            "You don't have enough steam to run that command.");
    }
}
```

Use in your code where needed:

```csharp
public class MyHandler : IEnvelopeHandler<MyRequest, MyResponse>
{
    public async Task<IEnvelope<MyResponse>> Handle(MyRequest request, CancellationToken cancellationToken)
    {
        var data = await _data.GetData();

        if(!data.HasSteam())
        {
            return CustomEnvelope<MyResponse>.NotEnoughSteam();
        }

        return Envelope<MyResponse>.Success(new MyResponse());
    }
}
```

You will need to modify your controller to account for the error message.

See each controller [section in-depth](#adding-support-for-custom-errors) for custom error handling in controllers.

#### Third-Party Validation

I **highly** recommend the [standard suite](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-8.0#built-in-attributes) of validators built into the dotnet framework.

> Swagger uses the standard validators to annotate your API for more details and metadata.

If you desire to use a third-party validation framework such as [FluentValidator](https://docs.fluentvalidation.net/en/latest/), you will need to validate your requests in each handler.

Assuming a validator that has the following...

```csharp
public class GetByIdValidator : AbstractValidator<FluentGetByIdRequest>
{
    public GetByIdValidator()
    {
        RuleFor(request => request.Id).NotEqual(Guid.Empty);
    }

    public static ValidationResult ValidateRequest(FluentGetByIdRequest request)
    {
        return new GetByIdValidator().Validate(request);
    }
}
```

Your handler would resemble:

```csharp
public async Task<IEnvelope<FluentGetByIdResponse>> Handle(FluentGetByIdRequest request, CancellationToken cancellationToken)
{
    var validationResult = GetByIdValidator.ValidateRequest(request);

    if (!validationResult.IsValid)
    {
        return Envelope<FluentGetByIdResponse>.ValidationConstraintNotMet();
    }

    var widget = await _widgetRepository.GetById(request.Id);

    if (widget == null)
    {
        return Envelope<FluentGetByIdResponse>.EntityWasNotFound();
    }

    var response = WidgetFactory.FluentResponse(widget);

    return Envelope<FluentGetByIdResponse>.Success(response);
}
```

> This method requires extra unit testing for the invalid logical branch.

## API Controllers

### Quick Start for API Controllers

1) Have your controller inherit from the [MediatorBuddyApi](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy.AspNet/MediatorBuddyApi.cs) base class.

2) Create an action method that will return a Task of type IActionResult.

3) Pass your requests to the "ExecuteRequest" method, and use one of the built-in success callbacks from the [ResponseOptions](https://github.com/mjbradvica/MediatorBuddy/tree/master/source/MediatorBuddy.AspNet/Responses) class.

4) Annotate your method with the built-in error response attributes for each specific error type you return.

> The base controller already annotates for a 400-Bad Request and 500-Internal Server Error codes.

```csharp
[ApiController]
[Route("[controller]")]
public class MyController : MediatorBuddyApi
{
    public MyController(IMediator mediator)
        : base(mediator)
    {
        [HttpGet]
        [MediatorBuddy404ErrorResponse]
        public async Task<IActionResult> GetMyData()
        {
            return await ExecuteRequest(new MyRequest(), ResponseOptions.OkResponse<MyResponse>());
        }
    }
}
```

> The ErrorResponse attributes are a short-hand approach for specifying a [ProducesResponseType](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.producesresponsetypeattribute?view=aspnetcore-8.0) attribute without having to pass the same arguments every time.

Implement a handler to account for global exceptions.

```csharp
 public class GlobalExceptionOccurredHandler : INotificationHandler<GlobalExceptionOccurred>
 {
     public Task Handle(GlobalExceptionOccurred notification, CancellationToken cancellationToken)
     {
         // log exception or handle gracefully.

         return Task.CompletedTask;
     }
 }
```

Create a concrete class for error endpoints. I suggest using the default base error controller class, then gradually overriding what you need.

```csharp
[ApiController]
[Route("[controller]")]
public class ErrorController : BaseErrorController
{
}
```

### Detailed Usage for API Controllers

#### Detailed Response

Some ResponseOptions allow you to pass another callback. Such is the case of a 201 Created response.

```csharp
[HttpPost(Name = "AddWeatherForecast")]
public async Task<IActionResult> Add(AddWeatherRequest request)
{
    return await ExecuteRequest(
        request,
        ResponseOptions.CreatedObjectResponse<AddWeatherResponse>(response => new Uri($"WeatherForecast/{response.Id}", UriKind.Relative)));
}
```

> MediatorBuddy uses the [Paredo Principle](https://en.wikipedia.org/wiki/Pareto_principle) a.k.a. 80/20 rule for responses. You may have a specific use case or two that requires a custom callback.

Some detailed responses ask that you return a Tuple of values, such as the case if you return a file result.

```csharp
[HttpGet(Name = "GetWeatherFile")]
public async Task<IActionResult> WeatherFile(WeatherFileRequest request)
{
    return await ExecuteRequest(
        request,
        ResponseOptions.FileResponse<WeatherFileResponse>(response => (response.File, "application/pdf", null, null, false)));
}
```

Hovering over the function name should give you ample documentation of what the response requires.

Any response option that contains the word "Empty" means that no object is returned in the result.

```csharp
[HttpPost(Name = "UpdateWeatherForecast")]
public async Task<IActionResult> Add(UpdatedWeatherRequest request)
{
    return await ExecuteRequest(request, ResponseOptions<Unit>.AcceptedEmpty());
}
```

> ResponseOptions needs to have the type of the response regardless of the result.

#### Custom Callbacks

In the case that you need a response type that doesn't exist already. You only need to pass a callback that accepts your response type and returns an IActionResult.

```csharp
[HttpPost(Name = "NeedCustomResponse")]
[ProducesResponseType(StatusCodes.Status418ImATeapot)]
public async Task<IActionResult> HasCustomResponse(MyRequest request)
{
    return await ExecuteRequest(request, _ => new StatusCodeResult(StatusCodes.Status418ImATeapot));
}
```

#### Handling Exceptions

MediatorBuddy uses the publishing of MediatR to allow you to handle exceptions. This is done because:

- We do not assume you are using logging
- We do not assume what kind of logging implementation you are using
- One less dependency to inject into every controller

Handling exceptions is a matter of defining a notification handler for the [GlobalExceptionOccurred](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy/GlobalExceptionOccurred.cs) class.

```csharp
public class GlobalExceptionOccurredHandler : INotificationHandler<GlobalExceptionOccurred>
{
    private readonly ILogger _logger;

    public GlobalExceptionOccurredHandler(ILogger logger)
    {
        _logger = logger;
    }

    public Task Handle(GlobalExceptionOccurred notification, CancellationToken cancellationToken)
    {
        _logger.LogError(notification.Exception, message: "Global exception at {dateTime}", notification.DateTime);

        return Task.CompletedTask;
    }
}
```

> Even if you choose to ignore exceptions, you must define a handler, or else MediatR will throw an exception.

#### Default Response Codes Reference

When using MediatorBuddy for an API project, here are the default responses for each application status.

| Status                              | HTTP Code   | Default Type Uri (Relative)           |
| ----------------------------------- | ----------- | ------------------------------------- |
| Success                             | User Chosen | None                                  |
| General Failure                     | 500         | Error/General                         |
| Operation Could Not Be Completed    | 500         | Error/OperationCouldNotBeCompleted    |
| Entity Was Not Found                | 404         | Error/EntityWasNotFound               |
| Conflict With Other Resource        | 409         | Error/ConflictWithOtherResource       |
| Validation Constraint Not Met       | 400         | Error/ValidationConstraintNotMet      |
| Pre-Condition Not Met               | 400         | Error/PreConditionNotMet              |
| Post-Condition Not Met              | 400         | Error/PostConditionNotMet             |
| Could Not Process Request           | 422         | Error/CouldNotProcessRequest          |
| User Does Not Exist                 | 404         | Error/UserDoesNotExist                |
| User Could Not Be Created           | 500         | Error/UserCouldNotBeCreated           |
| User Name Already Exists            | 409         | Error/UsernameAlreadyExists           |
| Email Is Already Used               | 409         | Error/EmailIsAlreadyUsed              |
| Password Is Incorrect               | 400         | Error/PasswordIsIncorrect             |
| Password Does Not Meet Requirements | 400         | Error/PasswordDoesNotMeetRequirements |
| Too Many Recent Attempts            | 429         | Error/TooManyRecentAttempts           |
| Account Is Locked Out               | 423         | Error/AccountIsLockedOut              |
| Account Has Not Been Verified       | 403         | Error/AccountHasNotBeenVerified       |
| Email Has Not Been Verified         | 403         | Error/EmailHasNotBeenVerified         |
| Two-Factor Code Incorrect           | 400         | Error/TwoFactorCodeIncorrect          |
| Unauthorized User                   | 401         | Error/UnauthorizedUser                |
| Content Is Forbidden                | 403         | Error/ContentIsForbidden              |
| General Auth                        | 401         | Error/GeneralAuthError                |
| Auth Challenged                     | 401         | Error/AuthenticationChallenged        |
| Global Exception                    | 500         | Error/General                         |

#### Overriding Existing Status Codes

If you would like to return a different status code from the chart above, you can pass a function to the constructor that will execute before the standard response.

```csharp
[ApiController]
[Route("[controller]")]
public class MyController : MediatorBuddyApi
{
    private static readonly Func<ApiErrorWrapper, IActionResult?>? ExtraOptions = wrapper =>
    {
        switch (wrapper.Status)
        {
            case ApplicationStatus.AccountHasNotBeenVerified:
                return new ObjectResult(new ErrorResponse(
                                        wrapper.ErrorTypes.AccountHasNotBeenVerified,
                                        wrapper.Title,
                                        wrapper.Status,
                                        wrapper.Detail,
                                        wrapper.Instance));
        }

        return null;
    };

    public MyController(IMediator mediator)
        : base(mediator, null, ExtraOptions)
    {
    }
}
```

If any request returns an "AccountHasNotBeenVerified" error, your custom response will now be returned instead.

> In keeping with the ethos of the library, please ensure you are returning an [ErrorResponse](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy.AspNet/ErrorResponse.cs) for each custom error. This will ensure consistency for errors between you and your client.

Examples of overridden errors can be found [here](https://github.com/mjbradvica/MediatorBuddy/tree/master/samples/MediatorBuddy.Samples.Api/CustomFaults).

#### Changing the Error Controller

MediatorBuddy uses an implementation of the [RFC 9457](https://www.rfc-editor.org/rfc/rfc9457.txt) spec, which states that your end user should have some kind of documentation on errors that may be returned.

There is a standard one by default that you may inherit from:

```csharp
[ApiController]
[Route("[controller]")]
public class ErrorController : BaseErrorController
{
}
```

You may override any response to enrich an error or update the text to your liking.

```csharp
[ApiController]
[Route("[controller]")]
public class ErrorController : BaseErrorController
{
    public override IActionResult UserCouldNotBeCreated()
    {
        return Ok("A user could not be created possibly due to the following errors...");
    }
}
```

#### Adding Support for Custom Errors

With custom errors, you will need to provide the controller with a few parameters, so it knows how to format your response.

Update the error controller with a new method.

```csharp
[ApiController]
[Route("[controller]")]
public class ErrorController : BaseErrorController
{
    [HttpGet("NotEnoughSteam")]
    public IActionResult NotEnoughSteam()
    {
        return Ok("The Not Enough Steam error occurs when the following happens...");
    }
}
```

Create a custom error types class that inherits from [ErrorTypes](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy.AspNet/ErrorTypes.cs) with the custom error URI.

```csharp
public class CustomErrorTypes : ErrorTypes
{
    public Uri NotEnoughSteam { get; set; } = new Uri("Error/NotEnoughSteam", UriKind.Relative);
}
```

Finally, pass a resolution Func and your new error types object to the constructor with the API endpoint.

```csharp
[ApiController]
[Route("[controller]")]
public class MyController : MediatorBuddyApi
{
    private static readonly Func<ApiErrorWrapper, IActionResult?>? ExtraOptions = wrapper =>
    {
        return wrapper.Status switch =>
        {
            CustomApplicationStatus.NotEnoughSteam => new ObjectResult(
                            new ErrorResponse(
                                (wrapper.ErrorTypes as CustomErrorTypes)?.NotEnoughSteam ?? wrapper.ErrorTypes.General,
                                wrapper.Title,
                                wrapper.Status,
                                wrapper.Detail,
                                wrapper.Instance)),
            _ => null,
        };
    };

    public MyController(IMediator mediator)
        : base(mediator, new CustomErrorTypes(), ExtraOptions)
    {
    }
}
```

## Razor Pages

### Quick Start for Razor Pages

The easiest way to use MediatorBuddy with Razor Pages is to use the standard page. The standard page gives you a predefined property for your view model and some simple methods to call for either a query or command.

Have your Page inherit from the MediatorBuddyStandardPage and pass the type of your view model into the generic parameter.

> Your view model must satisfy the "new()" constraint as the base page needs an empty constructor to create the object.

```csharp
public class MyPage : MediatorBuddyStandardPage<MyViewModel>
{
    public MyPage(IMediator mediator)
        : base(mediator)
    {
    }
}
```

Structure of the view model for reference:

```csharp
public class MyViewModel
{
    // Empty constructor for new() constraint.

    public Guid Id { get; set; }

    public string Name { get; set;}

    public void FromResponse(MyResponse response)
    {
        Id = response.Id;
        Name = response.Name;
    }
}
```

For a normal GET request, create the method and pass your request with an optional mapping Func to translate to your view model.

```csharp
public class MyPage : MediatorBuddyStandardPage<MyViewModel>
{
    public MyPage(IMediator mediator)
        : base(mediator)
    {
    }

    public async Task<IActionResult> OnGetAsync()
    {
        return await ExecuteQuery(new MyRequest(), MyViewModel.FromRequest)
    }
}
```

The base page POST implementation is best suited for grabbing some data from a form, sending that to the server, and re-directing to a page on success.

The POST implementation for the base page will execute a RedirectToPage result on success. The method accepts the page you want to route to as a string.

```csharp
public class MyPage : MediatorBuddyBasePage<MyViewModel>
{
    public MyPage(IMediator mediator)
        : base(mediator)
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        return await ExecuteCommand(new MyCommandRequest(), "Index")
    }
}
```

If you need to route to a page that accepts a parameter, use the following:

```csharp
public class MyPage : MediatorBuddyBasePage<MyViewModel>
{
    public MyPage(IMediator mediator)
        : base(mediator)
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        return await ExecuteCommand(
            new MyCommandRequest(), 
            response => ("Details", null, new RouteValueDictionary(new { Id = response.Widget.Id })));
    }
}
```

Unlike the API Controller, the base Razor Pages have no concept of a "standard" error response. It is up to you to decide how you want to handle errors that are returned from your handlers.

If you desire to keep things as simple as possible, you can just re-direct to the error page and log the errors in your backend to decipher why they occurred.

The standard page accepts the same type of function that returns an IActionResult that an API controller expects.

```csharp
public class MyPage : MediatorBuddyStandardPage<MyViewModel>
{
    private static readonly Func<RazorErrorWrapper, IActionResult?>? extraOptions = Wrapper =>
    {
        return Wrapper.status switch =>
        {
            ApplicationStatus.GeneralAuthError => new RedirectToPage("/LogIn"),
            ApplicationStatus.GeneralError => new RedirectToPage("/Home"),
            _ => null,
        }
    };

    public MyPage(IMediator mediator)
        : base(mediator, extraOptions)
    {
    }
}
```

### Detailed Usage For Razor Pages

#### Using the Base Page

The standard page is an opinionated version of the normal page. The standard page will satisfy most use cases, while the base page is useful if you need a customized approach.

Unlike the standard page, you will need to define your view model property and bind to it.

```csharp
public class MyModel : MediatorBuddyPage
{
    public MyModel(IMediator mediator)
        : base(mediator)
    {
        ViewModel = new MyViewModel();
    }

    [BindProperty]
    public MyViewModel ViewModel { get; set; }
}
```

The base page only has two methods-one that accepts an Action of type TResponse-typically for queries or GETs,-and another one that accepts a Func of type TResponse and returns an IActionResult, which is better for commands or POSTs.

```csharp
public class MyModel : MediatorBuddyPage
{
    public MyModel(IMediator mediator)
        : base(mediator)
    {
        ViewModel = new MyViewModel();
    }

    [BindProperty]
    public MyViewModel ViewModel { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        return await ExecuteRequest(new MyRequest(id), response => ViewModel == response);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        return await ExecuteRequest(
            new MyOtherRequest(),
            ResponseOptions.RedirectToPageResponse<MyResponse>(response => ("OtherPage")))
    }
}
```

> Sadly, you can not pass a ResponseOption callback for mapping due to how closures with anonymous methods work in C#. That's why the GET request uses an Action.

#### Integration With AutoMapper

If you use AutoMapper to translate between responses and view models, you can easily extend the standard or base page to work seamlessly.

```csharp
public abstract class MyBasePage<TViewModel> : MediatorBuddyStandardPage<TViewModel>
    where TViewModel : new()
{
    private readonly IMapper _mapper;

    protected MyBasePage(IMediator mediator, IMapper mapper)
        : base(mediator)
    {
        _mapper = mapper;
    }

    protected async Task<IActionResult> ExecuteGet<TResponse>(IEnvelopeRequest<TResponse> request)
    {
        return await ExecuteRequest(request, _mapper.Map<TResponse, TViewModel>)
    }
}
```

Your pages would now extend from your customer base page that would map responses to view models.

#### Using A Different Error Page

The default routing for Error Pages in RazorPages is "/Error".

If you use a different route, you may pass that new route into each page.

```csharp
public class MyPage : MediatorBuddyPage
{
    public MyPage(IMediator mediator)
        : base(mediator, null, "/CustomErrorRoute")
    {
    }
}
```

## MVC Controllers

### Quick Start for MVC Controller

Have your controller inherit from the MediatorBuddyMvc base class. Pass the IMediator instance into the base class.

```csharp
public class MyController : MediatorBuddyMvc
{
    public MyController(IMediator mediator)
        : base(mediator)
    {
    }
}
```

Create your controller actions as needed, and pass the request object to the "ExecuteRequest" method and the accompanying ResponseOptions callback.

You may also pass a mapping function to be called. In this case, the response object is converted to the view model from the view model's "FromResponse" method.

```csharp
public class MyController : MediatorBuddyMvc
{
    public MyController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return await ExecuteRequest(
            new MyRequest(),
            ResponseOptions.ViewResponse<MyResponse, MyViewModel>(MyViewModel.FromResponse)
        );
    }
}
```

Similar to how RazorPages works, you would pass a callback that maps your response object to your view model.

> ViewResponses require two generics. C# is unable to implicitly translate more than one generic type.

A request that does not return a view model would look like the following-(assuming your view model was also your request object):

```csharp
public class MyController : MediatorBuddyMvc
{
    public MyController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> AddWidget(AddWidgetViewModel viewModel)
    {
        return await ExecuteRequest(
            viewModel,
            ResponseOptions.RedirectToActionResponse<MyResponse>(_ => ("Index", "Widget"))
        );
    }
}
```

Just like RazorPages projects, errors in MVC are handled by passing a Func that will return the appropriate IActionResult you desire.

```csharp
public class MyController : MediatorBuddyMvc
{
    private static readonly Func<RazorErrorWrapper, IActionResult?>? extraOptions = Wrapper =>
    {
        return Wrapper.status switch =>
        {
            ApplicationStatus.GeneralAuthError => new RedirectToActionResult("Login", "Authentication"),
            ApplicationStatus.GeneralError => new RedirectToActionResult("Index", "Home"),
            _ => null,
        }
    };

    public MyController(IMediator mediator)
        : base(mediator, extraOptions)
    {
    }
}
```

> If you choose not to pass a function for errors, the controller will route the user to the "Error" action on the "Home" controller as this is the default for all MVC projects.

### Detailed Usage for MVC Controllers

#### Using the Controller TempData or ViewData

There are two methods in the base controller. The first one accepts the response object and returns an IActionResult.

The second is primarily used for views- it accepts both the response object and the [RazorViewData](https://github.com/mjbradvica/MediatorBuddy/blob/dependabot/nuget/Microsoft.AspNetCore.OpenApi-7.0.15/source/MediatorBuddy.AspNet/RazorViewData.cs) which will give you access to both the ITempDataDictionary and the ViewDataDictionary for the controller.

```csharp
public class MyController : MediatorBuddyMvc
{
    public MyController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return await ExecuteRequest(
            new MyRequest(),
            (response, razorData) => 
            {
                var tempData = razorData.TempData;
                var viewData = razorData.ViewData;

                // use temp or view data as needed

                return new ViewResponse();
            }
        );
    }
}
```

#### Integration For AutoMapper

Integrating with AutoMapper can be done with a custom base class that extends the existing MediatorBuddyMvc class.

```csharp
public abstract class MyBaseController : MediatorBuddyMvc
{
    private readonly IMapper _mapper;

    protected MyBaseController(IMediator mediator, IMapper mapper)
        : base(mediator)
    {
        _mapper = mapper;
    }

    protected async Task<IActionResult> ExecuteQuery<TResponse, TViewModel>(IRequest<IEnvelope<TRequest>> request)
    {
        return await ExecuteRequest(
            request,
            ResponseOptions.ViewResponse<TResponse, TViewModel>(response => _mapper.Map<TResponse, TViewModel>(response)));
    }
}
```

#### Using A Different Error Route

The base controller uses the default MVC error route of "Error" for the action and "Home" for the controller name. To use a different route, pass the desired parameters to the base class.

```csharp
public class MyController : MediatorBuddyMvc
{
    public MyController(IMediator mediator)
        : base(mediator, null, "Home", "Fault")
    {
    }
}
```

## FAQ

### What is MediatorBuddy?

MediatorBuddy is an opinionated implementation of the MediatR library.

It gives you a specific way to handle errors and responses from handlers and controllers. In certain situations, you may not need to unit test controllers at all.

### What is implied by an 80/20 library?

MediatorBuddy is only concerned with a subset of all available faults and responses that are the most common. There are situations where you may have to return a response that is not provided by default.

### How does MediatorBuddy handle errors?

MediatorBuddy forces you to return an Envelope on every request no matter what. This gives your application consistency when handling errors.

You must implement a handler for the GlobalExceptionOccurred notification. This event is raised every time an uncaught exception bubbles up to a controller.

> Throwing exceptions in your application is another form of a goto statement, especially when you can predict the execution path.

### What if I need to throw an exception?

If you need to throw, then throw. Just make sure you handle the exception gracefully in your global exception handler.

### Do I need to use the existing Envelope implementation?

No, you may implement your own from the IEnvelope interface. Still, using the default implementation is recommended to start.

### What is the difference between the ApplicationStatus and an HTTP status?

An application status is an abstract way of declaring the current state of your application. It makes zero assumptions about your presentation layer. This allows MediatorBuddy to be used with an API, MVC, Razor, Blazor, gPRC, or GraphQL application. Even if it doesn't provide a specific implementation.

HTTP status codes are an implementation detail and should not be allowed to leak in your application or domain layer.

### Can I only use MediatorBuddy for an API?

API, Razor Pages, and MVC will be supported on the initial release. There are plans to add support for gRPC and GraphQL at later dates.
