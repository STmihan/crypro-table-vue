using server.Models;

namespace server.Services;

public interface IUserService
{
    User? Get(UserLogin userLogin);
    string UpdateUserCoins(string userName, string coins);
    User GetByUsername(string userName);
}