namespace HMS.Abstraction
{
    public interface IContextService
    {
        bool IsUserLoggedIn();
        string GetUserId();
        string GetUserName();
    }
}
