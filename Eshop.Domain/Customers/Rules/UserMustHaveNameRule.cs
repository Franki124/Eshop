using Eshop.Domain.SeedWork;
using System.Text.RegularExpressions;

public class UserMustHaveNameRule : IBusinessRule
{
    private readonly string _userName;

    public UserMustHaveNameRule(string userName)
    {
        _userName = userName;
    }

    public bool IsBroken() => string.IsNullOrWhiteSpace(_userName) || !Regex.IsMatch(_userName, "^[A-Za-z]+$");

    public string Message => "User name must not be empty and contain only letters.";
}
