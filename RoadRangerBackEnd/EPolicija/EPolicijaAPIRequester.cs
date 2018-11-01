using RoadRangerBackEnd.Cars;
using System;
using System.Threading.Tasks;

namespace RoadRangerBackEnd.OutsideAPI
{
    public class EPolicijaAPIRequester : ICarStatusRequester
    {
        private static EPolicijaAPIRequester instance; 

        public static EPolicijaAPIRequester GetInstance() // jei jau yra toks objektas ji grazina, jei ne sukuria
        {
            if (instance != null)
            {
                return instance;
            }
            else
            {
                instance = new EPolicijaAPIRequester();
                return instance;
            }
        }

        private EPolicijaAPIRequester() { }

        private EPolicijaAPI ePolicijaAPI = EPolicijaAPI.getInstance(); // pasiema EPolicijosAPI objekta

        public async Task<CarStatus> AskCarStatus(string licensePlate)
        {
            try
            {
                return await ePolicijaAPI.AskCarStatus(licensePlate);// tikrina masina vogta ar ne
            }
            catch (LicenceNumberParseException e) //jei negali patikrinti pagal duotus duomenis meta exceptiona
            {
                Console.WriteLine(e);
                return CarStatus.UNKNOWN;
            }
        }
    }
}
