using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS.OutsideAPI
{
    class EPolicijaAPIRequester
    {
        EPolicijaAPI ePolicijaAPI = EPolicijaAPI.getInstance(); // pasiema EPolicijosAPI objekta

        public async Task<CarStatus> getCarStatus(ParsedCar car) {
            string licensePlate = car.licensePlate;
            try
            {
                return await ePolicijaAPI.IsCarStolen(licensePlate); // tikrina masina vogta ar ne
            }
            catch (LicenceNumberParseException e) //jei negali patikrinti pagal duotus duomenis meta exceptiona
            {
                Console.WriteLine(e);
            }
            return CarStatus.UNKNOWN;
        }
    }
}
