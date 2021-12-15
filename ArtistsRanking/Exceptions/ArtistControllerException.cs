using System;

namespace ArtistsRanking.Exceptions
{
    public class ArtistControllerException : Exception
    {
        protected ArtistControllerException()
        {
        }

        protected ArtistControllerException(string message) : base(message)
        {
        }

        protected ArtistControllerException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    public class ArtistAlreadyExistsException : ArtistControllerException
    {
        public ArtistAlreadyExistsException()
        {
        }

        public ArtistAlreadyExistsException(string message) : base(message)
        {
        }

        public ArtistAlreadyExistsException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}