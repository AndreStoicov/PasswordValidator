using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Threading;
using FluentValidation;
using FluentValidation.AspNetCore;
using PasswordValidatorAPI.Filters;
using PasswordValidatorAPI.Models;
using PasswordValidatorAPI.Validators;

namespace PasswordValidatorAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private const string Title = "Password Validator API: Release 1.0.0";

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddJsonFormatters();
            services.AddMvcCore().AddApiExplorer();

            services.AddMvcCore(options =>
            {
                options.Filters.Add(new ResultValidationFilter());
            }).AddFluentValidation();

            services.AddTransient<IValidator<RequestPassword>, PasswordValidator>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = Title,
                    Version = "v1"
                });
                c.DescribeAllEnumsAsStrings();
                c.EnableAnnotations();
                
 
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => { c.SwaggerEndpoint("../swagger/v1/swagger.json", Title); });
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("../swagger/v1/swagger.json", Title); });
                 
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "{controller}/{id}",
                    defaults: "{id?}");
            });

            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        }
    }
}