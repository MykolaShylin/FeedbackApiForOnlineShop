using Review.Domain.Models;

namespace Review.Domain.Interfaces
{
    public interface ILoginService
    {
        /// <summary>
        /// Проверить логин и пароль
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns></returns>
        bool CheckLogin(Login login);
    }
}
