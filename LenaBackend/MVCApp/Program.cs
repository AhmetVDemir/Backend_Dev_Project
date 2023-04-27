using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EFCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


//for DependincyInjection can be IoC
builder.Services.AddSingleton<IUserDal, EfUserDal>();
builder.Services.AddSingleton<IFormDal,EfFormDal>();
builder.Services.AddSingleton<IFieldDal,EfFieldDal>();


builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<IFormService, FormManager>();
builder.Services.AddSingleton<IFieldService, FieldManager>();
//----------------------------------

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        
        option.LoginPath = "/Auth/Index";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(1);
        option.AccessDeniedPath = "/Auth/Index";
        
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Home/Error", "?code={0}");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
