using System;
using Infrastructure.Services;

namespace ApplicationService.DataProviders
{
    public interface IAuthenticationDataProvider
    {
        string GetVerificationCode(string phoneNumber);
        bool VerifyUserTelephone(string verifyCode, string haschCode);
    }

    public class AuthenticationDataProvider : IAuthenticationDataProvider
    {

        public AuthenticationDataProvider(
            ISmsService smsService)
        {
            _smsService = smsService;
        }

        private readonly ISmsService _smsService;

        public string GetVerificationCode(string phoneNumber)
        {
            var code = HashCode.Hash(new Random(5).Next().ToString());
            _smsService.SendSms(phoneNumber, code);
            return code;
        }

        public bool VerifyUserTelephone(string verifyCode, string hashCode)
        {
            return HashCode.Hash(verifyCode).Equals(hashCode);
        }

        internal class HashCode
        {
            public static string Hash(string value)
            {
                ///make hash
                return value;
            }

            public static bool Equal(string value, string hashCode)
            {
                return value.Equals(hashCode);
            }
        }
    }
}
