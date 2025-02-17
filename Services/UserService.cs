using EventEaseApp.Models;

namespace EventEaseApp.Services;
public class UserService
{
    private List<User> users = new List<User>
    {
        new User { UserName = "admin", Email = "admin@example.com", Password = "admin123" },
        new User { UserName = "user", Email = "user@example.com", Password = "user123" }
    };

    public Task<bool> RegisterUserAsync(User newUser)
    {
        if (users.Exists(u => u.UserName == newUser.UserName || u.Email == newUser.Email))
        {
            return Task.FromResult(false); // User already exists
        }

        users.Add(newUser);
        return Task.FromResult(true);
    }

    public Task<User> GetUserAsync(string userName)
    {
        var user = users.Find(u => u.UserName == userName);
        return Task.FromResult(user);
    }
}