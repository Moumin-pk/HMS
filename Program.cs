using HMS.Abstraction;
//using HMS.Configurations;
using HMS.Data.Models;
using HMS.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using HMS.Validators;

public class Program
{
    private static string AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddTransient<IPatientServices, PatientServices>();
        builder.Services.AddTransient<IDoctoreServices, DoctoreServices>();
        builder.Services.AddTransient<IDepartmentServices, DepartmentServices>();
        builder.Services.AddTransient<IBillingServices , BillingServices>();
        builder.Services.AddScoped<IContextService, ContextService>();
        builder.Services.AddScoped<IUsersService, UsersService>();

        // Register IPasswordHasher with Identity's implementation
        builder.Services.AddScoped<IPasswordHasher, PasswordHasherService >();

        //Database
        builder.Services.AddDbContext<HmsContext>();

        // Custom services
       
        
        builder.Services.AddScoped<IContextService, ContextService>();

        // Validators
        //builder.Services.AddScoped<IValidator<Patient>, PatientValidator>();
        builder.Services.AddScoped<IConfigurationService, ConfigurationService>();
        builder.Services.AddControllersWithViews();

        


        var provider = builder.Services.BuildServiceProvider();

        var connectionString = builder.Configuration.GetConnectionString("HMS");
        builder.Services.AddDbContext<HmsContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddControllersWithViews()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<PatientValidator>(); // Register validators
    });


        // Authentication
        builder.Services.AddAuthentication(AuthenticationScheme)
            .AddCookie(option =>
            {
                option.LoginPath = "/Authentication/Login";
                option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
            });

        // AddHttpContextAccessor
        builder.Services.AddHttpContextAccessor();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
