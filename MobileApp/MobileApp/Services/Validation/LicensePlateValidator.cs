using System.Text.RegularExpressions;

namespace MobileApp.Services.Validation
{
    public class LicensePlateValidator : ITextValidator
    {
        public bool IsValid(string plate)
        {
            Regex regex = new Regex(@"^[A-Z]{2,3}\d{3}$");
            Match match = regex.Match(plate);
            return match.Success;
        }
    }
}
