using System.Linq;
using ApplicationService.Authentications;
using ApplicationService.Common;
using ApplicationService.DataProviders;
using ApplicationService.DTOS;
using ApplicationService.Users;
using AutoMapper;
using Domain.Domains;
using Infrastructure.Repositories;
using Infrastructure.Services;
using InfrastructureImplementation.Authentications;
using InfrastructureImplementation.Clerk;
using InfrastructureImplementation.ReaderRepositories;
using InfrastructureImplementation.users;
using InfrastructureImplementation.Users;
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
            services.AddScoped<ICrudRepository<AuthenticationEntity>, AuthenticationRepository>();
            services.AddScoped<ICrudRepository<UserEntity>, UserRepository>();
            services.AddScoped<IRepository<ClerkEntity>, ClerkRepository>();
            services.AddScoped<IReaderRepository<UserMinimal>, UserMinimalRepository>();
            services.AddScoped<IReaderRepository<UserMinimal>, UserMinimalRepository>();
            services.AddScoped<AssemblerBase<AuthenticationDTO, AuthenticationEntity>, AuthenticationAssembler>();
            services.AddScoped<AssemblerBase<AuthenticationDTO, UserEntity>, UserAssembler>();
            services.AddScoped<IAuthenticationDataProvider, AuthenticationDataProvider>();
            services.AddScoped<IUserDataProvider, UserDataProvider>();
            services.AddScoped<IClerkDataProvider, ClerkDataProvider>();
            services.AddControllers();
        }

        private void ConfigureContext(IServiceCollection services)
        {
            services.AddDbContext<UserContext>(o =>
            {
                o.UseSqlServer(Configuration["connectionStrings:ClassRoomDB"]);
            });
            services.AddDbContext<AuthenticationContext>(o =>
            {
                o.UseSqlServer(Configuration["connectionStrings:ClassRoomDB"]);
            });
            services.AddDbContext<ClerkContext>(o =>
            {
                o.UseSqlServer(Configuration["connectionStrings:ClassRoomDB"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
