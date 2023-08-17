using System;

namespace Domain.Interfaces
{
    public class ValidatorResult
    {
        public ValidatorResult(string message, string messageDetail)
        {
            Message = message;
            MessageDetail = messageDetail;
        }

        public ValidatorResult(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public string MessageDetail { get; set; }

        public void Merge(ValidatorResult validatorResult)
        {
            Message += Environment.NewLine + validatorResult.Message;
            MessageDetail += Environment.NewLine + validatorResult.MessageDetail;
        }

        public static ValidatorResult Empty
        {
            get { return new ValidatorResult(string.Empty, string.Empty); }
        }
    }
}
