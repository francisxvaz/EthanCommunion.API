using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Formatters;
using EthanCommunion.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EthanCommunion.API.Services;
using EthanCommunion.API.Models;

namespace EthanCommunion.API

{
    public class Startup
    {

        public static IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(env.ContentRootPath)
                                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<StarsContext>();

            services.AddCors();

            services.AddMvc()
                    .AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));
                    //By default its camel case but if you want to change that behavior than to use the following
                    //.AddJsonOptions(o =>
                    //{
                    //    if (o.SerializerSettings.ContractResolver != null)
                    //    {
                    //        var castedResolver = o.SerializerSettings.ContractResolver 
                    //                             as DefaultContractResolver;
                    //        castedResolver.NamingStrategy = null;
                    //    }
                        
                    //})
                    ;
            var connectionString = Startup.Configuration["ConnectionStrings:EthanCommunionDBConnection"];
            services.AddDbContext<StarsContext>(o => o.UseSqlServer(connectionString));
            services.AddSingleton<IStarsContext, StarsMongoContext>();
            services.AddSingleton<IStarRepository, StarMongoRepository>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory logger, StarsContext starsContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                                   .AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            starsContext.EnsureSeedDataForContext();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Star, StarDto>()
                     .ForMember(x => x.Id, opt => opt.Ignore());
                cfg.CreateMap<StarDto, Star>();
                cfg.CreateMap<Address, AddressDto>()
                    .ForMember(x => x.Id, opt => opt.Ignore());
                cfg.CreateMap<AddressDto, Address>()
                    .ForMember(x => x.Star, opt => opt.Ignore());

            });

            app.UseStatusCodePages();

            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
