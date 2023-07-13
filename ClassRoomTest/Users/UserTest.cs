using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomTest.Users
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        [ExpectedException(typeof(ErrorHappenedException))]
        public void CalidatePassword()
        {
            var user = new AuthenticationEntity();
            user.PassWord = "123";
        }
    }
}
