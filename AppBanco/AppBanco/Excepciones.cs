using System;

namespace AppBanco
{
    public class InvalidCreditOperationException : Exception
    {
        public InvalidCreditOperationException(string message) : base(message)
        {
        }
    }

    public class InvalidDebitOperationException : Exception
    {
        public InvalidDebitOperationException(string message) : base(message)
        {
        }
    }

    public class InvalidTransferenceOperationException : Exception
    {
        public InvalidTransferenceOperationException(string message) : base(message)
        {
        }
    }
}