using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InventoryManegementSystemCore.View;


namespace InventoryManegementSystemCore
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
            services.AddDbContext<Data.Furniture_InventoryContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("FurnitureConnection")));

            services.AddMvc();
            services.AddScoped<ProductsRepository>();          
            services.AddScoped<InventoryRepository>();
            services.AddScoped<LogsRepository>();
            services.AddScoped<UsersRepository>();
            services.AddScoped<CategoriesRepository>();
            services.AddScoped<UsersRepository>();
            services.AddScoped<SalesRepository>();
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseCors(builder=> 
            {
                builder.WithOrigins("http://localhost:4200/");
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();

            });


            app.UseMvc(routes =>
            {
                routes
                    .MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}")
                    .MapRoute(name: "api", template: "api/{controller}/{action}/{id?}");
            });
        }
    }
}
