using HMS.Abstraction;
using HMS.Data.Models;

namespace HMS.Services
{
    public class UsersService : IUsersService
    {
        private readonly HmsContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public UsersService(HmsContext context,IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;   
        }

        public User? GetUser(string emailOrUsername, string password)
        {
            return _context
                .Users
                .FirstOrDefault(x => x.UserName == emailOrUsername && x.PasswordHash == password);
        }

        public void Register(User user)
        {
            // Check if email already exists
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);

            if (existingUser != null)
            {
                throw new Exception("A user with this email address already exists.");
            }

            user.UserId = Guid.NewGuid();
            user.Salt = Guid.NewGuid();
             _passwordHasher.ComputeHash(user.PasswordHash, user.Salt.ToString());
            _context.Users.Add(user);
            _context.SaveChanges();
        }

    }
}