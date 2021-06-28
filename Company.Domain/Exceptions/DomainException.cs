using System;
using System.Net;

namespace Company.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public HttpStatusCode Status { get; protected set; }
        public DomainException(string message, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest) : base(message)
        {
            this.Status = Status;
        }
    }
}
