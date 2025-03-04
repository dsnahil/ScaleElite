using Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Services;
using WebAPI.Helper;


namespace WebAPI
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

            services.AddControllers();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowReactApp",
            //        builder => builder.WithOrigins("http://localhost:3000")
            //                          .AllowAnyHeader()
            //                          .AllowAnyMethod());
            //});

            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder => builder.WithOrigins("*")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            #region Configure Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BasicAuth", Version = "v1" });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });
            });
            #endregion


            services.AddDbContext<endel_weighbridgeContext>(options => { options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), ServerVersion.Parse("6.0.12-mysql")); });

            services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddScoped<IUsermasterService, UserService>();
            services.AddScoped<ICameraService, CameraService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IGateService, GateService>();
            services.AddScoped<IWeighbridgeService, WeighbridgeService>();
            services.AddScoped<IMasterFieldService, MasterFieldService>();
            services.AddScoped<IBarcodeService, BarcodeService>();
            services.AddScoped<ICustomFieldService, CustomFieldService>();
            services.AddScoped<IChangePassword, ChangePassword>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ICustomValueService, CustomValueService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransporterService, TransporterService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IGlobalService, GlobalService>();


        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseCors("AllowReactApp");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}