using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using SI.Application;
using SI.Domin.Abstractions.Authentication;
using SI.Infrastructure;
using SI.Infrastructure.Authentication.Administrator;
using SI.Web.ActionFilters;

namespace SI.web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(
                          options =>
                              {
                                  options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                                  options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                              }
                      )
                          .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

            services.AddResponseCompression();
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            services.AddApplication();
            services.AddInfrastructure(Configuration);
            services.AddScoped<ErrorHandlerFilter>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddHttpClient();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sales Imitation", Version = "v1" });
            });

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            // if (env.IsDevelopment())
            // {
            //     // app.AddUserSecrets();
            // }
            // else
            // {
            //     app.UseExceptionHandler("/Home/Error");
            //     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
            // }

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 302)
                {
                    context.Response.StatusCode = 401;
                    return;
                }

                if (context.Response.StatusCode == 404 &&
              !Path.HasExtension(context.Request.Path.Value) &&
              !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });



            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseCors("MyPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 15;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                        "public,max-age=" + durationInSeconds;
                }
            });

            app.UseResponseCompression();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            // app.UseSpa(spa =>
            // {
            //     spa.Options.SourcePath = "ClientApp";
            // });

        }
    }
}