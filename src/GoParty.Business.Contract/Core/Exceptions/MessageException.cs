using System;

namespace GoParty.Business.Contract.Core.Exceptions
{
    public class MessageException : Exception
    {
        public string CustomMessage { get; }

        public MessageException(string customMessage, string errorMessage, Exception innerException)
            : base(errorMessage, innerException)
        {
            CustomMessage = customMessage;
        }

        public MessageException(string errorMessage, Exception innerException)
            : this(errorMessage, errorMessage, innerException)
        {
        }

        public MessageException(string errorMessage) 
            : this(errorMessage, errorMessage)
        {
        }

        public MessageException(string customMessage, string errorMessage)
            : base(errorMessage)
        {
            CustomMessage = customMessage;
        }
    }
}