using System;

namespace NetworkMonitor.Common.Exceptions;

public class NetworkInterfaceException : Exception
{
    public NetworkInterfaceException()
    {
    }

    public NetworkInterfaceException(string message)
        : base(message)
    {

    }

    public NetworkInterfaceException(string message, Exception inner)
        : base(message, inner)
    {

    }
}