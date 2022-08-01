using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Server
{
	public class Startup : object
	{
		public Startup() : base()
		{
		}

		public Startup
			(Microsoft.Extensions.Configuration.IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

		public void ConfigureServices
			(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
		{
			//services.AddControllers();

			//using FluentValidation.AspNetCore;
			services.AddControllers()
				.AddFluentValidation(current =>
				{
					current.RegisterValidatorsFromAssemblyContaining<Startup>();

					current.LocalizationEnabled = true; // Default: [true]
					current.AutomaticValidationEnabled = true; // Default: [true]
					current.ImplicitlyValidateChildProperties = false; // Default: [false]
					current.ImplicitlyValidateRootCollectionElements = false; // Default: [false]
					current.RunDefaultMvcValidationAfterFluentValidationExecutes = false; // Default: [true]
				});
		}

		public void Configure
			(Microsoft.AspNetCore.Builder.IApplicationBuilder app,
			Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
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
