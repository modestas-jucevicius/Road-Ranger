using Road_rangerVS.OutsideAPI;
using System.Text.RegularExpressions;

namespace Road_rangerVS.Validation
{
    class LicensePlateValidator : ITextValidator
    {
        public bool IsValid(string plate)
        {
            Regex regex = new Regex(@"^[A-Z]{2,3}\d{3}$");
            Match match = regex.Match(plate);
            return match.Success;
        }
    }
}
