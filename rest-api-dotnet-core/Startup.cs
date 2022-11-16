using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using rest_api_dotnet_core.Data;
using rest_api_dotnet_core.Repositories.CommentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest_api_dotnet_core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)// configuration of out api
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //add confguration of DB & send the options to DBContext in ApiDbContext
            services.AddDbContext<ApiDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBConnection"))
            );
            services.AddSwaggerGen();
            /*  
             * AddScoped=> create one instence per http req(the scope of the req)(when we create new employee the count will be aumented by 1 (gives 4 for exmpl) and whene we create an other employee it will be 4 everytime), 
             * AddSingloton=> create only one instance of Irepo used by all http req throughout the app(such as call instance in controller & view)
             * , whene we create employee will be augmented each time i create one 4, 5, ... (cuz same instance)
             * AddTransient=> create new instance every time the Irepo is requested
             * THEY are using for registering the Dependencies Injection
             * WE USE it to tell the sys when we call IRepo => create for us Repo implimentation and inject it to the constructor (dependency injection)
             * Dependency Injection Benefits=> Loosly coupling, easy unit test, clean code, easy to maintain
             */
            services.AddScoped<ICommentRepository, CommentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseAuthentication();//use it all the time before the authorization
            app.UseAuthorization();// UseAuthorization are midellwares

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            }); ;

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
