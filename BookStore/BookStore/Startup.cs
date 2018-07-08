using BookStore.Auth;
using BookStore.Data;
using BookStore.Models;
using BookStore.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore
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
            services.AddDbContext<BookStoreDbContext>(options
                => options.UseSqlServer(Configuration.GetConnectionString("BookStoreDb")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<BookStoreDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.AddAuthentication()
                .AddMicrosoftAccount(microsoftOptions => 
                {
                    microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ApplicationId"];
                    microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:Password"];
                })
                .AddGoogle(googleOptions => 
                {
                    googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                })
                .AddTwitter(twitterOptions => 
                {
                    twitterOptions.ConsumerKey = Configuration["Authentication:Twitter:ConsumerKey"];
                    twitterOptions.ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"];
                })
                .AddFacebook(facebookOptions => 
                {
                    facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                    facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                });

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IBookReviewRepository, BookReviewRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddAntiforgery();

            services.AddMvc();

            //Claims-based
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdministratorOnly", policy => policy.RequireRole("Administrator"));
                options.AddPolicy("DeleteBook", policy => policy.RequireClaim("Delete Book", "Delete Book"));
                options.AddPolicy("AddBook", policy => policy.RequireClaim("Add Book", "Add Book"));
                options.AddPolicy("MinimumOrderAge", policy => policy.Requirements.Add(new MinimumOrderAgeRequirement(13)));
            });

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            BookStoreDbContext dbContext)
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
