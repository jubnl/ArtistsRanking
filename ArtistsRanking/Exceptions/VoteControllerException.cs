using System;

namespace ArtistsRanking.Exceptions;

public class VoteControllerException : Exception
{
    protected VoteControllerException()
    {
    }

    protected VoteControllerException(string message) : base(message)
    {
    }

    protected VoteControllerException(string message, Exception inner) : base(message, inner)
    {
    }
}

public class VoteAlreadyExistsException : VoteControllerException
{
    public VoteAlreadyExistsException()
    {
    }

    public VoteAlreadyExistsException(string message) : base(message)
    {
    }

    public VoteAlreadyExistsException(string message, Exception inner) : base(message, inner)
    {
    }
}