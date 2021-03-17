
using API.Helpers;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        //Iconfiguration this is in appsetting.json
        public Startup(IConfiguration config)
        {

            _config = config;
        }

        // public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //we need to add our store context here
        public void ConfigureServices(IServiceCollection services)
        {
            //Services order doesn't really matter
            //THERE'S ADDSingleton() lifetime is forever
            //There's AddScoped life time which is the life of a  http request
            services.AddScoped<IProductRepository, ProductRepository>();
            //for the services to be used throughout our application
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddAutoMapper(typeof(MappingProfiles));
            //store context as service
            services.AddControllers();
            // this will generate code for we can scaffle it database 
            services.AddDbContext<StoreContext>(x =>
             x.UseSqlite(_config.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }
        //DEPDENCY INJECTION CONTAINER
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Middleware order is very important of how u place it!
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();
            //goes to controller
            app.UseRouting();

            app.UseStaticFiles();
            //for authentication for l8r tho
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
