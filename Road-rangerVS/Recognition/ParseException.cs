using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Road_rangerVS.Recognition
{
	class ParseException : System.Exception
	{
		public ParseException() : base() { }
		public ParseException(string message) : base(message) { }
		public ParseException(JToken message) : base(JsonConvert.SerializeObject(message)) { }
	}
}
