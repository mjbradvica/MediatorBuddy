# MediatorBuddy

![build-status](https://github.com/mjbradvica/MediatorBuddy/workflows/main/badge.svg) ![downloads](https://img.shields.io/nuget/dt/MediatorBuddy) ![downloads](https://img.shields.io/nuget/v/MediatorBuddy) ![activity](https://img.shields.io/github/last-commit/mjbradvica/MediatorBuddy/master)

An opinionated implementation for the [MediatR](https://github.com/jbogard/MediatR) library.

## Overview

What does Mediator buddy give you?

- A consistent interface for communication between your presentation and application layer.
- An implementation of the [RFC 9457](https://www.rfc-editor.org/rfc/rfc9457.txt) spec for consistent and user friendly API error responses.
- A base controller that handles generic boilerplate for you. You may find that you no longer need to unit-test anything in your presentation layer.
- Extendability-you can define custom application status states and return a specific status code.
- Modifiable-override a status return code, title, or detail message.

## Installation

The easier way to get start is to: [Install with NuGet](https://www.nuget.org/).

In your application layer:

```bash
Install-Package MediatorBuddy
```

In your presentation layer:

```bash
Install-Package MediatorBuddy.AspNet
```

## What is implied by "opinionated" library?

If you are familiar with the [Prettier](https://prettier.io/) formatter for front-end frameworks-then the idea of an "opinionated" library should be familiar.

MediatorBuddy has a very specific way to handling requests and responses. The advantage you gain is up to 100% less unit testing in your presentation layer alongside a consistent way to handling failures.

## Background Story

MediatorBuddy is the third version of a small pattern I found myself constantly implementing on multiple projects. It started with not wanting to write the same unit test for API endpoints over and over again. It has since morphed into the formal version you see in this library.

MediatorBuddy's greatest strength is that it puts guardrails on your developers. Forcing them to code to a specific implementation. This will lead to a more consistent API for both your developers and customers.

## Setup

> This documentation assumes you are already familiar with how [MediatR](https://github.com/jbogard/MediatR) works.

## Quick Start

All requests inherit from the [IEnvelopeRequest](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy/IEnvelopeRequest.cs) interface.

```csharp
public class MyRequest : IEnvelopeRequest<MyResponse>
{
}
```

All handlers inherit from the [IEnvelopeHandler](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy/IEnvelopeHandler.cs) interface.

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

        if(data == null)
        {
            return Envelope<MyResponse>.EntityNotFound();
        }

        return Envelope<MyResponse>.Success(new MyResponse(data));
    }
}
```

Have your controller inherit from the [MediatorBuddyApi](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy.AspNet/MediatorBuddyApi.cs) base class.

Pass your requests the "ExecuteRequest" method and use one of the built-in success callbacks.

```csharp
[ApiController]
[Route("[controller]")]
public class MyController : MediatorBuddyApi
{
    public MyController(IMediator mediator)
        : base(mediator)
    {
        [HttpGet]
        public async Task<IActionResult> GetMyData()
        {
            return await ExecuteRequest(new MyRequest(), ResponseOptions.OkObjectResponse<MyResponse>());
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

That's 90% of how MediatorBuddy works!

I hope you are able to see the potential of what the library can do for you and your development team.

## In Depth

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

> MediatorBuddy does not imply HTTP status codes it the base library. It is important to separate the status of your application from a status code returned from an API.

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

Returning a response is straight forward:

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

Even if an handler returns void, an Envelope is still expected.

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

If you application experiences a fault, you are still expected to return an Envelope.

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

The title and description for failures is generic on purpose. You can enrich a fault by adding a custom title and description.

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

### Controllers

#### Base Controller Overview

The MediatorBuddy base controller takes care of the normal boring boilerplate you need for each action.

- Validates the request using the [built in validators](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-7.0).
- Wraps every operation in a try/catch for exceptions.
- Sends the request down the MediatR pipeline to be executed.
- Handles the response object accordingly.

The biggest benefit of MediatorBuddy is turning your presentation layer into a thin, already tested shield over your application.

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

Starting a request is as easy as calling the [ExecuteRequest](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy.AspNet/MediatorBuddyApi.cs) method with your request object and a success callback.

```csharp
[HttpGet(Name = "GetWeatherForecast")]
public async Task<IActionResult> Get()
{
    return await ExecuteRequest(new GetWeatherRequest(), ResponseOptions.OkObjectResponse<GetWeatherResponse>());
}
```

The [ResponseOptions](https://github.com/mjbradvica/MediatorBuddy/blob/master/source/MediatorBuddy.AspNet/ResponseOptions.cs) class is the preferred way of passing a success callback to the method. This is the response that will be used if the status of your envelope is not in a faulted state.

ResponseOptions has every response for any status code in the 100's or 200's.

#### Detailed Response

Some ResponseOptions allow you to pass another callback. Such in the case of a 201 Created response.

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

https://www.rfc-editor.org/rfc/rfc7807
https://www.rfc-editor.org/rfc/rfc9457.txt
