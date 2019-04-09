using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using GoParty.Business.Contract.Core.Exceptions;
using NLog;

namespace GoParty.Web.Handlers
{
    public class WebApiExceptionHandler : ExceptionHandler
    {
        private readonly ILogger _logger = LogManager.GetLogger("Default");

        public override void Handle(ExceptionHandlerContext context)
        {
            Exception exception = context.Exception;

            try
            {
                HttpResponseMessage httpResponse = null;

                if (exception is MessageException messageException)
                {
                    httpResponse = Process(messageException, context);
                }
                else
                {
                    httpResponse = Process(exception, context);
                }

                if (httpResponse != null)
                {
                    context.Result = new WebApiExceptionResult { HttpResponseMessage = httpResponse };
                }
            }
            catch (Exception)
            {
                _logger.Fatal(exception, "Error occurred: ");
                _logger.Fatal(exception, "This error occurred while Logging an error: ");
                throw;
            }
        }

        private HttpResponseMessage Process(MessageException messageException, ExceptionHandlerContext context)
        {
            _logger.Error(messageException, $"{messageException.CustomMessage}"); 

            return context.Request.CreateErrorResponse(HttpStatusCode.BadRequest, messageException.Message);
        }

        private HttpResponseMessage Process(Exception exception, ExceptionHandlerContext context)
        {
            var message = $"An error occured. Please write a letter to the support service" +
                          $" and attach en error id: {Guid.NewGuid()}";
            _logger.Error(exception, $"{exception.Message}");

            return context.Request.CreateErrorResponse(HttpStatusCode.BadRequest, message);
        }
    }
}