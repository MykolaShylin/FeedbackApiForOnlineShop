using Review.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Review.Domain.Interfaces;

namespace Review.Domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly DataBaseContext databaseContext;

        public LoginService(DataBaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public bool CheckLogin(Login login)
        {
            var existingLogin = databaseContext.Logins;
            foreach (var item in existingLogin)
            {
                if(item.UserName.Equals(login.UserName) && item.Password.Equals(login.Password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
