using Review.Domain.Interfaces;
using Review.Domain.Models;

namespace Review.Domain.Helper
{
    public static class Initialization
    {        
        public static Login[] SetLogins()
        {
            var logins = new List<Login>();
            var login = new Login()
            {  
                Id = 1,
                UserName = "admin", 
                Password = "admin" 
            };
            logins.Add(login);
            return logins.ToArray();
        }
    }
}
