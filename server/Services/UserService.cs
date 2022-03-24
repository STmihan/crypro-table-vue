using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Repositories;

namespace server.Services;

public class UserService : IUserService
{
    public User Get(UserLogin userLogin)
    {
        return UserRepository.Users
            .FirstOrDefault(user => 
                user.Username.Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase) 
                && user.Password == userLogin.Password) ?? throw new ArgumentException();
    }

    public string UpdateUserCoins(string userName, string coins)
    {
        User? firstOrDefault = UserRepository.Users.FirstOrDefault(user => user.Username == userName);
        if (firstOrDefault == null) throw new ArgumentException();
        firstOrDefault.Coins = coins;
        return firstOrDefault.Coins;
    }
    
    
    public User GetByUsername(string userName)
    {
        return UserRepository.Users.FirstOrDefault(user => user?.Username == userName) ?? throw new ArgumentException();
    }
}