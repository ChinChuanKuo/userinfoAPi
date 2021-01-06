using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using userinfoApi.App_Code;

namespace userinfoApi
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
            string[] items = new string[] { };
            items = new corsorigins().connectionString();
            services.AddCors(options =>
            {
                options.AddPolicy("Code",
                    builder => builder.WithOrigins(items[0], items[1], items[2], items[3], items[4]).AllowAnyHeader().WithMethods("POST"));
                options.AddPolicy("Forget",
                    builder => builder.WithOrigins(items[0], items[1], items[2], items[3], items[4]).AllowAnyHeader().WithMethods("POST"));
                options.AddPolicy("Login",
                    builder => builder.WithOrigins(items[0], items[1], items[2], items[3], items[4]).AllowAnyHeader().WithMethods("POST"));
                options.AddPolicy("Resend",
                    builder => builder.WithOrigins(items[0], items[1], items[2], items[3], items[4]).AllowAnyHeader().WithMethods("POST"));
                options.AddPolicy("Signup",
                    builder => builder.WithOrigins(items[0], items[1], items[2], items[3], items[4]).AllowAnyHeader().WithMethods("POST"));
                options.AddPolicy("Form",
                    builder => builder.WithOrigins(items[0], items[1], items[2], items[3], items[4]).AllowAnyHeader().WithMethods("POST"));
                options.AddPolicy("Icon",
                    builder => builder.WithOrigins(items[0], items[1], items[2], items[3], items[4]).AllowAnyHeader().WithMethods("POST"));
            });
            services.AddControllers();
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

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
