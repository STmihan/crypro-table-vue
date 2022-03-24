namespace server.Models;

public class User
{
    public string Username { get; set; }
    public List<Coin> Coins { get; set; }
    public string Password { get; set; }
}

public class UserLogin
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class Coin
{
    public string Name { get; set; }
    public bool isFavorite { get; set; }
}