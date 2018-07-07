using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ViVuStoreMVC.Auth;
using ViVuStoreMVC.Data;
using ViVuStoreMVC.Models;
using ViVuStoreMVC.Repositories;

namespace ViVuStoreMVC
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ViVuStoreDbContext>(options
                => options.UseSqlServer(Configuration
                .GetConnectionString("ViVuStoreMVCDb")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ViVuStoreDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();


            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));

            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ViVuStoreDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DbInitializer.Initializer(dbContext);
        }
    }
}
