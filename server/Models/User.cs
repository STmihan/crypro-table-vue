namespace server.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public Role[] Role { get; set; }
    public string Coins { get; set; }
    public string Password { get; set; }
}

public class UserLogin
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public enum Role
{
    User
}