using System;

namespace EasyWallet.Entries.Business.Exceptions
{
    public class InvalidEntryAmountException : FormatException
    {
        public InvalidEntryAmountException()
        {
        }

        public InvalidEntryAmountException(string message) : base(message)
        {
        }

        public InvalidEntryAmountException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
