using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using GoParty.Business.Contract.Core.Exceptions;

namespace GoParty.Web.Handlers
{
    public class WebApiExceptionHandler : ExceptionHandler
    {
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
                // TODO: logger 
            }
        }

        private HttpResponseMessage Process(MessageException messageException, ExceptionHandlerContext context)
        {
            // _logger.Error(messageException.Message); 

            return context.Request.CreateErrorResponse(HttpStatusCode.BadRequest, messageException.Message);
        }

        private HttpResponseMessage Process(Exception exception, ExceptionHandlerContext context)
        {
            // _logger.Error(exception.Message); 
            var message = $"An error occured. Please write a letter to the support service" +
                          $" and attach en error id: {Guid.NewGuid()}";

            return context.Request.CreateErrorResponse(HttpStatusCode.BadRequest, message);
        }
    }
}