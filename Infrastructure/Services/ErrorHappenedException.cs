using System;

namespace Infrastructure.Services
{
    public class ErrorHappenedException : Exception
    {
        public ErrorHappenedException(string message) : base(message)
        { }

        public ErrorHappenedException(string message, string detailMessage) : base(message)
        {
            DetailMessage = detailMessage;
        }
        public string DetailMessage { get; internal set; }

    }
}
