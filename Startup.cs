using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PortariaInteligente.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using PortariaInteligente.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace PortariaInteligente
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
           /*para usar com origem da interface do usuário de identidade completa, 
            * que no caso está com erro de sintaxe em:
            *options.AllowAreas = true;
            *services.AddSingleton<IEmailSender, EmailSender>();
            * Considerar a exclução.         
            */
            /*services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });*/

            services.AddDbContext<PortariaInteligenteContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("PortariaInteligenteDatabase")));

            /*.AddRoles e AddDefault Token from : Implementando JWT de forma fácil: https://www.youtube.com/watch?v=ccVmPgxNE6c */
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<PortariaInteligenteContext>()
                .AddDefaultTokenProviders();

            /*para usar com origem da interface do usuário de identidade completa, 
            * que no caso está com erro de sintaxe.*/
            /*services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<PortariaInteligenteContext>()
                .AddDefaultTokenProviders();

              services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddRazorPagesOptions(options =>
                {
                    options.AllowAreas = true;
                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });            
            services.AddSingleton<IEmailSender, EmailSender>();*/

            services.AddCors();
            services.AddControllersWithViews();
            services.AddRazorPages();


            /*Definição de políticas globais, dizendo que TODO endpoint da nossa API requer autenticação.*/
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
                config.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddAuthorization(options =>
            {
                /*Para o meu caso dada a simplicidade da decisão, talvez o mais interessante, 
                 * fácil e manutenível fosse aplicar <<roles>>, ao invés de <<claims>>*/
                options.AddPolicy("admin", policy => policy.RequireClaim("Portaria", "admin"));
                options.AddPolicy("visitado", policy => policy.RequireClaim("Portaria", "visitado"));
                options.AddPolicy("convidado", policy => policy.RequireClaim("Portaria", "convidado"));
                options.AddPolicy("portaria", policy => policy.RequireClaim("Portaria", "portaria"));
                options.AddPolicy("recepcao", policy => policy.RequireClaim("Portaria", "recepcao"));            
            });

            //JWT: https://balta.io/blog/aspnet-core-autenticacao-autorizacao
            services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
            .AddJwtBearer(x =>
            {
	            x.RequireHttpsMetadata = false;
	            x.SaveToken = true;
	            x.TokenValidationParameters = new TokenValidationParameters
	            {
		            ValidateIssuerSigningKey = true,
		            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:key"])),
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
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseStaticFiles(); 

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvcWithDefaultRoute();
        }
    }
}
