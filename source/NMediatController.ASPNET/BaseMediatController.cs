using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace NMediatController.ASPNET
{
    public abstract class BaseMediatController : ControllerBase
    {
        private readonly IMediator _mediator;

        protected BaseMediatController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
