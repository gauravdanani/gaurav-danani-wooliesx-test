﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Gaurav.Danani.WooliesX.ServiceHost.Unit
{
    public class MockProblemDetailsFactory : ProblemDetailsFactory
    {
        public override ProblemDetails CreateProblemDetails(HttpContext httpContext,
            int? statusCode = default, string title = default,
            string type = default, string detail = default, string instance = default)
        {
            return new ProblemDetails() {
                Detail = detail,
                Instance = instance,
                Status = statusCode,
                Title = title,
                Type = type,
            };
        }

        public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext,
            ModelStateDictionary modelStateDictionary, int? statusCode = default,
            string title = default, string type = default, string detail = default,
            string instance = default)
        {
            return new ValidationProblemDetails(new Dictionary<string, string[]>()) {
                Detail = detail,
                Instance = instance,
                Status = statusCode,
                Title = title,
                Type = type,
            };
        }
    }
}