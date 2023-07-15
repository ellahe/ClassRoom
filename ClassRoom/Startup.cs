using System.Linq;
using ApplicationService.Common;
using ApplicationService.DataProviders;
using ApplicationService.DTOS;
using AutoMapper;
using Domain.Domains;
using Infrastructure.Repositories;
using Infrastructure.Services;
using InfrastructureImplementation.Clerk;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ClassRoom
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
                options.AddPolicy("AllowAngularOrigins",
                builder =>
                {
                    builder.WithOrigins(
                                        "http://localhost:4200"
                                        )
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });

            // UseCors

           

            ConfigureContext(services);
            AddScope(services);

            // Auto Mapper Configurations

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClassRoomDB", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        private static void AddScope(IServiceCollection services)
        {
            services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<IRepository<ClerkEntity>, ClerkRepository>();
            services.AddScoped<IAuthenticationDataProvider, AuthenticationDataProvider>();
            services.AddScoped<IClerkDataProvider, ClerkDataProvider>();
            services.AddControllers();
        }

        private void ConfigureContext(IServiceCollection services)
        {
            services.AddDbContext<ClerkContext>(o =>
            {
                o.UseSqlServer(Configuration["connectionStrings:ClassRoomDB"]);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAngularOrigins");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClassRoom v1"));
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

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Entity, ClientDTO>();
            this.CreateMap<ClerkEntity, ClerkDTO>().ReverseMap();
        }
    }

}
