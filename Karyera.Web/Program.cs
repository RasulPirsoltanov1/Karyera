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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DbContextInterceptor>();

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







var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
