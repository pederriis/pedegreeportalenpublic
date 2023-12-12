using Animal.Application;
using Animal.Application.ApplicationServices;
using Animal.Infrastructure;
using Animal.Infrastructure.Query;
using Animal.Infrastructure.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PedigreePortalen.Framework;
using MassTransit;
using System;
using GreenPipes;
using Animal.Microservice.Consumers;

namespace Animal.Microservice
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
            services.AddDbContext<AnimalDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GearHostAnimalDatabaseConnection")));

            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            

            // Queries
            services.AddScoped<AnimalQuerys>();
            services.AddScoped<ParentingQuerys>();
            services.AddScoped<ExhibitionTitleQuerys>();
            services.AddScoped<HealthRecordQuerys>();
            services.AddScoped<HumanQuerys>();
            services.AddScoped<LitterQuerys>();
            services.AddScoped<RaceQuerys>();
            services.AddScoped<SubRaceQuerys>();

            // Command
            services.AddScoped<AnimalApplicationService>();
            services.AddScoped<ParentingApplicationService>();
            services.AddScoped<ExhibitionTitleApplicationService>();
            services.AddScoped<HealthRecordApplicationService>();
            services.AddScoped<HumanApplicationService>();
            services.AddScoped<LitterApplicationService>();
            services.AddScoped<RaceApplicationService>();
            services.AddScoped<SubRaceApplicationService>();

            // RabbitMQ
            services.AddMassTransit(x =>
            {
                x.AddConsumer<UserConsumer.CreateUserConsumer>();
                x.AddConsumer<UserConsumer.DeleteUserConsumer>();
                x.AddConsumer<HealthRecordConsumer.HealthRecordCreateConsumer>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.UseHealthCheck(provider);
                    cfg.Host(new Uri("rabbitmq://localhost:5672"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cfg.ReceiveEndpoint("AnimalCreateHealthRecordQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<HealthRecordConsumer.HealthRecordCreateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("CreateAnimalUserQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<UserConsumer.CreateUserConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("DeleteAnimalUserQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<UserConsumer.DeleteUserConsumer>(provider);
                    });
                }));
            });

            services.AddMassTransitHostedService();
            services.AddControllers();

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Animal",
                    Version = "v1"
                });
            });
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
