using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthRecord.Application;
using HealthRecord.Infrastructure;
using HealthRecord.Infrastructure.AnimalQuery;
using HealthRecord.Infrastructure.DiseaseQuery;
using HealthRecord.Infrastructure.HealthCertificateQuery;
using HealthRecord.Infrastructure.HealthRecordQuery;
using HealthRecord.Infrastructure.Shared;
using HealthRecord.Infrastructure.VaccinationQuery;
using HealthRecord.Microservice.Consumers;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PedigreePortalen.Framework;
using GreenPipes;

namespace HealthRecord.Microservice
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
            services.AddDbContext<HealthRecordDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GearHostHealthRecorddbDatabaseConnection")));
            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();

            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IDiseaseRepository, DiseaseRepository>();
            services.AddScoped<IHealthCertificateRepository, HealthCertificateRepository>();
            services.AddScoped<IHealthRecordRepository, HealthRecordRepository>();
            services.AddScoped<IVaccinationRepository, VaccinationRepository>();

            //Query-Controllerne
            services.AddScoped<AnimalQueries, AnimalQueries>();
            services.AddScoped<DiseaseQueries, DiseaseQueries>();
            services.AddScoped<HealthCertificateQueries, HealthCertificateQueries>();
            services.AddScoped<HealthRecordQueries, HealthRecordQueries>();            
            services.AddScoped<VaccinationQueries, VaccinationQueries>();

            //Command-Controllere
            services.AddScoped<AnimalApplicationService, AnimalApplicationService>();
            services.AddScoped<DiseaseApplicationService, DiseaseApplicationService>();
            services.AddScoped<HealthCertificateAppllicationService, HealthCertificateAppllicationService>();
            services.AddScoped<HealthRecordApplicationService, HealthRecordApplicationService>();
            services.AddScoped<VaccinationApplicationService, VaccinationApplicationService>();

            //MassTransit
            services.AddMassTransit(x =>
            {
                x.AddConsumer<AnimalConsumer.AmimalCreateConsumer>();
                x.AddConsumer<AnimalConsumer.AmimalUpdateConsumer>();
                x.AddConsumer<AnimalConsumer.AmimalDeleteConsumer>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.UseHealthCheck(provider);
                    cfg.Host(new Uri("rabbitmq://localhost:5672"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cfg.ReceiveEndpoint("HealthRecordCreateAnimalQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<AnimalConsumer.AmimalCreateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("HealthRecordUpdateAnimalQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<AnimalConsumer.AmimalUpdateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("HealthRecordDeleteAnimalQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<AnimalConsumer.AmimalDeleteConsumer>(provider);
                    });
                }));
            });
            services.AddMassTransitHostedService();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "HealthRecord-Halløj",
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
