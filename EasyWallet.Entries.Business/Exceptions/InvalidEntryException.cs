using System;

namespace EasyWallet.Entries.Business.Exceptions
{
    public class InvalidEntryException : FormatException
    {
        public InvalidEntryException()
        {
        }

        public InvalidEntryException(string message) : base(message)
        {
        }

        public InvalidEntryException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
