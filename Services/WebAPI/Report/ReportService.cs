using Models.Cars;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Services.WebAPI.Report
{
    public class ReportService : BaseService
    {
        private static ReportService instance;

        private ReportService() : base()
        {
        }

        public static ReportService GetInstance()
        {
            if (instance == null)
            {
                return instance = new ReportService();
            }
            else
            {
                return instance;
            }
        }

        public async Task ReportCar(CapturedCar car)
        {
            HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/report/car", new
            {
                Id = car.Id,
                UserId = car.UserId,
                LicensePlate = car.LicensePlate,
                ColorName = car.ColorName,
                MakeName = car.MakeName,
                Model = car.Model,
                BodyType = car.BodyType,
                Year = car.Year,
                IsReported = car.IsReported,
                Status = car.Status//,
                //Image = car.Image
            });
            response.EnsureSuccessStatusCode();
        }

        public async Task ReportMessage(MailMessage message)
        {
            HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/report/message", new
            {
                Subject = message.Subject,
                Body = message.Body
            });
            response.EnsureSuccessStatusCode();
        }
    }
}
