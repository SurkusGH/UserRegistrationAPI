using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UserRegistrationAPI.Core;
using UserRegistrationAPI.Core.Configurations;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
                                                   options.UseSqlServer(Configuration.GetConnectionString("sqlConnection"))
                                                   );
            services.AddAuthentication();
            //services.ConfigureIdentity();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthManager, AuthManager>();

            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IImageService, ImageService>();

            //services.AddAutoMapper(typeof(MapperInitialiser));
            services.ConfigureAutoMapper();

            #region (!) Cross-Origin-Resource-Sharing setup
            services.AddCors(options =>
            {  // <- Adding Cross-Origin-Resource-Sharing
                options.AddPolicy("CorsPolicy_AllowAll", builder =>
                    builder.AllowAnyOrigin() // <- defines who can access
                           .AllowAnyMethod() // <- defines what methods are allowed tb executed
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
