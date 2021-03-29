using API.Extensions;
using API.Helpers;
using API.Middleware;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


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
            //Services order doesn't really matter acually there is an exception
            //THERE'S ADDSingleton() lifetime is forever
            //There's AddScoped life time which is the life of a  http request

            services.AddAutoMapper(typeof(MappingProfiles));
            //store context as service
            services.AddControllers();
            // this is a cleanup
            // but u can refer to this in extension folder  AddApplicationServices




            // this will generate code for we can scaffle it database 
            services.AddDbContext<StoreContext>(x =>
             x.UseSqlite(_config.GetConnectionString("DefaultConnection")));
            //from extension folder 
            services.AddApplicationServices();

            services.AddSwaggerDocumentation();

        }
        //DEPDENCY INJECTION CONTAINER
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            //Middleware order is very important of how u place it!


            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();
            //goes to controller
            app.UseRouting();

            app.UseStaticFiles();
            //for authentication for l8r tho
            app.UseAuthorization();
            //from extension folder
            app.UseSwaggerDocumentation();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
