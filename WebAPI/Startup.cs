using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Interfaces;
using WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using WebAPI.Repository.Models;

namespace WebAPI
{
	public class Startup
	{
		private readonly byte[] secret = Encoding.ASCII.GetBytes("6686639a69fa018ce8419e97f1235eb6");

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
            services.AddEntityFrameworkNpgsql();
            services.AddDbContext<UserContext>();
            services.BuildServiceProvider();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(secret),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});

			services.AddSingleton<IAuthorizationService, AuthorizationService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			//app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseMvc();
		}
	}
}
