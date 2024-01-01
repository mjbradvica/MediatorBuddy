// <copyright file="GetByIdValidator.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using FluentValidation;
using FluentValidation.Results;

namespace MediatorBuddy.Samples.Mvc.FluentValidationExample
{
    /// <summary>
    /// Fluent validator for a get by id request.
    /// </summary>
    public class GetByIdValidator : AbstractValidator<FluentGetByIdRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetByIdValidator"/> class.
        /// </summary>
        public GetByIdValidator()
        {
            RuleFor(request => request.Id).NotEqual(Guid.Empty);
        }

        /// <summary>
        /// Validates the request.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>A <see cref="ValidationResult"/>.</returns>
        public static ValidationResult ValidateRequest(FluentGetByIdRequest request)
        {
            return new GetByIdValidator().Validate(request);
        }
    }
}
