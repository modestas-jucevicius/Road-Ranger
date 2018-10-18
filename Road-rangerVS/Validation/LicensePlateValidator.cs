using Road_rangerVS.OutsideAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Road_rangerVS.Validation
{
    class LicensePlateValidator : TextValidator
    {
        public bool isValid(string plate)
        {
            Regex regex = new Regex(@"^[A-Z]{2,3}\d{3}$");
            Match match = regex.Match(plate);
            return match.Success;
        }
    }
}
