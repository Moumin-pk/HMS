namespace HMS.Abstraction
{
    public interface IPasswordHasher
    {
       public string ComputeHash(string password, string salt);
    }
}
