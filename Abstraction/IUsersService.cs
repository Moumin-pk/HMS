using HMS.Data.Models;

namespace HMS.Abstraction
{
    public interface IUsersService
    {
        void Register(User user);
        User? GetUser(string emailOrUsername, string password);
    }
}
