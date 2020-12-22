using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
                options.AddPolicy("Code",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().WithMethods("POST"));
                options.AddPolicy("Forget",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().WithMethods("POST"));
                options.AddPolicy("Login",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().WithMethods("POST"));
                options.AddPolicy("Resend",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().WithMethods("POST"));
                options.AddPolicy("Signup",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().WithMethods("POST"));
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
