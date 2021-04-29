using ASPNetCoreConfig.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using BussinessLayer.UserService;
using System.Linq;
using DataAccessLayer.Entities;
using Microsoft.OpenApi.Models; // swagger
using BussinessLayer.ComputerService;
using Microsoft.Extensions.Logging;
using BussinessLayer.Lifecycle;
using BussinessLayer.Life;

namespace ASPNetCoreConfig
{
    public class Startup
    {

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
           var Environment = environment;
            Configuration = new ConfigurationBuilder().AddJsonFile($"appSettings.{environment.EnvironmentName}.json").Build();
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

           
             // Cors
            services.AddCors(options => 
                options.AddDefaultPolicy(builder => builder.AllowAnyOrigin())
            );

            services.AddDbContext<ApplicationDbContext>(options => 
            {
                options.UseSqlServer(Configuration["SqlServerConnectionString"], b => b.MigrationsAssembly("DataAccessLayer"));
            });

            //JWT
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(opt => {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = "http://localhost:5000",
                    ValidAudience = "http://localhost:5000",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
                };
            });
            //startap Logger ��� �������� ����� ��� ������ ������ ������ ������)
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<object>>();   //object ����� �������� ������������
            services.AddSingleton(typeof(ILogger), logger);

            //AddScoped(), AddSingleton(), AddTransient() ���������� ������ ���������� ��������� ������ ����������� 
            //AddScoped() ����� ������������� ������� 
            //AddTransient() ���� ������ ������ �������  ������� ����� ���������
            //AddSingleton() ������� ����� ��� ������ ����������  � ��������� ���� ����� ���������� ����� ������ ����� ����� ��������� ������� ������

            //Db
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>(); //��������� ��������� ����������� 
            services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IComputerService, ComputerService>();
            //startap Logger ��� �������� ����� ��������� ����� ������
            services.AddScoped<IComputerService, AdvansedComputerService>();

            services.AddScoped<IScopedInterface, LifecycleService>();
            services.AddTransient<ITransientInterfase, LifecycleService>();
            services.AddSingleton<ISingletonInterfase, LifecycleService>();


            //leaaonvideo
            services.AddScoped<IScoupe, Life>();
            services.AddTransient<ITrans, Life>();
            services.AddSingleton<ISingl, Life>();

            //Swager
            services.AddSwaggerGen(sw=>
            {
                sw.SwaggerDoc("v1", new OpenApiInfo {Title = "Swagger API", Version = "version 1"});
           /*     sw.SwaggerDoc("v2", new OpenApiInfo {Title = "Swager API", Version = "version 2"});*/
            });


            //settings
            var settings = new Settings();
            Configuration.Bind(settings);
            var set = settings;

            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();                   //  ������� ��� ��� �������� swagger
                app.UseSwaggerUI(sw => 
                {
                    sw.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1");  // ���� � ��� ������� ����� ��������
                });

            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment()) //if (env.IsDevelopment() || env.IsEnvironment("Staging"))
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            SeedDefaultData(app);
        }

        private void SeedDefaultData(IApplicationBuilder app) 
        {
            var ScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = ScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (dbContext.Users.FirstOrDefault(u => u.FirstName == "Jhon") == null)
                {
                    User johnDoe = new User
                    {
                        FirstName = "Jhon",
                        LastName = "Doe"
                    };
                    User bStroustrup = new User
                    {
                        FirstName = "Bjarne",
                        LastName = "Stroust"
                    };
                    User ITorvalds = new User
                    {
                        FirstName = "Linus",
                        LastName = "Torvald"
                    };

                    dbContext.Users.Add(johnDoe);
                    dbContext.Users.Add(bStroustrup);
                    dbContext.Users.Add(ITorvalds);
                    dbContext.SaveChanges();
                }
                if (dbContext.ComputerManufacturers.FirstOrDefault()==null)
                {
                    var computerManufacturerOne = new ComputerManufacturer
                    {
                          ManufacturerName="Aser"
                    };
                    var computerManufacturerTwo = new ComputerManufacturer
                    {
                        ManufacturerName = "Toshiba"
                    };
                    dbContext.AddRange(computerManufacturerOne, computerManufacturerTwo);
                    dbContext.SaveChanges();
                    var computerModelAserOne = new ComputerModel
                    {
                         ModelName = "A1",
                         ComputerManufacturerId = computerManufacturerOne.Id
                    };
                    var computerModelAserTwo = new ComputerModel
                    {
                        ModelName = "A2",
                        ComputerManufacturerId = computerManufacturerOne.Id
                    };

                    var computerModelToshibaOne = new ComputerModel
                    {
                        ModelName = "Rapid",
                        ComputerManufacturerId = computerManufacturerTwo.Id
                    };
                    var computerModelToshibaTwo = new ComputerModel
                    {
                        ModelName = "More fast",
                        ComputerManufacturerId = computerManufacturerTwo.Id
                    };
                    dbContext.AddRange(computerModelAserOne, computerModelAserTwo, computerModelToshibaOne, computerModelToshibaTwo);
                    dbContext.SaveChanges();

                   /* var aserTageOne = new ComputerModelTag
                    { 
                     TageName ="aserTegOne",
                     TagMeta = "aserTegOne_Meta",
                     TagExpiration = "4/6/2021",
                     ComputerModelId = computerModelAserOne.Id
                    };
                    var aserTageTwo = new ComputerModelTag
                    {
                        TageName = "aserTegTwo",
                        TagMeta = "aserTegTwo_Meta",
                        TagExpiration = "4/16/2021",
                        ComputerModelId = computerModelAserOne.Id
                    };
                    var aserTageThree = new ComputerModelTag
                    {
                        TageName = "aserTegThree",
                        TagMeta = "aserTegThree_Meta",
                        TagExpiration = "4/20/2021",
                        ComputerModelId = computerModelAserOne.Id
                    };
                    var aserTageFour = new ComputerModelTag
                    {
                        TageName = "aserTegFour",
                        TagMeta = "aserTegFour_Meta",
                        TagExpiration = "4/21/2021",
                        ComputerModelId = computerModelAserOne.Id
                    };
                    dbContext.AddRange(aserTageOne, aserTageTwo, aserTageThree, aserTageFour);
                    dbContext.SaveChanges();
*/
                }

              var compModelsTagExpandet = dbContext.ComputerModelTags.ToList();
            
            }
        }
    }
}
