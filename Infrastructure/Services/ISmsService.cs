namespace Infrastructure.Services
{
    public interface ISmsService
    {
        void SendSms(string phoneNumber , string code);
    }

    public class SmsService : ISmsService
    {
        public void SendSms(string phoneNumber, string code)
        {

        }
    }

}
