using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Mink.Data;
using Mink.Domain.Interfaces;
using Mink.Services;
using Mink.Services.Contracts.Interfaces;

namespace Mink.Api
{
    public class Startup
    {
        private readonly string _devAllowSpecificOrigins = "_devAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var httpClientTimeout = Configuration.GetValue<double>("HttpClientTimeout");

            services.AddDbContext<MinkDbContext>(options => options.UseSqlite(connectionString));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUriService, UriService>();

            services.AddCors(options =>
            {
                options.AddPolicy(_devAllowSpecificOrigins, builder =>
                {
                    builder
                        .WithOrigins("http://localhost:3000/", "http://localhost:5000/")
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                        // .AllowCredentials();
                });
                // options.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:3000/").AllowAnyHeader());
            });

            services.AddHttpClient<IUriService, UriService>(nameof(IUriService), client =>
            {
                client.Timeout = TimeSpan.FromSeconds(httpClientTimeout);
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mink.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mink.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(_devAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}