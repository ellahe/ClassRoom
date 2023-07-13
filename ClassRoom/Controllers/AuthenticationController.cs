using System;
using ApplicationService.Authentications;
using ApplicationService.Users;
using InfrastructureImplementation.Authentications;
using InfrastructureImplementation.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClassRoom.Controllers
{
    [ApiController]
    [Route("authentication")]
    public class AuthenticationController : ControllerBase
    {
        public AuthenticationController(IAuthenticationDataProvider authenticationDataProvider, IUserDataProvider userDataProvider)
        {
            _authenticationDataProvider = authenticationDataProvider;
            _userDataProvider = userDataProvider;
        }

        private readonly IAuthenticationDataProvider _authenticationDataProvider;
        private readonly IUserDataProvider _userDataProvider;

        [HttpPost("Add")]
        public IActionResult Add(AuthenticationDTO user)
        {
            ///it is not working yet
            using (SqlConnection con = new SqlConnection("connectionStrings:ClassRoomDB"))
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        using (AuthenticationContext context = new AuthenticationContext(new DbContextOptions<AuthenticationContext>()))
                        {
                            context.Database.UseTransaction(transaction);
                            _authenticationDataProvider.AddUser(user);
                            context.SaveChanges();
                        }

                        using (UserContext context = new UserContext(new DbContextOptions<UserContext>()))
                        {
                            context.Database.UseTransaction(transaction);

                            _userDataProvider.AddUser(user);
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        Console.WriteLine(ex.InnerException);
                    }
                }
            }

            using (var txscope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew))
            {
                try
                {
                    var id = _authenticationDataProvider.AddUser(user);
                    user.AuthenticationID = id;
                    _userDataProvider.AddUser(user);
                    txscope.Complete();
                    return Ok();
                }
                catch (System.Exception ex)
                {
                    // Log error      
                    txscope.Dispose();
                    return Problem(detail: ex.Message, title: ex.Message);
                }
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticationDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(long id)
        {
            var user = _authenticationDataProvider.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

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