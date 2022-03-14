using CvOnline.Domain.Models;
using CvOnline.Domain.Repositories;
using CvOnline.Domain.Services;
using CvOnline.Infrastructure;
using CvOnline.Infrastructure.Repositories;
using CvOnline.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.API
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

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.Configure<SystemSettings>(Configuration.GetSection("AppSettings"));


            //en ASP.NET CORE, il y a 3types de dependance injection: Transiet, scoped, singleton.
            //Transiet : les objets sont différents, Une nouvelle instance est fournie pour chaques controlleur et services.  
            //Scoped : Les objects sont les même que pour les requetes. 
            //Singleton : Une instance pour toute l'application durant la durée de vie de l'application. 

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CvOnline.API", Version = "v1" });
            });

            //Configuration autoMapper
            services.AddAutoMapper(typeof(Startup));

            //Configuration SQL Server
            services.AddDbContext<CvOnlineDbContext>(option => option.UseSqlServer(
                Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("CvOnline.Infrastructure")
                ));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEntrepriseService, EntrepriseService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<ICvItemService, CvItemService>();

            //services.AddTransient<IRepository<Entreprise>, EntrepriseRepository>();
            //services.AddTransient<IRepository<Address>, AddressRepository>();
            //services.AddTransient<IUserRepository, UserRepository>();


            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("AppSettings:Secret"));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    //A chaque requete Http, on utiliser IUserService pour vérifier l'existance de l'utilisateur.
                    OnTokenValidated = context =>
                    {
                        var userSerice = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userSerice.GetUserByIdAsync(userId);

                        if (user == null)
                        {
                            //return unauthorized if user no longer exists
                            context.Fail("Unauthoriezd");
                        }

                        return Task.CompletedTask;
                    }
                };

                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CvOnline.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
