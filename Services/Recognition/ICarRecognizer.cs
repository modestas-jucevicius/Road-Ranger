using System.Threading.Tasks;

namespace Services.Recognition
{
    public interface ICarRecognizer
    {
        Task<string> Recognize(string imageBase64);
    }
}
