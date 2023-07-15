using ApplicationService.DataProviders;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoom.Controllers
{
    [ApiController]
    [Route("authentication")]
    public class AuthenticationController : ControllerBase
    {
        public AuthenticationController(IAuthenticationDataProvider authenticationDataProvider)
        {
            _authenticationDataProvider = authenticationDataProvider;
        }

        private readonly IAuthenticationDataProvider _authenticationDataProvider;

        [HttpPost("GetVerifyCode")]
        public string GetVerifyCode([FromBody] string phoneNumber)
        {
            return _authenticationDataProvider.GetVerificationCode(phoneNumber);
        }

        [HttpPost("VerifyCode")]
        public bool VerifyCode([FromBody] (string code, string hashCode) value)
        {
            return _authenticationDataProvider.VerifyUserTelephone(value.code, value.hashCode);
        }

    }
}