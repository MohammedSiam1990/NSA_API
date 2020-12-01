using Telerik.WebReportDesigner.Services;
using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;
using AutoMapper;
using EmailService;
using ImagesService;
//using MailKit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Pos.IService;
using Pos.Service;
using POS.API.Helpers;
using POS.Data.DataContext;
using POS.Service.IService;
using POS.Service.Services;
using POS.Services;
using Steander.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using POS.API.Models.Telerik;

namespace POS.API.CORE
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        // private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            Configuration = configuration;
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

           
            //services.AddEntityFrameworkSqlServer();
            //services.AddDbContext<PosDbContext>();
            // services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>();


            services.AddDbContext<PosDbContext>(options =>
                          options.UseSqlServer(Configuration.GetConnectionString("DefaultPosConnection")));
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


            var lockoutOptions = new LockoutOptions()
            {
                AllowedForNewUsers = false,
                DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5),
                MaxFailedAccessAttempts = 5
            };
            services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Lockout = lockoutOptions;


            }).AddRoles<IdentityRole>()
                //.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>>()
                .AddEntityFrameworkStores<PosDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();


            //services.Configure<FormOptions>(options =>
            //{
            //    options.ValueLengthLimit = int.MaxValue;
            //    options.MultipartBodyLengthLimit = long.MaxValue; // <-- ! long.MaxValue
            //    options.MultipartBoundaryLengthLimit = int.MaxValue;
            //    options.MultipartHeadersCountLimit = int.MaxValue;
            //    options.MultipartHeadersLengthLimit = int.MaxValue;
            //});





            //    services.AddDbContext<PosDbContext>(c =>
            //c.UseInMemoryDatabase(Guid.NewGuid().ToString()).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddCors(o =>
            {
                o.AddPolicy("CorsAllowAll", policy => policy
                     .SetIsOriginAllowed(_ => true)
                     .AllowAnyHeader()
                     .AllowAnyMethod()
                     .AllowCredentials()
                     .SetPreflightMaxAge(TimeSpan.FromMinutes(600)));
            });
            services.AddMvc();
            services.AddCors();
            services.AddControllers().AddNewtonsoftJson();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers().AddNewtonsoftJson(options =>
     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            // Register the Swagger generator, defining 1 orMicrosoft.OpenApi more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API POS", Version = "v1" });
            });
            services.AddSwaggerDocumentation();
            //configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            //configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddLocalization(opts =>
            {
                opts.ResourcesPath = "Resources";
            });



            services.Configure<RequestLocalizationOptions>(opts =>
            {
                var supportedCultures = new List<CultureInfo> {
                    new CultureInfo("en"),
                    new CultureInfo("ar-EG"),   // Arabic Egypt
                  };

                opts.DefaultRequestCulture = new RequestCulture("en-US");
                // Formatting numbers, dates, etc.
                opts.SupportedCultures = supportedCultures;
                // UI strings that we have localized.
                opts.SupportedUICultures = supportedCultures;
            });
            #region  Eltype



            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["AuthSettings:Audience"],
                    ValidIssuer = Configuration["AuthSettings:Issuer"],
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AuthSettings:Key"])),
                    ValidateIssuerSigningKey = true

                };
            });
            #endregion


            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            var imagesPathConfig = Configuration
                  .GetSection("ImagesPath")
                  .Get<ImagesPath>();
            services.AddSingleton(imagesPathConfig);

            var SettingConfig = Configuration
                  .GetSection("Setting")
                  .Get<Setting>();
            services.AddSingleton(SettingConfig);


            //services.AddScoped<IEmailSender, EmailSender>();
            services.Configure<FormOptions>(o =>
                {
                    o.ValueLengthLimit = int.MaxValue;
                    o.MultipartBodyLengthLimit = int.MaxValue;
                    o.MemoryBufferThreshold = int.MaxValue;
                });
            // configure DI for application services
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICompaniesService, CompaniesService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IBranchService, BranchService>();
           services.AddScoped<IMajorServicesService, MajorServicesService>();
            services.AddScoped<IItemGroupsService, ItemGroupsService>();
            services.AddScoped<IlookUpService, LookUpService>();
            services.AddScoped<IMobileDataService, MobileDataService>();
            services.AddScoped<IDeleteRecordService, DeleteRecordService>();
            services.AddScoped<ITaxService, TaxService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemUomService, ItemUomService>();
            services.AddScoped<IRemarksTemplateService,RemarksTemplateService>();
            services.AddScoped<IAllDataJsonByBrandIDService, AllDataJsonByBrandIDService>();
            services.AddScoped<IBranchWorkStationsService, BranchWorkStationsService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IItemComponentsService, ItemComponentsService>();
            services.AddScoped<ISalesGroupsItemsService, SalesGroupsItemsService>();
            services.AddScoped<IPaymentMethodsService, PaymentMethodsService>();
            services.AddScoped<IBranchesConnectingService, BranchesConnectingService>();
            services.AddScoped<IMajorServicesIconsService, MajorServicesIconsService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IconfigService, ConfigService>();
            services.AddScoped<IMajorServiceTypesService, MajorServiceTypesService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();
           services.AddScoped<IDistrictService, DistrictService>();
           services.AddScoped<IUserDefinedService, UserDefinedService>();


            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddRazorPages()
                .AddNewtonsoftJson();
            services.TryAddSingleton<IReportServiceConfiguration>(sp =>
    new ReportServiceConfiguration
    {
        ReportingEngineConfiguration = ConfigurationHelper.ResolveConfiguration(sp.GetService<IWebHostEnvironment>()),
        HostAppId = "ReportingCore3App",
        Storage = new FileStorage(),
        ReportSourceResolver = new UriReportSourceResolver(
            System.IO.Path.Combine(sp.GetService<IWebHostEnvironment>().ContentRootPath, "Reports"))
    });
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles(); // For the wwwroot folder
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "uploads")),
                RequestPath = "/uploads",
                EnableDirectoryBrowsing = true
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("CorsAllowAll");
            }
            else
            {
                // production and staging cors should be here
                UseCors(app);
            }

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
            app.UseCookiePolicy();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API POS V1");
                c.RoutePrefix = string.Empty;
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });
            app.UseSwaggerDocumentation();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            // UseCors(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //  endpoints.MapRazorPages();
            });
            //to ignore the reference loop

        }

        private static void UseCors(IApplicationBuilder app)
        {
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );

        }
        private void ConfigureLocalizationOptions(IServiceCollection services)
        {
            const string enUSCulture = "en-US";
            const string arQACulture = "ar-EG";

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo(enUSCulture),
                    new CultureInfo(arQACulture)
                };

                options.DefaultRequestCulture = new RequestCulture(culture: enUSCulture, uiCulture: enUSCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new AcceptLanguageHeaderRequestCultureProvider(),
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };
            });
        }

    }

}
