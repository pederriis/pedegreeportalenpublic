using GreenPipes;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PedigreePortalen.Framework;
using System;
using User.Application;
using User.Application.ApplicationServices;
using User.Infrastructure;
using User.Infrastructure.Query;
using User.Infrastructure.Shared;
using User.Microservice.Consumers;

namespace User.Microservice
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
            services.AddDbContext<UserDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GearHostUserdb8DatabaseConnection")));
            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            
            //Applicationsservices
            services.AddScoped<UserApplicationService>();
            services.AddScoped<AnimalApplicationService>();

            //For Queurycontrollers
            services.AddScoped<UserQueries, UserQueries>();
            services.AddScoped<AnimalQueries, AnimalQueries>();

            //MassTransit
            services.AddMassTransit(x =>
            {
                x.AddConsumer<AnimalConsumer.CreateAmimalConsumer>();
                x.AddConsumer<AnimalConsumer.UpdateAnimalConsumer>();
                x.AddConsumer<AnimalConsumer.DeleteAnimalConsumer>();
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.UseHealthCheck(provider);
                    cfg.Host(new Uri("rabbitmq://localhost:5672"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cfg.ReceiveEndpoint("CreateUserAnimalQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<AnimalConsumer.CreateAmimalConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("UpdateUserAnimalQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<AnimalConsumer.UpdateAnimalConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("DeleteUserAnimalQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<AnimalConsumer.DeleteAnimalConsumer>(provider);
                    });
                }));
            });
            services.AddMassTransitHostedService();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "User-Microservice",
                    Version = "v1"
                });
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //c.RoutePrefix = string.Empty;
            });

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
