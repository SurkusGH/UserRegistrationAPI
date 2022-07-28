using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UserRegistrationAPI.Core;
using UserRegistrationAPI.Core.Repositories.IRepository;
using UserRegistrationAPI.Core.Repositories.Repository;
using UserRegistrationAPI.Core.Services;
using UserRegistrationAPI.Data;

namespace UserRegistrationAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
                                                   options.UseSqlServer(Configuration.GetConnectionString("sqlConnection"))
                                                   );
            services.AddAuthentication();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthManager, AuthManager>();

            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IImageService, ImageService>();

            services.ConfigureAutoMapper();

            #region (!) Cross-Origin-Resource-Sharing setup
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy_AllowAll", builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            });
            #endregion

            services.ConfigureIdentity();
            services.ConfigureJWT(Configuration);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserRegistrationAPI", Version = "v1" });
            });

            services.ConfigureSwaggerDoc();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserRegistrationAPI v1"));
            }

            app.UseCors("CorsPolicy_AllowAll");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
