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
using Microsoft.EntityFrameworkCore;
using MatingCalculator.Infrastructure.Shared;
using PedigreePortalen.Framework;
using MatingCalculator.Infrastructure.Query;
using Microsoft.OpenApi.Models;
using MatingCalculator.Application.Intefaces;
using MatingCalculator.Application.ApplicationServices;
using MatingCalculator.Infrastructure.Repositories;
using MatingCalculator.Application.Interfaces;
using GreenPipes;
using MassTransit;
using MatingCalculator.Microservice.Consumers;

namespace MatingCalculator.Microservice
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

            services.AddDbContext<MatingCalculatorDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GearHostMatingCalculaterDatabaseConnection")));
            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();

            //Query-controllers
            services.AddScoped<DogQueries, DogQueries>();
            services.AddScoped<DiseaseQueries, DiseaseQueries>();
            services.AddScoped<LitterQueries, LitterQueries>();
            services.AddScoped<MatingRulesQueries, MatingRulesQueries>();
            services.AddScoped<UserinformationQueries, UserinformationQueries>();
            services.AddScoped<ContractQueries, ContractQueries>();
            services.AddScoped<MatingCalculationQueries, MatingCalculationQueries>();
            services.AddScoped<ContractUserinformationQueries, ContractUserinformationQueries>();
            services.AddScoped<DogMatingCalculationQueries, DogMatingCalculationQueries>();
            services.AddScoped<ParentingQuries, ParentingQuries>();
            services.AddScoped<CalculatedDiseaseQueries, CalculatedDiseaseQueries>();
            services.AddScoped<HealthRecordQueries, HealthRecordQueries>();

            //Command-Controllere
            services.AddScoped<DogApplicationService, DogApplicationService>();
            services.AddScoped<DiseaseApplicationService, DiseaseApplicationService>();
            services.AddScoped<LitterApplicationService, LitterApplicationService>();
            services.AddScoped<MatingRulesApplicationService, MatingRulesApplicationService>();
            services.AddScoped<UserinformationApplicationService, UserinformationApplicationService>();
            services.AddScoped<MatingCalculatorApplicationService, MatingCalculatorApplicationService>();
            services.AddScoped<ContractApplicationService, ContractApplicationService>();
            services.AddScoped<ContractUserinformationApplicationService, ContractUserinformationApplicationService>();
            services.AddScoped<DogMatingCalculationApplicationService, DogMatingCalculationApplicationService>();
            services.AddScoped<ParentingApplicationService, ParentingApplicationService>();
            services.AddScoped<CalculatedDiseaseApplicationService, CalculatedDiseaseApplicationService>();
            services.AddScoped<HealthRecordApplicationService, HealthRecordApplicationService>();



            //Repositories
            services.AddScoped<IDogRepository, DogRepository>();
            services.AddScoped<IDiseaseRepository, DiseaseRepository>();
            services.AddScoped<ILitterRepository, LitterRepository>();
            services.AddScoped<IMatingRulesRepository, MatingRulesRepository>();
            services.AddScoped<IUserinformationRepository, UserinformationRepository>();
            services.AddScoped<IMatingCalculationRepository, MatingCalculatorRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IContractUserinformationRepository, ContractUserinformationRepository>();
            services.AddScoped<IDogMatingCalculationRepository, DogMatingCalculationRepository>();
            services.AddScoped<IParentingRepository, ParentingRepository>();
            services.AddScoped<ICalculatedDiseaseRepository, CalculatedDiseaseRepository>();
            services.AddScoped<IHealthRecordRepository, HealthRecordRepository>();


            //MassTransit
            services.AddMassTransit(x =>
            {
                x.AddConsumer<UserinformationConsumer.UserinformationCreateConsumer>();
                x.AddConsumer<UserinformationConsumer.UserinformationUpdateConsumer>();
                x.AddConsumer<UserinformationConsumer.UserinformationDeleteConsumer>();

                x.AddConsumer<DogConsumer.DogCreateConsumer>();
                x.AddConsumer<DogConsumer.DogUpdateConsumer>();
                x.AddConsumer<DogConsumer.DogDeleteConsumer>();
                x.AddConsumer<DogConsumer.DogAddDogToLitterConsumer>();

                x.AddConsumer<DiseaseConsumer.DiseaseCreateConsumer>();
                x.AddConsumer<DiseaseConsumer.DiseaseUpdateConsumer>();
                x.AddConsumer<DiseaseConsumer.DiseaseDeleteConsumer>();

                x.AddConsumer<HealthRecordConsumer.HealthRecordCreateConsumer>();

                x.AddConsumer<LitterConsumer.LitterCreateConsumer>();
                x.AddConsumer<LitterConsumer.LitterUpdateConsumer>();
                x.AddConsumer<LitterConsumer.LitterDeleteConsumer>();

                x.AddConsumer<ParentingConsumer.ParentingCreateConsumer>();
                x.AddConsumer<ParentingConsumer.ParentingDeleteConsumer>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.UseHealthCheck(provider);
                    cfg.Host(new Uri("rabbitmq://localhost:5672"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cfg.ReceiveEndpoint("CreateMatingCalculatirUserinformationQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<UserinformationConsumer.UserinformationCreateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("UpdateMatingCalculatirUserinformationQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<UserinformationConsumer.UserinformationUpdateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("DeleteMatingCalculatirUserinformationQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<UserinformationConsumer.UserinformationDeleteConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("CreateMatingCalculatorDogQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<DogConsumer.DogCreateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("UpdateMatingCalculatorDogQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<DogConsumer.DogUpdateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("DeleteMatingCalculatorDogQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<DogConsumer.DogDeleteConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("AddAnimalToLitterMatingCalculatorDogQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<DogConsumer.DogAddDogToLitterConsumer>(provider);
                    });



                    cfg.ReceiveEndpoint("CreateMatingCalculatorDiseaseQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<DiseaseConsumer.DiseaseCreateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("UpdateMatingCalculatorDiseaseQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<DiseaseConsumer.DiseaseUpdateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("DeleteMatingCalculatorDiseaseQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<DiseaseConsumer.DiseaseDeleteConsumer>(provider);
                    });


                    cfg.ReceiveEndpoint("CreateMatingCalculatorHealthRecordQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<HealthRecordConsumer.HealthRecordCreateConsumer>(provider);
                    });


                    cfg.ReceiveEndpoint("CreateMatingCalculatorLitterQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<LitterConsumer.LitterCreateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("UpdateMatingCalculatorLitterQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<LitterConsumer.LitterUpdateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("DeleteMatingCalculatorLitterQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<LitterConsumer.LitterDeleteConsumer>(provider);
                    });



                    cfg.ReceiveEndpoint("CreateMatingCalculatorParentingQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<ParentingConsumer.ParentingCreateConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("DeleteMatingCalculatorParentingQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<ParentingConsumer.ParentingDeleteConsumer>(provider);
                    });

                }));
            });
            services.AddMassTransitHostedService();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MatingCalculator",
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
