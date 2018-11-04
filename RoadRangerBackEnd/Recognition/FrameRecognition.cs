using System;
using System.Threading.Tasks;

namespace RoadRangerBackEnd.Recognition
{
    public static class FrameRecognition
    {
        public static Boolean isRunning;
        private static OpenALPRRecognizer recognizer = new OpenALPRRecognizer();

        public static async Task<String> Recognition(Byte[] frame)
        {
            isRunning = true;
            string cars = await recognizer.Recognize(frame);
            System.Threading.Thread.Sleep(2000);
			isRunning = false;
            return cars;
        }
    }
}
