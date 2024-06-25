using Karyera.Application.Abstractions;
using Karyera.Application.Features.Categories.Queries.GetAll;
using Karyera.Infrastructure.Concretes;
using Karyera.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using System.Reflection;
using Karyera.Application.Features.Categories.Commands.Create;
using FluentValidation.AspNetCore;
using Karyera.Infrastructure.Interceptors;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Karyera.Domain.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Karyera.Application.Mapping;
using Karyera.Application;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DbContextInterceptor>();


builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme=CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/AccessDenied";
    options.SlidingExpiration = true;
}
);

builder.Services.AddDbContext<AppDbContext>((sp, opt) =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    opt.AddInterceptors(sp.GetRequiredService<DbContextInterceptor>()); // Interceptor ekleme
});


builder.Services.AddScoped(typeof(IDbContextManager<>),typeof(DbContextManager<>));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(CategoryCreateCommandRequestValidator).Assembly);

builder.Services.AddMediatR(opt =>
{
    opt.RegisterServicesFromAssemblyContaining<CategoryGetAllQueryRequest>();
});
builder.Services.AddAutoMapper(typeof(MyMapping));

builder.Services.AddIdentity<AppUser,AppRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContext>();


builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    //options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = false;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
});


builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    //options.Cookie.HttpOnly = fas;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/AccessDenied";
    options.SlidingExpiration = true;
});

builder.Services.AddApplicationLayer();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();


app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
