using System;

namespace Microsoft.UsedCarDealerWeb.ApplicationCore.Exceptions;

public class DuplicateException : Exception
{
    public DuplicateException(string message) : base(message)
    {

    }

}
