using Kennel.Application;
using Kennel.Application.ApplicationServices;
using Kennel.Infrastructure;
using Kennel.Infrastructure.Query;
using Kennel.Infrastructure.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using MassTransit;
using GreenPipes;
using Kennel.Microservice.Consumers;

namespace Kennel.Microservice
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
            services.AddDbContext<KennelDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("KennelDatabaseConnection")));

            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();
            services.AddScoped<IKennelRepository, KennelRepository>();

            // Queries
            services.AddScoped<AnimalQuerys>();
            services.AddScoped<KennelQuerys>();
            services.AddScoped<LitterQuerys>();
            services.AddScoped<OwnerQuerys>();
            services.AddScoped<ProtokolQuerys>();
            services.AddScoped<HealthRecordQuerys>();
            services.AddScoped<HealthCertificateQuerys>();
            services.AddScoped<DiseaseQuerys>();
            services.AddScoped<VaccinationQuerys>();
            services.AddScoped<ParrentQuerys>();
            services.AddScoped<ChildQuerys>();

            // Command
            services.AddScoped<AnimalApplicationService>();
            services.AddScoped<KennelApplicationService>();
            services.AddScoped<ParrentApplicationService>();
            services.AddScoped<ChildApplicationService>();
            services.AddScoped<LitterApplicationService>();
            services.AddScoped<OwnerApplicationService>();
            services.AddScoped<ProtokolApplicationService>();
            services.AddScoped<HealthRecordApplicationService>();
            services.AddScoped<HealthCertificateApplicationService>();
            services.AddScoped<DiseaseApplicationService>();
            services.AddScoped<VaccinationApplicationService>();

            //MassTransit
            services.AddMassTransit(x =>
            {
                //Animal
                x.AddConsumer<AnimalConsumer.AmimalCreateConsumer>();
                x.AddConsumer<AnimalConsumer.AmimalUpdateConsumer>();
                x.AddConsumer<AnimalConsumer.AmimalDeleteConsumer>();

                //Litter
                x.AddConsumer<LitterConsumer.CreateLitterConsumer>();
                x.AddConsumer<LitterConsumer.UpdateLitterConsumer>();
                x.AddConsumer<LitterConsumer.DeleteLitterConsumer>();

                //Parrents
                //x.AddConsumer<ParrentConsumer.CreateParrentConsumer>();
                //x.AddConsumer<ParrentConsumer.DeleteParrentConsumer>();
                //x.AddConsumer<ParrentConsumer.AddParrentToLitterConsumer>();

                

                //HealthRecord
                x.AddConsumer<HealthRecordConsumer.CreateHealthRecordConsumer>();

                //Vaccination
                x.AddConsumer<VaccinationConsumer.CreateVaccinationConsumer>();
                x.AddConsumer<VaccinationConsumer.UpdateVaccinationConsumer>();
                x.AddConsumer<VaccinationConsumer.DeleteVaccinationConsumer>();


                //healthcertificate
                x.AddConsumer<HealthCertificateConsumer.HealthCertificateCreateConsumer>();
                x.AddConsumer<HealthCertificateConsumer.HealthCertificateUpdateConsumer>();
                x.AddConsumer<HealthCertificateConsumer.HealthCertificateDeleteConsumer>();

                //disease
                x.AddConsumer<DiseaseConsumer.DiseaseCreateConsumer>();
                x.AddConsumer<DiseaseConsumer.DiseaseUpdateConsumer>();
                x.AddConsumer<DiseaseConsumer.DiseaseDeleteConsumer>();

                //Owner
                x.AddConsumer<OwnerConsumer.OwnerCreateConsumer>();
                x.AddConsumer<OwnerConsumer.OwnerUpdateConsumer>();
                x.AddConsumer<OwnerConsumer.OwnerDeleteConsumer>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.UseHealthCheck(provider);
                    cfg.Host(new Uri("rabbitmq://localhost:5672"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    //Animal
                    cfg.ReceiveEndpoint("CreateKennelAnimalQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<AnimalConsumer.AmimalCreateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("UpdateKennelAnimalQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<AnimalConsumer.AmimalUpdateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("DeleteKennelAnimalQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<AnimalConsumer.AmimalDeleteConsumer>(provider);
                    });

                    //Litter
                    cfg.ReceiveEndpoint("CreateKennelLitterQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<LitterConsumer.CreateLitterConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("UpdateKennelLitterQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<LitterConsumer.UpdateLitterConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("DeleteKennelLitterQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<LitterConsumer.DeleteLitterConsumer>(provider);
                    });

                    //Parrent
                    //cfg.ReceiveEndpoint("CreateKennelParrentQueue", ep =>
                    //{
                    //    ep.PrefetchCount = 16;
                    //    ep.UseMessageRetry(r => r.Interval(2, 100));
                    //    ep.ConfigureConsumer<ParrentConsumer.CreateParrentConsumer>(provider);
                    //});
                    //cfg.ReceiveEndpoint("DeleteKennelParrentQueue", ep =>
                    //{
                    //    ep.PrefetchCount = 16;
                    //    ep.UseMessageRetry(r => r.Interval(2, 100));
                    //    ep.ConfigureConsumer<ParrentConsumer.DeleteParrentConsumer>(provider);
                    //});
                    //cfg.ReceiveEndpoint("AddKennelParrentToLitterQueue", ep =>
                    //{
                    //    ep.PrefetchCount = 16;
                    //    ep.UseMessageRetry(r => r.Interval(2, 100));
                    //    ep.ConfigureConsumer<ParrentConsumer.AddParrentToLitterConsumer>(provider);
                    //});

                    //HealthRecord
                    cfg.ReceiveEndpoint("CreateKennelHealthRecordQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<HealthRecordConsumer.CreateHealthRecordConsumer>(provider);
                    });

                    // Vaccination
                    cfg.ReceiveEndpoint("CreateKennelVaccinationQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<VaccinationConsumer.CreateVaccinationConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("UpdateKennelVaccinationQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<VaccinationConsumer.UpdateVaccinationConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("DeleteKennelVaccinationQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<VaccinationConsumer.DeleteVaccinationConsumer>(provider);
                    });

                    //HealthCertificate-consumers
                    cfg.ReceiveEndpoint("CreateKennelHealthCertificateQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<HealthCertificateConsumer.HealthCertificateCreateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("UpdateKennelHealthCertificateQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<HealthCertificateConsumer.HealthCertificateUpdateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("DeleteKennelHealthCertificateQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<HealthCertificateConsumer.HealthCertificateDeleteConsumer>(provider);
                    });

                    //Disease-consumers
                    cfg.ReceiveEndpoint("CreateKennelDiseaseQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<DiseaseConsumer.DiseaseCreateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("UpdateKennelDiseaseQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<DiseaseConsumer.DiseaseUpdateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("DeleteKennelDiseaseQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<DiseaseConsumer.DiseaseDeleteConsumer>(provider);
                    });

                    //Owner-consumers
                    cfg.ReceiveEndpoint("CreateKennelOwnerQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<OwnerConsumer.OwnerCreateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("UpdateKennelOwnerQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<OwnerConsumer.OwnerUpdateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("DeleteKennelOwnerQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<OwnerConsumer.OwnerDeleteConsumer>(provider);
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
                    Title = "Kennel",
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
