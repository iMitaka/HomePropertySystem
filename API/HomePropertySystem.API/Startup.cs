using HomePropertySystem.Data;
using HomePropertySystem.Helpers.Jwt;
using HomePropertySystem.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace HomePropertySystem.API
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            ConfigureDbContext(services);
            ConfigureIdentity(services);
            ConfigureAuthentication(services);
            IoCContainer.ConfigureServices(services);
            services.AddMvc();
            // services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            // ConfigureSignalRHubs(app);
            app.UseStaticFiles();
            app.UseAuthentication();
            DatabaseInitializer(app);
            app.UseMvc();
        }

        //private void ConfigureSignalRHubs(IApplicationBuilder app)
        //{
        //    app.UseSignalR(routes =>
        //    {
        //        routes.MapHub<Chat>("chat");
        //    });
        //}

        private void ConfigureDbContext(IServiceCollection services)
        {
            DbContextConfiguration.AddDbContext(services);
        }

        private void DatabaseInitializer(IApplicationBuilder app)
        {
            DbContextConfiguration.InitializeDatabase(app);
        }

        private void ConfigureIdentity(IServiceCollection services)
        {
           DbContextConfiguration.AddIdentity(services);
        }

        private void ConfigureAuthentication(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication((options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }))
                   .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters =
                            new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,

                                ValidIssuer = Helpers.Jwt.JwtConstants.GetIssuer(),
                                ValidAudience = Helpers.Jwt.JwtConstants.GetAudience(),
                                IssuerSigningKey =
                                 JwtSecurityKey.Create(Helpers.Jwt.JwtConstants.GetSigningKey())
                            };

                       options.Events = new JwtBearerEvents
                       {
                           OnAuthenticationFailed = context =>
                           {
                               return Task.CompletedTask;
                           },
                           OnTokenValidated = context =>
                           {
                               return Task.CompletedTask;
                           },
                           OnMessageReceived = context =>
                           {
                               var signalRTokenHeader = context.Request.Query["signalRTokenHeader"];

                               if (!string.IsNullOrEmpty(signalRTokenHeader) &&
                                   (context.HttpContext.WebSockets.IsWebSocketRequest || context.Request.Headers["Accept"] == "text/event-stream"))
                               {
                                   context.Token = context.Request.Query["signalRTokenHeader"];
                               }
                               return Task.CompletedTask;
                           }
                       };
                   });
        }
    }
}
