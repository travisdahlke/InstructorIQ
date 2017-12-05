﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace InstructorIQ.Web.Middleware
{
    public class JsonExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly Func<object, Task> _clearCacheHeadersDelegate;
        private readonly IOptions<MvcJsonOptions> _jsonOptions;
        private readonly JsonSerializer _serializer;

        public JsonExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IHostingEnvironment hostingEnvironment, IOptions<MvcJsonOptions> jsonOptions)
        {
            _next = next;
            _hostingEnvironment = hostingEnvironment;
            _jsonOptions = jsonOptions;
            _logger = loggerFactory.CreateLogger<ExceptionHandlerMiddleware>();
            _clearCacheHeadersDelegate = ClearCacheHeaders;

            _serializer = new JsonSerializer();
            _serializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
            _serializer.NullValueHandling = NullValueHandling.Ignore;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context).ConfigureAwait(false);
            }
            catch (Exception middlewareError)
            {
                _logger.LogError(middlewareError, "An unhandled exception has occurred while executing the request.");

                if (context.Response.HasStarted)
                {
                    _logger.LogWarning("The response has already started, the error page middleware will not be executed.");
                    throw;
                }

                try
                {
                    // reset body
                    if (context.Response.Body.CanSeek)
                        context.Response.Body.SetLength(0L);

                    context.Response.StatusCode = 500;
                    context.Response.OnStarting(_clearCacheHeadersDelegate, context.Response);

                    await WriteContent(context, middlewareError).ConfigureAwait(false);

                    return;
                }
                catch (Exception handlerError)
                {
                    // Suppress secondary exceptions, re-throw the original.
                    _logger.LogError(handlerError, "An exception was thrown attempting to execute the error handler.");
                }

                throw; // Re-throw the original if we couldn't handle it
            }
        }

        private async Task WriteContent(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var result = new ErrorResult { Message = exception.Message };

            switch (exception)
            {
                case ValidationException validationException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    result.Errors = validationException.Errors;
                    break;
            }

            result.Code = $"{context.Response.StatusCode}";
            result.Detail = exception.ToString();

            using (var writer = new StreamWriter(context.Response.Body))
            {
                _serializer.Serialize(writer, result);
                await writer.FlushAsync().ConfigureAwait(false);
            }
        }

        private Task ClearCacheHeaders(object state)
        {
            var response = (HttpResponse)state;
            response.Headers[HeaderNames.CacheControl] = "no-cache";
            response.Headers[HeaderNames.Pragma] = "no-cache";
            response.Headers[HeaderNames.Expires] = "-1";
            response.Headers.Remove(HeaderNames.ETag);

            return Task.CompletedTask;
        }

        private class ErrorResult
        {
            public string Code { get; set; }
            public string Message { get; set; }
            public string Detail { get; set; }

            public IEnumerable<ValidationFailure> Errors { get; set; }
        }
    }
}
