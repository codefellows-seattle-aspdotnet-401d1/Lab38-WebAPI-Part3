using Lab38George.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab38George
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // adding mvc
            services.AddMvc().AddXmlDataContractSerializerFormatters();
            // reference to the database connection string\
            // I don't remember how to comment json, but this pulls from the appsetting.json that I created
            services.AddDbContext<PartsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // adding mvc
            app.UseMvc();

            app.Run(async (context) =>
            {
                // Added text to the default page since there is no front end for the API
                await context.Response.WriteAsync("This is the parts API default page.");
            });
        }
    }
}
