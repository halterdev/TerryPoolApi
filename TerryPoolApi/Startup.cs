using BusinessLayer;
using BusinessLayer.Games;
using BusinessLayer.Seasons;
using BusinessLayer.Teams;
using BusinessLayer.Users;
using BusinessLayer.Weeks;
using Contracts.BusinessLayer.Games;
using Contracts.BusinessLayer.Seasons;
using Contracts.BusinessLayer.Teams;
using Contracts.BusinessLayer.Users;
using Contracts.BusinessLayer.Weeks;
using Contracts.DataLayer;
using Contracts.DataLayer.Games;
using Contracts.DataLayer.Seasons;
using Contracts.DataLayer.Teams;
using Contracts.DataLayer.Users;
using Contracts.DataLayer.Weeks;
using DataLayer;
using DataLayer.Games;
using DataLayer.Seasons;
using DataLayer.Teams;
using DataLayer.Users;
using DataLayer.Weeks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;

namespace TerryPoolApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "http://localhost:4200",
                    ValidAudience = "http://localhost:4200",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("auT68Dff3RtcHe34"))
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            services.AddDbContext<TerryPoolDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("TerryPoolApi")));

            services.AddTransient<ITerryPoolDbContext, TerryPoolDbContext>();

            services.AddTransient<IAddGameService, AddGameService>();
            services.AddTransient<IRetrieveGameService, RetrieveGameService>();
            services.AddTransient<ISeasonManagementService, SeasonManagementService>();
            services.AddTransient<ITeamManagementService, TeamManagementService>();
            services.AddTransient<IUpdateUserSelectionService, UpdateUserSelectionService>();
            services.AddTransient<IUserManagementService, UserManagementService>();
            services.AddTransient<IWeekManagementService, WeekManagementService>();

            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<ISeasonRepository, SeasonRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserSelectionRepository, UserSelectionRepository>();
            services.AddTransient<IWeekRepository, WeekRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
