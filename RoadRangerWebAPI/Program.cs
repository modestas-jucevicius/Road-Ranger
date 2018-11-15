using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace RoadRangerWebAPI
{
	public class Program
	{
		private static IWebHost host;
		public static void Main(string[] args)
		{
			host = CreateWebHost(args);
			host.Run();
		}

		public static IWebHost CreateWebHost(string[] args) {
			return new WebHostBuilder()
			.UseKestrel()
			.UseUrls("http://*:5000")
			.UseContentRoot(Directory.GetCurrentDirectory())
			.UseIISIntegration()
			.UseStartup<Startup>()
			.Build();
		}
	}
}
