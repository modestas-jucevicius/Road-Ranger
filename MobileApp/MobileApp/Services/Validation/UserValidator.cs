using System;

namespace MobileApp.Services.Validation
{
    public class UserValidator
    {
        public bool IsValid(string username, string password)
        {
            return username.Length >= 7 && username.Length <= 24 &&
            password.Length >= 7 && password.Length <= 24;
        }
    }
}
