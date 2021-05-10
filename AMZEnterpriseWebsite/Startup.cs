using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Data;
using AMZEnterpriseWebsite.Models.Constants;
using AMZEnterpriseWebsite.Persistence;
using AMZEnterpriseWebsite.Services.EmailSender;
using AMZEnterpriseWebsite.Services.FileHandler;
using AutoMapper;
using ElmahCore;
using ElmahCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartBreadcrumbs.Extensions;
using System;
using System.Collections.Generic;

namespace AMZEnterpriseWebsite
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

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IFileHandler, FileHandler>();


            //Breadcrumbs Navigation
            //These are the classes by default(Bootstrap 4.1)
            services.AddBreadcrumbs(GetType().Assembly, options =>
            {
                options.TagName = "nav";
                options.TagClasses = "";
                options.OlClasses = "breadcrumb";
                options.LiClasses = "breadcrumb-item";
                options.ActiveLiClasses = "breadcrumb-item active";
                options.SeparatorElement = "<li class=\"separator\">/</li>";
            });



            //Elmah Error Logger
            services.AddElmah<XmlFileErrorLog>(options =>
            {
                options.Path = "/Admin/emlah";
                options.LogPath = "~/log";
            });




            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAutoMapper(typeof(Startup));


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default")));




            //Configure IIS Options
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });



            services.AddIdentity<User, IdentityRole>(
                    options =>
                    {
                        options.Lockout.AllowedForNewUsers = true;
                        options.Lockout.MaxFailedAccessAttempts = 3;
                        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                        options.User.RequireUniqueEmail = true;
                        options.Password.RequireDigit = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequiredLength = 6;
                        options.SignIn.RequireConfirmedPhoneNumber = true;
                    })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();




            //Add Email Sender Service
            services.AddTransient<IEmailSender, EmailSender>();


            services.AddMvc()
                .AddNewtonsoftJson()
                .AddRazorRuntimeCompilation();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
            });


            services.ConfigureApplicationCookie(options => options.LoginPath = "/Panel/Users/Login");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseElmah();

            app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");



            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    areaName: "Panel",
                    name: "panel",
                    pattern: "/panel/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //Database Creation
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope())
            {
                if (serviceScope != null)
                {
                    var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                    var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                    var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    context.Database.EnsureCreated();

                    var roles = new List<string>()
                    {
                        ConstantUserRoles.SuperAdmin,
                        ConstantUserRoles.Admin,
                        ConstantUserRoles.Writer
                    };

                    var user = new User()
                    {
                        FirstName = "FirstName",
                        LastName = "LastName",
                        UserName = "A@dmin13",
                        Email = "example@gmail.com",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        IsActive = true,
                        FilesPathGuid = Guid.NewGuid(),
                        CreateDate = DateTime.Now,
                        LastEditDate = DateTime.Now
                    };

                    ApplicationDbInitializer.SeedData(context, userManager, roleManager, roles,
                        ConstantUserRoles.SuperAdmin, user, "p@ss123");
                }
            }
        }
    }
}
