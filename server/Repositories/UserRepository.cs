using server.Models;

namespace server.Repositories;

public class UserRepository
{
    public static List<User> Users = new()
    {
        new User {Username = "STmihanAdmin", Password = "admin", Coins = new List<Coin> {new() {Name = "BTC"}}},
        new User {Username = "STmihan", Password = "admin", Coins = new List<Coin> {new() {Name = "BTC"}, new() {Name = "ETH"}}}
    };
}