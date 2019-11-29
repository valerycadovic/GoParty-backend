using System;

namespace GoParty.Business.Contract.Core.Exceptions
{
    public class MessageException : Exception
    {
        public MessageException(string errorMessage, Exception innerException)
            : base(errorMessage, innerException)
        {
        }

        public MessageException(string errorMessage) : base(errorMessage)
        {
        }
    }
}