// <copyright file="MediatorBuddyAttributeTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using MediatorBuddy.AspNet.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Attributes
{
    /// <summary>
    /// Tests for mediator buddy error response attributes.
    /// </summary>
    [TestClass]
    public class MediatorBuddyAttributeTests
    {
        /// <summary>
        /// Ensures the mediator buddy 400 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy400Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy400ErrorResponseAttribute(), StatusCodes.Status400BadRequest);
        }

        /// <summary>
        /// Ensures the mediator buddy 401 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy401Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy401ErrorResponseAttribute(), StatusCodes.Status401Unauthorized);
        }

        /// <summary>
        /// Ensures the mediator buddy 402 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy402Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy402ErrorResponseAttribute(), StatusCodes.Status402PaymentRequired);
        }

        /// <summary>
        /// Ensures the mediator buddy 403 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy403Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy403ErrorResponseAttribute(), StatusCodes.Status403Forbidden);
        }

        /// <summary>
        /// Ensures the mediator buddy 404 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy404Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy404ErrorResponseAttribute(), StatusCodes.Status404NotFound);
        }

        /// <summary>
        /// Ensures the mediator buddy 405 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy405Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy405ErrorResponseAttribute(), StatusCodes.Status405MethodNotAllowed);
        }

        /// <summary>
        /// Ensures the mediator buddy 406 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy406Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy406ErrorResponseAttribute(), StatusCodes.Status406NotAcceptable);
        }

        /// <summary>
        /// Ensures the mediator buddy 407 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy407Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy407ErrorResponseAttribute(), StatusCodes.Status407ProxyAuthenticationRequired);
        }

        /// <summary>
        /// Ensures the mediator buddy 408 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy408Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy408ErrorResponseAttribute(), StatusCodes.Status408RequestTimeout);
        }

        /// <summary>
        /// Ensures the mediator buddy 409 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy409Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy409ErrorResponseAttribute(), StatusCodes.Status409Conflict);
        }

        /// <summary>
        /// Ensures the mediator buddy 410 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy410Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy410ErrorResponseAttribute(), StatusCodes.Status410Gone);
        }

        /// <summary>
        /// Ensures the mediator buddy 411 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy411Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy411ErrorResponseAttribute(), StatusCodes.Status411LengthRequired);
        }

        /// <summary>
        /// Ensures the mediator buddy 412 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy412Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy412ErrorResponseAttribute(), StatusCodes.Status412PreconditionFailed);
        }

        /// <summary>
        /// Ensures the mediator buddy 413 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy413Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy413ErrorResponseAttribute(), StatusCodes.Status413PayloadTooLarge);
        }

        /// <summary>
        /// Ensures the mediator buddy 414 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy414Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy414ErrorResponseAttribute(), StatusCodes.Status414UriTooLong);
        }

        /// <summary>
        /// Ensures the mediator buddy 415 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy415Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy415ErrorResponseAttribute(), StatusCodes.Status415UnsupportedMediaType);
        }

        /// <summary>
        /// Ensures the mediator buddy 416 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy416Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy416ErrorResponseAttribute(), StatusCodes.Status416RangeNotSatisfiable);
        }

        /// <summary>
        /// Ensures the mediator buddy 417 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy417Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy417ErrorResponseAttribute(), StatusCodes.Status417ExpectationFailed);
        }

        /// <summary>
        /// Ensures the mediator buddy 418 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy418Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy418ErrorResponseAttribute(), StatusCodes.Status418ImATeapot);
        }

        /// <summary>
        /// Ensures the mediator buddy 421 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy421Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy421ErrorResponseAttribute(), StatusCodes.Status421MisdirectedRequest);
        }

        /// <summary>
        /// Ensures the mediator buddy 422 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy422Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy422ErrorResponseAttribute(), StatusCodes.Status422UnprocessableEntity);
        }

        /// <summary>
        /// Ensures the mediator buddy 423 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy423Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy423ErrorResponseAttribute(), StatusCodes.Status423Locked);
        }

        /// <summary>
        /// Ensures the mediator buddy 424 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy424Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy424ErrorResponseAttribute(), StatusCodes.Status424FailedDependency);
        }

        /// <summary>
        /// Ensures the mediator buddy 425 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy425Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy425ErrorResponseAttribute(), 425);
        }

        /// <summary>
        /// Ensures the mediator buddy 426 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy426Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy426ErrorResponseAttribute(), StatusCodes.Status426UpgradeRequired);
        }

        /// <summary>
        /// Ensures the mediator buddy 428 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy428Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy428ErrorResponseAttribute(), StatusCodes.Status428PreconditionRequired);
        }

        /// <summary>
        /// Ensures the mediator buddy 429 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy429Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy429ErrorResponseAttribute(), StatusCodes.Status429TooManyRequests);
        }

        /// <summary>
        /// Ensures the mediator buddy 431 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy431Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy431ErrorResponseAttribute(), StatusCodes.Status431RequestHeaderFieldsTooLarge);
        }

        /// <summary>
        /// Ensures the mediator buddy 401 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy451Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy451ErrorResponseAttribute(), StatusCodes.Status451UnavailableForLegalReasons);
        }

        /// <summary>
        /// Ensures the mediator buddy 500 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy500Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy500ErrorResponseAttribute(), StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// Ensures the mediator buddy 501 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy501Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy501ErrorResponseAttribute(), StatusCodes.Status501NotImplemented);
        }

        /// <summary>
        /// Ensures the mediator buddy 502 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy502Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy502ErrorResponseAttribute(), StatusCodes.Status502BadGateway);
        }

        /// <summary>
        /// Ensures the mediator buddy 503 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy503Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy503ErrorResponseAttribute(), StatusCodes.Status503ServiceUnavailable);
        }

        /// <summary>
        /// Ensures the mediator buddy 504 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy504Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy504ErrorResponseAttribute(), StatusCodes.Status504GatewayTimeout);
        }

        /// <summary>
        /// Ensures the mediator buddy 505 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy505Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy505ErrorResponseAttribute(), StatusCodes.Status505HttpVersionNotsupported);
        }

        /// <summary>
        /// Ensures the mediator buddy 506 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy506Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy506ErrorResponseAttribute(), StatusCodes.Status506VariantAlsoNegotiates);
        }

        /// <summary>
        /// Ensures the mediator buddy 507 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy507Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy507ErrorResponseAttribute(), StatusCodes.Status507InsufficientStorage);
        }

        /// <summary>
        /// Ensures the mediator buddy 508 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy508Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy508ErrorResponseAttribute(), StatusCodes.Status508LoopDetected);
        }

        /// <summary>
        /// Ensures the mediator buddy 510 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy510Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy510ErrorResponseAttribute(), StatusCodes.Status510NotExtended);
        }

        /// <summary>
        /// Ensures the mediator buddy 511 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy511Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy511ErrorResponseAttribute(), StatusCodes.Status511NetworkAuthenticationRequired);
        }

        private static void AssertIsType(IApiResponseMetadataProvider attribute, int statusCode)
        {
            Assert.AreEqual(typeof(ErrorResponse), attribute.Type);
            Assert.AreEqual(statusCode, attribute.StatusCode);
        }
    }
}
