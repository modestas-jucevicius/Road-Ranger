
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Road_rangerVS.Recognition
{
	public class ParseException : System.Exception
	{
		public ParseException() : base() { }
		public ParseException(string message) : base(message) { }
		public ParseException(JToken message) : base(JsonConvert.SerializeObject(message)) { }
	}
}
