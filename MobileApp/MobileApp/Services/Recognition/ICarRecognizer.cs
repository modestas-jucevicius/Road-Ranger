using System.Threading.Tasks;

namespace MobileApp.Services.Recognition
{
    public interface ICarRecognizer
    {
        Task<string> Recognize(string imageBase64);
    }
}
