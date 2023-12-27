# MediatorBuddy

An opinionated implementation for the [MediatR](https://github.com/jbogard/MediatR) library.

![TempBuddy](./images/logo-web.png)

![build-status](https://github.com/mjbradvica/MediatorBuddy/workflows/main/badge.svg) ![downloads](https://img.shields.io/nuget/dt/MediatorBuddy) ![downloads](https://img.shields.io/nuget/v/MediatorBuddy) ![activity](https://img.shields.io/github/last-commit/mjbradvica/MediatorBuddy/master)

## Overview

What does MediatorBuddy give you?

- :telephone: A consistent interface for communication between your presentation and application layer.
- :clipboard: An implementation of the [RFC 9457](https://www.rfc-editor.org/rfc/rfc9457.txt) spec for consistent and user-friendly API error responses.
- :construction_worker: A base controller that handles generic boilerplate for you. You may find that you no longer need to unit-test anything in your presentation layer.
- :hammer: Extendable: You can define custom application status states and return a specific status code.
- :currency_exchange: Modifiable: Override a status return code, title, or detail message.

## Framework Support

| Framework   | Supported |
| ----------- | --------- |
| .NET API    | Yes       |
| .NET MVC    | Soon      |
| Razor Pages | Soon      |
| gRPC        | Planned   |
| graphQL     | Planned   |
| Blazor      | Planned   |

## Built-In Http Status Code Support

If you are using MediatorBuddy for API projects, there is built-in support for most, but not all HTTP non-error status codes.

| Codes | Supported          |
| ----- | ------------------ |
| 100s  | 100 - 102          |
| 200s  | 200 - 226          |
| 300s  | 301, 302, 307, 308 |

## Table of Contents

- [Overview](#overview)
- [Framework Support](#framework-support)
- [Dependencies](#dependencies)
- [Installation](#installation)
- [Explanation](#what-is-implied-by-an-opinionated-library)
- [Background](#background-story)
- [Setup](#setup)
- [Quick Start API](#quick-start-api)
- [In-Depth](#in-depth)
  - [Default Responses](#default-responses)
- [FAQ](#faq)

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

If you are familiar with the [Prettier](https://prettier.io/) format library for front-end frameworks-then the idea of an "opinionated" library should be familiar.

MediatorBuddy has a very specific way of handling requests and responses. The advantage you gain is up to 100% less unit testing in your presentation layer alongside a consistent way of handling failures.

MediatorBuddy assumes that you prefer to use the built-in [validation attributes](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-7.0#validation-attributes) that Microsoft provides out of the box.

> Attribute validators are highly recommended, especially if you are utilizing Swagger.

You may use a separate library such as [FluentValidation](https://www.nuget.org/packages/FluentValidation)-however you will need to validate request objects in your handlers.

A quick sample using FluentValidation is available [here.](https://github.com/mjbradvica/MediatorBuddy/tree/master/samples/MediatorBuddy.Samples.Api/FluentValidationExample)

## Background Story

MediatorBuddy is the third version of a small pattern I found myself constantly implementing on multiple projects. It started with not wanting to write the same unit test for API endpoints over and over again. It has since morphed into the formal version you see in this library.

MediatorBuddy's greatest strength is that it puts guardrails on your developers. Forcing them to code to a specific implementation. This will lead to a more consistent API for both your developers and customers.

## Setup

> This documentation assumes you are already familiar with how [MediatR](https://github.com/jbogard/MediatR) works.

While MediatorBuddy has nothing it needs to register with the dependency injection framework-its needs to turn off the default model state filter.

For convenience pass your MediatR configuration setup and MediatorBuddy will setup MediatR in the same call.

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

## Quick Start API

All requests inherit from the [IEnvelopeRequest](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy/IEnvelopeRequest.cs) interface.

```csharp
public class MyRequest : IEnvelopeRequest<MyResponse>
{
}
```

All handlers inherit from the [IEnvelopeHandler](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy/IEnvelopeHandler.cs) interface.

```csharp
public class MyHandler : IEnvelopeHandler<MyRequest, MyResponse>
{
    public async Task<IEnvelope<MyResponse>> Handle(MyRequest handler, CancellationToken cancellationToken)
    {
    }
}
```

Use the built-in [Envelope](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy/Envelope.cs) class to determine responses.

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

Have your controller inherit from the [MediatorBuddyApi](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy.AspNet/MediatorBuddyApi.cs) base class.

Pass your requests to the "ExecuteRequest" method and use one of the built-in success callbacks.

Annotate your method with the built-in error response attributes for each specific error type you return.

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

That's 90% of how MediatorBuddy works!

I hope the potential of what the library can do for you and your development team is apparent.

## In-Depth

### Requests

Creating a request object will now inherit from the IEnvelopeRequest interface.

```csharp
public class GetWeatherRequest : IEnvelopeRequest<GetWeatherResponse>
{
}
```

If your request does not need to return an object:

```csharp
public class GetWeatherRequest : IEnvelopeRequest
{
}
```

The [IEnvelopeRequest](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy/IEnvelopeRequest.cs) interface is a shorthand way of returning the [IEnvelope](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy/IEnvelope.cs) interface.

Every request from now on will return an "IEnvelope" even if the true return type is supposed to be void.

MediatorBuddy uses the interface to return a response based on the status of your application.

> MediatorBuddy does not imply HTTP status codes in the base library. It is important to separate the status of your application from a status code returned from an API.

### Handlers

Similar to requests, handlers will inherit from an [IEnvelopeHandler](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy/IEnvelopeHandler.cs) interface.

```csharp
public class GetWeatherHandler : IEnvelopeHandler<GetWeatherRequest, GetWeatherResponse>
{
    public Task<IEnvelope<GetWeatherResponse>> Handle(GetWeatherRequest request, CancellationToken cancellationToken)
    {
        // Implementation.
    }
}
```

### Envelopes

The best way to use the [IEnvelope](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy/IEnvelope.cs) interface is to utilize the built-in [Envelope](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy/Envelope.cs) class.

The class has a static function you can call for each application status.

> You are free to create your own implementation for the [IEnvelope](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy/IEnvelope.cs) interface. However, I recommend starting with the built-in class for most projects.

Returning a response is straightforward:

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

        return Envelope<GetWeatherResponse>.Success(new GetWeatherResponse(data));
    }
}
```

Even if a handler returns void, an Envelope is still expected.

```csharp
public class UpdateWeatherHandler : IEnvelopeHandler<UpdateWeatherRequest>
{
    private readonly IDataSource _data;

    public GetWeatherHandler(IDataSource data)
    {
        _data = data;
    }

    public async Task<IEnvelope<Unit>> Handle(UpdateWeatherRequest request, CancellationToken cancellationToken)
    {
        var data = await _data.UpdateData(request);

        return Envelope<Unit>.Success(Unit.Value);
    }
}
```

### Failures

If your application experiences a fault, you are still expected to return an Envelope.

> Throwing blanket exceptions is another form of a goto statement. If you "expected" something to happen, that does not qualify for an exception.

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
            return Envelope<GetWeatherResponse>.EntityNotFound();
        }

        return Envelope<GetWeatherResponse>.Success(new GetWeatherResponse(data));
    }
}
```

### Custom Fault Messages

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

### Custom Faults

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

Use in your code where needed...

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

```csharp
// TODO: Update
```

### Controllers

#### Base Controller Overview

The MediatorBuddy base controller takes care of the normal boring boilerplate you need for each action.

- Validates the request using the [built-in validators](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-7.0).
- Wraps every operation in a try/catch for exceptions.
- Sends the request down the MediatR pipeline to be executed.
- Handles the response object accordingly.

The biggest benefit of MediatorBuddy is turning your presentation layer into a thin, already-tested shield over your application.

Have your controller or page if using Razor pages inherit from the appropriate base class. Pass the "IMediator" interface to the base class.

```csharp
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : MediatorBuddyApi
{
    public WeatherForecastController(IMediator mediator)
        : base(mediator)
    {
    }
}
```

#### Simple Response

Starting a request is as easy as calling the [ExecuteRequest](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy.AspNet/MediatorBuddyApi.cs) method with your request object and a successful callback.

```csharp
[HttpGet(Name = "GetWeatherForecast")]
public async Task<IActionResult> Get()
{
    return await ExecuteRequest(new GetWeatherRequest(), ResponseOptions.OkObjectResponse<GetWeatherResponse>());
}
```

The [ResponseOptions](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy.AspNet/ResponseOptions.cs) class is the preferred way of passing a successful callback to the method. This is the response that will be used if the status of your envelope is not in a faulted state.

ResponseOptions has a majority of status codes in the 100's, 200's, and 300's.

> MediatorBuddy uses the responses available in the [ControllerBase](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase?view=aspnetcore-8.0) class as a reference point.

#### Error Type Annotations

MediatorBuddy comes with a set of attributes to annotate action responses for error codes.

```csharp
[HttpGet(Name = "GetWeatherForecast")]
[MediatorBuddy404ErrorResponse]
public async Task<IActionResult> Get()
{
    return await ExecuteRequest(new GetWeatherRequest(), ResponseOptions.OkObjectResponse<GetWeatherResponse>());
}
```

These are a shorthand way of replicating the [ProducesResponseType](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.producesresponsetypeattribute?view=aspnetcore-8.0) attribute.

> You don't need to an attribute for a 400 or 500 error code, the base controller already adds these for you.

#### Detailed Response

Some ResponseOptions allow you to pass another callback. Such is the case of a 201 Created response.

```csharp
[HttpPost(Name = "AddWeatherForecast")]
public async Task<IActionResult> Add(AddWeatherRequest request)
{
    return await ExecuteRequest(request,
    ResponseOptions.CreatedObjectResponse<AddWeatherResponse>(
        response => new Uri($"WeatherForecast/{response.Id}", UriKind.Relative)));
}
```

> MediatorBuddy uses the [Paredo Principle](https://en.wikipedia.org/wiki/Pareto_principle) a.k.a. 80/20 rule for responses. You may have a specific use case or two that requires a custom callback.

#### Custom Callbacks

In the case that you need a response type that doesn't exist already. You only need to pass a call back that accepts your response type and returns an IActionResult.

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

- We do not assume you are using logging.
- We do not assume what kind of logging implementation you are using.
- One less dependency to inject into every controller.

##### Exception handler

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

> Even if you choose to ignore exceptions. You must define a handler or else MediatR will throw an exception.

### Default Responses

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
| Global Exception                    | 500         | Error/General                         |

## FAQ

### What is MediatorBuddy?

MediatorBuddy is an opinionated implementation of the MediatR library.

It gives you a specific way to handle errors and responses from handlers and controllers. In certain situations, you may not need to unit test controllers at all.

### What is implied by an 80/20 library?

MediatorBuddy is only concerned with a subset of all available faults and responses that are the most common. There are situations where you may have to return a response that isn't provided by default.

### How does MediatorBuddy handle errors?

MediatorBuddy forces you to return an Envelope on every request no matter what. This gives your application consistency when handling errors.

You must implement a handler for the GlobalExceptionOccurred notification. This event is raised every time an uncaught exception bubbles up to a controller.

Reminder: Throwing exceptions in your application is another form of a goto statement, especially when you can predict the execution path.

### What if I need to throw an exception?

If you need to throw, throw. Just make sure you handle the exception gracefully in your global exception handler.

### Do I need to use the existing Envelope implementation?

No, you may implement your own from the IEnvelope interface. However, using the default implementation is recommended to start with.

### What is the difference between the ApplicationStatus and an HTTP status?

An application status is an abstract way of declaring the current state of your application. It makes zero assumptions about your presentation layer. This allows MediatorBuddy to be used with an API, MVC, Razor, Blazor, gPRC, or GraphQL application. Even if it doesn't provide a specific implementation.

HTTP status codes are an implementation detail and should not be allowed to leak in your application or domain layer.

### Can I only use MediatorBuddy for an API?

API projects will be fully supported, while Razor Pages and MVC projects will be partially supported on the initial release. There are plans to add support for gRPC and GraphQL at later dates.
