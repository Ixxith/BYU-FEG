using AspNetCore.Security.CAS;
using BYU_FEG.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BYU_FEG
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
         

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o =>
                {
                    o.LoginPath = new PathString("/login");

                    o.AccessDeniedPath = new PathString("/access-denied");

                    o.Cookie = new CookieBuilder
                    {
                        Name = ".AspNetCore.CasSample"
                    };

                    o.Events = new CookieAuthenticationEvents
                    {
                        // Add user roles to the existing identity.  
                        // This example is giving every user "User" and "Admin" roles.
                        // You can use services or other logic here to determine actual roles for your users.
                        OnSigningIn = context =>
                        {
                            // Use `GetRequiredService` if you have a service that is using DI or an EF Context.
                            var username = context.Principal.Identity.Name;
                            //var userSvc = context.HttpContext.RequestServices.GetRequiredService<UserService>();
                            // var roles = userSvc.GetRoles(username);
                            // Using the username, we will check the database for if that username exists.
                            // If it does check if they have researcher and admin roles and if they do, give them corresponding roles
                            List<String> roles = new List<string>();
                            UserPermission userPermission = new UserPermission(); // db.FirstOrDefault(u => u.username = username)
                            if (userPermission.IsResearcher)
                            {
                                roles.Add("User");
                            };
                            if (userPermission.IsAdmin)
                            {
                                roles.Add("Admin");
                            };
                            // Hard coded roles.
                            // string[] roles = new[]{ "User", "Admin" };

                            // `AddClaim` is not available directly from `context.Principal.Identity`.
                            // We can add a new empty identity with the roles we want to the principal. 
                            var identity = new ClaimsIdentity();

                            foreach (var role in roles)
                            {
                                identity.AddClaim(new Claim(ClaimTypes.Role, role));
                            }

                            context.Principal.AddIdentity(identity);
                            
                            return Task.FromResult(0);
                        }
                    };
                })
                .AddCAS(o =>
                {
                    o.CasServerUrlBase = Configuration["CasBaseUrl"];   // Set in `appsettings.json` file.
                    o.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                });



            
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
