using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using qrmenu.Services;
using KaynakKod.Services;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using DataAccess;
using AspNetCoreFileUploadFileTable;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //context.Database.EnsureCreated();
        }
        //readonly string ApiCorsPolicy = "_apiCorsPolicy";
        // add services to the DI container
        public void ConfigureServices(IServiceCollection services)
        {



            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
                   {
                       builder.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                   }));





            services.AddMvc();
            services.AddDbContext<DataContext>();
            services.AddCors();
            services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.IgnoreNullValues = false;
            });





            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // configure DI for application services
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUretimMaliyetiService, UretimMaliyetiService>();
            services.AddScoped<IKesimService, KesimService>();
            services.AddScoped<IMalzemeService, MalzemeService>();
            services.AddScoped<IKaynakService, KaynakService>();
            services.AddScoped<IBükümService, BükümService>();
            services.AddScoped<IBaglantıElemanlarıService, BağlantıElemanlarıService>();
            services.AddScoped<IKaplamaService, KaplamaService>();
            services.AddScoped<IDıs_OperasyonService, Dıs_OperasyonService>();

            services.AddScoped<IişService, İşService>();

            services.AddScoped<ITakımService, TakımService>();

            services.AddScoped<IBükümYeniService, BükümYeniService>();
            services.AddScoped<IParçaService, ParçaService>();
            services.AddScoped<IRevizeService, RevizeService>();
            services.AddScoped<IMalzemeMaliyetiSavedService, MalzemeMaliyetiSavedService>();
            services.AddScoped<IBükümMaliyetiSavedService, BükümMaliyetiSavedService>();
            services.AddScoped<IKesimMaliyetiSavedService, KesimMaliyetiSavedService>();
            services.AddScoped<IKaynakMaliyetiSavedService, KaynakMaliyetiSavedService>();
            services.AddScoped<IBağlantıElemanıSavedService, BağlantıElemanıSavedService>();
            services.AddScoped<IKaplamaMaliyetiServiceSavedService, KaplamaMaliyetiServiceSavedService>();
            services.AddScoped<IToplam_Maliyet_SavedService, Toplam_Maliyet_SavedService>();
            services.AddScoped<IDısOperasyonMaliyetiSavedService, DısOperasyonMaliyetiSavedService>();
            services.AddScoped<ITesviyeService, TesviyeService>();
            services.AddScoped<ITesviyeSavedService, TesviyeSavedService>();
            services.AddScoped<IBoyaService, BoyaService>();
            services.AddScoped<IPaketlemeService, PaketlemeService>();
            services.AddScoped<IPaketlemeSavedService, PaketlemeSavedService>();
            services.AddScoped<IBoyaSavedService, BoyaSavedService>();
            services.AddScoped<IFileRepository, FileService>();


            services.AddScoped<ValidateMimeMultipartContentFilter>();



            services.Configure<FormOptions>(x =>
                {
                    x.MultipartBodyLengthLimit = int.MaxValue;
                });

            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = int.MaxValue;
            });

            // services.Configure<KestrelServerOptions>(options =>
            // {
            //     options.Limits.MaxRequestBodySize = int.MaxValue; // if don't set default value is: 30 MB
            // });

            //IDısOperasyonMaliyetiSavedService

            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue; // if don't set default value is: 128 MB
                options.MultipartHeadersLengthLimit = int.MaxValue;
            });

            //IKesimMaliyetiSavedService

            ///IMalzemeMaliyetiSavedService

            services.AddAuthentication(x =>
            {

                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING")),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = System.TimeSpan.Zero
                };

            });


        }

        // configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext context)
        {



            // Enable Cors
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context_ = serviceScope.ServiceProvider.GetService<DataContext>();
                context_.Database.Migrate();
                context_.Database.EnsureCreated();
            }


            context.Database.EnsureCreated();
            createTestUser(context);
            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials



            app.UseRouting();
            app.UseStaticFiles();
            // global cors policy

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();





            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller}",
                     defaults: new { controller = "Login" }
                     );
             });
        }

        private void createTestUser(DataContext context)
        {

            // add hardcoded test user to db on startup

        }
    }
}
