using HMS.Abstraction;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

namespace HMS.Services
{
    public class PasswordHasherService : IPasswordHasher
    {

        public string ComputeHash( string password , string salt )
        {
            using var sha512 = SHA512.Create();

            var passwordSalt = $"{password}{salt}";

            var byteValue = Encoding.UTF8.GetBytes(passwordSalt);

            var byteHash = sha512.ComputeHash(byteValue);

            var hash = Convert.ToBase64String(byteHash);

            return hash;
        }

      
   }
}
