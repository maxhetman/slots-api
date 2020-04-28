using Application.Services;
using AutoMapper;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using Application;

namespace Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var connectionString = CreateConnectionString();

			services.AddEntityFrameworkSqlite().AddDbContext<SlotsContext>(o => o.UseSqlite(connectionString));
			services.AddAutoMapper(typeof(ApplicationAssemblyMarker));
			services.AddScoped<ISlotsService, SlotsService>();
			services.AddScoped<ISlotsRepository, SlotsRepository>();
			services.AddControllers();
		}

		private string CreateConnectionString()
		{
			var dbLocation = Path.Combine(ApplicationEnvironment.ApplicationBasePath, "database.db");
			var stringBuilder = new SqliteConnectionStringBuilder { DataSource = dbLocation };
			return stringBuilder.ConnectionString;
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
