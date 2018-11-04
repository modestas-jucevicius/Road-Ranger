using System.Threading.Tasks;

namespace RoadRangerBackEnd.Recognition
{
    public interface ICarRecognizer
    {
        Task<string> Recognize(string imageBase64);
    }
}
