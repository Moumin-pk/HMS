namespace HMS.Data.ViewModels;

public class LoginVM
{
    public string EmailOrUserName { get; set; } = string.Empty;
    public string PassWord { get; set; } = string.Empty;
    public bool KeepLoggedIn { get; set; } 
}