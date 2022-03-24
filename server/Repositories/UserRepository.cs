using server.Models;

namespace server.Repositories;

public class UserRepository
{
    public static List<User> Users = new()
    {
        new User {Username = "STmihanAdmin", Password = "admin", Role = new [] {Role.User}, Coins = "ETH,BTC"},
        new User {Username = "STmihan", Password = "admin", Role = new [] {Role.User}, Coins = "BTC"}
    };
}