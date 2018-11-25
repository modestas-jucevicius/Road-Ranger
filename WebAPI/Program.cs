using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebAPI
{
	public class Program
	{
		private static IWebHost host;
		public static void Main(string[] args)
		{
			host = CreateWebHost(args);
			host.Run();
		}

		public static IWebHost CreateWebHost(string[] args)
        {
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
