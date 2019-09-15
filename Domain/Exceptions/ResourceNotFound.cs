using System;

namespace Domain.Exceptions
{
    public class ResourceNotFound : Exception
    {
        public ResourceNotFound(string message) : base(message)
        {

        }
    }
}
