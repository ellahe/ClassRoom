namespace Infrastructure.Services
{
    public class ValidatorResult
    {
        public ValidatorResult(bool valid, string message, string messageDetail)
        {
            Valid = valid;
            Message = message;
            MessageDetail = messageDetail;
        }

        public ValidatorResult(bool valid, string message)
        {
            Valid = valid;
            Message = message;
        }

        public bool Valid { get; set; }
        public string Message { get; set; }
        public string MessageDetail { get; set; }

        public static ValidatorResult Empty
        {
            get { return new ValidatorResult(false, string.Empty, string.Empty); }
        }
    }
}
